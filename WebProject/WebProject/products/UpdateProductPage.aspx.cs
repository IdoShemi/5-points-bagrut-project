using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.products
{
    public partial class UpdateProductPage : System.Web.UI.Page
    {
        public static string productCode = "";
        public static string filename = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sellerName"] == null && Session["adminName"] == null)
            {
                Response.Redirect("/errorPage.aspx?m=4");
            }

            if (!IsPostBack)
            {
                OleDbConnection Con1 = new OleDbConnection();
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";


                Con1.Open();
                string sqlstring = "SELECT mycategoryname FROM categories";
                OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                OleDbDataReader Dr = cmd.ExecuteReader();
                category.DataSource = Dr;
                category.DataTextField = "mycategoryname";
                category.DataBind();
                Con1.Close();

                productCode = Request.QueryString["pc"];
                Con1.Open();
                sqlstring = $"SELECT * FROM products WHERE productCode = '{productCode}'";
                cmd = new OleDbCommand(sqlstring, Con1);
                Dr = cmd.ExecuteReader();
                Dr.Read();
                InsertProductName.Text = Dr["productName"].ToString();
                InsertSeller.Text = Dr["productSeller"].ToString();
                category.SelectedValue = Dr["category"].ToString();
                InsertSerialNum.Text = Dr["productCode"].ToString();
                InsertAmount.Text = Dr["availiableamount"].ToString();

                filename = Dr["imageCode"].ToString();
                Image1.ImageUrl = filename;
                Con1.Close();

                Con1.Open();
                sqlstring = $"SELECT mysubcategoryname FROM subcategories WHERE mycatergoryname = '{category.SelectedValue}'";
                cmd = new OleDbCommand(sqlstring, Con1);
                Dr = cmd.ExecuteReader();
                subcategory.DataSource = Dr;
                subcategory.DataTextField = "mysubcategoryname";
                subcategory.DataBind();
                Con1.Close();


                //ImageCode
            }
        }

        protected void dataChanged(object sender, EventArgs e)
        {
            OleDbConnection Con1 = new OleDbConnection();
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";


            Con1.Open();
            string sqlstring = $"SELECT mysubcategoryname FROM subcategories WHERE mycatergoryname = '{category.SelectedValue}'";
            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            OleDbDataReader Dr = cmd.ExecuteReader();
            subcategory.DataSource = Dr;
            subcategory.DataTextField = "mysubcategoryname";
            subcategory.DataBind();
            subcategory.Items.Insert(0, new ListItem("subcategory", "subcategory"));
            Con1.Close();
        }


        protected void Updatebutton(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection Con1 = new OleDbConnection();
                //  OleDbCommand cmd = null;
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";


                if (FileUpload1.HasFiles)
                {
                    string prefix = Server.MapPath("");
                    string path = "\\..\\images\\";
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(prefix + path);
                    int count = dir.GetFiles().Length + 1;
                    string[] a = FileUpload1.FileName.ToString().Split('.');
                    filename = path + count.ToString() + '.' + a[a.Length - 1];
                    FileUpload1.SaveAs(prefix + filename);
                }


                string sqlstring = $"UPDATE products SET productName = '{InsertProductName.Text}', category = '{category.SelectedValue}'," +
                    $" subcategory = '{subcategory.SelectedValue}', productCode = '{InsertSerialNum.Text}', ImageCode ='{filename}', " +
                    $"availiableamount='{InsertAmount.Text}' WHERE productCode ='{productCode}'";

                Response.Write(sqlstring);
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