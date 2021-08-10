using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace PikaNote.view
{
    public partial class Profile : System.Web.UI.Page
    {
        private String strConnect = ConfigurationManager.ConnectionStrings["ketnoi"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData(); 
            }
        }
        private void loadData()
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
                    var imgBackGround = sdr["background"].ToString();
                    if (imgBackGround.Equals(""))
                        this.imgBG.ImageUrl = "";
                    else
                        this.imgBG.ImageUrl = "~/image/" + imgBackGround;
                    this.imgUserProfile.ImageUrl = "~/image/" + sdr["avt"].ToString();
                    this.floatingName.Text = sdr["tennguoidung"].ToString();
                    this.floatingEmail.Text = sdr["email"].ToString();
                    this.floatingSDT.Text = sdr["sdt"].ToString();
                }
            }
        }
        protected void btnSaveUserProfile_Click(object sender, EventArgs e)
        {
            var nameBG = this.imgBG.ImageUrl.Equals("") ? "" : this.imgBG.ImageUrl.Substring(this.imgBG.ImageUrl.LastIndexOf("/") + 1);
            var nameAVT = this.imgUserProfile.ImageUrl.Substring(this.imgUserProfile.ImageUrl.LastIndexOf("/") + 1);
            var tenNguoiDung = this.floatingName.Text;
            var email = this.floatingEmail.Text;
            var sdt = this.floatingSDT.Text;

            if (Page.IsValid)
            {
                if (this.imgFileUploadBackground.HasFile)
                {
                    nameBG = Session["idUser"].ToString() + "_" + Session["user"].ToString() + "_" + "_bg" + Path.GetExtension(this.imgFileUploadBackground.FileName);
                    string filePath = MapPath("/image/" + nameBG);
                    imgFileUploadBackground.SaveAs(filePath);
                }

                if (this.imgFileUploadProFile.HasFile)
                {
                    nameAVT = Session["idUser"].ToString() + "_" + Session["user"].ToString() + "_" + "_avt" + Path.GetExtension(this.imgFileUploadProFile.FileName);
                    string filePath = MapPath("/image/" + nameAVT);
                    imgFileUploadProFile.SaveAs(filePath);
                }
            }
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                String strSqlUDInfo = "Update thongtinnguoidung set tennguoidung=N''+@name+'', email=@email, sdt=@sdt, avt=@avt, background=@bg where madn = @ma";
                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.CommandText = strSqlUDInfo;
                sqlCMD.Parameters.AddWithValue("@ma", Int32.Parse(Session["idUser"].ToString()));
                sqlCMD.Parameters.AddWithValue("@name", tenNguoiDung);
                sqlCMD.Parameters.AddWithValue("@email", email);
                sqlCMD.Parameters.AddWithValue("@sdt", sdt);
                sqlCMD.Parameters.AddWithValue("@avt", nameAVT);
                sqlCMD.Parameters.AddWithValue("@bg", nameBG);
                sqlCMD.Connection = conn;

                conn.Open();

                sqlCMD.ExecuteNonQuery();
            }
            Response.Redirect("Profile.aspx");
        }
    }
}