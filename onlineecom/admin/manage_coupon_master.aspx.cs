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
    public partial class manage_coupon_master : System.Web.UI.Page
    {
        //queary string data
        private string id;

        private string coupon_code;
        private int coupon_value;
        private string coupon_type;
        private int cart_min_value;

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

                string sql = "select * from coupon_master where id='" + id + "'";
                Config.da = new SqlDataAdapter(sql, Config.con);
                Config.dt = new DataTable();

                Config.da.Fill(Config.dt);
                int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                if (count > 0)
                {
                    fcoupon_code.Text = Config.dt.Rows[0][1].ToString();
                    fcoupon_value.Text = Config.dt.Rows[0][2].ToString();
                    fcoupon_type.Text = Config.dt.Rows[0][3].ToString();
                    fcart_min_value.Text = Config.dt.Rows[0][4].ToString();

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
            coupon_code = fcoupon_code.Text.ToString();
            coupon_value = Convert.ToInt32(fcoupon_value.Text.ToString());
            coupon_type = fcoupon_type.Text.ToString();
            cart_min_value = Convert.ToInt32(fcart_min_value.Text.ToString());

            //to check catagory is dublicate or not
            //string id = Request.QueryString["id"]; uper globle

            string q = "select * from coupon_master where coupon_code='"+coupon_code+"'";
            Config.da = new SqlDataAdapter(q, Config.con);
            Config.dt = new DataTable();
            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());


            Labelfcoupon_code.Text = "";
            Labelfcoupon_code.Style.Add("display", "none;");
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
                            Labelfcoupon_code.Text = "*Coupon Code Aleready Exist With THis Perticular Type";
                            Labelfcoupon_code.Style.Add("display", "inline-block");
                        }
                    }
                }
                else
                {
                    Labelfcoupon_code.Text = "*Coupon Code Aleready Exist With THis Perticular Type";
                    Labelfcoupon_code.Style.Add("display", "inline-block");
                }

            }


            if (String.IsNullOrEmpty(Labelfcoupon_code.Text))
            {
                //update category
                if (!String.IsNullOrEmpty(id))
                {
                    //to update image
                    string sql;

                    DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                    sql = "update coupon_master set coupon_code='" + coupon_code + "',coupon_value='" + coupon_value + "',coupon_type='" + coupon_type + "',cart_min_value='" + cart_min_value + "',updated_at='"+dateTime+"' where id='" + id.ToString() + "'";

                    //string id = Request.QueryString["id"]; *here to uper
                    //string categories = category.Text.ToString();*here to uper

                    Config.cmd = new SqlCommand(sql, Config.con);

                    int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Data updated Successfully');</script>");
                        Response.Redirect("coupon_master.aspx");
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
                    string sql = "insert into coupon_master(coupon_code,coupon_value,coupon_type,cart_min_value,status,created_at) values('" + coupon_code + "','" + coupon_value + "','" + coupon_type + "','" + cart_min_value + "','True','"+dateTime+"')";
                    Config.cmd = new SqlCommand(sql, Config.con);

                    int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {

                        Response.Write("<script>alert('Data inserted Successfully');</script>");
                        Response.Redirect("coupon_master.aspx");
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