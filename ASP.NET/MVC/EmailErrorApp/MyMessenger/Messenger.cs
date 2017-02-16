using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyMessenger
{
    public class Messenger : IDisposable
    {
        bool isDisposed = false;

        MailMessage _mail;
        SmtpClient _smtpServer;

        const string HOST = "smtp.mail.ru";
        const string USER_NAME = "*****@mail.ru";
        const int PORT = 587;
        const string SMTP_NODE = "smtp.mail.ru";

        public Messenger()
        {
            _mail = new MailMessage();
            _smtpServer = new SmtpClient(SMTP_NODE);
            _smtpServer.Credentials = new System.Net.NetworkCredential(USER_NAME, "**password**");
            _smtpServer.EnableSsl = true;
            _smtpServer.Port = PORT;
        }

        public void SendErrorMessage(string errorMessage, string mailTo)
        {
            if (isDisposed) { throw new ObjectDisposedException("the messenger has been disposed."); }

            _mail.From = new MailAddress(USER_NAME);
            _mail.To.Add(mailTo);
            _mail.Subject = "Error message in your webApp";
            _mail.Body = errorMessage;

            _smtpServer.Send(_mail);
        }

        private void CleanUp()
        {
            if (!isDisposed)
            {
                _smtpServer?.Dispose();
                _smtpServer = null;

                _mail?.Dispose();
                _mail = null;

                isDisposed = true;
            }
        }

        public void Dispose()
        {
            CleanUp();
            GC.SuppressFinalize(this);
        }

        ~Messenger()
        {
            CleanUp();
        }
    }
}
