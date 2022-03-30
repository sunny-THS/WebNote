using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

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
            String strUserName = this.floatingInputSignin.Text.Trim();
            String strPw = Hash.ComputeSha256Hash(this.floatingPasswordSignin.Text);
            if (strUserName.Equals("") || this.floatingPasswordSignin.Text.Trim().Equals(""))
            {
                String strb = "Toast.fire({icon: 'warning', title: 'Vui lòng điền đủ thông tin đăng nhập' })";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", strb, true);
                return;
            }
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

        protected void btnForgotPW_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                String strSqlCheckLogin = "select * from dangnhap join thongtinnguoidung ttnd on dangnhap.ma=ttnd.madn where tendangnhap = @tenDN";

                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.CommandText = strSqlCheckLogin;
                sqlCMD.Parameters.AddWithValue("@tenDN", this.floatingUsernameForgotPW.Text.Trim());

                sqlCMD.Connection = conn;
                conn.Open();
                SqlDataReader sdr = sqlCMD.ExecuteReader();
                if (sdr.Read())
                {
                    Session["idUser"] = sdr["ma"].ToString();
                    Session["user"] = this.floatingUsernameForgotPW.Text.Trim();
                    Session["emailAddress"] = sdr["email"].ToString();
                    Response.Redirect("ForgetPassword.aspx");
                }
                else
                {
                    String strb = "Toast.fire({icon: 'error', title: 'Không có tên đăng nhặp này. Vui lòng kiểm tra lại' })";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", strb, true);
                    this.floatingUsernameForgotPW.Text = "ex: username";
                }
            }
        }
    }
}