using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;

namespace PikaNote.auth
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class MailService : System.Web.Services.WebService
    {

        [WebMethod]
        public static int sendMail(String _to) // trả về mã xác nhận của bạn
        {
            using (SmtpClient client = new SmtpClient())
            {
                String _from = "noreply.pikanote@gmail.com";
                String _subject = "Mã Xác Nhận Email";
                String _body = "Mã xác nhận của bạn: ";

                return SendMail(_from, _to, _subject, _body, client);
            }
        }
        public static int SendMail(string _from, string _to, string _subject, string _body, SmtpClient client)
        {
            Random _r = new Random();
            int code = _r.Next(1000000, 9999999);
            // Tạo nội dung Email
            MailMessage message = new MailMessage(_from, _to);
            message.Subject = _subject;
            message.Body = _body + "<span style='font-size:1.5rem; font-weight:bold;'>" + code.ToString() + "</span>";

            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            try
            {
                client.Send(message);
                return code;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
