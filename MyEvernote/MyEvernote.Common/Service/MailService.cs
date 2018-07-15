using MyEvernote.Common.Helper;
using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyEvernote.Common.Service
{
    public class MailService
    {
        public static class MailTemplateKeys
        {
            public const string  ActivedAccountTemplate= "ActivedAccountTemplate";
        }

        public static bool SendMail(string mailAdress, string TemplateMail)
        {
            return SendMail(mailAdress, TemplateMail, null);
        }

        public static bool SendMail(string mailAdress, string TemplateMail, Dictionary<string, string> properties)
        {
            bool response = false;
            try
            {
                var viewsPath = AppDomain.CurrentDomain.BaseDirectory + Utility.EmailTemplatePath;

                var engines = new ViewEngineCollection();
                engines.Add(new FileSystemRazorViewEngine(viewsPath));
                var service = new EmailService(engines);

                dynamic email = new Email(TemplateMail);
                email.To = mailAdress;
                email.prop = properties;
                service.Send(email);
                response = true;
            }
            catch (Exception ex)
            {
                response = false;
                //Utility.ReportError(ex);

            }

            return response;
        }
    }
}
