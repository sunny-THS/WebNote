using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace PikaNote
{
    public partial class masterPage : System.Web.UI.MasterPage
    {
        private String strConnect = ConfigurationManager.ConnectionStrings["ketnoi"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                String strSqlGetInfo = "select * from thongtinnguoidung where madn = @ma";
                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.CommandText = strSqlGetInfo;
                sqlCMD.Parameters.AddWithValue("@ma", Int32.Parse(Session["idUser"].ToString()));
                sqlCMD.Connection = conn;

                conn.Open();

                SqlDataReader sdr = sqlCMD.ExecuteReader();
                if (sdr.Read())
                {
                    this.body.Style.Add("background-image", "../image/" + sdr["background"].ToString());
                    this.ImageUser.ImageUrl = "~/image/" + sdr["avt"].ToString();
                    this.logoUser.Attributes.Add("title", sdr["tennguoidung"].ToString());
                }
            }
        }
    }
}