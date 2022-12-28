using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace WebProject
{
    public partial class InsertUser : System.Web.UI.Page
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
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\database.accdb";

                string gender = "";
                if (RadioButton1.Checked) gender = "male";
                else gender = "female";

                string sqlstring = " INSERT INTO users (myusername,mypassword, mybirthdate, myemail, mygender, myphonenumber, mycity, myaddress, myname, mylastname) VALUES "
                                + "('" + InsertName.Text + "','" + InsertPass.Text + "','" + birthDay.Text+'/'+ birthMonth.Text+'/'+ birthYear.Text + "','" +
                                InsertMail.Text + "','" + gender + "','" + InsertPhone.Text + "','" + InsertCity.Text+ "','" + InsertAddress.Text+ "','" + InsertFirstName.Text + "','" + InsertLastName.Text + "');";

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