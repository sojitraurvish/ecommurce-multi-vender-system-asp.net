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
    public partial class product : System.Web.UI.Page
    {
        string gcondition = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Config.con = FunctionInc.connection();
            //if (Session["ADMIN_LOGIN"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}

            // to display data in repeter
            string condition = "";
            if (Convert.ToInt32(Session["ADMIN_ROLE"])==1)
            {
                gcondition = "and added_by = '" + Session["ADMIN_ID"] + "'";
                condition ="and product.added_by = '"+Session["ADMIN_ID"] +"'";
            }
            Config.q = "select categories.*,categories.id as cid,categories.status as cstatus,product.*,product.id as pid,product.status as pstatus from product inner join sub_categories on product.sub_categories_id=sub_categories.id inner join categories on product.categories_id=categories.id " + condition+ " where categories.status='True' and categories.deleted_at IS NULL and sub_categories.status='True' and sub_categories.deleted_at IS NULL and product.deleted_at IS NULL order by product.id desc;";
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
                    string update_status_sql = "update product set status='" + status.ToString() + "' where id='" + id.ToString() + "' "+gcondition+"";

                    Config.cmd = new SqlCommand(update_status_sql, Config.con);

                    var i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {
                        Response.Write("<script>alert('updated successfully');</script>");
                        Response.Redirect("product.aspx");
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
                    string delete_sql = "update product set product.deleted_at='"+dateTime+"' where id='" + id + "' "+ gcondition + "";
                    Config.cmd = new SqlCommand(delete_sql, Config.con);

                    var i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Deleted successfully');</script>");
                        Response.Redirect("product.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Not deleted successfully');</script>");
                    }
                }

            }
        }
        public int pending_qty(int product_id)
        {
            int productSoldQtyByProductId = FunctionInc.productSoldQtyByProductId(Convert.ToInt32(product_id));
            int productTotalQtyByProductId = FunctionInc.productTotalQtyByProductId(Convert.ToInt32(product_id));

            int pending_qty = productTotalQtyByProductId - productSoldQtyByProductId;
            return pending_qty;
        }
    }
        
    
}