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
    public partial class cart : System.Web.UI.Page
    {

        private string user_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }

            Config.con = FunctionInc.connection();

            if (IsPostBack) return;

            //queary string data intialization
            //if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            //{
            //    id = Request.QueryString["id"].ToString();
            //}
            //else
            //{
            //    Response.Write("<script>alert('query string data null');</script>");
            //}


            //int value;
            ////Try converting the value to integer
            //bool isValueNumeric = int.TryParse(id, out value);
            //if (!String.IsNullOrEmpty(id) && /*here*/isValueNumeric && Convert.ToInt64(id) > 0)
            //{
            // to display data in repeter

                user_id = Session["USER_ID"].ToString();

                Config.q = "select cart.*,product.*,product.id as product_id from cart,product where cart.product_id=product.id and cart.user_id='" + user_id.ToString() + "' order by cart.id desc";
                Config.da = new SqlDataAdapter(Config.q, Config.con);

                Config.dt = new DataTable();

                Config.da.Fill(Config.dt);
                int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                if (count > 0)
                {
                    cart_product_repeter.DataSource = Config.dt;
                    cart_product_repeter.DataBind();
                }
                else
                {
                    //single_product.Style.Add("display", "none");
                    //single_product_not_found.Style.Add("display", "inline-block");
                    //single_product_not_found.Text = "Data Not Found.";
                    //Response.Write("<script>alert('this id kind of dat');</script>");
                    //Response.Redirect("index.aspx");
                }
            //}
            //else
            //{
            //    //Response.Write("<script>alert('this id kind of dat');</script>");
            //    //Response.Redirect("product.aspx");
            //}
        }
    }
}