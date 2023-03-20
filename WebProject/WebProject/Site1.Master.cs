using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string linksites = "";
            if (Session["userName"] != null)
            { // user pages
                linksites = "<a href='/index.html' class='nav-item nav-link'>Home</a>" +
                    "<a href='/user/ShowUsersPage.aspx' class='nav-item nav-link'>Catalog</a>" +
                            "<a href='/user/UpdateUserCredintialsPage.aspx' class='nav-item nav-link'>Update Credintials</a>";


                Literal2.Text = "<a href='/LogOutPage.aspx' class='btn px-0 ml-3' style='color:white'>Log Out</a>";
            }
            else if (Session["sellerName"] != null)
            { // seller pages
                linksites = "<a href='/index.html' class='nav-item nav-link'>Home</a>" +
                    "<a href='/products/InsertProductPage.aspx' class='nav-item nav-link'>Insert Product</a>" +
                            "<a href='/products/MangeProductsPage.aspx' class='nav-item nav-link'>Manage Products</a>" +
                            "<a href='/seller/UpdateDeleteSeller.aspx' class='nav-item nav-link'>Update Seller credentials</a>" +
                            "<a href='/categories/AskCategory.aspx' class='nav-item nav-link'>Ask Category</a>";
                Literal3.Text = "<a href='/categories/Notifications.aspx' class='btn px-0 ml-3'>" +
                    "<i class='fas fa-bell text-primary'></i>" +
                    "<span class='badge text-secondary border border-secondary rounded-circle' style='padding-bottom: 2px;'>"+ CountNotifications().ToString() +"</span></a>";
            }
            else if (Session["adminName"] != null)
            {
                // admin pages - add menu and add all the pages 
            }
            else
            {// unregistered user
                linksites = "<a href='/index.html' class='nav-item nav-link'>Home</a>" +
                "<a href='/SignUp.aspx' class='nav-item nav-link'>Sign Up</a>" +
                "<a href='/SignIn.aspx' class='nav-item nav-link'>Sign In</a>";
            }

            literl1.Text = linksites;
        }

        protected int CountNotifications()
        {
            OleDbConnection Con1 = new OleDbConnection();
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con1.Open();
            string sqlstring = $"select * from Responses WHERE Mto='{Session["sellerName"].ToString()}'"; OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            OleDbDataReader Dr = cmd.ExecuteReader();
            Dr.Read();
            int count = 0;
            if (Dr.HasRows)
            {
                do
                    count++;
                while (Dr.Read());
            }
            return count;
        }
    }
}