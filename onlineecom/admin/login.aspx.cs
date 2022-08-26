using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace onlineecom.admin
{
    public partial class login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Config.con = FunctionInc.connection();
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = Config.con.CreateCommand();
            cmd.CommandType=CommandType.Text;
            string myusername = FunctionInc.get_safe_value(username.Text.ToString());
            string mypassword = FunctionInc.get_safe_value(password.Text.ToString());
            cmd.CommandText = "select * from admin_users where username='"+myusername.ToString()+"' and password='"+mypassword.ToString()+"'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            int i = Convert.ToInt32(dt.Rows.Count.ToString());

                if(i>0)
                {
                    if (dt.Rows[0][6].ToString() == "True")
                    {
                        Session["ADMIN_LOGIN"] = "yes";
                        Session["ADMIN_ID"] = dt.Rows[0][0].ToString();
                        Session["ADMIN_USERNAME"] = dt.Rows[0][1].ToString();
                        Session["ADMIN_ROLE"] = dt.Rows[0][3].ToString();
                        //foreach (DataRow dr in dt.Rows)
                        //{
                        //Session["ADMIN_USERNAME"] = dr["username"].ToString();
                        //}
                        Response.Redirect("categories.aspx");
                    }
                    else
                    {
                    fall_error.InnerText = "Your Profile Is Disabeled By Admin";
                        fall_error.Style.Add("display", "block");
                    }
                }
                else
                {
                    ferror.Style.Add("display", "block");
                }
        }
    }
}