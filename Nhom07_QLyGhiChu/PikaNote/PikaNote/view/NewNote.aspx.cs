using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PikaNote.view
{
    public partial class NewNote : System.Web.UI.Page
    {
        private String strConnect = ConfigurationManager.ConnectionStrings["ketnoi"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnXN_Click(object sender, EventArgs e)
        {
            var titleNote = this.floatingTitleNote.Text;
            var contentNote = this.floatingContentNote.Text;
            if (!titleNote.Trim().Equals("") || !contentNote.Trim().Equals(""))
            {
                using (SqlConnection conn = new SqlConnection(strConnect))
                {
                    SqlCommand sqlCMD = new SqlCommand("spAddNote", conn);
                    sqlCMD.CommandType = CommandType.StoredProcedure;

                    SqlParameter paraTitleNote = new SqlParameter()
                    {
                        ParameterName = "@Title",
                        Value = titleNote
                    };
                    sqlCMD.Parameters.Add(paraTitleNote);

                    SqlParameter paraCodeDN = new SqlParameter()
                    {
                        ParameterName = "@CodeDN",
                        Value = Int32.Parse(Session["idUser"].ToString())
                    };
                    sqlCMD.Parameters.Add(paraCodeDN);

                    SqlParameter paraContentNote = new SqlParameter()
                    {
                        ParameterName = "@ContentCard",
                        Value = contentNote
                    };
                    sqlCMD.Parameters.Add(paraContentNote);

                    SqlParameter paraId = new SqlParameter()
                    {
                        ParameterName = "@NewId",
                        Value = -1,
                        Direction = ParameterDirection.Output
                    };
                    sqlCMD.Parameters.Add(paraId);

                    conn.Open();
                    sqlCMD.ExecuteNonQuery();
                }
                Response.Redirect("~/view/Home.aspx");
            }
            else
            {
                String strb = "Toast.fire({icon: 'warning', title: 'Vui lòng nhập tiêu đề hoặc nội dung của ghi chú' })";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", strb, true);
            }
        }
    }
}