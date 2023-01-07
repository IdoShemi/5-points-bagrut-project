using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.products
{
    public partial class InsertProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                category.Items.Insert(0, new ListItem("category", "category"));
                Con1.Close();
            }
        }

        protected void Insertbutton(object sender, EventArgs e)
        {
            try
            {
                if (!(category.SelectedIndex == 0 || subcategory.SelectedIndex == 0))
                {
                    OleDbConnection Con1 = new OleDbConnection();
                    //  OleDbCommand cmd = null;
                    Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";


                    string filename = "";
                    if (FileUpload1.HasFiles)
                    {
                        string prefix = Server.MapPath("");
                        string path = "\\..\\images\\";
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(prefix + path);
                        int count = dir.GetFiles().Length + 1;
                        string[] a = FileUpload1.FileName.ToString().Split('.');
                        filename = path + count.ToString() + '.' + a[a.Length - 1];
                        FileUpload1.SaveAs(prefix+filename);
                    }


                    string sqlstring = " INSERT INTO products (productName,productSeller, category, subcategory, productCode, ImageCode, availiableamount) VALUES "
                                    + "('" + InsertProductName.Text + "','" + InsertSeller.Text + "','" + category.SelectedValue + "','" +
                                    subcategory.SelectedValue + "','" + InsertSerialNum.Text + "','" + filename + "','" + InsertAmount.Text + "');";

                    Con1.Open();
                    OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                    int y = 0;
                    y = cmd.ExecuteNonQuery();
                    Response.Write(y);
                    Con1.Close();
                }
                else
                    Response.Write("you must select a category and a subcategory");

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
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

    }
}