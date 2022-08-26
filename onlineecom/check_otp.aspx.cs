using onlineecom.admin;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineecom
{
    public partial class check_otp : System.Web.UI.Page
    {
        private string otp;
        private string type;
        protected void Page_Load(object sender, EventArgs e)
        {
            ////queary string data intialization
            //if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            //{
            //    id = Request.QueryString["id"].ToString();
            //}
            //else
            //{
            //    Response.Write("<script>alert('query string data null');</script>");
            //}

            Config.con = FunctionInc.connection();
            ////if (session["admin_login"] == null)
            ////{
            ////    response.redirect("login.aspx");
            ////}

            //if (IsPostBack) return;

            type = Request["type"];

            if (type == "email")
            {
                otp = Request["otp"];
                string storedotp = Session["otp"].ToString();

                if (otp == storedotp)
                {
                    Response.Write("done");
                }
                else
                {
                    Response.Write("no");
                }
            }
        }
    }
}