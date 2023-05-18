using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProject.Shippy;

namespace WebProject.user
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null)
                Response.Redirect("/errorPage.aspx?m=2");
            if(Session["basket"] == null)
            {
                basket bs = new basket();
                Session["basket"] = bs;
            }


            basket b = new basket();
            b = (basket)Session["basket"];

            DataTable DT = new DataTable();
            DataColumn ProductName = new DataColumn("productName");
            DataColumn SellerName = new DataColumn("productSeller");
            DataColumn Price = new DataColumn("Price");
            DataColumn ImageCode = new DataColumn("ImageCode");
            DataColumn productCode = new DataColumn("productCode");
            DT.Columns.Add(ProductName);
            DT.Columns.Add(SellerName);
            DT.Columns.Add(Price);
            DT.Columns.Add(ImageCode);
            DT.Columns.Add(productCode);


            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";

            Con.Open();
            double sum = 0;

            //DataTable table = new DataTable();

            foreach (item i in b.Basket)
            {
                string sqlstring = "select * from products where productName='" + i.pName + "'";
                OleDbCommand Cmd = new OleDbCommand(sqlstring, Con);
                OleDbDataReader Dr = Cmd.ExecuteReader();


                Dr.Read();
                DataRow DD = DT.NewRow();
                DD["productName"] = Dr["productName"].ToString();
                DD["productSeller"] = Dr["productSeller"].ToString();
                DD["Price"] = Dr["Price"].ToString();
                DD["ImageCode"] = Dr["ImageCode"].ToString();
                DD["productCode"] = Dr["productCode"].ToString();
                sum += Convert.ToDouble(Dr["Price"].ToString());
                DT.Rows.Add(DD);
                //DataList1.DataSource = DT;
                //DataList1.DataBind();
                
                Session["DL"] = myRepeater;

                //table.Rows.Add(Dr["productName"], Dr["productSeller"], Dr["Price"], Dr["ImageCode"]);
            }
            myRepeater.DataSource = DT;
            myRepeater.DataBind();
            Total.Text = sum.ToString();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void btnRemove_Click(object sender, EventArgs e) {

            string[] values = ((ImageButton)sender).CommandArgument.Split(',');
            basket b = new basket();
            b = (basket)Session["basket"];
            int c = 0;
            foreach (item i in b.Basket)
            {
                if (i.pName == values[0] && i.seller == values[1])
                {
                    b._basket.RemoveAt(c);
                    Session["basket"] = b;
                    Response.Redirect("/user/ShoppingCart.aspx");
                }
                c++;
            }

        }


        public class Product
        {
            public string Name { get; set; }
            public string Seller { get; set; }
            public int Count { get; set; }
            public bool IsInStock { get; set; }
        }

        protected void Checkout(object sender, EventArgs e)
        {
            // update stock
            basket b = new basket();
            b = (basket)Session["basket"];

            // Create a dictionary to store the counts
            Dictionary<string, int> itemCounts = new Dictionary<string, int>();

            // Loop through each item in the basket
            foreach (item item in b._basket)
            {
                // Generate a key for the item based on its name and seller
                string key = item.pName + "|" + item.seller;

                // Check if the item is already in the dictionary
                if (itemCounts.ContainsKey(key))
                {
                    // If it is, increment the count
                    itemCounts[key]++;
                }
                else
                {
                    // If not, add it to the dictionary with a count of 1
                    itemCounts.Add(key, 1);
                }
            }

            foreach (KeyValuePair<string, int> item in itemCounts)
            {
                string[] values = item.Key.Split('|');
                int amount = item.Value;
                (bool inStock, int amount_in_stock) = CheckStock(values[0], values[1], amount);

                // If the item is not in stock, raise an alert in JavaScript
                if (!inStock)
                {
                    string alertScript = "alert('Product " + values[0] + " from " + values[1] + " has "+ amount_in_stock + " items in stock.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", alertScript, true);
                    return;
                }
            }

            //order code
            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\..\\database.accdb";

            Con.Open();
            string sqlstring = "SELECT order_id FROM orders ORDER BY order_id DESC";
            OleDbCommand cmd1 = new OleDbCommand(sqlstring, Con);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            dr1.Read();
            int newcodenumber = Convert.ToInt32(dr1["order_id"]) + 1;
            Con.Close();

            foreach (KeyValuePair<string, int> item in itemCounts)
            {

                string[] values = item.Key.Split('|');
                int amount = item.Value;

                (bool inStock, int amount_in_stock) = CheckStock(values[0], values[1], amount);
                LowerStock(values[0], values[1], amount, amount_in_stock);
                SendOrder(values[0], values[1], amount, newcodenumber);
            }
            Response.Redirect("/user/orderSent.aspx?id=" + newcodenumber);
        }


        public (bool, int) CheckStock(string prod_name, string seller_name, int amount)
        {
            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con.Open();
            string sqlstring = $"select * from products WHERE productSeller = '{seller_name}' AND productName= '{prod_name}'";

            OleDbCommand Cmd = new OleDbCommand(sqlstring, Con);
            OleDbDataReader dr1 = Cmd.ExecuteReader();
            dr1.Read();
            int amount_in_stock = Convert.ToInt32(dr1["availiableamount"]);
            bool b = amount_in_stock >= amount;
            return (b , amount_in_stock);
        }


        public void LowerStock(string prod_name, string seller_name, int amount, int amount_in_stock)
        {
            OleDbConnection Con1 = new OleDbConnection();
            //  OleDbCommand cmd = null;
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";

            string sqlstring = $"UPDATE products SET availiableamount = '{amount_in_stock-amount}' WHERE productSeller = '{seller_name}' AND productName= '{prod_name}'";

            Con1.Open();
            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            int y = 0;
            y = cmd.ExecuteNonQuery();
            Con1.Close();
        }


        public void SendOrder(string prod_name, string seller_name, int amount, int newcodenumber)
        {
            string userName = Session["userName"].ToString();

            // part 1 - get user information and seller information.
            OleDbConnection Con = new OleDbConnection();
            Con.ConnectionString = @"provider=microsoft.ACE.oledb.12.0;data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con.Open();

            // reading product information
            string sqlstring = $"select * from users WHERE myusername = '{userName}'";

            OleDbCommand Cmd = new OleDbCommand(sqlstring, Con);
            OleDbDataReader dr1 = Cmd.ExecuteReader();
            dr1.Read();
            string address = dr1["myaddress"].ToString(); 
            string city = dr1["mycity"].ToString();
            Con.Close();

            // reading seller information
            Con.Open();

            sqlstring = $"select * from sellers WHERE MySellerName = '{seller_name}'";

            Cmd = new OleDbCommand(sqlstring, Con);
            dr1 = Cmd.ExecuteReader();
            
            dr1.Read();
            string shipping_days = dr1["AverageDeliveryTime"].ToString();
            Con.Close();

            // part 2 - insert into the database
            Con.Open();
            string date = DateTime.Now.ToString("dd/MM/yyyy");

            sqlstring = "INSERT INTO orders (user_name, seller, address, city, product_name, order_id, shipping_days, product_quantity, order_date, order_status) VALUES "
                            + "('" + userName + "','" + seller_name + "','" + address + "','" +
                            city + "','" + prod_name + "','" + newcodenumber + "','" + shipping_days + "','" + amount + "','" + date +"','sent"+ "');";

            OleDbCommand cmd1 = new OleDbCommand(sqlstring, Con);
            int y = 0;
            y = cmd1.ExecuteNonQuery();
            Con.Close();

            ShippySoapClient s = new ShippySoapClient();
            s.InsertShipmentData(userName, seller_name, address, city, prod_name, date, newcodenumber.ToString(), amount);

        }

    }
}