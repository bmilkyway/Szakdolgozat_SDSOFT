using CRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Delete(int id);
        Task<T> Ceate(T entity);
        Task<T> Update(int id, T entity);

        Task<IEnumerable<User>> ActiveUsers();

        Task<IEnumerable<Message>> IncomingMessages(int toUserId);
        Task<IEnumerable<Message>> SentMessages(int fromUserId);

    }
}
