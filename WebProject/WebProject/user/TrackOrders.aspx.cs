using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProject.Shippy;
namespace WebProject.user
{
    public partial class TrackOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null)
                Response.Redirect("/errorPage.aspx?m=2");
            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\..\\database.accdb";

            Con.Open();
            string sqlstring = "SELECT * FROM orders WHERE user_name='" + Session["userName"].ToString() + "'";

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
        protected string GetShipmentCode(string orderId, string productName)
        {
            ShippySoapClient s = new ShippySoapClient();
            return s.ReadShipmentIdByOrderIdAndProductName(orderId, productName);
        }



        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void myCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}