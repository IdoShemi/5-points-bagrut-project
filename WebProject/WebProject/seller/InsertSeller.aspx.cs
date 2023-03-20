using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.seller
{
    public partial class InsertSeller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Insertbutton(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection Con1 = new OleDbConnection();
                //  OleDbCommand cmd = null;
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";


                Con1.Open();
                string sqlstring_getcodenumber = "SELECT SellerCode FROM sellers ORDER BY SellerCode DESC";
                OleDbCommand cmd1 = new OleDbCommand(sqlstring_getcodenumber, Con1);
                OleDbDataReader Dr = cmd1.ExecuteReader();
                Dr.Read();
                int newcodenumber = Convert.ToInt32(Dr["SellerCode"]) + 1;
                Con1.Close();

                string sqlstring = " INSERT INTO sellers (Myusername,Mypassword, MySellerName, SellerCode, BankAccountNum, MyAddress, AverageDeliveryTime, MyEmail, MyCity, myphonenumber) VALUES "
                                + "('" + UserName.Text + "','" + InsPass.Text + "','" + SellerName.Text + "','" +
                                newcodenumber + "','" + BankAccount.Text + "','" + InsertAddress.Text + "','" + avgDelivery.Text + "','" + Mymail.Text + "','" + InsertCity.Text + "','" + Phone.Text + "');";

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