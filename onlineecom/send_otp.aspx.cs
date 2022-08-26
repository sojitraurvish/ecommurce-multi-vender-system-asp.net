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
    public partial class send_otp : System.Web.UI.Page
    {
        private string email;
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
                email = Request["email"];

                
                    
                    string subject = "Forgot Password";
                    string otp = FunctionInc.GeneratePassword();
                    
                    Session["otp"] = otp;

                    Boolean flag = FunctionInc.mysent_mail(email.ToString(), subject, otp);
                    if (flag)
                    {
                        Response.Write("done");
                    }
                    else
                    {
                        Response.Write("error");
                    }
               
            }
        }
    }
}