using onlineecom.admin;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace onlineecom
{
    public partial class checkout : System.Web.UI.Page
    {
        private string user_id;

        private string accordion_class;//to hide login form

        private int cart_total = 0;//cart total

        //submit on click data
        private string address;
        private string city;
        private int pincode;
        private string payment_type;
        private decimal total_price;
        private string payment_status;
        private int order_status;
        private DateTime created_at;

        private string order_id;

        //payu payment getway
        private string tnxid;
        string key;
        string salt;
        private string txnid;
        string firstname;
        string email;
        string phone;
        string productinfo;
        string MARCHANT_KEY;
        Double amount;
        protected void Page_Load(object sender, EventArgs e)
        {
            accordion_class = "accordion__hide";//to hide login form
            if (Session["USER_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {

                checkout_method_lable.Style.Add("display", "none");
                checkout_method_form.Style.Add("display", "none");
                accordion_class = "accordion__title";//to hide login form
                address_information.Attributes.Add("class", accordion_class);//to hide login form
                payment_information.Attributes.Add("class", accordion_class);//to hide login form
                //address_information.Style.Add("display", "none");
                //lblWithoutClass.Attributes.Add("class", "ClassJoined");
                //lblMessage.CssClass = "LabelGrey";
            }
            Config.con = FunctionInc.connection();

            if (IsPostBack) return;

            //queary string data intialization
            //if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            //{
            //    id = Request.QueryString["id"].ToString();
            //}
            //else
            //{
            //    Response.Write("<script>alert('query string data null');</script>");
            //}


            user_id = Session["USER_ID"].ToString();

            Config.q = "select cart.*,product.*,product.id as product_id from cart,product where cart.product_id=product.id and cart.user_id='" + user_id.ToString() + "' order by cart.id desc";
            Config.da = new SqlDataAdapter(Config.q, Config.con);

            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (count > 0)
            {
                checkout_product_repeter.DataSource = Config.dt;
                checkout_product_repeter.DataBind();
            }
            else
            {
                //single_product.Style.Add("display", "none");
                //single_product_not_found.Style.Add("display", "inline-block");
                //single_product_not_found.Text = "Data Not Found.";
                //Response.Write("<script>alert('this id kind of dat');</script>");
                Response.Redirect("index.aspx");
            }

            //this is temporary datatable
            DataTable dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("cart_total");


            foreach (DataRow dr in Config.dt.Rows)
            {
                cart_total += Convert.ToInt32(dr["price"]) * Convert.ToInt32(dr["qty"]);
            }
            DataRow dr1 = dt1.NewRow();
            dr1["cart_total"] = cart_total.ToString();
            dt1.Rows.Add(dr1);

            checkout_product_total_price_repeter.DataSource = dt1;
            checkout_product_total_price_repeter.DataBind();


            if (Session["COUPON_ID"] != null)
            {

                Session.Remove("COUPON_ID");
                Session.Remove("FINAL_PRICE");
                Session.Remove("COUPON_VALUE");
                Session.Remove("COUPON_CODE");
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            address = faddress.Text;
            city = fcity.Text;
            pincode = Convert.ToInt32(fpincode.Text);
            payment_type = fpayment_type.Text;
            user_id = Session["USER_ID"].ToString();

            //for total price
            Config.q = "select cart.*,product.*,product.id as product_id from cart,product where cart.product_id=product.id and cart.user_id='" + user_id.ToString() + "' order by cart.id desc";
            Config.da = new SqlDataAdapter(Config.q, Config.con);
            Config.dt = new DataTable();
            Config.da.Fill(Config.dt);
            int cart_total2=0;
            foreach (DataRow dr in Config.dt.Rows)
            {
                cart_total2 += Convert.ToInt32(dr["price"]) * Convert.ToInt32(dr["qty"]);
            }
            total_price = Convert.ToDecimal(cart_total2);

            payment_status = "Pending";//default if other then cod
            if (payment_type == "cod")
            {
                payment_status = "success";
            }
            order_status = 1;

            created_at = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));

            //transection id
            Random random = new Random();
            txnid = Convert.ToString(random.Next(10000, 20000)) + FunctionInc.GetRandomString(10) + Convert.ToString(random.Next(10000, 20000));

            
            string coupon_id,coupon_value, coupon_code;
            if (Session["COUPON_ID"] != null)
            {
                coupon_id = Session["COUPON_ID"].ToString();
                coupon_value = Session["COUPON_VALUE"].ToString();
                total_price = Convert.ToInt32(total_price - Convert.ToInt32(coupon_value));
                coupon_code=Session["COUPON_CODE"].ToString();
                Session.Remove("COUPON_ID");
                Session.Remove("FINAL_PRICE");
                Session.Remove("COUPON_VALUE");
                Session.Remove("COUPON_CODE");
            }
            else
            {
                coupon_id ="";
                coupon_value = "";
                coupon_code = "";
            }
            //insert new order
            string sql = "insert into order_master(user_id,address,city,pincode,payment_type,total_price,payment_status,order_status,created_at,txnid,coupon_id,coupon_value,coupon_code) values('" + user_id + "','" + address + "','" + city + "','" + pincode + "','" + payment_type + "','" + total_price + "','" + payment_status + "','" + order_status + "','" + created_at + "','"+txnid.ToString()+"','"+coupon_id+"','"+coupon_value+"','"+coupon_code+"')";
            Config.cmd = new SqlCommand(sql, Config.con);

            int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
            if (i > 0)
            {

                //Response.Write("<script>alert('Data inserted Successfully');</script>");
                //Response.Redirect("product.aspx");
            }
            else
            {
                Response.Write("<script>alert('Data not inserted Successfully.');</script>");
            }

            //to find last inserted recored form order_master

            string q = "select MAX(id) from order_master where user_id='"+user_id.ToString()+"'";
            Config.da = new SqlDataAdapter(q, Config.con);
            Config.dt = new DataTable();

            Config.da.Fill(Config.dt);
            int count = Convert.ToInt32(Config.dt.Rows.Count.ToString());
            if (count > 0)
            {
                order_id = Config.dt.Rows[0][0].ToString();
            }
            else
            {
                Response.Write("<script>alert('Data not inserted Successfully.');</script>");
            }

            //to find cart total product
            Config.q = "select cart.*,product.*,product.id as product_id from cart,product where cart.product_id=product.id and cart.user_id='" + user_id.ToString() + "' order by cart.id desc";
            Config.da = new SqlDataAdapter(Config.q, Config.con);
            Config.dt = new DataTable();
            Config.da.Fill(Config.dt);
            foreach (DataRow dr in Config.dt.Rows)
            {
                //to insert into order_detail table for one user multiple product
                string product_id = dr["product_id"].ToString();
                string qty = dr["qty"].ToString();
                string price = dr["price"].ToString();

                Config.q = "insert into order_detail(order_id,product_id,qty,price,created_at) values('"+ order_id + "','"+ product_id + "','"+ qty + "','"+ price + "','"+created_at+"')";
                Config.cmd = new SqlCommand(Config.q, Config.con);

                int f = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                if (f > 0)
                {
                    if (payment_type == "cod")
                    {
                        email_order_invoice();
                    }
                    //Response.Write("<script>alert('Data inserted Successfully');</script>");
                    //Response.Redirect("product.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Data not inserted Successfully.');</script>");
                }
            }

            //-------------------------------------------------------------------------------------
            //Cart_function.deleteProduct(user_id);
            //to delete product into cart
            Config.q = "delete from cart where user_id='" + user_id + "'";
            Config.cmd = new SqlCommand(Config.q, Config.con);

            int c = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
            if (c > 0)
            {

                //Response.Write("<script>alert('Data inserted Successfully');</script>");
                //Response.Redirect("product.aspx");
            }
            else
            {
                //Response.Write("<script>alert('Data not inserted Successfully.');</script>");
            }
            //-------------------------------------------------------------------------------------

            //for payu payment getway
            if (payment_type == "payu")
            {
                //if (!IsPostBack)
                //{ //lbl_price.Text = Request.QueryString["price"].ToString();
                //    Random random = new Random();
                //    txnid.Value = (Convert.ToString(random.Next(10000, 20000)));
                //    txnid.Value = "Hariti" + txnid.Value.ToString();
                //    Response.Write(txnid.Value.ToString());
                //}

                //to get user details 
                user_id = Session["USER_ID"].ToString();

                Config.q = "select * from users where id='"+user_id.ToString()+"'";
                Config.da = new SqlDataAdapter(Config.q, Config.con);

                Config.dt = new DataTable();

                Config.da.Fill(Config.dt);
                int a = Convert.ToInt32(Config.dt.Rows.Count.ToString());
                if (a > 0)
                { 
                    foreach (DataRow dr in Config.dt.Rows)
                    {
                        firstname = dr["name"].ToString();//
                        email = dr["email"].ToString();//
                        phone = dr["mobile"].ToString();//
                    }
                }
                else
                {
                    //single_product.Style.Add("display", "none");
                    //single_product_not_found.Style.Add("display", "inline-block");
                    //single_product_not_found.Text = "Data Not Found.";
                    Response.Write("<script>alert('data not found');</script>");
                    //Response.Redirect("index.aspx");                   

                }

                //for payu payment getway
                MARCHANT_KEY = "gtKFFx";//
                key = MARCHANT_KEY;//
                salt = "wia56q6O";
                //transection id is above
                
                amount = (double)total_price;//
                
                productinfo = "Womens";

                String text = key.ToString() + "|" + txnid.ToString() + "|" + amount + "|" + productinfo.ToString() + "|" + firstname.ToString() + "|"
                    + email.ToString() + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "||||||" + salt.ToString();


                //to encode the string 
                byte[] message = Encoding.UTF8.GetBytes(text);

                //UnicodeEncoding UE = new UnicodeEncoding();

                SHA512Managed hashString = new SHA512Managed();
                string hex = "";
                byte[] hashValue = hashString.ComputeHash(message);
                foreach (byte x in hashValue)
                {
                    hex += String.Format("{0:x2}", x);
                }
                //hash.Value = hex;

                System.Collections.Hashtable data = new System.Collections.Hashtable();
                data.Add("hash", hex.ToString());
                data.Add("txnid", txnid.ToString());
                data.Add("key", key.ToString());

                data.Add("amount", amount);
                data.Add("firstname", firstname.Trim());
                data.Add("email", email.Trim());
                data.Add("phone", phone.Trim());
                data.Add("productinfo", productinfo.ToString());
                data.Add("udf1", "1");
                data.Add("udf2", "1");
                data.Add("udf3", "1");
                data.Add("udf4", "1");
                data.Add("udf5", "1");

                data.Add("surl", "https://localhost:44326/payu_payment_complete.aspx");
                data.Add("furl", "https://localhost:44326/payu_payment_fail.aspx");

                data.Add("service_provider", "");

                string strForm = PreparePOSTForm("https://test.payu.in/_payment", data);
                //string strForm = PreparePOSTForm("https://secure.payu.in/_payment", data);
                Page.Controls.Add(new LiteralControl(strForm));
            }
            else
            {
                Response.Redirect("thank_you.aspx");
            }
            
            
        }

        //payu pament getway
        private string PreparePOSTForm(string url, System.Collections.Hashtable data)
        {
            string formID = "PostForm";

            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" + formID + "\" action=\"" + url + "\" method=\"POST\">");

            foreach (System.Collections.DictionaryEntry key in data)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + key.Key + "\" value=\"" + key.Value + "\">");
            }

            strForm.Append("</form>");
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + "=document." + formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            return strForm.ToString() + strScript.ToString();
        }

        protected void email_order_invoice()
        {
            string name="", due_date="", item_price="", total="", item_name="",mail_to="";
            string sql = "select order_master.*,users.* from order_master,users where order_master.user_id=users.id and order_master.id='"+order_id+"'";

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

            string q1= "select sum(qty) as 'count' from order_detail where order_id = '" + order_id + "'";

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