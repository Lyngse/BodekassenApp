using System;
using System.Collections.Generic;
using System.Data.Entity;
using Bodekassen.Helpers;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bodekassen.Attributes;
using Bodekassen.DB;

namespace Bodekassen.Controllers
{
    //[CORS]
    public class APIController : Controller
    {
        MOTMHelper mh = new MOTMHelper();
        BodekassenDBContainer db = new BodekassenDBContainer();
        // GET: API
        public ActionResult Index()
        {
            return Json(new { status = "success" });
        }

        [HttpPost]
        public ActionResult CreateTeam(string name, string email, string password)
        {
            int fineAmount = 0;
            int fineDepositedAmount = 0;
            int casesOfBeer = 0;
            int casesOfBeerDeposited = 0;
            Team t = new Team { Name = name, Email = email, Password = password, FineAmount = fineAmount, FineDepositedAmount = fineDepositedAmount, CasesOfBeer = casesOfBeer, CasesOfBeerDeposited = casesOfBeerDeposited };
            db.TeamSet.Add(t);
            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpPost]
        public ActionResult UpdateTeam(int teamId, string name, string email, string password)
        {
            Team t = db.TeamSet.Find(teamId);
            t.Name = name;
            t.Email = email;
            t.Password = password;
            t.FineAmount = t.FineAmount;
            t.FineDepositedAmount = t.FineDepositedAmount;
            t.CasesOfBeerDeposited = t.CasesOfBeerDeposited;
            t.CasesOfBeer = t.CasesOfBeer;

            db.Entry(t).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpDelete]
        public ActionResult DeleteTeam(int teamId)
        {
            Team t = db.TeamSet.Find(teamId);
            foreach (Player p in t.Players)
            {
                db.FineSet.RemoveRange(p.Fines);
            }

            foreach (FineType ft in t.FineTypes)
            {
                db.FineSet.RemoveRange(ft.Fines);
            }

            db.FineTypeSet.RemoveRange(t.FineTypes);
            db.PlayerSet.RemoveRange(t.Players);
            db.TeamSet.Remove(t);

            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpPost]
        public ActionResult CreatePlayer(string name, int teamId)
        {
            Team t = db.TeamSet.Find(teamId);
            int fineAmount = 0;
            int fineDepositedAmount = 0;
            int casesOfBeer = 0;
            int casesOfBeerDeposited = 0;

            Player u = db.PlayerSet.Add(new Player { Name = name, FineAmount = fineAmount, FineDepositedAmount = fineDepositedAmount, CasesOfBeer = casesOfBeer, CasesOfBeerDepostited = casesOfBeerDeposited, Team = t, TeamId = t.Id});
            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpPut]
        public ActionResult UpdatePlayer(int playerId, string name)
        {
            Player p = db.PlayerSet.Find(playerId);

            p.Name = name;
            p.FineAmount = p.FineAmount;
            p.FineDepositedAmount = p.FineDepositedAmount;
            p.CasesOfBeer = p.CasesOfBeer;
            p.CasesOfBeerDepostited = p.CasesOfBeerDepostited;

            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpDelete]
        public ActionResult DeletePlayer(int playerId)
        {
            Player p = db.PlayerSet.Find(playerId);
            db.FineSet.RemoveRange(p.Fines);
            db.PlayerSet.Remove(p);

            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpPost]
        public ActionResult CreateFineType(string name, int defaultAmount, int teamId, bool isDeleted = false, bool isCaseOfBeer = false, bool isDeposit = false)
        {
            Team t = db.TeamSet.Find(teamId);

            FineType ft = db.FineTypeSet.Add(new FineType { Name = name, DefaultAmount = defaultAmount, IsDeleted = isDeleted, IsCaseOfBeer = isCaseOfBeer, IsDeposit = isDeposit, Team = t, TeamId = t.Id });
            db.SaveChanges();

            return Json(new { status = "success" });
        }

        public ActionResult ReadFineTypes(int teamId)
        {
            Team t = db.TeamSet.Find(teamId);
            List<Object> fineTypes = new List<Object>();

            foreach (FineType ft in t.FineTypes)
            {
                fineTypes.Add(new { Id = ft.Id, Name = ft.Name, DefaultAmount = ft.DefaultAmount });
            }

            Object obj = new { status = "success", FineTypes = fineTypes };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public ActionResult DelelteFineType(int fineTypeId, bool isDeleted = true)
        {

            //Hvis en finetype bliver "slettet" ændres dens bool (IsDeleted) blot. Hvor alle bøder hvor deres bødetype er
            // IsDeleted = true, skal ikke med regnes eller vises, samt bødetypen skal ikke vises nogle steder
            FineType ft = db.FineTypeSet.Find(fineTypeId);

            ft.IsDeleted = isDeleted;

            db.Entry(ft).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpPost]
        public ActionResult AddFine(int fineTypeId, int amount, int playerId)
        {
            Player p = db.PlayerSet.Find(playerId);
            Team t = db.TeamSet.Find(p.TeamId);
            FineType ft = db.FineTypeSet.Find(fineTypeId);
            DateTime date = DateTime.Now;

            Fine f = db.FineSet.Add(new Fine { FineType = ft, Amount = amount, Player = p, PlayerId = p.Id });

            if(f.FineType.IsCaseOfBeer == true && f.FineType.IsDeposit == false)
            {
                p.CasesOfBeer += amount;
                t.CasesOfBeer += amount;
            }
            else if(f.FineType.IsCaseOfBeer == true && f.FineType.IsDeposit == true)
            {
                p.CasesOfBeerDepostited += amount;
                t.CasesOfBeerDeposited += amount;
            }
            else if(f.FineType.IsCaseOfBeer == false && f.FineType.IsDeposit == true)
            {
                p.CasesOfBeerDepostited += amount;
                t.CasesOfBeerDeposited += amount;
            }
            else
            {
                p.FineAmount += amount;
                t.FineAmount += amount;
            }

            db.Entry(p).State = EntityState.Modified;
            db.Entry(t).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpPut]
        public ActionResult UpdateFine(int fineId, FineType fineType, int amount)
        {
            Fine f = db.FineSet.Find(fineId);

            f.FineType = fineType;
            f.Amount = amount;

            db.Entry(f).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpDelete]
        public ActionResult DeleteFine(int fineId, int playerId)
        {
            Fine f = db.FineSet.Find(fineId);
            Player p = db.PlayerSet.Find(playerId);

            db.FineSet.Remove(f);
            p.Fines.Remove(f);

            db.SaveChanges();

            return Json(new { status = "success" });
        }

        public ActionResult GetAllFines(int teamId)
        {
            Team t = db.TeamSet.Find(teamId);
            List<Object> fines = new List<Object>();

            foreach (Player p in t.Players)
            {
                foreach (Fine f in p.Fines)
                {
                    fines.Add(new { Id = f.Id, FineType = f.FineType, Date = f.Date, ActualPrice = f.Amount });
                }
            }

            Object obj = new { status = "success", AllFines = fines };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateMatch(int teamId, string opposingTeam, bool isHomeMatch, Player[] players, DateTime date)
        {
            Team t = db.TeamSet.Find(teamId);

            int goalsFor = 0;
            int goalsAgainst = 0;

            Match m = db.MatchSet.Add(new Match { OpposingTeam = opposingTeam, GoalsFor = goalsFor, GoalsAgainst = goalsAgainst, IsHomeMatch = isHomeMatch, Date = date, Team = t, TeamId = t.Id, Players = players });

            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpPut]
        public ActionResult UpdateMatch(int matchId, string opposingTeam, bool isHomeMatch, Player[] players, int goalsFor, int goalsAgainst, DateTime date)
        {
            Match m = db.MatchSet.Find(matchId);
            m.OpposingTeam = opposingTeam;
            m.IsHomeMatch = isHomeMatch;
            m.Players = players;
            m.GoalsFor = goalsFor;
            m.GoalsAgainst = goalsAgainst;
            m.Date = date;

            db.Entry(m).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpPost]
        public ActionResult CreateGoal(int playerId, int matchId)
        {
            Match m = db.MatchSet.Find(matchId);
            Player p = db.PlayerSet.Find(playerId);

            Goal g = db.GoalSet.Add(new Goal { Player = p, PlayerId = p.Id, Match = m, MatchId = m.Id});

            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpPut]
        public ActionResult UpdateGoal(int goalId, int playerId)
        {
            Goal g = db.GoalSet.Find(goalId);
            Player oldP = db.PlayerSet.Find(g.PlayerId);
            Player p = db.PlayerSet.Find(playerId);

            oldP.Goals.Remove(g);
            g.Player = p;
            g.PlayerId = p.Id;

            db.Entry(oldP).State = EntityState.Modified;
            db.Entry(p).State = EntityState.Modified;
            db.Entry(g).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpDelete]
        public ActionResult DeleteGoal(int goalId)
        {
            Goal g = db.GoalSet.Find(goalId);
            Player p = db.PlayerSet.Find(g.PlayerId);
            Match m = db.MatchSet.Find(g.MatchId);

            m.Goals.Remove(g);
            p.Goals.Remove(g);
            db.GoalSet.Remove(g);

            db.SaveChanges();

            return Json(new { status = "success" });
        }

        public ActionResult GetGoal(int goalId)
        {
            Goal g = db.GoalSet.Find(goalId);

            Object obj = new { status = "success", Player = g.Player, Match = g.Match };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateVote(int matchId, int playerId)
        {
            Match m = db.MatchSet.Find(matchId);
            Player p = db.PlayerSet.Find(playerId);

            Vote v = db.VoteSet.Add(new Vote { Player = p, PlayerId = p.Id, Match = m, MatchId = m.Id });

            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpDelete]
        public ActionResult DeleteVote(int voteId)
        {
            Vote v = db.VoteSet.Find(voteId);
            Match m = db.MatchSet.Find(v.MatchId);
            Player p = db.PlayerSet.Find(v.PlayerId);

            m.Votes.Remove(v);
            p.Votes.Remove(v);
            db.VoteSet.Remove(v);

            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpPost]
        public ActionResult CreateMOTM(Match m)
        {
            if (mh.CalcMOTM(m) == true)
            {
                return Json(new { status = "success" });
            }
            else
            {
                return Json(new { status = "failed" });
            }          
        }

        [HttpPut]
        public ActionResult UpdateMOTM(int motmId)
        {
            MOTM motm = db.MOTMSet.Find(motmId);
            Player p = db.PlayerSet.Find(motm.PlayerId);
            Match m = db.MatchSet.Find(motm.Match.Id);

            p.MOTMs.Remove(motm);
            db.MOTMSet.Remove(motm);

            if (mh.CalcMOTM(m) == true)
            {
                return Json(new { status = "success" });
            }
            else
            {
                return Json(new { status = "failed" });
            }
        }

        [HttpDelete]
        public ActionResult DeleteMOTM(int motmId)
        {
            MOTM motm = db.MOTMSet.Find(motmId);
            Player p = db.PlayerSet.Find(motm.PlayerId);
            Match m = db.MatchSet.Find(motm.Match.Id);

            p.MOTMs.Remove(motm);
            db.MOTMSet.Remove(motm);

            db.SaveChanges();

            return Json(new { status = "success" });
        }
    }
}