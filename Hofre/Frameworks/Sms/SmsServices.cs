using SmsIrRestful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks.Sms
{
    public class SmsServices : ISmsServices
    {
        public async Task SendMessage(string phoneNumber, string message)
        {
            await Task.Run(() =>
            {
                var lines = new SmsLine().GetSmsLines(GetToken().Result);
                if (lines == null) return;

                var line = lines.SMSLines.Last().LineNumber.ToString();
                var messageSendObject = new MessageSendObject()
                {
                    Messages = new List<string> { message }.ToArray(),
                    MobileNumbers = new List<string> { phoneNumber }.ToArray(),
                    LineNumber = line,
                    SendDateTime = DateTime.Now,
                    CanContinueInCaseOfError = true
                };

                MessageSendResponseObject messageSendResponseObject = new MessageSend().Send(GetToken().Result, messageSendObject);

                if (messageSendResponseObject.IsSuccessful) return;

                line = lines.SMSLines.First().LineNumber.ToString();
                messageSendObject.LineNumber = line;
                new MessageSend().Send(GetToken().Result, messageSendObject);
            });
        }
        public async Task<string> GetToken()
        {
            string result = "";
            await Task.Run(() =>
            {
                SmsIrRestful.Token tk = new SmsIrRestful.Token();
                result = tk.GetToken("9f836f01b0809cdbab6489c", "abcd");
            });
            return result;
        }
    }
}
