using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.user
{
    public partial class ShowUsersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Selectbutton(object sender, EventArgs e)
        {
            usersRepeater.Visible = true;

            OleDbConnection Con1 = new OleDbConnection();
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con1.Open();
            string sqlstring = "SELECT * FROM users";
            OleDbCommand Cmd = new OleDbCommand(sqlstring, Con1);
            OleDbDataReader dr = Cmd.ExecuteReader();
            if (dr.HasRows)
            {
                usersRepeater.DataSource = dr;
                usersRepeater.DataBind();
                Con1.Close();
            }
            else
            {
                l1.Text = ("NOT found");
                Con1.Close();
            }
        }


        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DeleteUser")
            {
                string user = e.CommandArgument.ToString();
                // Delete the user with the given ID from the database

                OleDbConnection Con1 = new OleDbConnection();
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
                Con1.Open();
                string sqlstring = "DELETE * FROM users WHERE myusername='" + user + "';";
                OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                int y = 0;
                y = cmd.ExecuteNonQuery();
                Response.Redirect("/admin/ShowUsersPage.aspx");
            }

        }

    }
}