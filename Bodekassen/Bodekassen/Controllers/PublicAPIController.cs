using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bodekassen.DB;

namespace Bodekassen.Controllers
{
    public class PublicAPIController : Controller
    {
        BodekassenDBContainer db = new BodekassenDBContainer();
        // GET: PublicAPI
        public ActionResult Index()
        {
            return Json(new { status = "success" });
        }

        public ActionResult GetTeam(int teamId)
        {
            Team t = db.TeamSet.Find(teamId);
            List<Object> players = new List<Object>();

            foreach(Player p in t.Players.OrderBy(x => x.Name))
            {
                players.Add(new { Id = p.Id, Name = p.Name, FineAmount = p.FineAmount, FineDepositedAmount = p.FineDepositedAmount});
            }

            Object obj = new {status = "success", Players = players, Id = t.Id, Name = t.Name, FineTypes = t.FineTypes, FineAmount = t.FineAmount, FineDepositedAmount = t.FineDepositedAmount };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetPlayer(int playerId)
        {
            Player p = db.PlayerSet.Find(playerId);
            List<Object> fines = new List<Object>();

            foreach (Fine f in p.Fines.OrderBy(x => x.Date))
            {
                fines.Add(new { FineType = f.FineType, Date = f.Date, Amount = f.Amount });
            }

            Object obj = new { status = "success", Id = p.Id, Name = p.Name, Fines = fines, FineAmount = p.FineAmount, FineDepositedAmount = p.FineDepositedAmount };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPlayers(int teamId)
        {
            Team t = db.TeamSet.Find(teamId);
            List<Object> players = new List<Object>();

            foreach (Player p in t.Players)
            {
                players.Add(new { Id = p.Id, Name = p.Name, FineAmount = p.FineAmount, FineDepositedAmount = p.FineDepositedAmount});
            }

            Object obj = new { status = "success", Players = players };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetGoals(int matchId)
        {
            Match m = db.MatchSet.Find(matchId);
            List<object> goals = new List<object>();

            foreach (Goal g in m.Goals)
            {
                goals.Add( new { Player = g.Player, PlayerId = g.PlayerId, Match = g.Match, MatchId = g.MatchId });
            }

            Object obj = new { status = "success", Goals = goals };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMatch(int matchId)
        {
            Match m = db.MatchSet.Find(matchId);

            Match match = new Match { Players = m.Players, Goals = m.Goals, GoalsAgainst = m.GoalsAgainst, GoalsFor = m.GoalsFor, Date = m.Date, IsHomeMatch = m.IsHomeMatch, OpposingTeam = m.OpposingTeam, MOTM = m.MOTM, Id = m.Id, Team = m.Team, TeamId = m.TeamId, Votes = m.Votes };

            Object obj = new { status = "success", Match = match };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMatches(int teamId)
        {
            Team t = db.TeamSet.Find(teamId);
            List<object> matches = new List<object>();

            foreach (Match m in t.Matches)
            {
                matches.Add( new { GoalsFor = m.GoalsFor, GoalsAgainst = m.GoalsAgainst, Date = m.Date, IsHomeMatch = m.IsHomeMatch, OpposingTeam = m.OpposingTeam, Team = m.Team, TeamId = m.TeamId });
            }

            Object obj = new { status = "success", Matches = matches };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPlayerStats(int teamId)
        {
            Team t = db.TeamSet.Find(teamId);
            List<Player> player = new List<Player>();

            foreach (Player p in t.Players)
            {
                player.Add(new Player { Id = p.Id, Name = p.Name, Goals = p.Goals, Votes = p.Votes, MOTMs = p.MOTMs });
            }
            
            Object obj = new { status = "success", PlayerStats = player };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

    }
}