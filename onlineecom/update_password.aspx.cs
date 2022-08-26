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
    public partial class update_password : System.Web.UI.Page
    {
        int uid;
        string current_password;
        string new_password;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("hellow");
            Config.con = FunctionInc.connection();
            ////if (session["admin_login"] == null)
            ////{
            ////    response.redirect("login.aspx");
            ////}

            if (IsPostBack) return;

            uid = Convert.ToInt32(Session["USER_ID"]);
            current_password = Request["current_password"];
            new_password = Request["new_password"];

            string q = "select * from users where id='" + uid + "'";
            Config.da = new SqlDataAdapter(q, Config.con);
            Config.dt = new DataTable();
            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());

            if (count > 0)
            {
                foreach (DataRow dr in Config.dt.Rows)
                {
                    if (dr["password"].ToString() != current_password)
                    {
                        Response.Write("Please Enter Your Current Valid Password");
                    }
                    else
                    {
                        DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                        string sql = "update users set password='" + new_password + "',updated_at='"+dateTime+"' where id='" + uid + "'";
                        Config.cmd = new SqlCommand(sql, Config.con);

                        int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                        if (i > 0)
                        {
                            Response.Write("Password Updated");
                            //Response.Write("<script>alert('Data inserted Successfully');</script>");
                            //Response.Redirect("product.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Data not inserted Successfully.');</script>");
                        }
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Data not Successfully.');</script>");
            }
        }
    }
}