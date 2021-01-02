using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Demo.WebUI.Ultilities
{
    public class EmailSender
    {
        public void Send(string subject, string body, string receiver)
        {
            try 
            {
                //SMTP protocol: giao thức gửi mail 1 chiều
                //POP3 gửi và nhận mail
                using (SmtpClient sender = new SmtpClient("smtp.gmail.com")) //xài using đểg khi gởi xong thì giải phóng tham số tuyền vài tùy dạng mail vd:smtp.yahoo.com
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("trieunguyen.03072000@gmail.com");
                    mail.To.Add(receiver);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true; // để mail hiểu dạng html nếu không nó in thẻ ra vd table
                    sender.Port = 587;
                    //gmail app password
                    sender.Credentials = new System.Net.NetworkCredential("trieunguyen.03072000@gmail.com", "frixnkhtxylydnxt");
                    sender.EnableSsl = true;
                    sender.Send(mail);
                }    

            }
            catch(Exception ex)
            {
                throw new Exception("gửi Email bị lỗi :" + ex.Message);
            }
        }
    }
}