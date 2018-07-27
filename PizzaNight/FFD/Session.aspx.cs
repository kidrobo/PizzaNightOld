using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaNight.FFD
{
    public partial class Session : System.Web.UI.Page
    {
        int SessionID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
                return;
            SessionID = int.Parse(Request.QueryString["id"].ToString());
            LoadGameInfo();
        }

        private void LoadGameInfo()
        {
            using (FinalFantasyDrunkDataContext dc = new FinalFantasyDrunkDataContext())
            {
                PizzaNight.Session currentSession = (from t in dc.Sessions where t.ID == SessionID select t).FirstOrDefault();
                lblGameType.Text = currentSession.Game.GameType.Name;
                lblCharacterName.Text = currentSession.Game.CharacterName;

                DataTable dt = new DataTable();
                dt.Columns.Add("Total Sessions");
                dt.Columns.Add("Total Time");
                dt.Columns.Add("Total Drinks");
                DataRow dr = dt.NewRow();
                dr[0] = currentSession.Game.Sessions.Count;
                dr[1] = GetTotalTime(currentSession.Game);
                dr[2] = GetDrinkCount(currentSession.Game);
                dt.Rows.Add(dr);
                gvGameInfo.DataSource = dt;
                gvGameInfo.DataBind();

                var drinkRules = (from t in dc.Drinks
                                  where t.GameTypeID == currentSession.Game.GameTypeID
                                  orderby t.DrinkRule select t);
                List<SessionDrinkRule> sessionDrinkRules = new List<SessionDrinkRule>();
                foreach (var rule in drinkRules)
                {
                    SessionDrinkRule sessionRule = new SessionDrinkRule()
                    {
                        DrinkRule = rule.DrinkRule,
                        DrinkPenalty = rule.Penalty,
                        DrinkRuleID = rule.ID
                    };
                    sessionRule.SessionCount = currentSession.SessionDrinks.Where(x => x.DrinkID == rule.ID).Count();
                    List<int> sessions = currentSession.Game.Sessions.Select(x => x.ID).ToList<int>();
                    sessionRule.TotalCount = (from t in dc.SessionDrinks where t.DrinkID == rule.ID && sessions.Contains(t.SessionID) select t).Count();
                    sessionDrinkRules.Add(sessionRule);
                }
                gvDrinks.DataSource = sessionDrinkRules.OrderByDescending(x => x.TotalCount).ThenByDescending(x => x.SessionCount).ThenBy(x => x.DrinkRule);
                gvDrinks.DataBind();
            }
        }

        protected void gvDrinks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0)
                return;
            string id = e.Row.Cells[4].Text;
            LinkButton lb = new LinkButton()
            {
                Text = "Take a Drink",
                CommandArgument = id,
                ID = id
            };
            lb.Click += AddDrink;
            e.Row.Cells[4].Controls.Add(lb);
        }

        private void AddDrink(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            using (FinalFantasyDrunkDataContext dc = new FinalFantasyDrunkDataContext())
            {
                SessionDrink drink = new SessionDrink()
                {
                    DrinkID = int.Parse(lb.CommandArgument),
                    SessionID = SessionID
                };
                dc.SessionDrinks.InsertOnSubmit(drink);
                dc.SubmitChanges();
            }
            LoadGameInfo();
        }

        /// <summary>
        ///     Get the total number of drinks a game has
        /// </summary>
        /// <param name="game">Current Game</param>
        /// <returns>Total number of session drinks multiplied by the number of players per session</returns>
        internal static object GetDrinkCount(Game game)
        {
            int totalCount = 0;
            foreach (var session in game.Sessions)
            {
                //TODO: Add multiplier back in when we get the per rule figured out
                int multiplier = 1; //session.SessionPlayers.Count();
                totalCount += session.SessionDrinks.Count() * multiplier;
            }
            return totalCount;
        }
        /// <summary>
        ///     Returns total timme across all sessions
        /// </summary>
        /// <param name="game"></param>
        /// <returns>Total Minutes</returns>
        internal static object GetTotalTime(Game game)
        {
            double totalMinutes = 0;
            foreach (var session in game.Sessions)
            {
                if (session.DateEnded.HasValue)
                {
                    TimeSpan span = session.DateEnded.Value - session.DateStarted;
                    totalMinutes += span.TotalMinutes;
                }
            }
            return totalMinutes;
        }

        protected void EndSession_Click(object sender, EventArgs e)
        {
            using (FinalFantasyDrunkDataContext dc = new FinalFantasyDrunkDataContext())
            {
                PizzaNight.Session session = (from t in dc.Sessions where t.ID == SessionID select t).FirstOrDefault();
                session.DateEnded = DateTime.Now;
                dc.SubmitChanges();
            }
            Response.Redirect("StartGame", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }

    class SessionDrinkRule
    {
        public string DrinkRule { get; set; }
        public string DrinkPenalty { get; set; }
        public int TotalCount { get; set; }
        public int SessionCount { get; set; }
        public int DrinkRuleID { get; set; }
    }
}