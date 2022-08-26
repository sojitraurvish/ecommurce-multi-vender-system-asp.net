 using System;
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
    public partial class manage_product : System.Web.UI.Page
    {
        //queary string data
        private string id;

        private int categories_id;
        private int sub_categories_id;
        private string name;
        private decimal mrp;
        private decimal price;
        private int qty;
        private string image;
        private string short_desc;
        private string description;
        private string best_seller;
        private string meta_title;
        private string meta_desc;
        private string meta_keyword;


        //admin or vender condition 
       
        string condition = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Config.con = FunctionInc.connection();
            if (Session["admin_login"] == null)
            {
                Response.Redirect("login.aspx");
            }

            

            //queary string data intialization
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Request.QueryString["id"].ToString();
            }
            else
            {
                Response.Write("<script>alert('query string data null');</script>");
            }

            
            if (Convert.ToInt32(Session["ADMIN_ROLE"]) == 1)
            {
                
                condition = "and added_by = '" + Session["ADMIN_ID"] + "'";
            }

            if (IsPostBack) return;
            if (!IsPostBack)
            {
                //for category dropdown
                
                string q = "select * from categories where categories.status='True' and categories.deleted_at IS NULL order by categories desc";
                Config.da = new SqlDataAdapter(q, Config.con);
                Config.dt = new DataTable();
                Config.da.Fill(Config.dt);
                fcategories_id.DataSource = Config.dt;
                fcategories_id.DataTextField = "categories";
                fcategories_id.DataValueField = "id";
                fcategories_id.DataBind();
                if (String.IsNullOrEmpty(id)){
                    this.fcategories_id_SelectedIndexChanged(sender, e);
                }
                
            }
            

            int value;
            //Try converting the value to integer
            bool isValueNumeric = int.TryParse(id, out value);

           
            if (!String.IsNullOrEmpty(id) && /*here*/isValueNumeric && Convert.ToInt64(id) > 0)
            {
                
                //check if update category it will fill value
                //string id = Request.QueryString["id"]; uper
                
                string sql = "select * from product where id='" + id + "' " + condition + "";
                Config.da = new SqlDataAdapter(sql, Config.con);
                Config.dt = new DataTable();
                
                Config.da.Fill(Config.dt);
                int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                if (count > 0)
                {
                    //categories_id.Text = Config.dt.Rows[0][1].ToString();
                    fcategories_id.ClearSelection(); //making sure the previous selection has been cleared
                    fcategories_id.Items.FindByValue(Config.dt.Rows[0][1].ToString()).Selected = true;
                    this.fcategories_id_SelectedIndexChanged(sender, e);
                    fsub_categories_id.Items.FindByValue(Config.dt.Rows[0][2].ToString()).Selected = true;
                    fname.Text= Config.dt.Rows[0][3].ToString();
                    fmrp.Text = Config.dt.Rows[0][4].ToString();
                    fprice.Text = Config.dt.Rows[0][5].ToString();
                    fqty.Text = Config.dt.Rows[0][6].ToString();
                    RequiredFieldValidatorfimage.Enabled = false;//to disable required filed validater
                    fshort_desc.Text = Config.dt.Rows[0][8].ToString();
                    fdescription.Text = Config.dt.Rows[0][9].ToString();
                    fbest_seller.Text = Config.dt.Rows[0][10].ToString();
                    fmeta_title.Text = Config.dt.Rows[0][11].ToString();
                    fmeta_desc.Text = Config.dt.Rows[0][12].ToString();
                    fmeta_keyword.Text = Config.dt.Rows[0][13].ToString();
                    

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
            
            categories_id=Convert.ToInt32(fcategories_id.SelectedItem.Value);
            sub_categories_id=Convert.ToInt32(fsub_categories_id.SelectedItem.Value);
            name = fname.Text.ToString();
            mrp= Convert.ToDecimal(fmrp.Text); 
            price= Convert.ToDecimal(fprice.Text);
            qty = Convert.ToInt32(fqty.Text);
            image = "image";
            short_desc= fshort_desc.Text.ToString();
            description= fdescription.Text.ToString();
            best_seller= fbest_seller.Text.ToString();
            meta_title= fmeta_title.Text.ToString();
            meta_desc= fmeta_desc.Text.ToString();
            meta_keyword= fmeta_keyword.Text.ToString();
        
            //to check catagory is dublicate or not
            //string id = Request.QueryString["id"];uper globle

            string q = "select * from product where categories_id='"+categories_id+"' and sub_categories_id='"+sub_categories_id+"' and name='" + name.ToString() + "' " + condition + "";
            Config.da = new SqlDataAdapter(q, Config.con);
            Config.dt = new DataTable();
            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());


            Labelfname.Text = "";
            Labelfname.Style.Add("display", "none;");
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
                            Labelfname.Text = "*Product Already Exist In This Sub Category";
                            Labelfname.Style.Add("display", "inline-block");
                        }
                    }
                }
                else
                {
                    Labelfname.Text = "*Product Already Exist In This Sub Category";
                    Labelfname.Style.Add("display", "inline-block");
                }

            }


            if (String.IsNullOrEmpty(Labelfname.Text))
            {
                //update category
                if (!String.IsNullOrEmpty(id))
                {
                    //to update image
                    string sql;
                    DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                    if (!String.IsNullOrEmpty(fimage.FileName.ToString()))
                    {
                        //to save image
                        image = FunctionInc.GetRandomString(10) + "_" + fimage.FileName.ToString();//
                        //PhysicalApplicationPath take path upto librarymanagementsystem root folder
                        fimage.SaveAs(Request.PhysicalApplicationPath + "/media/product/" + image.ToString());//
                                                                                                                                                   //string path = "books_images/" + image.ToString();//
                        sql = "update product set categories_id='" + categories_id + "',sub_categories_id='"+sub_categories_id+"',name='" + name + "',mrp='" + mrp + "',price='" + price + "',qty='" + qty + "',image='" + image + "',short_desc='" + short_desc + "',description='" + description + "',best_seller='"+best_seller+"',meta_title='" + meta_title + "',meta_desc='" + meta_desc + "',meta_keyword='" + meta_keyword + "',updated_at='"+dateTime+"' where id='" + id.ToString() + "' " + condition + "";
                    }
                    else
                    {
                         sql = "update product set categories_id='" + categories_id + "',sub_categories_id='" + sub_categories_id + "',name='" + name + "',mrp='" + mrp + "',price='" + price + "',qty='" + qty + "',short_desc='" + short_desc + "',description='" + description + "',best_seller='" + best_seller + "',meta_title='" + meta_title + "',meta_desc='" + meta_desc + "',meta_keyword='" + meta_keyword + "',updated_at='" + dateTime + "' where id='" + id.ToString() + "' " + condition + "";
                    }

                    
                    //string id = Request.QueryString["id"]; *here to uper
                    //string categories = category.Text.ToString();*here to uper
                    
                    Config.cmd = new SqlCommand(sql, Config.con);

                    int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Data updated Successfully');</script>");
                        Response.Redirect("product.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Data not updated Successfully.');</script>");
                    }
                }
                else
                {
                    //to save image
                    image = FunctionInc.GetRandomString(10) + "_" + fimage.FileName.ToString() ;//
                    //PhysicalApplicationPath take path upto librarymanagementsystem root folder
                    fimage.SaveAs(Request.PhysicalApplicationPath + "/media/product/" + image.ToString());//
                    //string path = "books_images/" + image.ToString();//

                    DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                    //insert new category
                    string sql = "insert into product(categories_id,sub_categories_id,name,mrp,price,qty,image,short_desc,description,best_seller,meta_title,meta_desc,meta_keyword,status,added_by,created_at) values('" + categories_id + "','" + sub_categories_id + "','" + name + "','"+ mrp + "','"+ price + "','"+ qty + "','"+ image + "','"+ short_desc + "','"+ description + "','"+best_seller+"','"+ meta_title + "','"+ meta_desc + "','"+ meta_keyword + "','true','"+ Session["ADMIN_ID"] + "','"+dateTime+"')";
                    Config.cmd = new SqlCommand(sql, Config.con);

                    int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {
                        
                        Response.Write("<script>alert('Data inserted Successfully');</script>");
                        Response.Redirect("product.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Data not inserted Successfully.');</script>");
                    }

                }
            }

        }

        protected void fcategories_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            fsub_categories_id.ForeColor = System.Drawing.Color.Black;
            //for sub category dropdown
            int categories_id = Convert.ToInt32(fcategories_id.SelectedValue);
            string sql = "select sub_categories.* from categories,sub_categories where categories.id=sub_categories.categories_id and sub_categories.categories_id='"+categories_id+"' and categories.status='True' and categories.deleted_at IS NULL and sub_categories.status='True' and sub_categories.deleted_at IS NULL order by sub_categories desc";
            SqlDataAdapter adp= new SqlDataAdapter(sql, Config.con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            int count = Convert.ToInt32(dt.Rows.Count.ToString());
            if(count>0)
            {
                fsub_categories_id.DataSource = dt;
                fsub_categories_id.DataTextField = "sub_categories";
                fsub_categories_id.DataValueField = "id";
                fsub_categories_id.DataBind();
            }
            else
            {
                fsub_categories_id.Items.Clear();
                fsub_categories_id.Items.Insert(0,new ListItem("Sub Category Not Found!", "-1"));
                fsub_categories_id.ForeColor = System.Drawing.Color.Red;
            }
            
        }
    }
}