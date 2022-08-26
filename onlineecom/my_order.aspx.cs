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
    public partial class my_order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }

            Config.con = FunctionInc.connection();

            if (IsPostBack) return;

            Config.q = "select order_master.*,order_status.* from order_master,order_status where order_master.order_status=order_status.id and user_id='" + Session["USER_ID"].ToString()+"'";
            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (count > 0)
            {
                my_all_orders.DataSource = Config.dt;
                my_all_orders.DataBind();
            }
            else
            {
                //single_product.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                //Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }
        }
    }
}