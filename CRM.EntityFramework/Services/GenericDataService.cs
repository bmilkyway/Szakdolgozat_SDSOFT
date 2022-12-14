using CRM.Domain.Models;
using CRM.Domain.Services;

using Microsoft.EntityFrameworkCore;

namespace CRM.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly CRM_DbContextFactory _contextFactory;

        public GenericDataService(CRM_DbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {
                var createEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Get(int id)
        { //!!!
            using var context = _contextFactory.CreateDbContext();
            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {

            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().AsNoTracking().ToArrayAsync();
                return entities;
            }
        }

        public async Task<IEnumerable<User>> ActiveUsers()
        {
            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {

                IEnumerable<User> entities = await context.Set<User>().Where(e => e.IsActive == true).ToArrayAsync();
                return entities;


            }

        }

        public async Task<T> Update(int id, T entity)
        {
            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<IEnumerable<Message>> IncomingMessages(int toUserId)
        {

            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Message> entities = await context.Set<Message>().Where(e => e.ToUserId == toUserId).OrderByDescending(e => e.SendDate).ToArrayAsync();
                return entities;
            }
        }

        public async Task<IEnumerable<Message>> SentMessages(int fromUserId)
        {

            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Message> entities = await context.Set<Message>().Where(e => e.FromUserId == fromUserId).OrderByDescending(e => e.SendDate).ToArrayAsync();
                return entities;
            }
        }

        public async Task<User> Login(string username, string password)
        {
            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {
                User activeUser = await context.Set<User>().FirstOrDefaultAsync((e) => e.UserName == username && e.Password == password);
                return activeUser;
            }
        }

        public async Task<User> ForgotUser(string email)
        {
            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {
                User forgotUser = await context.Set<User>().FirstOrDefaultAsync((e) => e.Email == email);
                return forgotUser;
            }
        }

        public async Task<IEnumerable<Domain.Models.Task>> OwnTask(int userId)
        {
            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Domain.Models.Task> tasks = await context.Set<Domain.Models.Task>().Where((e) => e.ResponsibleUserId == userId).OrderBy((e) => e.DeadLine).OrderBy((a) => a.TaskStatusId).ToArrayAsync();
                return tasks;
            }
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            using (CRM_DbContext context = _contextFactory.CreateDbContext())
            {

                IEnumerable<User> entities = await context.Set<User>().Where(e => e.PermissionId != 5).ToArrayAsync();
                return entities;

            }
        }


    }
}
