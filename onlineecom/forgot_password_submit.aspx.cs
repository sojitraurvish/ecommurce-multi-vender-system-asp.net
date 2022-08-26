using onlineecom.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace onlineecom
{
    public partial class forgot_password_submit : System.Web.UI.Page
    {
        private string email;
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

            email = Request["email"];

            string q = "select * from users where email='" + email.ToString() + "'";
            Config.da = new SqlDataAdapter(q, Config.con);
            Config.dt = new DataTable();
            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());

            if (count > 0)
            {
                
                string password=Config.dt.Rows[0][2].ToString();
                string body = "Your Password is:<strong>" + password+ "</strong>";
                string subject = "Forgot Password";
                Boolean flag=FunctionInc.sent_mail(email.ToString(),subject,body,false);
                if (flag)
                {
                    Response.Write("Please check your email id for password");
                }
                else
                {
                    Response.Write("error");
                }
            }
            else
            {
                Response.Write("Email id not register with us");
            }
        }
    }
}