using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject
{
    public partial class SignInSellerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignInFunc(object sender, EventArgs e)
        {
            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\database.accdb";
            Con.Open();
            string sqlstring = $"select * from sellers WHERE Myusername = '{InputUserName.Text}' AND Mypassword ='{InputPassWord.Text}'";

            OleDbCommand Cmd = new OleDbCommand(sqlstring, Con);
            OleDbDataReader dr1 = Cmd.ExecuteReader();
            if (dr1.HasRows)
            {
                dr1.Read();
                Session["sellerName"] = dr1["MySellerName"].ToString();
                Response.Redirect("products/MangeProductsPage.aspx");
            }
            else
                Label1.Text = "not valid username or password";


        }
    }
}