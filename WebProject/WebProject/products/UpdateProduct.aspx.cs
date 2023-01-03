﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.products
{
    public partial class UpdateProduct : System.Web.UI.Page
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
                Con1.Close();

                string productCode = Request.QueryString["pc"];
                Con1.Open();
                sqlstring = $"SELECT * FROM products WHERE serialNumber = '{productCode}'";
                cmd = new OleDbCommand(sqlstring, Con1);
                Dr = cmd.ExecuteReader();
                Dr.Read();
                InsertProductName.Text = Dr["productName"].ToString();
                InsertSeller.Text = Dr["productSeller"].ToString();
                category.SelectedValue = Dr["category"].ToString();
                InsertSerialNum.Text = Dr["serialNumber"].ToString();
                InsertAmount.Text = Dr["availiableamount"].ToString();

                string path = Dr["imageCode"].ToString();
                Image1.ImageUrl = path;
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
            //    try
            //    {
            //        if (!(category.SelectedIndex == 0 || subcategory.SelectedIndex == 0))
            //        {
            //            OleDbConnection Con1 = new OleDbConnection();
            //            //  OleDbCommand cmd = null;
            //            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";

            //            string filename = "0";
            //            if (FileUpload1.HasFiles)
            //            {
            //                string path = Server.MapPath("") + "\\..\\images\\";
            //                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
            //                int count = dir.GetFiles().Length + 1;
            //                string[] a = FileUpload1.FileName.ToString().Split('.');
            //                filename = path + count.ToString() + '.' + a[a.Length - 1];
            //                FileUpload1.SaveAs(filename);
            //            }


            //            string sqlstring = " INSERT INTO products (productName,productSeller, category, subcategory, serialNumber, ImageCode, availiableamount) VALUES "
            //                            + "('" + InsertProductName.Text + "','" + InsertSeller.Text + "','" + category.SelectedValue + "','" +
            //                            subcategory.SelectedValue + "','" + InsertSerialNum.Text + "','" + filename + "','" + InsertAmount.Text + "');";

            //            Con1.Open();
            //            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            //            int y = 0;
            //            y = cmd.ExecuteNonQuery();
            //            Response.Write(y);
            //            Con1.Close();
            //        }
            //        else
            //            Response.Write("you must select a category and a subcategory");

            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write(ex.Message);
            //    }
        }
    }
}