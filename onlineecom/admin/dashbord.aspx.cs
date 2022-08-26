using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using onlineecom.admin;

namespace onlineecom.admin
{
    public partial class dashbord : System.Web.UI.Page
    {
        int data;
        protected void Page_Load(object sender, EventArgs e)
        {
            ftotalUsers.Text = totalUsers().ToString();
            ftotalOrders.Text= totalOrders().ToString();
            ftotalVendors.Text = totalVendors().ToString();
            ftotalSales.Text = totalSales().ToString();
            ftotalProducts.Text = totalProducts().ToString();
            ftotalCategories.Text = totalCategories().ToString();
            ftotalSubCategories.Text = totalSubCategories().ToString();


            
        }

        public int totalCategories()
        {
            Config.q = "select Count(*) as totalusers from categories where categories.status = 'True' and categories.deleted_at IS NULL ";

            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());

            if (count > 0)
            {
                foreach (DataRow dr in Config.dt.Rows)
                {
                    data = Convert.ToInt32(dr["totalusers"].ToString());
                }
                //for product

            }
            else
            {

                //review_display.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                ////Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }
            return data;
        }public int totalSubCategories()
        {
            Config.q = "select Count(*) as totalusers from sub_categories, categories where categories.status = 'True' and categories.deleted_at IS NULL and sub_categories.status = 'True' and sub_categories.deleted_at IS NULL and categories.id = sub_categories.categories_id ";

            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());

            if (count > 0)
            {
                foreach (DataRow dr in Config.dt.Rows)
                {
                    data = Convert.ToInt32(dr["totalusers"].ToString());
                }
                //for product

            }
            else
            {

                //review_display.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                ////Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }
            return data;
        }
        
        public int totalUsers()
        {
            Config.q = "select count(*) as totalusers from users where deleted_at IS NULL;";

            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());

            if (count > 0)
            {
                foreach (DataRow dr in Config.dt.Rows)
                {
                    data = Convert.ToInt32(dr["totalusers"].ToString());
                }
                //for product

            }
            else
            {

                //review_display.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                ////Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }
            return data;
        }public int totalOrders()
        {
            Config.q = "select COUNT(*) as totalUsers from order_master,order_status where order_master.order_status=order_status.id and order_status.id!='4' and order_status.id!='3';";

            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());

            if (count > 0)
            {
                foreach (DataRow dr in Config.dt.Rows)
                {
                    data = Convert.ToInt32(dr["totalUsers"].ToString());
                }
                //for product

            }
            else
            {

                //review_display.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                ////Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }
            return data;
        }public int totalVendors()
        {
            Config.q = "select count(*) as admin_users from admin_users where deleted_at IS NULL and role='1';";

            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());

            if (count > 0)
            {
                foreach (DataRow dr in Config.dt.Rows)
                {
                    data = Convert.ToInt32(dr["admin_users"].ToString());
                }
                //for product

            }
            else
            {

                //review_display.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                ////Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }
            return data;
        }public int totalSales()
        {
            Config.q = "select COUNT(*) as totalUsers from order_master,order_status where order_master.order_status=order_status.id and order_status.id='4'; ";

            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());

            if (count > 0)
            {
                foreach (DataRow dr in Config.dt.Rows)
                {
                    data = Convert.ToInt32(dr["totalUsers"].ToString());
                }
                //for product

            }
            else
            {

                //review_display.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                ////Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }
            return data;
        }
        public int totalProducts()
        {
            Config.q = "select Count(*) as totalusers from product, sub_categories, categories where categories.status = 'True' and categories.deleted_at IS NULL and sub_categories.status = 'True' and sub_categories.deleted_at IS NULL and product.status = 'True' and product.deleted_at IS NULL and categories.id = sub_categories.categories_id and product.sub_categories_id = sub_categories.id;";

            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());

            if (count > 0)
            {
                foreach (DataRow dr in Config.dt.Rows)
                {
                    data = Convert.ToInt32(dr["totalusers"].ToString());
                }
                //for product

            }
            else
            {

                //review_display.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                ////Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }
            return data;
        }

        
    }
}