using onlineecom.admin;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.Net;

namespace onlineecom
{
    public partial class payu_payment_complete : System.Web.UI.Page
    {
        string payment_mode ;
        string pay_id;
        string status ;
        string firstname ;
        string amount ;
        string txnid ;
        string posted_hash ;
        string key ;
        string productinfo;
        string email ;
        string MERCHANT_KEY;
        string salt;
        string udf5 ;
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //if (Session["USER_LOGIN"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}

            payment_mode = Request.Form["mode"];
            pay_id = Request.Form["mihpayid"];
            status = Request.Form["status"];
            firstname = Request.Form["firstname"];
            amount = Request.Form["amount"];
            txnid = Request.Form["txnid"];
            posted_hash= Request.Form["hash"];
            key = Request.Form["key"];
            productinfo = Request.Form["productinfo"];
            email = Request.Form["email"];
            MERCHANT_KEY = "gtKFFx"; 
            salt = "wia56q6O";
            udf5 = "";

            //MARCHANT_KEY = "gtKFFx";//
            //key = MARCHANT_KEY;//
            //salt = "wia56q6O";

            //string text = key.ToString() + "|" + txnid.ToString() + "|" + amount + "|" + productinfo.ToString() + "|" + firstname.ToString() + "|"
            //    + email.ToString() + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "||||||" + salt.ToString();


            ////to encode the string 
            //string newtext=salt+"|"+status+"|"+"|||||"+udf5+"|||||"+email+"|"+firstname+"|"+productinfo+"|"+amount+"|"+txnid+"|"+MERCHANT_KEY;
            //byte[] message = Encoding.UTF8.GetBytes(newtext);

            ////UnicodeEncoding UE = new UnicodeEncoding();

            //SHA512Managed hashString = new SHA512Managed();
            //string hex = "";
            //byte[] hashValue = hashString.ComputeHash(message);
            //foreach (byte x in hashValue)
            //{
            //    hex += String.Format("{0:x2}", x);
            //}

            string q;
            if (status == "success")
            {
                q = "update order_master set payment_status='" + status + "',mihpayid='" + pay_id + "' where txnid='" + txnid + "'";
                Config.cmd = new SqlCommand(q, Config.con);

                int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                if (i > 0)
                {
                    
                    
                    //Response.Write("<script>alert('Data inserted Successfully');</script>");
                    Response.Redirect("thank_you.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Data not updated Successfully.');</script>");
                }
            }
            else
            {
                 q = "update order_master set payment_status='"+status+"',mihpayid='"+ pay_id + "' where txnid='"+txnid+"'";
                Config.cmd = new SqlCommand(q, Config.con);

                int i = Convert.ToInt32(Config.cmd.ExecuteNonQuery());
                if (i > 0)
                {

                    //Response.Write("<script>alert('Data inserted Successfully');</script>");
                    Response.Redirect("payu_payment_fail.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Data not updated Successfully.');</script>");
                }
            }
        

        }

        
    }
}