using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineecom.admin
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ADMIN_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }
            //login page 
            Session["ADMIN_ID"] = "";
            Session["ADMIN_LOGIN"] = "";
            Session["ADMIN_USERNAME"] = "";
            Session["ADMIN_ROLE"] = "";
            Response.Redirect("login.aspx");
            
        }
    }
}