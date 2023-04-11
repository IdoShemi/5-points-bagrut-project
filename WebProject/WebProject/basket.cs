using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace WebProject
{

    public class basket
    {
        public ArrayList _basket = new ArrayList();
        public ArrayList Basket
        {
            get { return _basket; }
            set { _basket = value; }
        }
        public void ADDitem(item i)
        {
            _basket.Add(i);
        }

        public int len()
        {
            return _basket.Count;
        }
    }


    public class item
    {
        public string seller;
        public string pName;
        public double price;
        public item(string s, string name, double price)
        {
            this.seller = s;
            this.price = price;
            this.pName = name;
        }
    }
}