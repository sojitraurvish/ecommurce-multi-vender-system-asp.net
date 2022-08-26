using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using onlineecom.admin;

namespace onlineecom
{
    public partial class send_review : System.Web.UI.Page
    {
        private int product_id;
        private string review;
        private int ratting;
        
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

            product_id = Convert.ToInt32(Request["product_id"]);
            review = Request["review"];
            ratting = Convert.ToInt32(Request["ratting"]);
            

            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
            string sql = "insert into review(product_id,user_id,ratting,review,status,created_at) values('" + product_id.ToString() + "','" + Session["USER_ID"] + "','" + ratting.ToString() + "','" + review.ToString() + "','True','" + dateTime + "')";
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