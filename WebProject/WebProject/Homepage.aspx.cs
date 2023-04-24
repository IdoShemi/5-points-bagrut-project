using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Define the SQL query to get the top 5 best-selling products for this year
            string connectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\database.accdb";

            DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            string sqlQuery = "SELECT TOP 5 orders.seller, orders.product_name, products.productCode, products.ImageCode, SUM(orders.product_quantity) as total_quantity " +
                              "FROM orders INNER JOIN products ON orders.product_name = products.productName " +
                              "WHERE order_date >= #" + startOfYear.ToString("dd/MM/yyyy") + "# " +
                              "GROUP BY orders.seller, orders.product_name, products.ImageCode, products.productCode " +
                              "ORDER BY SUM(orders.product_quantity) DESC";
            //"GROUP BY product_name, seller " +
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
    }
}