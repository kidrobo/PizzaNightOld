using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaNight.FFD
{
    public partial class AddDrinkingRule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadGameTypes();
        }

        private void LoadGameTypes()
        {
            using (FinalFantasyDrunkDataContext dc = new FinalFantasyDrunkDataContext())
            {
                var types = (from t in dc.GameTypes orderby t.Name select t);
                ddGameType.DataSource = types;
                ddGameType.DataTextField = "Name";
                ddGameType.DataValueField = "ID";
                ddGameType.DataBind();
            }
        }

        protected void AddRule_Click(object sender, EventArgs e)
        {
            using (FinalFantasyDrunkDataContext dc = new FinalFantasyDrunkDataContext())
            {
                Drink drink = new Drink()
                {
                    DrinkRule = tbRule.Text,
                    Penalty = tbPenalty.Text,
                    DateAdded = DateTime.Now
                };
                dc.Drinks.InsertOnSubmit(drink);
                dc.SubmitChanges();
            }
            Response.Redirect("/FFD/AddDrinkRule", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}