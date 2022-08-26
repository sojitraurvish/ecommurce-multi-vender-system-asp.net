using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using onlineecom.admin;

namespace onlineecom
{
    public partial class send_message : System.Web.UI.Page
    {
        private string name;
        private string email;
        private string mobile;
        private string message;
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

            if (IsPostBack) return;

            name = Request["name"];
            email = Request["email"];
            mobile = Request["mobile"];
            message = Request["message"];

            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
            string sql = "insert into contact_us(name,email,mobile,comment,created_at) values('" + name.ToString() + "','" + email.ToString() + "','" + mobile.ToString() + "','" + message.ToString() + "','" + dateTime + "')";
            Config.cmd = new SqlCommand(sql, Config.con);

            int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
            if (i > 0)
            {
                Response.Write("right");
                //Response.Write("<script>alert('Data inserted Successfully');</script>");
                //Response.Redirect("product.aspx");
            }
            else
            {
                Response.Write("wrong");
                Response.Write("<script>alert('Data not inserted Successfully.');</script>");
            }
            
        }
    }
}