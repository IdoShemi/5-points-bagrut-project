using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace WebProject.categories
{
    public partial class AddCategoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adminName"] == null)
                Response.Redirect("/errorPage.aspx?m=3");
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

                Con1.Open();
                string sqlstring_getcodenumber = "SELECT categorycode FROM categories ORDER BY categorycode DESC";
                OleDbCommand cmd1 = new OleDbCommand(sqlstring_getcodenumber, Con1);
                OleDbDataReader Dr = cmd1.ExecuteReader();
                Dr.Read();
                int newcodenumber = Convert.ToInt32(Dr["categorycode"]) + 1;
                Con1.Close();


                string sqlstring = $" INSERT INTO categories (mycategoryname, categorycode) VALUES('{CatText.Text}', '{newcodenumber}');";

                Con1.Open();
                OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                int y = 0;
                y = cmd.ExecuteNonQuery();
                Response.Write(y);
                Con1.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void InsertSubCategorybutton(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection Con1 = new OleDbConnection();
                //  OleDbCommand cmd = null;
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";

                Con1.Open();
                string sqlstring_getcodenumber = "SELECT subcategorycode FROM subcategories ORDER BY subcategorycode DESC";
                OleDbCommand cmd1 = new OleDbCommand(sqlstring_getcodenumber, Con1);
                OleDbDataReader Dr = cmd1.ExecuteReader();
                Dr.Read();
                int newcodenumber = Convert.ToInt32(Dr["subcategorycode"]) + 1;
                Con1.Close();


                string sqlstring = " INSERT INTO subcategories (mycatergoryname , mysubcategoryname, subcategorycode) VALUES " + "('" + showcategories.SelectedValue + "','" + subCatText.Text + "','" + newcodenumber + "')";

                Con1.Open();
                OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                int y = 0;
                y = cmd.ExecuteNonQuery();
                Response.Write(y);
                Con1.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}