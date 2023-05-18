using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace WebService
{
    /// <summary>
    /// Summary description for Shippy
    /// </summary>
    [WebService(Namespace = "http://shippy.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Shippy : System.Web.Services.WebService
    {

        [WebMethod]
        public static string GetCode()
        {
            Guid guid = Guid.NewGuid();
            string guidString = guid.ToString("N").Substring(0, 16);
            return guidString;
        }

        [WebMethod]
        public void InsertShipmentData(string userName, string seller, string address, string city, string productName, string orderDate, string orderId, int productQuantity)
        {
            string code = GetCode();
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source="+Server.MapPath("~/database2.accdb");
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "INSERT INTO Shipments (ShipmentId, UserName, Seller, Address, City, ProductName, OrderDate, OrderId, ProductQuantity) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", code);
                    command.Parameters.AddWithValue("?", userName);
                    command.Parameters.AddWithValue("?", seller);
                    command.Parameters.AddWithValue("?", address);
                    command.Parameters.AddWithValue("?", city);
                    command.Parameters.AddWithValue("?", productName);
                    command.Parameters.AddWithValue("?", orderDate);
                    command.Parameters.AddWithValue("?", orderId);
                    command.Parameters.AddWithValue("?", productQuantity);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        [WebMethod]
        public void DeleteShipmentData(string orderId, string productName)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/database2.accdb");
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "DELETE FROM Shipments WHERE OrderId = ? And ProductName = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", orderId);
                    command.Parameters.AddWithValue("?", productName);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        [WebMethod]
        public string ReadShipmentIdByOrderIdAndProductName(string orderId, string productName)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/database2.accdb");

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT ShipmentId FROM Shipments WHERE OrderId = ? AND ProductName = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", orderId);
                    command.Parameters.AddWithValue("?", productName);

                    connection.Open();
                    string result = command.ExecuteScalar() as string;

                    return result == null ? "None": result;
                }
            }
        }
    }
}
