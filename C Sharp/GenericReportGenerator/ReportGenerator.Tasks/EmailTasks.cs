using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailTools;

namespace ReportGenerator.Tasks
{
    public class EmailTasks
    {
        private IMailProvider _mailProv;
        private string _timeStamp;

        private List<EmailName> _emailErrorAddressList;
        private string _emailErrorSubject;

        private List<EmailName> _emailAddressList;
        private string _emailSubject;
        private string _emailMessage;

        public EmailTasks()
            : this(new SmtpMailProvider())
        { }

        public EmailTasks(IMailProvider mailProv)
        {
            _mailProv = mailProv;
            _emailErrorAddressList = CreateErrorEmailListFromAppConfig();
            _emailErrorSubject = ConfigurationManager.AppSettings["ErrorEmailSubject"];

            string numberDay = DateTime.Now.Day.ToString().PadLeft(2, '0');
            string numberMonth = DateTime.Now.Month.ToString().PadLeft(2, '0');
            string numberYear = DateTime.Now.Year.ToString();
            _timeStamp = String.Format("{0}/{1}/{2}", numberMonth, numberDay, numberYear);

            _emailAddressList = CreateEmailListFromAppConfig();
            _emailSubject = ConfigurationManager.AppSettings["EmailSubject"];
        }

        public void EmailAttachmentToEmailList(FileInfo attachment)
        {
            var subject = String.Format("{0}, {1}", _emailSubject, _timeStamp);
            var msgBody = String.Format("Please find {0} for {1} attached.", _emailSubject, _timeStamp);

            foreach (var recipient in _emailAddressList)
            {
                SendEmail(recipient, attachment, subject, msgBody);
            }
        }

        public void SendErrorEmails(string errorStep, string error)
        {
            var subject = String.Format("{0}. {1}", _emailErrorSubject, _timeStamp);
            var msgBody = String.Format("The report did not generate successfully. Error occurred during the {0} step. {1} {2}Error Stack Trace: {3}{4} {5}.", errorStep, Environment.NewLine, Environment.NewLine, Environment.NewLine, Environment.NewLine, error);

            foreach (var recipient in _emailErrorAddressList)
            {
                SendEmail(recipient, subject, msgBody);
            }
        }

        public void SendEmail(EmailName recipient, string sub, string body)
        {
            var msg = CreateMessage(recipient, sub, body);
            _mailProv.SendMessage(msg);
        }

        public void SendEmail(EmailName recipient, FileInfo attachment, string sub, string body)
        {
            var fileStream = new FileStream(attachment.FullName, FileMode.Open, FileAccess.Read);
            var msg = CreateMessage(recipient, fileStream, sub, body);
            _mailProv.SendMessage(msg);
        }

        private MailNote CreateMessage(EmailName recipient, string sub, string body)
        {
            var msg = new MailNote();
            msg.FromAddress = ConfigurationManager.AppSettings["FromEmail"];
            msg.ToAddress.Add(recipient.Email);
            msg.Subject = sub;
            msg.Message = body;
            return msg;
        }

        private MailNote CreateMessage(EmailName recipient, FileStream attachment, string sub, string body)
        {
            var msg = new MailNote();
            var fileName = Path.GetFileName(attachment.Name);

            msg.Attachments.Add(fileName, attachment);
            msg.FromAddress = ConfigurationManager.AppSettings["FromEmail"];
            msg.ToAddress.Add(recipient.Email);
            msg.Subject = sub;
            msg.Message = body;
            return msg;
        }

        public List<EmailName> CreateErrorEmailListFromAppConfig()
        {
            var emailList = new List<EmailName>();
            //allows adding up to 100 emails from app config
            for (int i = 1; i < 101; i++)
            {
                var emailKey = "ErrorToEmail" + i;
                if (ConfigurationManager.AppSettings[emailKey] != null)
                {
                    string email = ConfigurationManager.AppSettings[emailKey].Split(',')[0];
                    string name = ConfigurationManager.AppSettings[emailKey].Split(',')[1];
                    emailList.Add(new EmailName(name, email));
                }
            }
            return emailList;
        }

        public List<EmailName> CreateEmailListFromAppConfig()
        {
            var emailList = new List<EmailName>();
            //allows adding up to 100 emails from app config
            for (int i = 1; i < 101; i++)
            {
                var emailKey = "ToEmail" + i;
                if (ConfigurationManager.AppSettings[emailKey] != null)
                {
                    string email = ConfigurationManager.AppSettings[emailKey].Split(',')[0];
                    string name = ConfigurationManager.AppSettings[emailKey].Split(',')[1];
                    emailList.Add(new EmailName(name, email));
                }
            }
            return emailList;
        }
    }
}
