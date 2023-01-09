using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;



namespace WebProject
{
    public partial class showProduct : System.Web.UI.Page
    {
        public static string productCode = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            productCode = Request.QueryString["pc"];
            OleDbConnection Con1 = new OleDbConnection();
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";


            Con1.Open();
            
            string sqlstring = $"SELECT * FROM products WHERE productCode = '{productCode}'";
            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            OleDbDataReader Dr = cmd.ExecuteReader();
            Dr.Read();

            InsertProductName.Text = Dr["productName"].ToString();
            InsertSeller.Text = Dr["productSeller"].ToString();
            Category.Text = Dr["category"].ToString();
            subcategory.Text = Dr["subcategory"].ToString();
            InsertAmount.Text = Dr["availiableamount"].ToString();

            string filename = Dr["imageCode"].ToString();
            Image1.ImageUrl = filename;
            Con1.Close();


        }
    }
}