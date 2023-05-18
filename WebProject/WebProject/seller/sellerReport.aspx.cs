using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace WebProject.seller
{
    public partial class sellerReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sellerName"] == null)
                Response.Redirect("/errorPage.aspx?m=1");
            ShowBest5Month();
            ShowBest5Year();
        }


        protected void ShowBest5Year()
        {
            // Define the SQL query to get the top 5 best-selling products for this year
            string connectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\..\\database.accdb";

            DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            string sqlQuery = "SELECT TOP 5 product_name, SUM(product_quantity) as total_quantity " +
                             "FROM orders " +
                             "WHERE order_date >= #" + startOfYear.ToString("dd/MM/yyyy") + "# AND seller = '" + Session["sellerName"].ToString() +"' " +
                             "GROUP BY product_name, seller " +
                             "ORDER BY SUM(product_quantity) DESC";

            // Create a new OleDbConnection object and open the connection
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Create a new OleDbCommand object with the SQL query and connection
                using (OleDbCommand command = new OleDbCommand(sqlQuery, connection))
                {
                    // Create a new OleDbDataAdapter to execute the command and fill a DataTable with the results
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to a GridView control to display the results
                        repeater2.DataSource = dataTable;
                        repeater2.DataBind();
                    }
                }

                connection.Close();
            }
        }
        protected void ShowBest5Month()
        {
            // Define the SQL query to get the top 5 best-selling products
            string connectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\..\\database.accdb";

            DateTime currentDate = DateTime.Now;
            DateTime startOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            string sqlQuery = "SELECT TOP 5 product_name, SUM(product_quantity) as total_quantity " +
                             "FROM orders " +
                             "WHERE DATEDIFF('d', order_date, Date()) <= " + (currentDate.Day - 1) + " " +
                             "AND order_date >= #" + startOfMonth.ToString("dd/MM/yyyy") + "# AND seller = '" + Session["sellerName"].ToString() + "' " +
                             "GROUP BY product_name, seller " +
                             "ORDER BY SUM(product_quantity) DESC";

            // Create a new OleDbConnection object and open the connection
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Create a new OleDbCommand object with the SQL query and connection
                using (OleDbCommand command = new OleDbCommand(sqlQuery, connection))
                {
                    // Create a new OleDbDataAdapter to execute the command and fill a DataTable with the results
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to a GridView control to display the results
                        repeater.DataSource = dataTable;
                        repeater.DataBind();
                    }
                }

                connection.Close();
            }
        }
    }
}