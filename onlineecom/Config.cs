using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace onlineecom.admin
{
    public class Config
    {
        //constant 
        public static string SERVER_PATH = HttpContext.Current.Request.PhysicalApplicationPath;
        public static string SITE_PATH = "https://localhost:44326/";

        public static string PRODUCT_IMAGE_SERVER_PATH = SERVER_PATH +"/media/product/";//209,178-manageproduct.aspx.cs
        public static string PRODUCT_IMAGE_SITE_PATH = SITE_PATH + "media/product/";//product.aspx-47,


        public static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LJUF3KB;Initial Catalog=test;Integrated Security=True");
        public static SqlCommand cmd ;
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static string q;

        //***********1 insert update delete
        //    s = "insert into tbl_student values('"+txtid.Text+"','"+txtname.Text+"','"+txtaddress.Text+"')";

        //        cmd = new SqlCommand(s, con);

        //    con.Open();
        //        int d = cmd.ExecuteNonQuery();

        //        if (d > 0)
        //        {
        //            txtid.Clear();
        //            txtname.Text = "";
        //            txtaddress.Text = "";
        //            MessageBox.Show("inserted successfully!");
        //        }
        //con.Close();
        //-----------------------------

        //SqlCommand cmd = con.CreateCommand();
        //cmd.CommandText = CommandType.Text.ToString();
        //        cmd.CommandText = "update books set books_video='' where id='"+Request.QueryString["id"].ToString()+"'";
        //        cmd.ExecuteNonQuery();


        //***********select

        //s = "select * from tbl_student where id='"+txtid.Text+"'";

        //    SqlDataAdapter adp = new SqlDataAdapter(s, con);

        //DataTable dt = new DataTable();

        //adp.Fill(dt);

        //    txtid.Text=dt.Rows[0][0].ToString();
        //txtname.Text = dt.Rows[0][1].ToString();
        //txtaddress.Text = dt.Rows[0][2].ToString();

        //********************************************
        //SqlCommand cmd2 = con.CreateCommand();
        //cmd2.CommandType = CommandType.Text;
        //    cmd2.CommandText = "select * from penalty";
        //    cmd2.ExecuteNonQuery();
        //    DataTable dt2 = new DataTable();
        //SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        //da2.Fill(dt2);
        //    foreach (DataRow dr2 in dt2.Rows)
        //    {
        //        penalty = dr2["penalty"].ToString();
        //}

        //-----------------------------------------------------------
        //        int count = 0;
        //        SqlCommand cmd = con.CreateCommand();
        //        cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = "select * from penalty";
        //            cmd.ExecuteNonQuery();
        //            DataTable dt = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //            count=Convert.ToInt32(dt.Rows.Count.ToString());
        //            if (count == 0)
        //            {
        //                SqlCommand cmd1 = con.CreateCommand();
        //        cmd1.CommandType = CommandType.Text;
        //                cmd1.CommandText = "insert into penalty values('"+penalty.Text+"')";
        //                cmd1.ExecuteNonQuery();
        //            }
        //            else
        //            {
        //                SqlCommand cmd1 = con.CreateCommand();
        //    cmd1.CommandType = CommandType.Text;
        //                cmd1.CommandText = "update penalty set penalty='"+penalty.Text+"'";
        //                cmd1.ExecuteNonQuery();
        //            }

        //Response.Redirect("add_penalty.aspx");


        //Response.Write("<script>alert('deleted successfully');</script>");
        //Response.Write("<script>alert('please select books'); window.location.href=window.location.href;</script>");

        //pass value to javascript function
        //onclick='<%# "PopulateTicketDiv(" +Eval("SHOW_ID") + " );" %>'
        //onclick="<%# "manage_cart(" +Eval("product_id") + ",'remove');" %>">
        //<%# Convert.ToInt32(DataBinder.Eval(Container.DataItem, "qty")) * Convert.ToInt32(DataBinder.Eval(Container.DataItem, "price")) %> 
        //<%# Eval("product_id") %>qty
        //onchange="<%# "sort_product_dropdown(" +Eval("categories_id") + ")" %>" 


        //-------------------------------------
        //query string data validation
        //int value;
        ////Try converting the value to integer
        //bool isValueNumeric = int.TryParse(Request.QueryString["id"], out value);

        //    if (!String.IsNullOrEmpty(Request.QueryString["id"]) && /*here*/isValueNumeric && Convert.ToInt64(Request.QueryString["id"]) > 0)
        //    {


        //----------------------------------------display none for error
        //<div class="alert alert-success" id="msg" runat="server" style="margin-top:10px; display:none;" >
        //    <strong>Your books added successfully.</strong>
        //</div>
        //backend msg.Style.Add("display", "block");
        //address_information.Style.Add("display", "none");
        //lblWithoutClass.Attributes.Add("class", "ClassJoined");
        //lblMessage.CssClass = "LabelGrey";

        //for meta title and description
        //string rest = string.Join(" ", arr.Skip(1));
        //string fullPageName = Path.GetFileName(Request.Path);
        //var arr = fullPageName.Split('.');
        //string pageName = arr[0].ToString();
            
        //title.InnerText = dr["meta_title"].ToString();
        
                    


    }
}