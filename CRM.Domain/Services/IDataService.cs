using CRM.Domain.Models;

namespace CRM.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<User>> GetAllUser();
        Task<T> Get(int id);
        Task<bool> Delete(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);

        Task<IEnumerable<User>> ActiveUsers();

        Task<IEnumerable<Message>> IncomingMessages(int toUserId);
        Task<IEnumerable<Message>> SentMessages(int fromUserId);

        Task<IEnumerable<Models.Task>> OwnTask(int userId);


        Task<User> Login(string username, string password);

        Task<User> ForgotUser(string email);

    }
}
