using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject
{
    public partial class ShowUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void Selectbutton(object sender, EventArgs e)
        {
            OleDbConnection Con1 = new OleDbConnection();
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\database.accdb";
            Con1.Open();
            string sqlstring = "SELECT * FROM users";
            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            OleDbDataReader Dr = cmd.ExecuteReader();
            Dr.Read();
            
            if (Dr.HasRows)
            {
                int count = 0;
                string tableResponse = "<table><tr style='background:#ddd;'><td>username</td><td>email</td><td>gender</td><td>phonenumber</td></tr>";
                do
                {
                    tableResponse += $"<tr><td>{Dr["myusername"].ToString()}</td><td>" +
                        $"{Dr["myemail"].ToString()}</td><td>{Dr["mygender"].ToString()}<td>{Dr["myphonenumber"].ToString()}</td></tr>";
                    count++;
                }
                while (Dr.Read());
                tableResponse += "</table>";
                Con1.Close();
                Response.Write($"<div class='tableContainer'>{tableResponse}<br/>found {count} </div>");


                //   Response.Redirect("Welcome.aspx");
                //Response.Write("Found!");

            }
            else
            {
                Response.Write("NOT found");
                Con1.Close();

            }


        }
    }
}