namespace WebAPI.Repositories {
    public interface IEmailRepository {
        bool SendEmail (string from, string to, string body, string subject);
    }
}