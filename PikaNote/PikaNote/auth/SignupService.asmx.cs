using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

namespace PikaNote.auth
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class SignupService : System.Web.Services.WebService
    {
        private String strConnect = ConfigurationManager.ConnectionStrings["ketnoi"].ConnectionString;

        [WebMethod]
        public String AddAccount(Signup signup)
        {
            String res = "Success";
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                String strSqlCheckAccount = "select * from dangnhap where tendangnhap = @tenDN";
                String strSqlAddAccount = "Insert dangnhap select @tenDN, @pw";
                String strSqlAddInfoAccount = "Insert thongtinnguoidung(TENNGUOIDUNG, EMAIL, SDT, MADN) values (N''+ @tenND +'', @email, @sdt, @maDN)";
                String strSqlGetMaDN = "Select MA from dangnhap where tendangnhap = @tenDN";

                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.CommandText = strSqlCheckAccount;
                sqlCMD.Parameters.AddWithValue("@tenDN", signup.Username);

                sqlCMD.Connection = conn;
                conn.Open();
                SqlDataReader sdr = sqlCMD.ExecuteReader();
                if (sdr.Read())
                {
                    // da co account 
                    res = "username";
                }
                else
                {
                    sdr.Close();
                    // chua co account
                    sqlCMD.CommandText = strSqlAddAccount;
                    sqlCMD.Parameters.AddWithValue("@pw", signup.Password);
                    if (sqlCMD.ExecuteNonQuery() > 0)
                    {
                        sqlCMD.CommandText = strSqlGetMaDN;
                        sdr = sqlCMD.ExecuteReader();
                        sdr.Read();
                        int ma = Int32.Parse(sdr["MA"].ToString());
                        sdr.Close();

                        sqlCMD.CommandText = strSqlAddInfoAccount;
                        sqlCMD.Parameters.AddWithValue("@tenND", signup.Name);
                        sqlCMD.Parameters.AddWithValue("@email", signup.Email);
                        sqlCMD.Parameters.AddWithValue("@sdt", signup.Tel);
                        sqlCMD.Parameters.AddWithValue("@maDN", ma);

                        if (sqlCMD.ExecuteNonQuery() < 0)
                            res = "fail";
                    }
                    else res = "fail";
                }
            }
            return res;
        }
    }
}
