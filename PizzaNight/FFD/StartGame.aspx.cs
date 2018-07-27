using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaNight.FFD
{
    public partial class StartGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGames();
            }
        }
        

        private void LoadGames()
        {
            using (FinalFantasyDrunkDataContext dc = new FinalFantasyDrunkDataContext())
            {
                // Fill Game Type dropdown list
                var gametypes = (from t in dc.GameTypes orderby t.Name select t);
                ddGameType.DataSource = gametypes;
                ddGameType.DataValueField = "ID";
                ddGameType.DataTextField = "Name";
                ddGameType.DataBind();
                
                // Fill past games
                var games = (from t in dc.Games
                             orderby t.LastPlayed descending
                             select new
                             {
                                 Continue = t.ID,
                                 GameType = t.GameType.Name,
                                 t.CharacterName,
                                 LastPlayer = t.LastPlayed.HasValue ? t.LastPlayed.Value.ToString() : "",
                                 TotalSessions = t.Sessions.Count
                             });
                gvContinue.DataSource = games;
                gvContinue.DataBind();
            }
        }

        protected void AddGame_Click(object sender, EventArgs e)
        {
            using (FinalFantasyDrunkDataContext dc = new FinalFantasyDrunkDataContext())
            {
                Game game = new Game()
                {
                    DateStarted = DateTime.Now,
                    CharacterName = tbCharacterName.Text,
                    LastPlayed = DateTime.Now,
                    GameTypeID = int.Parse(ddGameType.SelectedValue)
                };
                dc.Games.InsertOnSubmit(game);
                dc.SubmitChanges();
                PizzaNight.Session session = new PizzaNight.Session()
                {
                    GameID = game.ID,
                    DateStarted = DateTime.Now
                };
                dc.Sessions.InsertOnSubmit(session);
                dc.SubmitChanges();
                SessionPlayer newPlayerRobb = new SessionPlayer()
                {
                    SessionID = session.ID,
                    PlayerID = 1
                };
                SessionPlayer newPlayerBrian = new SessionPlayer()
                {
                    SessionID = session.ID,
                    PlayerID = 2
                };
                dc.SessionPlayers.InsertOnSubmit(newPlayerRobb);
                dc.SessionPlayers.InsertOnSubmit(newPlayerBrian);
                dc.SubmitChanges();
                Response.Redirect("Session?id=" + session.ID, false);
            }
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void gvContinue_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0)
                return;
            using (FinalFantasyDrunkDataContext dc = new FinalFantasyDrunkDataContext())
            {
                string gameID = e.Row.Cells[0].Text;

                Game game = (from t in dc.Games where t.ID == int.Parse(gameID) select t).FirstOrDefault();

                PizzaNight.Session session = game.Sessions.Where(x => !x.DateEnded.HasValue).FirstOrDefault();
                if (session == null)
                {
                    // Create new session and go ahead
                    session = new PizzaNight.Session()
                    {
                        DateStarted = DateTime.Now,
                        GameID = game.ID
                    };
                    dc.Sessions.InsertOnSubmit(session);
                    dc.SubmitChanges();

                    SessionPlayer newPlayerRobb = new SessionPlayer()
                    {
                        SessionID = session.ID,
                        PlayerID = 1
                    };
                    SessionPlayer newPlayerBrian = new SessionPlayer()
                    {
                        SessionID = session.ID,
                        PlayerID = 2
                    };
                    dc.SessionPlayers.InsertOnSubmit(newPlayerRobb);
                    dc.SessionPlayers.InsertOnSubmit(newPlayerBrian);
                    dc.SubmitChanges();
                }

                HyperLink hl = new HyperLink()
                {
                    NavigateUrl = "Session?id=" + session.ID,
                    Text = "Go",
                    CssClass = "btn btn-default btn-cs"
                };
                e.Row.Cells[0].Controls.Add(hl);
            }
        }
    }
}