namespace CRM.Domain.Services.NewFolder
{
    public interface IPasswordHasherService
    {
        string PasswordEncodeing(string password);
    }
}
