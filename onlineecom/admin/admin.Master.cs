using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace onlineecom.admin
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Config.con = FunctionInc.connection();
            if (Session["ADMIN_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }

            //to display template date AND to check page role wise
            currentYear.Text=DateTime.Now.ToString("yyyy");

            //to display user's name
            string sql = "select * from admin_users where id='" + Session["ADMIN_ID"] + "'";
            Config.da = new SqlDataAdapter(sql, Config.con);
            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (count > 0)
            {
                if (Convert.ToInt32(Session["ADMIN_ROLE"]) == 1)
                {
                    //to hide manue for wender
                    categories.Style.Add("display", "none");
                    sub_categories.Style.Add("display", "none");
                    user.Style.Add("display", "none");
                    coupon.Style.Add("display", "none");
                    contact_us.Style.Add("display", "none");
                    vendor_management.Style.Add("display", "none");
                    banner.Style.Add("display", "none");
                    dashbord.Style.Add("display", "none");
                    //review.Style.Add("display", "none");
                    setting.Style.Add("display", "none");
                    vendor.Attributes.Add("href", "order_master_vendor.aspx");
                    //for meta title and description
                    //string rest = string.Join(" ", arr.Skip(1));
                    string fullPageName = Path.GetFileName(Request.Path);
                    var arr = fullPageName.Split('.');
                    string pageName = arr[0].ToString();
                    if (pageName == "product" || pageName == "manage_product" || pageName == "order_master_vendor" || pageName == "review")
                    {
                        
                    }
                    else
                    {
                        Response.Redirect("product.aspx");
                    }

                }
                admin_name.Text = "Welcome " + Config.dt.Rows[0][1].ToString();

            }
            else
            {
                //Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("product.aspx");
            }
        }
    }
}