using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace PikaNote
{
    public partial class masterPage : System.Web.UI.MasterPage
    {
        private String strConnect = ConfigurationManager.ConnectionStrings["ketnoi"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }
        public void loadData()
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
                    string path;
                    var pathFile = "../image/";

                    var imgBackGround = sdr["background"].ToString();
                    if (imgBackGround.Equals(""))
                        this.body.Style.Add("background", "var(--bs-dark)");
                    else
                    {
                        path = Server.MapPath(pathFile + imgBackGround);

                        this.body.Style.Add("background-image", view.convertImage.ConvertIMG(path));
                    }
                    path = Server.MapPath(pathFile + sdr["avt"].ToString());

                    this.ImageUser.ImageUrl = view.convertImage.ConvertIMG(path);
                    this.logoUser.Attributes.Add("title", sdr["tennguoidung"].ToString() + " - " + Session["user"].ToString());
                }
            }
        }
    }
}