using onlineecom.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace onlineecom
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["USER_LOGIN"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}

            Config.con = FunctionInc.connection();


            // to display data in repeter
            Config.q = "select * from banner where status='True' order by order_by asc";

            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (count > 0)
            {
                
                //for product
                banner.DataSource = Config.dt;
                banner.DataBind();
            }
            else
            {

                //single_product.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                ////Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }


            // to display data in repeter
            Config.q = "select TOP(8)*,product.id as pid from categories,sub_categories,product where categories.status='True' and categories.deleted_at IS NULL and sub_categories.status='True' and sub_categories.deleted_at IS NULL and product.status='True' and product.deleted_at IS NULL and product.sub_categories_id=sub_categories.id and categories.id=sub_categories.categories_id order by product.id desc";
            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int t = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (t > 0)
            {


                new_arrivals_repeter.DataSource = Config.dt;
                new_arrivals_repeter.DataBind();
                
            }
            else
            {

                //single_product.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                ////Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }

            // to display data in best_seller_repeter
            Config.q = "select product.*,categories.* from product,sub_categories,categories where categories.status='True' and categories.deleted_at IS NULL and sub_categories.status='True' and sub_categories.deleted_at IS NULL and product.status='True' and product.deleted_at IS NULL and product.sub_categories_id=sub_categories.id and categories.id=sub_categories.categories_id and product.best_seller='1' order by product.id desc";
            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int c = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (c > 0)
            {


                best_seller_repeter.DataSource = Config.dt;
                best_seller_repeter.DataBind();

            }
            else
            {

                //single_product.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                ////Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }

        }
    }
}