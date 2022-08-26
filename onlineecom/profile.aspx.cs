using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using onlineecom.admin;

namespace onlineecom
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Config.con = FunctionInc.connection();
            if (Session["USER_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (IsPostBack) return;

            //to fill profile data(name only)
            string sql = "select * from users where id='" + Session["USER_ID"] + "'";
            Config.da = new SqlDataAdapter(sql, Config.con);
            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (count > 0)
            {
                fname.Text = Config.dt.Rows[0][1].ToString();
            }
            else
            {
                //Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("product.aspx");
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
            string sql = "update users set name='"+fname.Text+ "',updated_at='" + dateTime + "' where id='" + Session["USER_ID"]+"'";
            Config.cmd = new SqlCommand(sql, Config.con);

            int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
            if (i > 0)
            {

                Response.Write("<script>alert('Profile Updated Successfully');</script>");
                Response.Redirect("index.aspx");
            }
            else
            {
                Response.Write("<script>alert('Profile Not Updated Successfully.');</script>");
            }
        }
    }
}