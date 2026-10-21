namespace ISC_IdentityCore.Services
{
    public interface IEmailService
    {
        public bool SendMail(string email, string subject, string body);
    }
}
