using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineecom.admin
{
    public partial class sub_categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Config.con = FunctionInc.connection();
            if (Session["ADMIN_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }

            // to display data in repeter
            Config.q = "select categories.categories,sub_categories.* from categories,sub_categories where categories.id=sub_categories.categories_id and categories.status='True' and categories.deleted_at IS NULL and sub_categories.deleted_at IS NULL order by id desc";
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

                // to active and deactive categories
                if (type.Equals("status"))
                {
                    string opration = Request.QueryString["opration"].ToString();
                    string id = Request.QueryString["id"].ToString();
                    string status;
                    if (opration == "active")
                    {
                        status = "True";
                    }
                    else
                    {
                        status = "False";
                    }
                    string update_status_sql = "update sub_categories set status='" + status.ToString() + "' where id='" + id.ToString() + "'";

                    Config.cmd = new SqlCommand(update_status_sql, Config.con);

                    var i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {
                        Response.Write("<script>alert('updated successfully');</script>");
                        Response.Redirect("sub_categories.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Not updated successfully');<script>");
                    }
                }

                // to delete categories
                if (type == "delete")
                {

                    string id = Request.QueryString["id"].ToString();
                    DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                    string delete_sql = "update sub_categories set deleted_at='"+dateTime+"' where id='" + id + "'";
                    Config.cmd = new SqlCommand(delete_sql, Config.con);

                    var i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Deleted successfully');</script>");
                        Response.Redirect("sub_categories.aspx");
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