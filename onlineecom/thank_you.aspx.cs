using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using onlineecom.admin;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace onlineecom
{
    public partial class thank_you : System.Web.UI.Page
    {
        string order_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }
            //to find user id
            string t = "select MAX(id) from order_master where user_id='" + Session["USER_ID"] + "'";
            SqlDataAdapter adp = new SqlDataAdapter(t, Config.con);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            int c = Convert.ToInt32(dt.Rows.Count.ToString());
            if (c > 0)
            {
                order_id = dt.Rows[0][0].ToString();
            }
            else
            {
                Response.Write("<script>alert('Data not inserted Successfully.');</script>");
            }
            email_order_invoice();
        }

        protected void email_order_invoice()
        {
            string name = "", due_date = "", item_price = "", total = "", item_name = "", mail_to = "";
            string sql = "select order_master.*,users.* from order_master,users where order_master.user_id=users.id and order_master.id='" + order_id + "'";

            Config.da = new SqlDataAdapter(sql, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int a = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (a > 0)
            {
                name = Config.dt.Rows[0][17].ToString();
                due_date = Config.dt.Rows[0][21].ToString();
                //invoice_id = ;
                //string date = "09/04/2022";
                //string invoice_datails = "invoce dtails";
                mail_to = Config.dt.Rows[0][19].ToString();
                item_price = Config.dt.Rows[0][6].ToString();
                total = Config.dt.Rows[0][6].ToString();
            }
            else
            {
                //single_product.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                //Response.Write("<script>alert('data not found');</script>");
                //Response.Redirect("index.aspx");                   

            }

            string q1 = "select sum(qty) as 'count' from order_detail where order_id = '" + order_id + "'";

            Config.da = new SqlDataAdapter(q1, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int b = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (b > 0)
            {
                item_name = Config.dt.Rows[0][0].ToString(); ;
            }
            else
            {
                //single_product.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                //Response.Write("<script>alert('data not found');</script>");
                //Response.Redirect("index.aspx");                   

            }
            string html = File.ReadAllText(Server.MapPath("~/email_order_invoice.html")); //Convert HTML to String

            //string strNewPassword = GeneratePassword().ToString();

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("sisprojectcollab@gmail.com");
            msg.To.Add(mail_to);
            msg.Subject = "CONFORMATATION ORDER FROM AtoZ";
            //msg.AlternateViews.Add(Mail_Body());



            //var inlineLogo = new LinkedResource(Server.MapPath(@"image-1.png"), "image/png");
            //inlineLogo.ContentId = Guid.NewGuid().ToString();

            //string body = string.Format(@"html", inlineLogo);

            //var view = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            //view.LinkedResources.Add(inlineLogo);
            //msg.AlternateViews.Add(view);



            html = html.Replace("{Name}", name);
            html = html.Replace("{total}", total);
            html = html.Replace("{due_date}", due_date);
            //html = html.Replace("{invoice_id}", invoice_id);
            html = html.Replace("{date}", due_date);
            //html = html.Replace("{invoice_datails}", invoice_datails);
            //html = html.Replace("{item_name}", item_name);
            html = html.Replace("{item_name}", item_name);
            html = html.Replace("{item_price}", item_price);
            html = html.Replace("{total_price}", total);



            msg.Body = html;

            msg.IsBodyHtml = true;

            SmtpClient smt = new SmtpClient();
            smt.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntwd = new NetworkCredential();
            ntwd.UserName = "sisprojectcollab@gmail.com"; //Your Email ID  
            ntwd.Password = "Ecomm123"; // Your Password  
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;
            smt.Port = 587;
            smt.EnableSsl = true;
            smt.Send(msg);

        }
    }
}