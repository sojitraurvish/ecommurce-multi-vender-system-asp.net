using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace onlineecom.admin
{
    public partial class users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Config.con = FunctionInc.connection();
            if (Session["ADMIN_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }

            // to display data in repeter
            Config.q = "select * from users where deleted_at IS NULL order by id desc";
            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            r1.DataSource = Config.dt;
            r1.DataBind();


            if (Request.QueryString["type"] != null)
            {
                //Response.Write("<script>alert('deleted successfully');</script>");
                //Response.Write("<script>alert('please select books'); window.location.href=window.location.href;</script>");
                string type = Request.QueryString["type"].ToString();

                // to delete categories
                if (type == "delete")
                {
                    DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                    string id = Request.QueryString["id"].ToString();
                    string delete_sql = "update users set deleted_at='"+dateTime+"' where id='" + id + "'";
                    Config.cmd = new SqlCommand(delete_sql, Config.con);

                    var i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Deleted successfully');</script>");
                        Response.Redirect("users.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Not deleted successfully');</script>");
                    }
                }

            }
        }
    }
}