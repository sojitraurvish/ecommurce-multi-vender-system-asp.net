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
    public partial class manage_vendor_management : System.Web.UI.Page
    {
        //queary string data
        private string id;

        private string username;
        private string password;
        private string email;
        private string mobile;

        protected void Page_Load(object sender, EventArgs e)
        {
            //queary string data intialization
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Request.QueryString["id"].ToString();
            }
            else
            {
                Response.Write("<script>alert('query string data null');</script>");
            }

            Config.con = FunctionInc.connection();
            if (Session["admin_login"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (IsPostBack) return;


            int value;
            //Try converting the value to integer
            bool isValueNumeric = int.TryParse(id, out value);


            if (!String.IsNullOrEmpty(id) && /*here*/isValueNumeric && Convert.ToInt64(id) > 0)
            {

                //check if update category it will fill value
                //string id = Request.QueryString["id"]; uper

                string sql = "select * from admin_users where id='" + id + "'";
                Config.da = new SqlDataAdapter(sql, Config.con);
                Config.dt = new DataTable();

                Config.da.Fill(Config.dt);
                int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                if (count > 0)
                {
                    fusername.Text = Config.dt.Rows[0][1].ToString();
                    fpassword.Text = Config.dt.Rows[0][2].ToString();
                    femail.Text = Config.dt.Rows[0][4].ToString();
                    fmobile.Text = Config.dt.Rows[0][5].ToString();

                }
                else
                {
                    //Response.Write("<script>alert('this id kind of dat');</script>");
                    //Response.Redirect("product.aspx");
                }

            }
            //else
            //{
            //    //Response.Write("<script>alert('You have modified url');</script>");
            //    Response.Redirect("categories.aspx");
            //}
        }


        protected void submit_Click(object sender, EventArgs e)
        {
            username = fusername.Text.ToString();
            password = fpassword.Text.ToString();
            email = femail.Text.ToString();
            mobile = fmobile.Text.ToString();

            //to check email is dublicate or not
            //string id = Request.QueryString["id"]; uper globle

            string q = "select * from admin_users where email='" + email + "'";
            Config.da = new SqlDataAdapter(q, Config.con);
            Config.dt = new DataTable();
            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());


            Labelfemail.Text = "";
            Labelfemail.Style.Add("display", "none;");
            if (count > 0)
            {
                if (!String.IsNullOrEmpty(id))
                {
                    foreach (DataRow dr in Config.dt.Rows)
                    {
                        //to check edit category is same to textbox category
                        if (id == dr["id"].ToString())
                        {

                        }
                        else
                        {
                            Labelfemail.Text = "*Email Aleready Exists";
                            Labelfemail.Style.Add("display", "inline-block");
                        }
                    }
                }
                else
                {
                    Labelfemail.Text = "*Email Aleready Exists";
                    Labelfemail.Style.Add("display", "inline-block");
                }

            }
            
            
            //to check mobile is dublicate or not
            //string id = Request.QueryString["id"]; uper globle

            string p = "select * from admin_users where mobile='" + mobile + "'";
            Config.da = new SqlDataAdapter(p, Config.con);
            Config.dt = new DataTable();
            Config.da.Fill(Config.dt);
            int t = Convert.ToInt32(Config.dt.Rows.Count.ToString());


            Labelfmobile.Text = "";
            Labelfmobile.Style.Add("display", "none;");
            if (t > 0)
            {
                if (!String.IsNullOrEmpty(id))
                {
                    foreach (DataRow dr in Config.dt.Rows)
                    {
                        //to check edit category is same to textbox category
                        if (id == dr["id"].ToString())
                        {

                        }
                        else
                        {
                            Labelfmobile.Text = "*Mobile Number Aleready Exists";
                            Labelfmobile.Style.Add("display", "inline-block");
                        }
                    }
                }
                else
                {
                    Labelfmobile.Text = "*Mobile Number Aleready Exists";
                    Labelfmobile.Style.Add("display", "inline-block");
                }

            }


            if (String.IsNullOrEmpty(Labelfemail.Text) && String.IsNullOrEmpty(Labelfmobile.Text))
            {
                //update category
                if (!String.IsNullOrEmpty(id))
                {
                    //to update image
                    string sql;

                    DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                    sql = "update admin_users set username='" + username + "',password='" + password + "',email='" + email + "',mobile='" + mobile + "',updated_at='"+dateTime+"' where id='" + id.ToString() + "'";

                    //string id = Request.QueryString["id"]; *here to uper
                    //string categories = category.Text.ToString();*here to uper

                    Config.cmd = new SqlCommand(sql, Config.con);

                    int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Data updated Successfully');</script>");
                        Response.Redirect("vendor_management.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Data not updated Successfully.');</script>");
                    }
                }
                else
                {

                    DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                    //insert new category
                    string sql = "insert into admin_users(username,password,role,email,mobile,status,created_at) values('" + username + "','" + password + "','1','" + email + "','" + mobile + "','True','"+dateTime+"')";
                    Config.cmd = new SqlCommand(sql, Config.con);

                    int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {

                        Response.Write("<script>alert('Data inserted Successfully');</script>");
                        Response.Redirect("vendor_management.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Data not inserted Successfully.');</script>");
                    }

                }
            }
        }
    }
}