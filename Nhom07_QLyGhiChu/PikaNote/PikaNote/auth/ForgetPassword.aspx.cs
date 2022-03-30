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
    public partial class ForgetPassword : System.Web.UI.Page
    {
        private static int codeXN;
        private String strConnect = ConfigurationManager.ConnectionStrings["ketnoi"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                String strEmail = Session["emailAddress"].ToString();
                MailService msc = new MailService();
                codeXN = msc.sendMail(strEmail);
                this.floatingEmailXN.Text = Session["emailAddress"].ToString();
            }
        }

        protected void btnXn_Click(object sender, EventArgs e)
        {
            if (codeXN != int.Parse(this.floatingMXNForgorPw.Text)) // check mã xác nhận
            {
                String strb = "Toast.fire({icon: 'error', title: 'Mã xác nhận không chính xác. Vui lòng kiểm tra lại' })";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", strb, true);
                return;
            }
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                String strSqlChangePw = "Update dangnhap set matkhau = @pw where tendangnhap = @tendn";

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strSqlChangePw;
                sqlCommand.Parameters.AddWithValue("@tendn", Session["user"].ToString());
                sqlCommand.Parameters.AddWithValue("@pw", Hash.ComputeSha256Hash(this.floatingPasswordNew.Text));
                sqlCommand.Connection = conn;

                conn.Open();

                sqlCommand.ExecuteNonQuery();
            }
            Response.Redirect("Signin.aspx");
        }
    }
}