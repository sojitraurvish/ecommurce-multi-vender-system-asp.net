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
    public partial class my_order_details : System.Web.UI.Page
    {
        //queary string data
        private string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }

            Config.con = FunctionInc.connection();

            if (IsPostBack) return;

            //queary string data intialization
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Request.QueryString["id"].ToString();
            }
            else
            {
                Response.Write("<script>alert('query string data null');</script>");
            }

            Config.q = "select order_master.*,product.*,order_detail.*,order_detail.qty as 'myqty' from order_detail,product,order_master where order_master.id=order_detail.order_id and order_detail.product_id=product.id and order_detail.order_id='" + id+"' and order_master.user_id='" + Session["USER_ID"].ToString() + "'";
            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (count > 0)
            {
                my_all_orders.DataSource = Config.dt;
                my_all_orders.DataBind();
                
            }
            else
            {
                //single_product.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                //Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }

            
            //for displaing full total and coupon value 
            Config.q = "select order_master.* from order_master where id='" + id + "' and user_id='" + Session["USER_ID"].ToString() + "'";
            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int t = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (t > 0)
            {
                my_all_orders_total_price.DataSource = Config.dt;
                my_all_orders_total_price.DataBind();

                //my_all_orders.DataSource = Config.dt;
                //my_all_orders.DataBind();
            }
            else
            {
                
                //single_product.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                //Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }
        }

        protected string coupon_value()
        {
            Config.q = "select order_master.* from order_master where id='" + id + "' and user_id='" + Session["USER_ID"].ToString() + "'";
            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (count > 0)
            {
                if(!string.IsNullOrEmpty(Config.dt.Rows[0][14].ToString()))
                {
                    return "True";
                }
                else
                {
                    return "False";
                }
                
                //my_all_orders.DataSource = Config.dt;
                //my_all_orders.DataBind();
            }
            else
            {
                return "False";
                //single_product.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                //Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }
            
        }
    }
}