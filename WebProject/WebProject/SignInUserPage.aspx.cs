using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


namespace WebProject
{
    public partial class SignInUserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignInFunc(object sender, EventArgs e)
        {
            string s = CheckForAdmin();
            if (s != "")
            {
                Session["adminName"] = s;
                Response.Redirect("/admin/adminHub.aspx");
            }



            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\database.accdb";
            Con.Open();
            string sqlstring = "select * from users WHERE myusername = '"+InputUserName.Text+"' AND mypassword ='"+InputPassWord.Text+"'";
            OleDbCommand Cmd = new OleDbCommand(sqlstring, Con);
            OleDbDataReader dr1 = Cmd.ExecuteReader();
            if (dr1.HasRows)
            {
                dr1.Read();
                Session["userName"] = dr1["myusername"].ToString();
                Response.Redirect("user/ProductsCatalogPage.aspx");
            }
            else
                Label1.Text = "not valid username or password";


        }

        protected string CheckForAdmin()
        {
            // Load the XML file
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("")+ "/admins.xml");

            // Select the admin node that matches the username and password
            string username = InputUserName.Text;
            string password = InputPassWord.Text;
            XmlNode adminNode = xmlDoc.SelectSingleNode("//admin[@username='" + username + "' and @password='" + password + "']");
            return adminNode != null ? username : "";
        }
    }
}