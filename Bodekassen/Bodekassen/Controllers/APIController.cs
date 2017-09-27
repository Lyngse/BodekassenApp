using System;
using System.Collections.Generic;
using System.Data.Entity;
using Bodekassen.Helpers;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bodekassen.Attributes;
using Bodekassen.DB;
using System.Threading.Tasks;

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
            Random generator = new Random();
            int fineTotal = 0;
            int fineDeposited = 0;
            int casesOfBeerTotal = 0;
            int casesOfBeerDeposited = 0;
            string connectionCode = generator.Next(000000, 999999).ToString();

            Team t = new Team { Name = name, FineTotal = fineTotal, FineDeposited = fineDeposited, CasesOfBeerTotal = casesOfBeerTotal, CasesOfBeerDeposited = casesOfBeerDeposited, ConnectionCode = connectionCode };
            db.TeamSet.Add(t);

            Match[] matches = { };
            Season s = db.SeasonSet.Add(new Season { TeamId = t.Id, Team = t, Matches = matches });
            t.CurrentSeasonId = s.Id;

            db.Entry(t).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpPost]
        public ActionResult UpdateTeam(int teamId, string name)
        {
            Team t = db.TeamSet.Find(teamId);
            t.Name = name;
            //t.FineTotal = t.FineTotal;
            //t.FineDeposited = t.FineDeposited;
            //t.CasesOfBeerDeposited = t.CasesOfBeerDeposited;
            //t.CasesOfBeerTotal = t.CasesOfBeerTotal;

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
            int fineTotal = 0;
            int fineDeposited = 0;
            int casesOfBeerTotal = 0;
            int casesOfBeerDeposited = 0;

            Player p = db.PlayerSet.Add(new Player { Name = name, FineTotal = fineTotal, FineDeposited = fineDeposited, CasesOfBeerTotal = casesOfBeerTotal, CasesOfBeerDepostited = casesOfBeerDeposited, Team = t, TeamId = t.Id});
            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpPut]
        public ActionResult UpdatePlayer(int playerId, string name)
        {
            Player p = db.PlayerSet.Find(playerId);

            p.Name = name;
            p.FineTotal = p.FineTotal;
            p.FineDeposited = p.FineDeposited;
            p.CasesOfBeerTotal = p.CasesOfBeerTotal;
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
        public ActionResult CreateFineType(string name, int defaultPrice, int teamId, bool isDeleted = false, bool isCaseOfBeer = false, bool isDeposit = false)
        {
            Team t = db.TeamSet.Find(teamId);

            FineType ft = db.FineTypeSet.Add(new FineType { Name = name, DefaultPrice = defaultPrice, IsDeleted = isDeleted, IsCaseOfBeer = isCaseOfBeer, IsDeposit = isDeposit, Team = t, TeamId = t.Id });
            db.SaveChanges();

            return Json(new { status = "success" });
        }

        public ActionResult ReadFineTypes(int teamId)
        {
            Team t = db.TeamSet.Find(teamId);
            List<Object> fineTypes = new List<Object>();

            foreach (FineType ft in t.FineTypes)
            {
                fineTypes.Add(new { Id = ft.Id, Name = ft.Name, DefaultAmount = ft.DefaultPrice });
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
        public ActionResult AddFine(int fineTypeId, int price, int playerId)
        {
            Player p = db.PlayerSet.Find(playerId);
            Team t = db.TeamSet.Find(p.TeamId);
            FineType ft = db.FineTypeSet.Find(fineTypeId);
            DateTime date = DateTime.Now;

            Fine f = db.FineSet.Add(new Fine { FineType = ft, Price = price, Player = p, PlayerId = p.Id });

            if(f.FineType.IsCaseOfBeer == true && f.FineType.IsDeposit == false)
            {
                p.CasesOfBeerTotal += price;
                t.CasesOfBeerTotal += price;
            }
            else if(f.FineType.IsCaseOfBeer == true && f.FineType.IsDeposit == true)
            {
                p.CasesOfBeerDepostited += price;
                t.CasesOfBeerDeposited += price;
            }
            else if(f.FineType.IsCaseOfBeer == false && f.FineType.IsDeposit == true)
            {
                p.CasesOfBeerDepostited += price;
                t.CasesOfBeerDeposited += price;
            }
            else
            {
                p.FineTotal += price;
                t.FineTotal += price;
            }

            db.Entry(p).State = EntityState.Modified;
            db.Entry(t).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new { status = "success" });
        }

        [HttpPut]
        public ActionResult UpdateFine(int fineId, FineType fineType, int price)
        {
            Fine f = db.FineSet.Find(fineId);

            f.FineType = fineType;
            f.Price = price;

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
                    fines.Add(new { Id = f.Id, FineType = f.FineType, Date = f.Date, Price = f.Price });
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

        [HttpPost]
        public  ActionResult CreateNewSeason (int teamId)
        {
            Team t = db.TeamSet.Find(teamId);
            Match[] matches = { };

            Season s = db.SeasonSet.Add(new Season { TeamId = teamId, Team = t, Matches = matches });
            t.CurrentSeasonId = s.Id;

            db.Entry(t).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new { status = "success" });
        }
    }
}