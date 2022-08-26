using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineecom.admin
{
    public partial class order_master_vendor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Config.con = FunctionInc.connection();
            if (Session["ADMIN_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }

            // to display data in repeter
            Config.q = "select order_detail.*,order_master.*,product.* from order_detail,order_master,product where order_detail.order_id = order_master.id and order_detail.product_id = product.id and product.added_by = '"+ Session["ADMIN_ID"] + "' ";
            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            int count = Convert.ToInt32(Config.da.Fill(Config.dt));
            if (count > 0)
            {
                r1.DataSource = Config.dt;
                r1.DataBind();
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