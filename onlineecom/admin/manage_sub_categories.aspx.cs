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
    public partial class manage_sub_categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Config.con = FunctionInc.connection();
            if (Session["ADMIN_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (IsPostBack) return;

            //for category dropdown
            string q = "select * from categories where categories.status='True' and categories.deleted_at IS NULL order by categories desc";
            Config.da = new SqlDataAdapter(q, Config.con);
            Config.dt = new DataTable();
            Config.da.Fill(Config.dt);
            fcategories_id.DataSource = Config.dt;
            fcategories_id.DataTextField = "categories";
            fcategories_id.DataValueField = "id";
            fcategories_id.DataBind();

            int value;
            //Try converting the value to integer
            bool isValueNumeric = int.TryParse(Request.QueryString["id"], out value);

            if (!String.IsNullOrEmpty(Request.QueryString["id"]) && /*here*/isValueNumeric && Convert.ToInt64(Request.QueryString["id"]) > 0)
            {

                //check update category
                string id = Request.QueryString["id"];
                string sql = "select * from sub_categories where id='" + id + "'";
                Config.da = new SqlDataAdapter(sql, Config.con);
                Config.dt = new DataTable();

                Config.da.Fill(Config.dt);
                int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                if (count > 0)
                {
                    fcategories_id.Text = Config.dt.Rows[0][1].ToString();
                    fsub_categories.Text = Config.dt.Rows[0][2].ToString();
                }
                else
                {
                    //Response.Write("<script>alert('this id kind of dat');</script>");
                    Response.Redirect("categories.aspx");
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
            //to check catagory is dublicate or not
            string id = Request.QueryString["id"];
            int categories_id = Convert.ToInt32(fcategories_id.SelectedValue.ToString());
            string sub_categories = fsub_categories.Text.ToString();

            string q = "select * from sub_categories where categories_id='"+categories_id+"' and sub_categories='" + sub_categories.ToString() + "'";
            Config.da = new SqlDataAdapter(q, Config.con);
            Config.dt = new DataTable();
            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());


            Labelfsub_categories.Text = "";
            Labelfsub_categories.Style.Add("display", "none;");
            if (count > 0)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    foreach (DataRow dr in Config.dt.Rows)
                    {
                        //to check edit category is same to textbox category
                        if (id == dr["id"].ToString())
                        {

                        }
                        else
                        {
                            Labelfsub_categories.Text = "*Sub Category Already Exist In This Main Category";
                            Labelfsub_categories.Style.Add("display", "inline-block");
                        }
                    }
                }
                else
                {
                    Labelfsub_categories.Text = "*Sub Category Already Exist In This Main Category";
                    Labelfsub_categories.Style.Add("display", "inline-block");
                }

            }


            if (String.IsNullOrEmpty(Labelfsub_categories.Text))
            {

                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    //update category
                    //string id = Request.QueryString["id"]; *here to uper
                    //string categories = category.Text.ToString();*here to uper
                    DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                    string sql = "update sub_categories set categories_id='"+ categories_id + "',sub_categories='" + sub_categories.ToString() + "',updated_at='"+dateTime+"' where id='" + id.ToString() + "'";
                    Config.cmd = new SqlCommand(sql, Config.con);

                    int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Data updated Successfully');</script>");
                        Response.Redirect("sub_categories.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Data not updated Successfully.');</script>");
                    }
                }
                else
                {
                    //insert new category
                    DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                    string sql = "insert into sub_categories(categories_id,sub_categories,status,created_at) values('"+ categories_id+ "','" + sub_categories.ToString() + "','1','"+dateTime+"')";
                    Config.cmd = new SqlCommand(sql, Config.con);

                    int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Data inserted Successfully');</script>");
                        Response.Redirect("sub_categories.aspx");
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