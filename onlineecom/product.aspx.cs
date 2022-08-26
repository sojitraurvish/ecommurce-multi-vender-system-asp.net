using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using onlineecom.admin;

namespace onlineecom
{
    public partial class product : System.Web.UI.Page
    {
        //product id
        private string id;
        private string availability = "yes";
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["USER_LOGIN"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}

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


            


            int value;
            //Try converting the value to integer
            bool isValueNumeric = int.TryParse(id, out value);

            //to fill data in repeter
            if (!String.IsNullOrEmpty(id) && /*here*/isValueNumeric && Convert.ToInt64(id) > 0)
            {
                // to display data in repeter
                Config.q = "select product.*,categories.*,categories.id as cid from product,sub_categories,categories where product.status = 'True' and product.deleted_at IS NULL and categories.status = 'True' and categories.deleted_at IS NULL and sub_categories.status = 'True' and sub_categories.deleted_at IS NULL and product.id = '"+id+"' and categories.id=sub_categories.categories_id and sub_categories.id=product.sub_categories_id;";

                Config.da = new SqlDataAdapter(Config.q, Config.con);

                Config.dt = new DataTable();

                Config.da.Fill(Config.dt);
                int t = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                if (t > 0)
                {
                    foreach (DataRow dr in Config.dt.Rows)
                    {
                        int qty = Convert.ToInt32(dr["qty"].ToString());
                        int productID = Convert.ToInt32(dr["id"].ToString());
                        int soldQty = FunctionInc.productSoldQtyByProductId(productID);
                        if (qty > soldQty)
                        {
                            favailability.Text = "In Stock";
                        }
                        else
                        {
                            favailability.Text = "Not In Stock";
                            availability = null;
                        }
                    }

                    //for product
                    product_repeter.DataSource = Config.dt;
                    product_repeter2.DataSource = Config.dt;
                    product_repeter.DataBind();
                    product_repeter2.DataBind();
                }
                else
                {

                    single_product.Style.Add("display", "none");
                    single_product_not_found.Style.Add("display", "inline-block");
                    single_product_not_found.Text = "Data Not Found.";
                    //Response.Write("<script>alert('this id kind of dat');</script>");
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                //Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("product.aspx");
            }


            // to display data in repeter
            Config.q = "select review.*,review.created_at as 'date',users.*,users.name as 'username',ratting.name as 'ratting_name' from review,users,ratting where review.user_id=users.id and review.ratting=ratting.id and review.status='True' and review.product_id='" + id + "';";

            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (count > 0)
            {

                //for product
                review_repeater.DataSource = Config.dt;
                review_repeater.DataBind();
            }
            else
            {

                //review_display.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                ////Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }

            Config.q = "select * from product where id='" + id + "'";
            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int cunt = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (cunt > 0)
            {
                int sub_categories_id = Convert.ToInt32(Config.dt.Rows[0][2].ToString());
                string q = "select * from product where sub_categories_id='" + sub_categories_id + "'";
                SqlDataAdapter da = new SqlDataAdapter(q, Config.con);

                DataTable dt = new DataTable();

                da.Fill(dt);
                int cnt = Convert.ToInt32(dt.Rows.Count.ToString());
                if (cnt > 0)
                {
                    categories_repeter.DataSource = dt;
                    categories_repeter.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('sub_categories in categories data not found');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('sub_categories in categories data not found');</script>");
            }
        }

        public string availability_of_product()
        {
            return availability;
        }
        
    }
}