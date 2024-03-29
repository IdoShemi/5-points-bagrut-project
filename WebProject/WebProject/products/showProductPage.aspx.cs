﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.products
{
    public partial class showProductPage : System.Web.UI.Page
    {

        public static string productCode = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["sellerName"] == null && Session["userName"] == null && Session["adminName"] == null)
            //    Response.Redirect("/errorPage.aspx?m=4");

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
            InsertPrice.Text = Dr["Price"].ToString();

            string filename = Dr["imageCode"].ToString();
            Image1.ImageUrl = filename;
            Con1.Close();

            if (Session["userName"] == null)
                addbtn.Visible = false;


        }



        protected void UpdateBasket(object sender, EventArgs e)
        {
            productCode = Request.QueryString["pc"];
            OleDbConnection Con1 = new OleDbConnection();
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";


            Con1.Open();

            string sqlstring = $"SELECT * FROM products WHERE productCode = '{productCode}'";
            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            OleDbDataReader Dr = cmd.ExecuteReader();
            Dr.Read();
            string seller = Dr["productSeller"].ToString();
            string prodName = Dr["productName"].ToString();
            double price = Convert.ToDouble(Dr["Price"].ToString());

            item i = new item(seller, prodName ,price);
            basket b = new basket();
            b = (basket)Session["basket"];
            b.ADDitem(i);
            Session["basket"] = b;

            // Get a reference to the master page
            var master = Master as Site1;
            master?.UpdateBasketText();

            Con1.Close();

            ShowPopup();
        }

        private void ShowPopup()
        {
            popup.Style.Add("display", "block");
            ScriptManager.RegisterStartupScript(this, GetType(), "HidePopup", "setTimeout(function() { document.getElementById('" + popup.ClientID + "').style.display = 'none'; }, 3000);", true);
        }
    }
}