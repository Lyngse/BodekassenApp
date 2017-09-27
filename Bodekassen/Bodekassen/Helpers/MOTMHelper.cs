using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bodekassen.DB;

namespace Bodekassen.Helpers
{
    public class MOTMHelper
    {
        BodekassenDBContainer db = new BodekassenDBContainer();
        public bool CalcMOTM(Match match)
        {
            int voteCount = 0;
            int highestVoteCount = 0;
            Player player = new Player();

            if(match.Votes.Count > 0)
            {
                foreach (Player p in match.Players)
                {
                    foreach (Vote v in match.Votes)
                    {
                        foreach (Vote pv in p.Votes)
                        {
                            if (v.MatchId == pv.MatchId)
                            {
                                voteCount++;
                            }
                        }
                    }
                    if (voteCount > highestVoteCount)
                    {
                        highestVoteCount = voteCount;
                        player = p;
                    }
                    voteCount = 0;
                }

                MOTM motm = db.MOTMSet.Add(new MOTM { Player = player, PlayerId = player.Id, Match = match });
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }        
        }
    }
}