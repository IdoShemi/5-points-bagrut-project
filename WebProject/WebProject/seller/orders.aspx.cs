using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.seller
{
    public partial class orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sellerName"] == null)
                Response.Redirect("/errorPage.aspx?m=1");
            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\..\\database.accdb";

            Con.Open();
            string sqlstring = "SELECT * FROM orders WHERE seller='" + Session["sellerName"].ToString() + "'";

            if (myCheckBox.Checked)
                sqlstring += " AND order_status = 'sent'";
            sqlstring += " ORDER BY order_id DESC";
            //string sqlstring = $"SELECT * FROM orders";
            OleDbCommand cmd1 = new OleDbCommand(sqlstring, Con);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            usersRepeater.DataSource = dr1;
            usersRepeater.DataBind();
            Con.Close();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delivered")
            {
                string[] values = e.CommandArgument.ToString().Split(',');
                // Delete the user with the given ID from the database

                OleDbConnection Con1 = new OleDbConnection();
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
                string sqlstring = $"UPDATE orders SET order_status = 'delivered' WHERE product_name = '{values[0]}' AND order_id= {values[1]}";

                //string sqlstring = "update orders Set order_status='delivered' WHERE product_name='" +  + "' and order_id='" + values[1] +"';";
                Con1.Open();
                OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                int y = 0;
                y = cmd.ExecuteNonQuery();
                Con1.Close();
                Response.Redirect("/seller/orders.aspx");
            }
        }

        protected void myCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}