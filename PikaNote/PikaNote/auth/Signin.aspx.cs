using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;

namespace PikaNote.auth
{
    public partial class Signup1 : System.Web.UI.Page
    {
        private String strConnect = ConfigurationManager.ConnectionStrings["ketnoi"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            String strUserName = this.floatingInputSignin.Text;
            String strPw = ComputeSha256Hash(this.floatingPasswordSignin.Text);
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                String strSqlCheckLogin = "select * from dangnhap where tendangnhap = @tenDN and matkhau = @pw";

                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.CommandText = strSqlCheckLogin;
                sqlCMD.Parameters.AddWithValue("@tenDN", strUserName);
                sqlCMD.Parameters.AddWithValue("@pw", strPw);

                sqlCMD.Connection = conn;
                conn.Open();
                SqlDataReader sdr = sqlCMD.ExecuteReader();
                if (sdr.Read())
                {
                    Session["idUser"] = sdr["ma"].ToString();
                    Session["userName"] = strUserName;
                    Session["user"] = strUserName;
                    Response.Redirect("../view/Home.aspx");
                }
                else
                {
                    String strb = "Toast.fire({icon: 'error', title: 'Thông tin đăng nhập không chính xác' })";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", strb, true);
                }
            }
        }
        static String ComputeSha256Hash(String rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}