using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaNight
{
    public partial class LASERDIscs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillLaserdiscTable();
        }

        private void FillLaserdiscTable()
        {
            using (PizzaNightDataContext dc = new PizzaNightDataContext())
            {
                var tings = (from t in dc.LaserDiscs
                             orderby t.Title
                             select new
                             {
                                 t.Title,
                                 t.Edition
                             });

                litCount.Text = tings.Count().ToString();
                gvLaserdiscs.DataSource = tings;
                gvLaserdiscs.DataBind();
            }
        }
    }
}