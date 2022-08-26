using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;


namespace onlineecom.admin
{
    public class FunctionInc
    {
        

        public void pr()
        {
            
        }
        public void prx(Object o)
        {

        }

        public static string get_safe_value(string str)
        {
                return Regex.Replace(str, @"[\x00'""\b\n\r\t\cZ\\%_=+!-#$^&*(){}[\]|:;<,>?/`~]", "").Trim();
        }

        public static SqlConnection connection() 
        {

            if (Config.con.State == ConnectionState.Closed)
            {
                Config.con.Open();
            }
            return Config.con;
        }

        public static string GetRandomString(int length)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string password = string.Empty;
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int x = random.Next(1, chars.Length);
                //For avoiding Repetation of Characters
                if (!password.Contains(chars.GetValue(x).ToString()))
                    password += chars.GetValue(x);
                else
                    i = i - 1;
            }
            return password;
        }

        //for otp
        public static string GeneratePassword()
        {
            string PasswordLength = "4";
            string NewPassword = "";

            string allowedChars = "";
            allowedChars = "1,2,3,4,5,6,7,8,9,0";
            // allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            // allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";


            char[] sep = {
            ','
        };
            string[] arr = allowedChars.Split(sep);


            string IDString = "";
            string temp = "";

            Random rand = new Random();

            for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                IDString += temp;
                NewPassword = IDString;

            }
            return NewPassword;
        }

        //for mail
        public static Boolean sent_mail(string mail_id,string subject,string body,bool flag)
        {
            //string html = File.ReadAllText(Server.MapPath("~/HtmlPage1.html"));K //Convert HTML to String
            string strNewPassword = GeneratePassword().ToString();

           
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("sisprojectcollab@gmail.com");
            msg.To.Add(mail_id);
            msg.Subject = subject;
            if(flag)
            {
                msg.Body = "Your OTP is: " + strNewPassword; /*+ html;*/
            }
            else
            {
                msg.Body = body;/*"Your OTP is: " + strNewPassword +html;*/
            }

            
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
            
            try
            {
                smt.Send(msg);
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        public static Boolean mysent_mail(string mail_id,string subject,string otp)
        {
            //string html = File.ReadAllText(Server.MapPath("~/HtmlPage1.html"));K //Convert HTML to String
            string strNewPassword = GeneratePassword().ToString();

           
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("sisprojectcollab@gmail.com");
            msg.To.Add(mail_id);
            msg.Subject = subject;
            
            msg.Body = "Your OTP is: " + otp; /*+ html;*/
            
            

            
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
            
            try
            {
                smt.Send(msg);
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        public static int productSoldQtyByProductId(int pid)
        {
            Config.con = FunctionInc.connection();

            string q= "select sum(order_detail.qty) as qty from order_detail,order_master where order_master.id=order_detail.order_id and order_detail.product_id='"+pid.ToString()+ "' and order_master.order_status != '4' and ((order_master.payment_type='payu' and order_master.payment_status='success') or (order_master.payment_type='cod' and order_master.payment_status!=''))";
            SqlDataAdapter adp = new SqlDataAdapter(q, Config.con);
            DataTable dt=new DataTable();
            adp.Fill(dt);
            int p=Convert.ToInt32(dt.Rows.Count.ToString());
            if(p>0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
            {
                foreach(DataRow dr in dt.Rows)
                {
                    return Convert.ToInt32(dr["qty"].ToString());
                }
            }
            else
            {
                return 0;
                //return Convert.ToInt32(dr["qty"].ToString());
            }
            return 0;
        }
        
        public static int productTotalQtyByProductId(int pid)
        {
            Config.con = FunctionInc.connection();

            string q= "select qty from product where id='"+pid+"'";
            SqlDataAdapter adp = new SqlDataAdapter(q, Config.con);
            DataTable dt=new DataTable();
            adp.Fill(dt);
            int p=Convert.ToInt32(dt.Rows.Count.ToString());
            if(p>0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
            {
                foreach(DataRow dr in dt.Rows)
                {
                    return Convert.ToInt32(dr["qty"].ToString());
                }
            }
            else
            {
                return 0;
                //return Convert.ToInt32(dr["qty"].ToString());
            }
            return 0;
        }

        
        //SqlCommand cmd = con.CreateCommand();
        //cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "select * from librarian_registration where username='"+username.Text+"' and password='"+password.Text+"'";
        //    cmd.ExecuteNonQuery();

        //    DataTable dt = new DataTable();
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //da.Fill(dt);
        //    int i = Convert.ToInt32(dt.Rows.Count.ToString());

        //    if(i>0)
        //    {
        //        Response.Redirect("demo.aspx");
        //    }
        //    else
        //    {
        //        error.Style.Add("display", "block");
        //    }


        //               if (con.State == ConnectionState.Open)
        //            {
        //                con.Close();
        //            }
        //    con.Open();

        //            if (IsPostBack) return;

        //            SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = "select * from penalty";
        //            cmd.ExecuteNonQuery();
        //            DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);
        //            foreach(DataRow dr in dt.Rows)
        //            {
        //                penalty.Text = dr["penalty"].ToString();
        //}
    }
}