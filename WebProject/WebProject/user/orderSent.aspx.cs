using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject.user
{
    public partial class orderSent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string order_code = Request.QueryString["id"];
            l1.Text = order_code;   
        }
    }
}