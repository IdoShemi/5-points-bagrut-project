using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.products
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sellerName"] == null)
                Response.Redirect("../errorPage.aspx?m=1");
            

            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con.Open();
            string sqlstring = $"select * from products WHERE productSeller = '{Session["sellerName"]}'";

            OleDbCommand Cmd = new OleDbCommand(sqlstring, Con);
            OleDbDataReader dr1 = Cmd.ExecuteReader();

            DataList2.DataSource = dr1;
            DataList2.DataBind();

            //basket b = new basket();
            //Session["basket"] = b;
        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(',');
            string code = args[0];
            string name = args[1];
            if (e.CommandName == "ShowProduct")
            {
                Response.Redirect("showProduct.aspx?pc=" + code);
            }
            else
                 if (e.CommandName == "EditProduct") Response.Redirect("UpdateProduct.aspx?pc="+code);

        }
    }
}