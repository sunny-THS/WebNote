using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

namespace PikaNote.view
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class NoteService : System.Web.Services.WebService
    {
        private String strConnect = ConfigurationManager.ConnectionStrings["ketnoi"].ConnectionString;

        [WebMethod]
        public List<Note> getCard(String TenDN)
        {
            List<Note> lstNote = new List<Note>();
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                String strSqlCheckAccount = "select * from note join content_plaintext cp on note.ma=cp.manote where TinhTrang is NULL and madn = (select ma from dangnhap where tendangnhap=@user)";
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = strSqlCheckAccount;
                sqlCmd.Parameters.AddWithValue("@user", TenDN.Split('-')[1].Trim());
                sqlCmd.Connection = conn;

                conn.Open();
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                while (sdr.Read())
                {
                    lstNote.Add(new Note(Int32.Parse(sdr["ma"].ToString()), sdr["Title"].ToString(), sdr["TinhTrang"].ToString(), DateTime.Parse(sdr["NgayTao"].ToString()), Int32.Parse(sdr["maDN"].ToString()), sdr["NoiDung"].ToString()));
                }
            }
            return lstNote;
        }
        [WebMethod]
        public List<Note> getCard_Storage(String TenDN)
        {
            List<Note> lstNote = new List<Note>();
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                String strSqlCheckAccount = "select * from note join content_plaintext cp on note.ma=cp.manote where TinhTrang='Storage' and madn = (select ma from dangnhap where tendangnhap=@user)";
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = strSqlCheckAccount;
                sqlCmd.Parameters.AddWithValue("@user", TenDN.Split('-')[1].Trim());
                sqlCmd.Connection = conn;

                conn.Open();
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                while (sdr.Read())
                {
                    lstNote.Add(new Note(Int32.Parse(sdr["ma"].ToString()), sdr["Title"].ToString(), sdr["TinhTrang"].ToString(), DateTime.Parse(sdr["NgayTao"].ToString()), Int32.Parse(sdr["maDN"].ToString()), sdr["NoiDung"].ToString()));
                }
            }
            return lstNote;
        }
        [WebMethod]
        public List<Note> getCard_Recycle(String TenDN)
        {
            List<Note> lstNote = new List<Note>();
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                String strSqlCheckAccount = "select * from note join content_plaintext cp on note.ma=cp.manote where TinhTrang='Recycle' and madn = (select ma from dangnhap where tendangnhap=@user)";
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = strSqlCheckAccount;
                sqlCmd.Parameters.AddWithValue("@user", TenDN.Split('-')[1].Trim());
                sqlCmd.Connection = conn;

                conn.Open();
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                while (sdr.Read())
                {
                    lstNote.Add(new Note(Int32.Parse(sdr["ma"].ToString()), sdr["Title"].ToString(), sdr["TinhTrang"].ToString(), DateTime.Parse(sdr["NgayTao"].ToString()), Int32.Parse(sdr["maDN"].ToString()), sdr["NoiDung"].ToString()));
                }
            }
            return lstNote;
        }
        [WebMethod]
        public String editCard(Note note)
        {
            String res = "success";
            int upNote = -1;

            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                String strSqlEditTitleNote = "Update Note set Title=N''+ @titleNote +'' where ma=@ma";
                String strSqlEditContentNote = "Update content_plaintext set NoiDung=N''+@contentNote+'' where maNote=@ma";

                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.CommandText = strSqlEditTitleNote;
                sqlCMD.Parameters.AddWithValue("@ma", Int32.Parse(note.Id.ToString()));
                sqlCMD.Parameters.AddWithValue("@titleNote", note.Title);
                sqlCMD.Connection = conn;
                conn.Open();
                try
                {
                    upNote = sqlCMD.ExecuteNonQuery();

                    sqlCMD.CommandText = strSqlEditContentNote;
                    sqlCMD.Parameters.AddWithValue("@contentNote", note.Content);
                    upNote = sqlCMD.ExecuteNonQuery();

                    if (upNote < 0) res = "fail";
                }
                catch (Exception e)
                {
                    res = e.ToString();
                }
            }
            return res;
        }
        [WebMethod]
        public String removeCard(int id)
        {
            String res = "success";
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                String strSqlUpTT = "Update note set tinhTrang='Recycle' where ma=@maNote";
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = strSqlUpTT;
                sqlCmd.Parameters.AddWithValue("@maNote", id);
                sqlCmd.Connection = conn;

                conn.Open();
                try
                {
                    int upTT = sqlCmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    res = e.ToString();
                }
            }
            return res;
        }
        [WebMethod]
        public String storageCard(int id)
        {
            String res = "success";
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                String strSqlUpTT = "Update note set tinhTrang='Storage' where ma=@maNote";
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = strSqlUpTT;
                sqlCmd.Parameters.AddWithValue("@maNote", id);
                sqlCmd.Connection = conn;

                conn.Open();
                try
                {
                    int upTT = sqlCmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    res = e.ToString();
                }
            }
            return res;
        }
        [WebMethod]
        public String defaultCard(int id)
        {
            String res = "success";
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                String strSqlUpTT = "Update note set tinhTrang=NULL where ma=@maNote";
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = strSqlUpTT;
                sqlCmd.Parameters.AddWithValue("@maNote", id);
                sqlCmd.Connection = conn;

                conn.Open();
                try
                {
                    int upTT = sqlCmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    res = e.ToString();
                }
            }
            return res;
        }
        [WebMethod]
        public String DeleteCard(int id)
        {
            String res = "success";
            using (SqlConnection conn = new SqlConnection(strConnect))
            {
                String strSqlDelTT = "Delete note where ma=@maNote";
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = strSqlDelTT;
                sqlCmd.Parameters.AddWithValue("@maNote", id);
                sqlCmd.Connection = conn;

                conn.Open();
                try
                {
                    int del = sqlCmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    res = e.ToString();
                }
            }
            return res;
        }
    }
}
