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


            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con.Open();
            string sqlstring = $"select * from products";
            //string sqlstring = $"select * from products WHERE productSeller = '{Session["sellerName"]}'";

            OleDbCommand Cmd = new OleDbCommand(sqlstring, Con);
            OleDbDataReader dr1 = Cmd.ExecuteReader();

            DataList2.DataSource = dr1;
            DataList2.DataBind();

            //basket b = new basket();
            //Session["basket"] = b;
        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }
    }
}