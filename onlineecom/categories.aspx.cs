using onlineecom.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace onlineecom
{
    public partial class categories : System.Web.UI.Page
    {
        //category id
        private string id;
        private string sub_categories;
        private string sort_order;
        private string price_high_selected, price_low_selected, new_selected, old_selected;
        public string Price_high_selected { get { return price_high_selected; } }
        public string Price_low_selected { get { return price_low_selected; } }
        public string New_selected { get { return new_selected; } }
        public string Old_selected { get { return old_selected; } }
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
                //Response.Write("<script>alert('query string data null');</script>");
            }
            
            //queary string data for sub categories intialization
            if (!String.IsNullOrEmpty(Request.QueryString["sub_categories"]))
            {
                sub_categories = Request.QueryString["sub_categories"].ToString();
                Config.q = "select * from sub_categories where id='"+sub_categories+"'";
                Config.da = new SqlDataAdapter(Config.q, Config.con);

                Config.dt = new DataTable();

                Config.da.Fill(Config.dt);
                int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                if (count > 0)
                {
                    id = Config.dt.Rows[0][1].ToString();
                }
                else
                {
                    //Response.Write("<script>alert('sub_categories in categories data not found');</script>");
                }
            }
            else
            {
                //Response.Write("<script>alert('query string data null for sub categories');</script>");
            }

            //if sort_product_dropdown id found

            

            if (!String.IsNullOrEmpty(Request.QueryString["sort"]))
            {
                string sort = Request.QueryString["sort"].ToString();
                if(sort== "price_high")
                {
                    sort_order = "order by product.price desc";
                    price_high_selected = "selected";

                } 
                if(sort== "price_low")
                {
                    sort_order = "order by product.price asc";
                    price_low_selected = "selected";
                } 
                if(sort== "new")
                {
                    sort_order = "order by product.id desc";
                    new_selected = "selected";
                } 
                if(sort== "old")
                {
                    sort_order = "order by product.id asc";
                    old_selected = "selected";
                }
            }

            int value;
            //Try converting the value to integer
            bool isValueNumeric = int.TryParse(id, out value);


            int val;
            //Try converting the value to integer
            bool isValueNumericOrNot = int.TryParse(id, out val);
            string local_sub_categories = "";
            //for sub categories
            if (!string.IsNullOrEmpty(sub_categories))
            {
                
                if (!String.IsNullOrEmpty(sub_categories) && /*here*/isValueNumericOrNot && Convert.ToInt64(sub_categories) > 0)
                {


                    // to display data in repeter

                    if (!String.IsNullOrEmpty(sort_order))
                    {
                        Config.q = "select product.*,categories.*,categories.id as categories_id from product,sub_categories,categories where categories.status='True' and categories.deleted_at IS NULL and sub_categories.status='True' and sub_categories.deleted_at IS NULL and product.status='True' and product.deleted_at IS NULL and categories.id = sub_categories.categories_id and product.sub_categories_id = sub_categories.id and sub_categories.categories_id='" + id.ToString() + "' and product.sub_categories_id='" + sub_categories.ToString() + "' " + sort_order + "";
                    }
                    else
                    {
                        Config.q = "select product.*,categories.*,categories.id as categories_id from product,sub_categories,categories where categories.status='True' and categories.deleted_at IS NULL and sub_categories.status='True' and sub_categories.deleted_at IS NULL and product.status='True' and product.deleted_at IS NULL and categories.id = sub_categories.categories_id and product.sub_categories_id = sub_categories.id and sub_categories.categories_id='" + id.ToString() + "' and product.sub_categories_id='" + sub_categories.ToString() + "' order by product.id desc";

                    }
                    Config.da = new SqlDataAdapter(Config.q, Config.con);

                    Config.dt = new DataTable();

                    Config.da.Fill(Config.dt);
                    int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                    if (count > 0)
                    {
                        categories_repeter.DataSource = Config.dt;
                        categories_repeter.DataBind();

                    }
                    else
                    {
                        single_product.Style.Add("display", "none");
                        single_product_not_found.Style.Add("display", "inline-block");
                        single_product_not_found.Text = "Data Not Found.";
                        //Response.Write("<script>alert('this id kind of dat');</script>");
                        //Response.Redirect("index.aspx");
                    }
                }
                else
                {
                    //Response.Write("<script>alert('this id kind of dat');</script>");
                    //Response.Redirect("product.aspx");
                }
            }
            else
            {
                
                if (!String.IsNullOrEmpty(id) && /*here*/isValueNumeric && Convert.ToInt64(id) > 0)
                {


                    // to display data in repeter

                    if (!String.IsNullOrEmpty(sort_order))
                    {
                        Config.q = "select product.*,categories.*,categories.id as categories_id from product,sub_categories,categories where categories.status='True' and categories.deleted_at IS NULL and sub_categories.status='True' and sub_categories.deleted_at IS NULL and product.status='True' and product.deleted_at IS NULL and product.sub_categories_id=sub_categories.id and categories.id=sub_categories.categories_id and product.categories_id='" + id.ToString() + "' " + sort_order + "";
                    }
                    else
                    {
                        Config.q = "select product.*,categories.*,categories.id as categories_id from product,sub_categories,categories where categories.status='True' and categories.deleted_at IS NULL and sub_categories.status='True' and sub_categories.deleted_at IS NULL and product.status='True' and product.deleted_at IS NULL and product.sub_categories_id=sub_categories.id and categories.id=sub_categories.categories_id and product.categories_id='" + id.ToString() + "' order by product.id desc";

                    }
                    Config.da = new SqlDataAdapter(Config.q, Config.con);

                    Config.dt = new DataTable();

                    Config.da.Fill(Config.dt);
                    int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                    if (count > 0)
                    {
                        categories_repeter.DataSource = Config.dt;
                        categories_repeter.DataBind();

                    }
                    else
                    {
                        single_product.Style.Add("display", "none");
                        single_product_not_found.Style.Add("display", "inline-block");
                        single_product_not_found.Text = "Data Not Found.";
                        //Response.Write("<script>alert('this id kind of dat');</script>");
                        //Response.Redirect("index.aspx");
                    }
                }
                else
                {
                    //Response.Write("<script>alert('this id kind of dat');</script>");
                    //Response.Redirect("product.aspx");
                }
            }    

            

            

            //for sort_product_dropdown

            //Try converting the value to integer

            if (!String.IsNullOrEmpty(id) && /*here*/isValueNumeric && Convert.ToInt64(id) > 0)
            {
                // to display data in repeter

                Config.q = "select categories.id as categories_id from categories where id='" + id.ToString() + "'";
                Config.da = new SqlDataAdapter(Config.q, Config.con);

                Config.dt = new DataTable();

                Config.da.Fill(Config.dt);
                int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                if (count > 0)
                {
                    sort_product_dropdown.DataSource = Config.dt;
                    sort_product_dropdown.DataBind();

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
        }
    }
}