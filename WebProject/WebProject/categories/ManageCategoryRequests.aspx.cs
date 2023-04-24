using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.categories
{
    public partial class ManageCategoryRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // add admin permission
            if (Session["adminName"] == null)
                Response.Redirect("/errorPage.aspx?m=3");

            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con.Open();
            string sqlstring = $"select * from AskedCategories";

            OleDbCommand Cmd = new OleDbCommand(sqlstring, Con);
            OleDbDataReader dr1 = Cmd.ExecuteReader();

            DataList2.DataSource = dr1;
            DataList2.DataBind();


            if (!IsPostBack)
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
                string sql = "SELECT * FROM categories ORDER BY mycategoryname";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand(sql, connection);
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string categoryName = reader["mycategoryname"].ToString();
                            string subCategorySql = $"SELECT * FROM subcategories WHERE mycatergoryname='{categoryName}'";
                            OleDbCommand subCategoryCommand = new OleDbCommand(subCategorySql, connection);
                            OleDbDataReader subCategoryReader = subCategoryCommand.ExecuteReader();

                            categoryList.Text +=($"<h2>{categoryName}</h2>");

                            if (subCategoryReader.HasRows)
                            {
                                categoryList.Text +=("<ul>");

                                while (subCategoryReader.Read())
                                {
                                    string subCategoryName = subCategoryReader["mysubcategoryname"].ToString();
                                    categoryList.Text +=($"<li>{subCategoryName}</li>");
                                }

                                categoryList.Text +=("</ul>");
                            }
                            else
                            {
                                categoryList.Text +=("<p>No subcategories found.</p>");
                            }

                            subCategoryReader.Close();
                        }
                    }
                    else
                    {
                        categoryList.Text +=("<p>No categories found.</p>");
                    }

                    reader.Close();
                }
            }

            
        }

        

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(',');
            if (e.CommandName == "AcceptRequest")
            {
                if (args[2] == "")
                    InsertCategorybutton(args);
                else
                    InsertSubCategorybutton(args);

                SendResponse("Request Accepted", args);
            }
            else
            {
                SendResponse("Request Denied", args);
            }

            OleDbConnection Con1 = new OleDbConnection();
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con1.Open();
            string sqlstring = "DELETE * FROM AskedCategories WHERE Id=" + args[3] + ";";
            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            int y = 0;
            y = cmd.ExecuteNonQuery();
            if (y > 0)
            {
                Thread.Sleep(500);
                Response.Redirect("/categories/ManageCategoryRequests.aspx");
            }
        }

        protected void SendResponse(string res, string[] args)
        {
            OleDbConnection Con1 = new OleDbConnection();
            //  OleDbCommand cmd = null;
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
            string sqlstring = $"INSERT INTO Responses (Mto, Mmessage) VALUES ('{args[0].ToString()}', '{res.ToString()}');";
            Response.Write(sqlstring);
            Con1.Open();
            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            int y = 0;
            y = cmd.ExecuteNonQuery();
            Response.Write(y);
            Con1.Close();
        }


        protected void InsertCategorybutton(string[] args)
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


                string sqlstring = $" INSERT INTO categories (mycategoryname, categorycode) VALUES('{args[1]}', '{newcodenumber}');";

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



        protected void InsertSubCategorybutton(string[] args)
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


                string sqlstring = " INSERT INTO subcategories (mycatergoryname , mysubcategoryname, subcategorycode) VALUES " + "('" + args[1] + "','" + args[2] + "','" + newcodenumber + "')";

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