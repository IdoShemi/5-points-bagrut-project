using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject
{
    public partial class UpdateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void Updatebutton(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection Con1 = new OleDbConnection();
                //  OleDbCommand cmd = null;
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";

                string gender = "";
                if (RadioButton1.Checked) gender = "male";
                else gender = "female";

                string sqlstring = $"UPDATE users SET mypassword = '{InsertPass.Text}', mybirthdate = '{birthDay.Text + '/' + birthMonth.Text + '/' + birthYear.Text}" +
                    $"', myemail = '{InsertMail.Text}', mygender = '{gender}', myphonenumber = '{InsertPhone.Text}', myaddress ='{InsertAddress.Text}', " +
                    $"mycity='{InsertCity.Text}', myname='{InsertFirstName.Text}', mylastname='{InsertLastName.Text}' WHERE myusername ='{InsertName.Text}'";

                Response.Write(sqlstring);
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
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\database.accdb";
            Con1.Open();
            string sqlstring = "SELECT * FROM users WHERE myusername = '" + InsertName.Text+"';";

            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            OleDbDataReader Dr = cmd.ExecuteReader();
            Dr.Read();

            InsertName.Enabled = false;

            if (Dr.HasRows)
            {
                InsertName.Text = Dr["myusername"].ToString();
                InsertFirstName.Text = Dr["myname"].ToString();
                InsertLastName.Text = Dr["mylastname"].ToString();
                InsertPass.Text = Dr["mypassword"].ToString();
                InsertPhone.Text = Dr["myphonenumber"].ToString();
                InsertMail.Text = Dr["myemail"].ToString();
                InsertCity.Text = Dr["mycity"].ToString();
                InsertAddress.Text = Dr["myaddress"].ToString();
                birthDay.Text = Dr["mybirthdate"].ToString().Substring(0,2);
                birthMonth.Text = Dr["mybirthdate"].ToString().Substring(3, 2);
                birthYear.Text = Dr["mybirthdate"].ToString().Substring(6, 4);
                if (Dr["mygender"].ToString() == "male")
                    RadioButton1.Checked = true;
                else
                    RadioButton2.Checked = true;

                Con1.Close();


                //   Response.Redirect("Welcome.aspx");
                //Response.Write("Found!");

            }
            else
            {
                Response.Write("NOT found");
                Con1.Close();

            }
        }
    }
}