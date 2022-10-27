using CRM.Domain.Models;

using Microsoft.EntityFrameworkCore;


namespace CRM.EntityFramework
{
    public class CRM_DbContext : DbContext
    {


        public DbSet<User>? Users { get; set; }
        public DbSet<Feedback>? Feedbacks { get; set; }
        public DbSet<Message>? Messages { get; set; }
        public DbSet<Permission>? Permissions { get; set; }
        public DbSet<Status>? Statuses { get; set; }
        public DbSet<Domain.Models.Task>? Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback {Id=1, FeedbackDate = DateTime.Now, Rate = 2.2, FeedbackDescription = "Ez az első visszajelzés", FeedbackType = "Visszajelzés", FeedbackUserId = 1, isRead = false, isRevised = false });
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "Admin", Password = "Admin", Name = "Bajár Milán", Email = "Bajarmilan2001@gmail.com", RegistrationDate = DateTime.Now, IsActive = true, LoginDate = DateTime.Now, PermissionId = 1 });

            modelBuilder.Entity<Message>().HasData(
                   new Message { Id = 1, ToUserId = 1, FromUserId = 1, Subject = "Első levél", isRead = false, MessageText = "Ez az első elküldött levél", SendDate = DateTime.Now });
            modelBuilder.Entity<Permission>().HasData(

                 new Permission { Id = 2, PermissionName = "Tulajdonos" },
                  new Permission { Id = 3, PermissionName = "Irodai munkatárs" },
                   new Permission { Id = 4, PermissionName = "Külsős" });

            modelBuilder.Entity<Status>().HasData(
              new Status { Id = 1, StatusName = "Tervezés alatt" },
                 new Status { Id = 2, StatusName = "Szabad" },
                   new Status { Id = 3, StatusName = "Elvállalt" },
                     new Status { Id = 4, StatusName = "Lezárt" });
            modelBuilder.Entity<Domain.Models.Task>().HasData(
                new Domain.Models.Task { Id = 1, Category = "Prgramozás", CreateDate = DateTime.Now, CreatedUserId = 1, TaskName = "Első feladat", TaskDescription = "Ez az első feladat leírása", ResponsibleUserId = 1, DeadLine = DateTime.Parse("2022.09.20"), TaskStatusId = 1 });

        }






        public CRM_DbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
