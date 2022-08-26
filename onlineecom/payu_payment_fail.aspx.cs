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
    public partial class payu_payment_fail : System.Web.UI.Page
    {
        string pay_id;
        string status;
        string txnid;
        protected void Page_Load(object sender, EventArgs e)
        {

            pay_id = Request.Form["mihpayid"];
            status = Request.Form["status"];
            txnid = Request.Form["txnid"];
            //if (Session["USER_LOGIN"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}
            string q = "update order_master set payment_status='" + status + "',mihpayid='" + pay_id + "' where txnid='" + txnid + "'";
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
            //lbl_transactionid.Text = "Transaction ID:" + Request.Form["txnid"] + "has been failed";
        }
    }
}