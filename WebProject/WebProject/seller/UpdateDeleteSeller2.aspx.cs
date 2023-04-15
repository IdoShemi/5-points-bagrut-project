using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.seller
{
    public partial class UpdateDeleteSeller2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["adminName"] == null)
                Response.Redirect("/errorPage.aspx?m=3");
            UserName.Enabled = false;
            InsPass.Enabled = false;
            SellerName.Enabled = false;
            BankAccount.Enabled = false;
            InsertAddress.Enabled = false;
            avgDelivery.Enabled = false;
            Mymail.Enabled = false;
            InsertCity.Enabled = false;
            Phone.Enabled = false;


        }



        protected void Updatebutton(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection Con1 = new OleDbConnection();
                //  OleDbCommand cmd = null;
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";


                string sqlstring = $"UPDATE sellers SET Mypassword = '{InsPass.Text}', MySellerName = '{SellerName.Text}" +
                    $"', BankAccountNum = '{BankAccount.Text}', AverageDeliveryTime = '{avgDelivery.Text}', MyAddress = '{InsertAddress.Text}', MyEmail ='{Mymail.Text}', " +
                    $"myphonenumber='{Phone.Text}', MyCity='{InsertCity.Text}',Myusername ='{UserName.Text}' WHERE Myusername ='{InsertName.Text}'";


                InsertName.Enabled = true;
                UserName.Text = "";
                InsPass.Text = "";
                SellerName.Text = "";
                BankAccount.Text = "";
                InsertAddress.Text = "";
                avgDelivery.Text = "";
                Mymail.Text = "";
                InsertCity.Text = "";
                Phone.Text = "";


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

        protected void UpdateValuesbutton(object sender, EventArgs e)
        {
            OleDbConnection Con1 = new OleDbConnection();
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con1.Open();
            string sqlstring = "SELECT * FROM sellers WHERE Myusername = '" + InsertName.Text + "';";

            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            OleDbDataReader Dr = cmd.ExecuteReader();
            Dr.Read();



            if (Dr.HasRows)
            {
                InsertName.Enabled = false;
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

                UserName.Enabled = true;
                InsPass.Enabled = true;
                SellerName.Enabled = true;
                BankAccount.Enabled = true;
                InsertAddress.Enabled = true;
                avgDelivery.Enabled = true;
                Mymail.Enabled = true;
                InsertCity.Enabled = true;
                Phone.Enabled = true;
                deleteBtn.Visible = true;

                //   Response.Redirect("Welcome.aspx");
                //Response.Write("Found!");

            }
            else
            {
                string name = InsertName.Text.ToString();
                InsertName.Text = "";
                Response.Write($"{name} NOT found");
                Con1.Close();
            }
        }

        protected void Delbutton(object sender, EventArgs e)
        {
            OleDbConnection Con1 = new OleDbConnection();
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con1.Open();
            string sqlstring = "DELETE * FROM sellers WHERE Myusername='" + UserName.Text + "';";
            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            int y = 0;
            y = cmd.ExecuteNonQuery();
            Response.Write(y);
        }
    }
}