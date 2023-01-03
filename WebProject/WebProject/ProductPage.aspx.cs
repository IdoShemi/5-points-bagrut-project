using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.IO;

namespace WebProject
{
    public partial class ProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uploadImage(object sender, EventArgs e)
        {
            //// Get the file
            //HttpPostedFile file = Request.Files[0];

            //// Check if the file is an image
            //    // Read the file into a byte array
            //byte[] data;
            //using (BinaryReader br = new BinaryReader(file.InputStream))
            //{
            //    data = br.ReadBytes(file.ContentLength);
            //}

            //    // Save the image to the database

            //OleDbConnection conn = new OleDbConnection();
            //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\database.accdb";
            //conn.Open();

            //// Create a new command
            //string sqlstring = $"INSERT INTO Images (ID, ImageName, ImageData, ImageMimeType) VALUES ('5', '{file.FileName}', '{data}', '{file.ContentType}');";
            //OleDbCommand cmd = new OleDbCommand(sqlstring, conn);

            //// Add the parameters
            ////cmd.Parameters.Add("@data", OleDbType.VarBinary).Value = ;
            ////cmd.Parameters.Add("@type", OleDbType.VarChar).Value = ;

            //// Execute the command
            //int y = cmd.ExecuteNonQuery();
            //Response.Write(y);
            //conn.Close();
            string path = Server.MapPath("") + "\\images\\";
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
            int count = dir.GetFiles().Length+1;
            string[] a = FileUpload1.FileName.ToString().Split('.');
            FileUpload1.SaveAs(path+ count.ToString()+'.'+a[a.Length-1]);
        }
    }
}
