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
            if (Session["adminName"] == null)
                Response.Redirect("/errorPage.aspx?m=3");
            if (!IsPostBack)
            {

            }
        }

        protected void Selectbutton(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";

            string whereClause = "WHERE";
            if (!string.IsNullOrWhiteSpace(InsertMail.Text))
                whereClause += $" myemail='{InsertMail.Text}'";
            if (!string.IsNullOrWhiteSpace(Insertphonenumber.Text))
            {
                if (whereClause != "WHERE")
                    whereClause += "AND";
                whereClause += $" myphonenumber='{Insertphonenumber.Text}'";
            }

                
            if (whereClause == "WHERE")
                whereClause = "";


            string sql = $"SELECT * FROM users {whereClause}";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    usersRepeater.Visible = true;
                    usersRepeater.DataSource = reader;
                    usersRepeater.DataBind();
                }
                else
                {
                    usersRepeater.Visible = false;
                    l1.Text = "No users found.";
                }
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