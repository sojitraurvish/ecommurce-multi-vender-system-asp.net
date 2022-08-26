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
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Config.con = FunctionInc.connection();
            if (Session["USER_LOGIN"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (IsPostBack) return;
        }
    }
}