namespace Arkusnexus.StockTaking.Infrastructure.Commun
{
    public interface IMailService
    {
        Task SendEmail(string To, string Body, string subject);
    }
}