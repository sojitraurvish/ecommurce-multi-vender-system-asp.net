using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineecom
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }
            //login page
            Session.Remove("USER_LOGIN");
            Session.Remove("USER_ID");
            Session.Remove("USER_NAME");

            //for coupon code
            Session.Remove("COUPON_ID");
            Session.Remove("FINAL_PRICE");
            Session.Remove("COUPON_VALUE");
            Session.Remove("COUPON_CODE");

            Response.Redirect("login.aspx");

        }
    }
}