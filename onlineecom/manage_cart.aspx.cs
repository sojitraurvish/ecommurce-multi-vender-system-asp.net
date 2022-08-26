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
    public partial class manage_cart : System.Web.UI.Page
    {
        //product id
        private string user_id;
        private string product_id;
        private string qty;
        private string type;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["USER_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }

            Config.con = FunctionInc.connection();

            if (IsPostBack) return;

            //queary string data intialization
            if (!String.IsNullOrEmpty(Request["product_id"]) && !String.IsNullOrEmpty(Request["qty"]) && !String.IsNullOrEmpty(Request["type"]))
            {
                user_id = Session["USER_ID"].ToString();
                product_id = Request["product_id"].ToString();
                qty = Request["qty"].ToString();
                type = Request["type"].ToString();
            }
            else
            {
                Response.Write("<script>alert('query string data null');</script>");
            }

            int productSoldQtyByProductId = FunctionInc.productSoldQtyByProductId(Convert.ToInt32(product_id));
            int productTotalQtyByProductId = FunctionInc.productTotalQtyByProductId(Convert.ToInt32(product_id));

            int pending_qty = productTotalQtyByProductId - productSoldQtyByProductId;

            if (Convert.ToInt32(qty) <= 0)
            {
                Response.Write("qty_zero");
            }
            else
            {
                if (Convert.ToInt32(qty) > pending_qty)
                {
                    Response.Write("not_avaliable");
                }
                else
                {
                    //to add product
                    if (type == "add")
                    {

                        //Cart_function.addProduct(user_id,product_id, qty);
                        Config.q = "select * from cart where user_id='" + user_id + "' and product_id='" + product_id + "'";

                        Config.da = new SqlDataAdapter(Config.q, Config.con);

                        Config.dt = new DataTable();

                        Config.da.Fill(Config.dt);

                        int c = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                        if (c > 0)
                        {
                            Response.Write("<script>alert('Product Already Added Into Cart!');</script>");
                            //updateProduct(user_id, product_id, qty);
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

                    //Remove Product---------------------------------------------------------------------
                    if (type == "remove")
                    {
                        //Cart_function.removeProduct(user_id,product_id);
                        //to delete product into cart
                        Config.q = "delete from cart where user_id='" + user_id + "' and product_id='" + product_id + "'";
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

                    //Update Product---------------------------------------------------------------------
                    if (type == "update")
                    {

                        //Cart_function.updateProduct(user_id, product_id,qty);
                        //to add product into cart
                        DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                        Config.q = "update cart set qty='" + qty + "' where user_id='" + user_id + "' and product_id='" + product_id + "'";
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

                    //Remove Product---------------------------------------------------------------------
                    if (type == "delete")
                    {
                        //Cart_function.deleteProduct(user_id);
                        //to delete product into cart
                        Config.q = "delete from cart where user_id='" + user_id + "'";
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

                    //to return total product into cart
                    int totalproduct;
                    string sql = "select Count(DISTINCT product_id) from cart where user_id='" + user_id + "'";

                    Config.da = new SqlDataAdapter(sql, Config.con);

                    Config.dt = new DataTable();

                    Config.da.Fill(Config.dt);

                    int count = Convert.ToInt32(Config.dt.Rows[0][0].ToString());
                    if (count > 0)
                    {
                        totalproduct = Convert.ToInt32(count);
                    }
                    else
                    {
                        totalproduct = 0;
                    }
                    Response.Write(totalproduct);
                }
            }
        }
    }
}