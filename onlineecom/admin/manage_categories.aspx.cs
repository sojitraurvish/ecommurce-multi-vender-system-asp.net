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
    public partial class manage_categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            Config.con = FunctionInc.connection();
            if (Session["ADMIN_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (IsPostBack) return;

            int value;
            //Try converting the value to integer
            bool isValueNumeric = int.TryParse(Request.QueryString["id"], out value);

            if (!String.IsNullOrEmpty(Request.QueryString["id"]) && /*here*/isValueNumeric && Convert.ToInt64(Request.QueryString["id"]) > 0)
            {
                
                //check update category
                string id = Request.QueryString["id"];
                string sql = "select * from categories where id='" + id + "'";
                Config.da = new SqlDataAdapter(sql, Config.con);
                Config.dt = new DataTable();

                Config.da.Fill(Config.dt);
                int count=Convert.ToInt32(Config.dt.Rows.Count.ToString());
                if(count>0)
                {
                    category.Text = Config.dt.Rows[0][1].ToString();
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
            string categories = category.Text.ToString();

            string q = "select * from categories where categories='" + categories.ToString() + "'";
            Config.da = new SqlDataAdapter(q, Config.con);
            Config.dt = new DataTable();
            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());


            msg.Text = "";
            msg.Style.Add("display", "none;");
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
                            msg.Text = "*Category already exist";
                            msg.Style.Add("display", "inline-block");
                        }
                    }
                }
                else
                {
                    msg.Text = "*Category already exist";
                    msg.Style.Add("display", "inline-block");
                }

            }


            if(String.IsNullOrEmpty(msg.Text))
            { 

                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    //update category
                    //string id = Request.QueryString["id"]; *here to uper
                    //string categories = category.Text.ToString();*here to uper
                    DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                    string sql = "update categories set categories='" + categories.ToString() + "',updated_at='"+dateTime+"' where id='" + id.ToString() + "'";
                    Config.cmd = new SqlCommand(sql, Config.con);

                    int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Data updated Successfully');</script>");
                        Response.Redirect("categories.aspx");
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
                    string sql = "insert into categories(categories,status,created_at) values('" + categories.ToString() + "','1','"+dateTime+"')";
                    Config.cmd = new SqlCommand(sql, Config.con);

                    int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Data inserted Successfully');</script>");
                        Response.Redirect("categories.aspx");
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