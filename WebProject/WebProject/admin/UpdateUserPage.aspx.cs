using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.user
{
    public partial class UpdateUserPage : System.Web.UI.Page
    {
        enum Months
        {
            January = 1,    // 0
            February,   // 1
            March,      // 2
            April,      // 3
            May,        // 4
            June,       // 5
            July,        // 6
            August,       // 7
            September,       // 8
            October,       // 9
            November,       // 10
            December       // 11

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Application["userToUpdate"] = Request.QueryString["un"];
            if (!IsPostBack)
            {
                UpdateData(Application["userToUpdate"].ToString());
                OleDbConnection Con1 = new OleDbConnection();
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";


                Con1.Open();
                string sqlstring = "SELECT myday FROM datestbl WHERE myday BETWEEN 1 AND 31;";
                OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                OleDbDataReader Dr = cmd.ExecuteReader();
                days.DataSource = Dr;
                days.DataTextField = "myday";
                days.DataBind();
                Con1.Close();

                Con1.Open();
                sqlstring = "SELECT mymonth FROM datestbl WHERE NOT mymonth ='' ";
                cmd = new OleDbCommand(sqlstring, Con1);
                Dr = cmd.ExecuteReader();
                monthsDdl.DataSource = Dr;
                monthsDdl.DataTextField = "mymonth";
                monthsDdl.DataBind();
                Con1.Close();

                Con1.Open();
                sqlstring = "SELECT myyear FROM datestbl WHERE myyear BETWEEN 1920 AND 2023 ORDER BY myyear DESC;";
                cmd = new OleDbCommand(sqlstring, Con1);
                Dr = cmd.ExecuteReader();
                years.DataSource = Dr;
                years.DataTextField = "myyear";
                years.DataBind();
                Con1.Close();
            }
        }


        protected void Updatebutton(object sender, EventArgs e)
        {
            string newUserName = InsertName.Text;
            try
            {
                OleDbConnection Con1 = new OleDbConnection();
                //  OleDbCommand cmd = null;
                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";

                string gender = "";
                if (RadioButton1.Checked) gender = "male";
                else gender = "female";

                string sqlstring = $"UPDATE users SET mypassword = '{InsertPass.Text}', mybirthdate = '{days.SelectedValue + '/' + monthsDdl.SelectedValue + '/' + years.SelectedValue}" +
                    $"', myemail = '{InsertMail.Text}', mygender = '{gender}', myphonenumber = '{InsertPhone.Text}', myaddress ='{InsertAddress.Text}', " +
                    $"mycity='{InsertCity.Text}', myname='{InsertFirstName.Text}', mylastname='{InsertLastName.Text}',myusername ='{newUserName}' WHERE myusername ='{Application["userToUpdate"].ToString()}'";
                Application["userToUpdate"] = newUserName;
                Response.Write(sqlstring);
                Con1.Open();
                OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                int y = 0;
                y = cmd.ExecuteNonQuery();
                Con1.Close();


                

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            Response.Redirect("/admin/ShowUsersPage.aspx");
        }

        protected void UpdateData(string user)
        {
            OleDbConnection Con1 = new OleDbConnection();
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\..\\database.accdb";
            Con1.Open();
            string sqlstring = "SELECT * FROM users WHERE myusername = '" + Application["userToUpdate"].ToString() + "';";

            OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
            OleDbDataReader Dr = cmd.ExecuteReader();
            Dr.Read();


            if (Dr.HasRows)
            {
                InsertName.Text = Application["userToUpdate"].ToString();
                InsertFirstName.Text = Dr["myname"].ToString();
                InsertLastName.Text = Dr["mylastname"].ToString();
                InsertPass.Text = Dr["mypassword"].ToString();
                InsertPhone.Text = Dr["myphonenumber"].ToString();
                InsertMail.Text = Dr["myemail"].ToString();
                InsertCity.Text = Dr["mycity"].ToString();
                InsertAddress.Text = Dr["myaddress"].ToString();
                years.SelectedIndex = Math.Abs(Convert.ToInt32(Dr["mybirthdate"].ToString().Substring(6, 4)) - 2023);

                string monthName = Dr["mybirthdate"].ToString().Split('/')[1];
                Months month = (Months)System.Enum.Parse(typeof(Months), monthName);
                int monthValue = (int)month - 1;
                monthsDdl.SelectedIndex = monthValue;

                days.SelectedIndex = Math.Abs(Convert.ToInt32(Dr["mybirthdate"].ToString().Substring(0, 2)) - 1);

                //Convert.ToInt32(Dr["mybirthdate"].ToString().Substring(0, 2)) day
                //birthYear.Text = Dr["mybirthdate"].ToString().Substring(6, 4);
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