using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.user
{
    public partial class ProductsCatalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sqlstring;
            if (!IsPostBack)
            {
                //basket b = new basket();
                //Session["basket"] = b;

                OleDbConnection Con1 = new OleDbConnection();
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
                Con1.Open();
                sqlstring = "SELECT mycategoryname FROM categories";
                OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                OleDbDataReader Dr = cmd.ExecuteReader();
                Category.DataSource = Dr;
                Category.DataTextField = "mycategoryname";
                Category.DataBind();
                Category.Items.Insert(0, new ListItem("category", "category"));
                Con1.Close();

                
            }


            sqlstring = "SELECT * FROM products WHERE 1=1";
            if (Category.SelectedIndex != 0)
                sqlstring += $" AND category = '{Category.SelectedValue}'";
            if (SubCat.SelectedIndex != 0)
                sqlstring += $" AND subcategory = '{SubCat.SelectedValue}'";
            if (MaxPrice.Text != "")
                sqlstring += $" AND Price <= {MaxPrice.Text}";
            if (MinPrice.Text != "")
                sqlstring += $" AND Price >= {MinPrice.Text}";

            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con.Open();
            sqlstring = $"select * from products";
            //string sqlstring = $"select * from products WHERE productSeller = '{Session["sellerName"]}'";

            OleDbCommand Cmd = new OleDbCommand(sqlstring, Con);
            OleDbDataReader dr1 = Cmd.ExecuteReader();

            DataList2.DataSource = dr1;
            DataList2.DataBind();


        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void SetFilters(object sender, EventArgs e)
        {
            string sqlstring = "SELECT * FROM products WHERE 1=1";
            if (Category.SelectedIndex != 0)
                sqlstring += $" AND category = '{Category.SelectedValue}'";
            if (SubCat.SelectedIndex != 0)
                sqlstring += $" AND subcategory = '{SubCat.SelectedValue}'";
            if (MaxPrice.Text != "")
                sqlstring += $" AND Price <= {MaxPrice.Text}";
            if (MinPrice.Text != "")
                sqlstring += $" AND Price >= {MinPrice.Text}";
            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con.Open();
            //string sqlstring = $"select * from products WHERE productSeller = '{Session["sellerName"]}'";

            OleDbCommand Cmd = new OleDbCommand(sqlstring, Con);
            OleDbDataReader dr1 = Cmd.ExecuteReader();

            DataList2.DataSource = dr1;
            DataList2.DataBind();


        }


        protected void dataChanged(object sender, EventArgs e)
        {
            OleDbConnection Con1 = new OleDbConnection();
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";


            Con1.Open();
            string sqlstring = $"SELECT mysubcategoryname FROM subcategories WHERE mycatergoryname = '{Category.SelectedValue}'";
            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            OleDbDataReader Dr = cmd.ExecuteReader();
            SubCat.DataSource = Dr;
            SubCat.DataTextField = "mysubcategoryname";
            SubCat.DataBind();
            SubCat.Items.Insert(0, new ListItem("subcategory", "subcategory"));
            Con1.Close();
        }
    }
}