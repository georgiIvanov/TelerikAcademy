using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Typesafe.Mailgun;

namespace itGeorgeHook.Controllers
{
    public class HookController : ApiController
    {
        public void Post([FromBody] Dictionary<string, object> content)
        {
            var buildReport = JsonConvert.SerializeObject(content);

            var mailgunKeyName = "key-71yata1c1lo30of2hlltk628nh8oznu0";

            var mailClient = new MailgunClient("app16919.mailgun.org", ConfigurationManager.AppSettings[mailgunKeyName]);
            mailClient.SendMail(new System.Net.Mail.MailMessage("CodeJewelsHook@AppHarbor.net", "georgi.ivanovtn@gmail.com")
            {
                Subject = "Build Report",
                Body = buildReport
            });
            
        }
    }
}
