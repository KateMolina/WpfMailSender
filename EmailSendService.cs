using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace WpfTestMailSender
{
    class EmailSendService
    {
        List<string> to;
        string from;
        string bodyText;
        string subject;
        string password;

        public EmailSendService(List<string> to, string from, string text, string subject, string pass)
        {
            this.to = to;
            this.from = from;
            bodyText = text;
            this.subject = subject;
            password = pass;
        }

        public void SendEmail()
        {
            foreach (string mail in to)
            {
                using (MailMessage mm = new MailMessage(from, mail, subject, bodyText))
                {
                    mm.IsBodyHtml = false;
                    using (SmtpClient sc = new SmtpClient(DataSet.server, DataSet.port))
                    {
                        sc.EnableSsl = true;
                        sc.UseDefaultCredentials = false;
                        sc.Credentials = new NetworkCredential(from, password);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (SmtpException ex)
                        {
                            throw new SmtpException(ex.Message);
                        }
                    }
                }
            }
        }

    }
}
