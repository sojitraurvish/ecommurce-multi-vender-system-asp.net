using onlineecom.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace onlineecom
{
    public partial class customer : System.Web.UI.MasterPage
    {
        private string user_id;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Session["USER_LOGIN"]==null)
            {
                btn_login_register.Style.Add("display", "inline-block");
            }
            else
            {
                my_account.Style.Add("display", "inline");
                //btn_logout.Style.Add("display", "inline");
                //btn_my_order.Style.Add("display", "inline");
                //logout_my_order_line.Style.Add("display", "inline");
                logout_my_order.Attributes.Add("class", "");
            }

            Config.con = FunctionInc.connection();

            if (IsPostBack) return;
           
            //for meta title and description
            //string rest = string.Join(" ", arr.Skip(1));
            string fullPageName = Path.GetFileName(Request.Path);
            var arr = fullPageName.Split('.');
            string pageName= arr[0].ToString();
            if (pageName=="product")
            {
                Config.q = "select * from product where id='"+Request.QueryString["id"].ToString()+"'";

                Config.da = new SqlDataAdapter(Config.q, Config.con);

                Config.dt = new DataTable();

                Config.da.Fill(Config.dt);
                int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                if (count > 0)
                {
                    foreach (DataRow dr in Config.dt.Rows)
                    {
                        title.InnerText = dr["meta_title"].ToString();
                        meta_description.Attributes.Add("content",dr["meta_desc"].ToString());
                        meta_keywords.Attributes.Add("content",dr["meta_keyword"].ToString());
                    }


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
            if(pageName=="categories")
            {
                account.Style.Add("margin-top","40px");
                
            }
            if(pageName=="contact")
            {
                title.InnerText = "Contact Us";
            }
            //if (pageName == "checkout")
            //{
            //    form1.Style.Add("display", "none");

            //}


            if (!this.IsPostBack)
            {
                
                // to display data in web_categories_repeter and mobile_categories_repeter
                Config.q = "select * from categories where status='True' and deleted_at IS NULL order by categories asc";
                Config.da = new SqlDataAdapter(Config.q, Config.con);

                Config.dt = new DataTable();

                Config.da.Fill(Config.dt);

                web_categories_repeter.DataSource = Config.dt;
                mobile_categories_repeter.DataSource = Config.dt;
                web_categories_repeter.DataBind();
                mobile_categories_repeter.DataBind();
                
                
                
            }

            

            

            //to show product into add to cart
            if (Session["USER_ID"] == null) 
            {
                cart_qty.Text = "0";
                wishlist_qty.Text = "0";
            }
            else
            {
                user_id = Session["USER_ID"].ToString();

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
               
                cart_qty.Text = totalproduct.ToString();

                //to return total product into wishlist
                int wishlist_totalproduct;
                string q = "select Count(DISTINCT product_id) from wishlist where user_id='" + user_id + "'";

                Config.da = new SqlDataAdapter(q, Config.con);

                Config.dt = new DataTable();

                Config.da.Fill(Config.dt);

                int c = Convert.ToInt32(Config.dt.Rows[0][0].ToString());
                if (c > 0)
                {
                    wishlist_totalproduct = Convert.ToInt32(c);
                }
                else
                {
                    wishlist_totalproduct = 0;
                }

                wishlist_qty.Text = wishlist_totalproduct.ToString();
            }
            
        }
        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            //// to display data in web_sub_categories_repeter and mobile_categories_repeter
            //string id = (e.Item.FindControl("id") as HiddenField).Value;
            System.Web.UI.HtmlControls.HtmlInputHidden f_categories_id = (System.Web.UI.HtmlControls.HtmlInputHidden)e.Item.FindControl("categories_id");
            string categories_id = f_categories_id.Value;

            //TextBox c_id = e.Item.FindControl("c_id") as TextBox;
            Config.q = "select *,sub_categories.id as sid from categories,sub_categories where categories.id=sub_categories.categories_id and categories.status='True' and categories.deleted_at IS NULL and sub_categories.status='True' and sub_categories.deleted_at IS NULL and sub_categories.categories_id='" + categories_id + "' order by sub_categories asc";
            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            Repeater rptOrders = e.Item.FindControl("web_sub_categories_repeter") as Repeater;
            rptOrders.DataSource = Config.dt;
            rptOrders.DataBind();

        }
        //protected void OnItemDataBoundMobile(object sender, RepeaterItemEventArgs e)
        //{
            
        //        // to display data in web_sub_categories_repeter and mobile_categories_repeter
        //        string id = (e.Item.FindControl("id") as HiddenField).Value;
                
        //        Config.q = "select * from sub_categories where status='True' and categories_id='" + id+ "' order by sub_categories asc";
        //        Config.da = new SqlDataAdapter(Config.q, Config.con);

        //        Config.dt = new DataTable();

        //        Config.da.Fill(Config.dt);
        //        Repeater rptOrders = e.Item.FindControl("mobile_sub_categories_repeter") as Repeater;
        //        rptOrders.DataSource = Config.dt;
        //        rptOrders.DataBind();
            
        //}
    }
}