using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.categories
{
    public partial class AskCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sellerName"] == null && Session["adminName"] == null)
            {
                Response.Redirect("/errorPage.aspx?m=1");
            }

            if (!IsPostBack)
            {
                OleDbConnection Con1 = new OleDbConnection();
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
                Con1.Open();
                string sqlstring = "SELECT mycategoryname FROM categories";
                OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                OleDbDataReader Dr = cmd.ExecuteReader();
                showcategories.DataSource = Dr;
                showcategories.DataTextField = "mycategoryname";
                showcategories.DataBind();
                Con1.Close();
            }
        }

        protected void InsertCategorybutton(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection Con1 = new OleDbConnection();
                //  OleDbCommand cmd = null;
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";


                string sqlstring = $"INSERT INTO AskedCategories (categoryName, subCategoryName, sellerName) VALUES ('{CatText.Text}', '', '{Session["sellerName"].ToString()}');";

                Con1.Open();
                OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                int y = 0;
                y = cmd.ExecuteNonQuery();
                l1.Text =  y == 1 ? "request sent to admin" : "error";
                Con1.Close();

            }
            catch (Exception ex)
            {
                l1.Text = (ex.Message);
            }
        }

        protected void InsertSubCategorybutton(object sender, EventArgs e) // change to request!!!
        {
            try
            {
                OleDbConnection Con1 = new OleDbConnection();
                //  OleDbCommand cmd = null;
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";


                string sqlstring = $"INSERT INTO AskedCategories (categoryName, subCategoryName, sellerName) VALUES ('{showcategories.SelectedValue}', '{subCatText.Text}', '{Session["sellerName"].ToString()}');";

                Con1.Open();
                OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                int y = 0;
                y = cmd.ExecuteNonQuery();
                l1.Text = y == 1 ? "request sent to admin" : "error";
                Con1.Close();

            }
            catch (Exception ex)
            {
                l1.Text = (ex.Message);
            }
        }
    }
}