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
    public partial class manage_banner : System.Web.UI.Page
    {

        //queary string data
        private string id;

        private string heading1;
        private string heading2;
        private string btn_txt;
        private string btn_link;
        private string image;
        private string order_by;
        

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

                string sql = "select * from banner where id='" + id + "'";
                Config.da = new SqlDataAdapter(sql, Config.con);
                Config.dt = new DataTable();

                Config.da.Fill(Config.dt);
                int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                if (count > 0)
                {
                    fheading1.Text = Config.dt.Rows[0][1].ToString();
                    fheading2.Text = Config.dt.Rows[0][2].ToString();
                    fbtn_txt.Text = Config.dt.Rows[0][3].ToString();
                    fbtn_link.Text = Config.dt.Rows[0][4].ToString();
                    RequiredFieldValidatorfimage.Enabled = false;//to disable required filed validater
                    forder_by.Text = Config.dt.Rows[0][6].ToString();
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
            heading1 = fheading1.Text.ToString();
            heading2 = fheading2.Text.ToString();
            btn_txt = fbtn_txt.Text.ToString();
            btn_link = fbtn_link.Text.ToString();
            image = "image";
            order_by = forder_by.Text.ToString();

            //to check catagory is dublicate or not
            //string id = Request.QueryString["id"]; uper globle

            //string q = "select * from coupon_master where coupon_code='" + coupon_code + "' and coupon_type='" + coupon_type + "'";
            //Config.da = new SqlDataAdapter(q, Config.con);
            //Config.dt = new DataTable();
            //Config.da.Fill(Config.dt);
            //int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());


            //Labelfcoupon_code.Text = "";
            //Labelfcoupon_code.Style.Add("display", "none;");
            //if (count > 0)
            //{
            //    if (!String.IsNullOrEmpty(id))
            //    {
            //        foreach (DataRow dr in Config.dt.Rows)
            //        {
            //            //to check edit category is same to textbox category
            //            if (id == dr["id"].ToString())
            //            {

            //            }
            //            else
            //            {
            //                Labelfcoupon_code.Text = "*Coupon Code Aleready Exist With THis Perticular Type";
            //                Labelfcoupon_code.Style.Add("display", "inline-block");
            //            }
            //        }
            //    }
            //    else
            //    {
            //        Labelfcoupon_code.Text = "*Coupon Code Aleready Exist With THis Perticular Type";
            //        Labelfcoupon_code.Style.Add("display", "inline-block");
            //    }

            //}


            //if (String.IsNullOrEmpty(Labelfcoupon_code.Text))
            //{
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
                        fimage.SaveAs(Request.PhysicalApplicationPath + "/media/banner/" + image.ToString());//
                                                                                                              //string path = "books_images/" + image.ToString();//
                        sql = "update banner set heading1='" + heading1+"',heading2='"+ heading2 + "',btn_txt='"+btn_txt+"',btn_link='"+btn_link+"',image='"+image+"',order_by='"+order_by+"',updated_at='"+dateTime+"' where id='" + id.ToString() + "' ";
                    }
                    else
                    {
                        sql = "update banner set heading1='" + heading1 + "',heading2='" + heading2 + "',btn_txt='" + btn_txt + "',btn_link='" + btn_link + "',order_by='" + order_by + "',updated_at='" + dateTime + "' where id='" + id.ToString() + "' ";
                    }


                    //string id = Request.QueryString["id"]; *here to uper
                    //string categories = category.Text.ToString();*here to uper

                    Config.cmd = new SqlCommand(sql, Config.con);

                    int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Data updated Successfully');</script>");
                        Response.Redirect("banner.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Data not updated Successfully.');</script>");
                    }
                }
                else
                {

                    //to save image
                    image = FunctionInc.GetRandomString(10) + "_" + fimage.FileName.ToString();//
                                                                                               //PhysicalApplicationPath take path upto librarymanagementsystem root folder
                    fimage.SaveAs(Request.PhysicalApplicationPath + "/media/banner/" + image.ToString());//
                                                                                                         //string path = "books_images/" + image.ToString();//

                DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));
                //insert new category
                string sql = "insert into banner(heading1,heading2,btn_txt,btn_link,image,order_by,status,created_at) values('" + heading1+"','"+ heading2 + "','"+btn_txt+"','"+btn_link+"','"+image+"','"+order_by+"','True','"+dateTime+"')";
                    Config.cmd = new SqlCommand(sql, Config.con);

                    int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                    if (i > 0)
                    {

                        Response.Write("<script>alert('Data inserted Successfully');</script>");
                        Response.Redirect("banner.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Data not inserted Successfully.');</script>");
                    }

                }
            
        }
    }
}