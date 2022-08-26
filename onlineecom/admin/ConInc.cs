using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace onlineecom.admin
{
    public class C 
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-LJUF3KB;Initial Catalog=test;Integrated Security=True");
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static string q;


        //************insert update delate********************

        //    s = "delete from tbl_student where id='"+txtid.Text+"'";

        //        cmd = new SqlCommand(s, con);

        //    con.Open();
        //        int d = cmd.ExecuteNonQuery();

        //        if (d > 0)
        //        {
        //            txtid.Clear();
        //            txtname.Clear();
        //            txtaddress.Clear();
        //            MessageBox.Show("deleted successfully!");
        //        }
        //con.Close();
        //---------------2 libary
        //public static SqlCommand cmd = con.CreateCommand();
        //cmd.CommandType=CommandType;
        //cmd.CommandText = "select * from librarian_registration where username='"+username.Text+"' and password='"+password.Text+"'";
        //cmd.ExecuteNonQuery();

        //public static DataTable dt = new DataTable();
        //public static SqlDataAdapter da = new SqlDataAdapter(cmd);
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


        //******************** select queary ********************

        //s = "select * from tbl_student where id='"+txtid.Text+"'";

        //    SqlDataAdapter adp = new SqlDataAdapter(s, con);

        //DataTable dt = new DataTable();

        //adp.Fill(dt);

        //    txtid.Text=dt.Rows[0][0].ToString();
        //txtname.Text = dt.Rows[0][1].ToString();
        //txtaddress.Text = dt.Rows[0][2].ToString();
        //---------------2 library-------------------------
        //SqlCommand cmd =con.CreateCommand();
        //cmd.CommandType = CommandType.Text;
        //cmd.CommandText = "select * from categories order by categories desc";
        //cmd.ExecuteNonQuery();

        //DataTable dt = new DataTable();
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //da.Fill(dt);
        //r1.DataSource = dt;
        //r1.DataBind();




    }
}