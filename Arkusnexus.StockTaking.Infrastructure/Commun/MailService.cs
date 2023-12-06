using SendGrid.Helpers.Mail;
using SendGrid;

namespace Arkusnexus.StockTaking.Infrastructure.Commun
{
    public class MailService : IMailService
    {
        public async Task SendEmail(string To, string Body, string subject)
        {
            var sendGridClient = new SendGridClient("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");
            var from = new EmailAddress("rmora@arkusnexus.com", "admin notaria");
            var _subject = subject;
            var to = new EmailAddress(To);
            var plainContent = "Hola";
            var htmlContent = Body;
            var mailMessage = MailHelper.CreateSingleEmail(from, to, _subject, plainContent, htmlContent);
            var response =  await sendGridClient.SendEmailAsync(mailMessage);
            var test = response;

        }
    }
}
