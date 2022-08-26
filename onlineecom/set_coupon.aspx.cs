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
    public partial class set_coupon : System.Web.UI.Page
    {
        private string coupon_str;
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

            
            if (Session["COUPON_ID"] != null)
            {
                
                Session.Remove("COUPON_ID");
                Session.Remove("FINAL_PRICE");
                Session.Remove("COUPON_VALUE");
                Session.Remove("COUPON_CODE");
            }

            coupon_str = Request["coupon_str"];


            string sql = "select * from coupon_master where coupon_code='" + coupon_str + "' and status='True'";
            Config.da = new SqlDataAdapter(sql, Config.con);
            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (count > 0)
            {
                //fname.Text = Config.dt.Rows[0][1].ToString();
                int coupon_value = Convert.ToInt32(Config.dt.Rows[0][2].ToString());
                string coupon_type = Config.dt.Rows[0][3].ToString();
                int cart_min_value = Convert.ToInt32(Config.dt.Rows[0][4].ToString());
                //for total price
                Config.q = "select cart.*,product.*,product.id as product_id from cart,product where cart.product_id=product.id and cart.user_id='" + Session["USER_ID"].ToString() + "' order by cart.id desc";
                Config.da = new SqlDataAdapter(Config.q, Config.con);
                Config.dt = new DataTable();
                Config.da.Fill(Config.dt);
                int cart_total2 = 0;
                foreach (DataRow dr in Config.dt.Rows)
                {
                    cart_total2 += Convert.ToInt32(dr["price"]) * Convert.ToInt32(dr["qty"]);
                }
                decimal cart_total_price = Convert.ToDecimal(cart_total2);
                //Response.Write(total_price);
                if(cart_min_value>cart_total_price)
                {
                    Response.Write("less-total_" + cart_min_value);
                }
                else
                {
                    decimal final_price = 0;
                    if(coupon_type=="0")
                    {
                        final_price = cart_total_price - coupon_value;
                        
                    }
                    else
                    {
                        final_price = cart_total_price-((cart_total_price * coupon_value) / 100);
                    }
                    decimal dd = cart_total_price - final_price;
                    Session["COUPON_ID"] = Config.dt.Rows[0][0].ToString();
                    Session["FINAL_PRICE"] = final_price;
                    Session["COUPON_VALUE"] = dd;
                    Session["COUPON_CODE"] = coupon_str;
                    Response.Write(final_price+"_"+dd);
                }

            }
            else
            {
                Response.Write("not_found");
                //Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("product.aspx");
            }

        }
    }
}