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
    public partial class register_submit : System.Web.UI.Page
    {
        private string name;
        private string email;
        private string mobile;
        private string password;
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
            password = Request["password"];

            string q = "select * from users where email='" + email.ToString() + "'";
            Config.da = new SqlDataAdapter(q, Config.con);
            Config.dt = new DataTable();
            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());

            if (count > 0)
            {
                Response.Write("present");

            }
            else
            {
                DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                string sql = "insert into users(name,email,mobile,password,created_at) values('"+name.ToString()+"','"+email.ToString()+"','"+mobile.ToString()+"','"+password.ToString()+"','"+dateTime+"')";
                Config.cmd = new SqlCommand(sql, Config.con);

                int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                if (i > 0)
                {

                    //Response.Write("<script>alert('Data inserted Successfully');</script>");
                    //Response.Redirect("product.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Data not inserted Successfully.');</script>");
                }
                Response.Write("insert");
            }

            
        }
    }
}