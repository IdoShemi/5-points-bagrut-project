using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.categories
{
    public partial class Notifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sellerName"] == null)
                Response.Redirect("../errorPage.aspx?m=1");

            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con.Open();
            string sqlstring = $"select * from Responses WHERE Mto='{Session["sellerName"].ToString()}'";

            OleDbCommand Cmd = new OleDbCommand(sqlstring, Con);
            OleDbDataReader dr1 = Cmd.ExecuteReader();

            DataList2.DataSource = dr1;
            DataList2.DataBind();

            //basket b = new basket();
            //Session["basket"] = b;
        }


        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(',');

            OleDbConnection Con1 = new OleDbConnection();
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con1.Open();
            string sqlstring = "DELETE * FROM Responses WHERE Id=" + args[0] + ";";
            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            int y = 0;
            y = cmd.ExecuteNonQuery();
            if (y > 0)
            {
                Thread.Sleep(700);
                Response.Redirect("/categories/Notifications.aspx"); 
            }
        }
    }
}