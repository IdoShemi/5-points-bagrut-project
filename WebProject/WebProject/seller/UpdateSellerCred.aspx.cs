using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.seller
{
    public partial class UpdateSellerCred : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sellerName"] == null)
                Response.Redirect("/errorPage.aspx?m=1");
            if (!IsPostBack)
            {
                OleDbConnection Con1 = new OleDbConnection();
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
                Con1.Open();
                string sqlstring = "SELECT * FROM sellers WHERE MySellerName = '" + Session["sellerName"].ToString() + "';";

                OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                OleDbDataReader Dr = cmd.ExecuteReader();
                Dr.Read();



                UserName.Text = Dr["Myusername"].ToString();
                InsPass.Text = Dr["Mypassword"].ToString();
                SellerName.Text = Dr["MySellerName"].ToString();
                BankAccount.Text = Dr["BankAccountNum"].ToString();
                InsertAddress.Text = Dr["MyAddress"].ToString();
                avgDelivery.Text = Dr["AverageDeliveryTime"].ToString();
                Mymail.Text = Dr["MyEmail"].ToString();
                InsertCity.Text = Dr["MyCity"].ToString();
                Phone.Text = Dr["myphonenumber"].ToString();

                Con1.Close();
            }
            
        }

        protected void Updatebutton(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection Con1 = new OleDbConnection();
                //  OleDbCommand cmd = null;
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";

                string s = BankAccount.Text;

                string sqlstring = $"UPDATE sellers SET Mypassword = '{InsPass.Text}', MySellerName = '{SellerName.Text}" +
                    $"', BankAccountNum = '{BankAccount.Text}', AverageDeliveryTime = '{avgDelivery.Text}', MyAddress = '{InsertAddress.Text}', MyEmail ='{Mymail.Text}', " +
                    $"myphonenumber='{Phone.Text}', MyCity='{InsertCity.Text}',Myusername ='{UserName.Text}' WHERE MySellerName ='{Session["sellerName"].ToString()}'";

                Response.Write(sqlstring);

                Con1.Open();
                OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                int y = 0;
                y = cmd.ExecuteNonQuery();
                Response.Write(y);
                Con1.Close();
                Response.Redirect("~/Homepage.aspx");

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }



        protected void Delbutton(object sender, EventArgs e)
        {
            OleDbConnection Con1 = new OleDbConnection();
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con1.Open();
            string sqlstring = "DELETE * FROM sellers WHERE MySellerName='" + Session["sellerName"].ToString() + "';";
            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            int y = 0;
            y = cmd.ExecuteNonQuery();
            Response.Write(y);
        }
    }
}