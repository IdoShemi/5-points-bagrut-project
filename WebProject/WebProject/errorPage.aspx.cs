﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject
{
    public partial class errorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string errcode = Request.QueryString["m"];
            if (errcode == "1")
                Label1.Text = "You are not logged as a seller";
        }

        protected void moveToSignIn(object sender, EventArgs e)
        {
            Response.Redirect("SignInSeller.aspx");
        }
    }
}