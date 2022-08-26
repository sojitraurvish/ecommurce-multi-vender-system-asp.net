using onlineecom.admin;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onlineecom
{
    public class Wishlist_function
    {
        public static void addProduct(string user_id, string product_id, string qty)
        {
            string sql = "select * from cart where user_id='" + user_id + "' and product_id='" + product_id + "'";

            Config.da = new SqlDataAdapter(sql, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);

            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (count > 0)
            {
                updateProduct(user_id, product_id, qty);
            }
            else
            {
                //to add product into cart
                DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                Config.q = "insert into cart(user_id,product_id,qty,created_at) values('" + user_id + "','" + product_id + "','" + qty + "','" + dateTime + "')";
                Config.cmd = new SqlCommand(Config.q, Config.con);

                int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                if (i > 0)
                {

                    //Response.Write("<script>alert('Data inserted Successfully');</script>");
                    //Response.Redirect("product.aspx");
                }
                else
                {
                    //Response.Write("<script>alert('Data not inserted Successfully.');</script>");
                }
            }



        }


        public static void updateProduct(string user_id, string product_id, string qty)
        {
            //to add product into cart
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
            string sql = "update cart set qty='" + qty + "' where user_id='" + user_id + "' and product_id='" + product_id + "'";
            Config.cmd = new SqlCommand(sql, Config.con);

            int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
            if (i > 0)
            {

                //Response.Write("<script>alert('Data inserted Successfully');</script>");
                //Response.Redirect("product.aspx");
            }
            else
            {
                //Response.Write("<script>alert('Data not inserted Successfully.');</script>");
            }
        }

        public static void removeProduct(string user_id, string product_id)
        {
            //to delete product into cart
            string sql = "delete from cart where user_id='" + user_id + "' and product_id='" + product_id + "'";
            Config.cmd = new SqlCommand(sql, Config.con);

            int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
            if (i > 0)
            {

                //Response.Write("<script>alert('Data inserted Successfully');</script>");
                //Response.Redirect("product.aspx");
            }
            else
            {
                //Response.Write("<script>alert('Data not inserted Successfully.');</script>");
            }
        }

        public static void deleteProduct(string user_id)
        {
            //to delete product into cart
            string sql = "delete from cart where user_id='" + user_id + "'";
            Config.cmd = new SqlCommand(sql, Config.con);

            int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
            if (i > 0)
            {

                //Response.Write("<script>alert('Data inserted Successfully');</script>");
                //Response.Redirect("product.aspx");
            }
            else
            {
                //Response.Write("<script>alert('Data not inserted Successfully.');</script>");
            }
        }

        public static int totalProduct(string user_id)
        {
            string sql = "select Count(DISTINCT product_id) from cart where user_id='" + user_id + "'";

            Config.da = new SqlDataAdapter(sql, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);

            int count = Convert.ToInt32(Config.dt.Rows[0][0].ToString());
            if (count > 0)
            {
                return Convert.ToInt32(count);
            }
            else
            {
                return 0;
            }
            return Convert.ToInt32(count);
        }


    }
}