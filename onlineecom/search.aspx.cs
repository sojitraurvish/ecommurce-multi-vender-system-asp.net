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
    public partial class search : System.Web.UI.Page
    {
        private string str;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["USER_LOGIN"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}

            Config.con = FunctionInc.connection();

            if (IsPostBack) return;

            //queary string data intialization
            if (!String.IsNullOrEmpty(Request.QueryString["str"]))
            {
                str = Request.QueryString["str"].ToString();
            }
            else
            {
                Response.Write("<script>alert('query string data null');</script>");
            }

            
            if (!String.IsNullOrEmpty(str))
            {
                // to display data in repeter
                Config.q = "select product.*,categories.* from product,categories where categories.status='True' and product.status='True' and product.categories_id=categories.id and (product.name like '%" + str.ToString() + "%' or product.description like '%" + str.ToString() + "%') order by product.id desc";
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
    }
}