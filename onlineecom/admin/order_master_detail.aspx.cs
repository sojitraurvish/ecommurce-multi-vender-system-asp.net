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
    public partial class order_master_detail : System.Web.UI.Page
    {
        private string id;

        string address;
        string city;
        string pincode;
        string order_status;
        string total_price;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ADMIN_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }

            Config.con = FunctionInc.connection();

            if (IsPostBack) return;

            //queary string data intialization
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Request.QueryString["id"].ToString();
            }
            else
            {
                Response.Write("<script>alert('query string data null');</script>");
            }

            //product details
            Config.q = "select order_status.*,order_master.*,product.*,product.name as 'product_name',product.price as 'product_price',order_detail.*,order_detail.qty as 'soled_qty',order_detail.price as 'soled_price',admin_users.* from order_status,order_detail,product,order_master,admin_users where order_status.id=order_master.order_status and order_master.id=order_detail.order_id and order_detail.product_id=product.id and product.added_by=admin_users.id and order_detail.order_id='" + id + "'";
            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (count > 0)
            {
                product_details.DataSource = Config.dt;
                product_details.DataBind();
                order_status = Config.dt.Rows[0][1].ToString();    
            }
            else
            {
                //single_product.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                //Response.Write("<script>alert('this id kind of dat');</script>");
                //Response.Redirect("index.aspx");
            }

            
            
            
            
            
            
            //address details



            //this is temporary datatable
            DataTable dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("address");
            dt1.Columns.Add("city");
            dt1.Columns.Add("pincode");
            dt1.Columns.Add("order_status");
            dt1.Columns.Add("total_price");

            foreach (DataRow dr in Config.dt.Rows)
            {
                //cart_total += Convert.ToInt32(dr["price"]) * Convert.ToInt32(dr["qty"]);
                address = dr["address"].ToString();
                city=dr["city"].ToString();
                pincode =dr["pincode"].ToString();
                total_price = dr["total_price"].ToString();
                //order_status = Config.dt.Rows[0][1].ToString();               
                //order_status = dr["name"].ToString();
            }


            DataRow dr1 = dt1.NewRow();
            dr1["address"] = address.ToString();
            dr1["city"] = city.ToString();
            dr1["pincode"] = pincode.ToString();
            dr1["order_status"] = order_status.ToString();
            dr1["total_price"] = total_price.ToString();
            dt1.Rows.Add(dr1);

            address_detail.DataSource = dt1;
            address_detail.DataBind();

            string q = "select * from order_status";
            Config.da = new SqlDataAdapter(q, Config.con);
            Config.dt = new DataTable();
            Config.da.Fill(Config.dt);
            forder_status.DataSource = Config.dt;
            forder_status.DataTextField = "name";
            forder_status.DataValueField = "id";
            forder_status.DataBind();


            int value;
            //Try converting the value to integer
            bool isValueNumeric = int.TryParse(id, out value);


            if (!String.IsNullOrEmpty(id) && /*here*/isValueNumeric && Convert.ToInt64(id) > 0)
            {

                //check if update category it will fill value
                //string id = Request.QueryString["id"]; uper

                string sql = "select * from order_status where name='"+order_status.ToString()+"'";
                Config.da = new SqlDataAdapter(sql, Config.con);
                Config.dt = new DataTable();

                Config.da.Fill(Config.dt);
                int f = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                if (f > 0)
                {
                    //categories_id.Text = Config.dt.Rows[0][1].ToString();
                    forder_status.ClearSelection(); //making sure the previous selection has been cleared
                    forder_status.Items.FindByValue(Config.dt.Rows[0][0].ToString()).Selected = true;

                }
                else
                {
                    //Response.Write("<script>alert('this id kind of dat');</script>");
                    //Response.Redirect("product.aspx");
                }

            }

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            int order_status=Convert.ToInt32(forder_status.SelectedItem.Value);
            string sql = "update order_master set order_status='"+order_status+"' where id='"+ Request.QueryString["id"].ToString() + "'";
            Config.cmd = new SqlCommand(sql, Config.con);

            int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
            if (i > 0)
            {

                //Response.Write("<script>alert('Data inserted Successfully');</script>");
                Response.Redirect("order_master.aspx");
            }
            else
            {
                Response.Write("<script>alert('Data not inserted Successfully.');</script>");
            }
        }
    }
}