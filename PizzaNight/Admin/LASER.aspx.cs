using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaNight.Admin
{
    public partial class LASER : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillTable();
        }

        private void FillTable()
        {
            using (var dc = new PizzaNightDataContext())
            {
                var tings = (from t in dc.LaserDiscs orderby t.Title, t.Edition select new
                {
                    Delete = t.ID,
                    t.Title,
                    t.Edition
                });
                gvDiscs.DataSource = tings;
                gvDiscs.DataBind();

            }
        }

        protected void AddMove_Click(object sender, EventArgs e)
        {
            if (tbTitle.Text != null)
            {
                using (var dc = new PizzaNightDataContext())
                {
                    LaserDisc newDisc = new LaserDisc() {
                        ID = Guid.NewGuid(),
                        Title = tbTitle.Text,
                        Edition = tbEdition.Text
                    };

                    dc.LaserDiscs.InsertOnSubmit(newDisc);
                    dc.SubmitChanges();
                }
            }
            tbTitle.Text = string.Empty;
            tbEdition.Text = string.Empty;
            tbTitle.Focus();

            FillTable();
        }

        protected void gvDiscs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0) return;

            LinkButton lb = new LinkButton();
            lb.ID = e.Row.Cells[0].Text;
            lb.Click += Lb_Click;
            lb.Text = "Delete";
            e.Row.Cells[0].Controls.Add(lb);
        }

        private void Lb_Click(object sender, EventArgs e)
        {
            Guid guid = Guid.Parse(((LinkButton)sender).ID);
            using (var dc = new PizzaNightDataContext())
            {
                LaserDisc disc = (from t in dc.LaserDiscs where t.ID == guid select t).FirstOrDefault();
                dc.LaserDiscs.DeleteOnSubmit(disc);
                dc.SubmitChanges();
            }

            FillTable();
        }
    }
}