
using System;
using System.Windows;

using CRM.Domain.Models;
using CRM.Domain.Services;
using CRM.EntityFramework;
using CRM.EntityFramework.Services;
using CRM.LocalDb;

using SQLite;

namespace CRM.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public IDataService<User>? UserService;
        public Visibility isAdmin { get; set; }
        public User currentUser { get; set; }
        public  MainWindow(int userId)
        {
   
            InitializeComponent();
            Application.Current.MainWindow = this;
            UserService = new GenericDataService<User>(new CRM_DbContextFactory());
            currentUser = UserService!.Get(userId).Result;
            isAdmin = currentUser.PermissionId == 1 ? Visibility.Visible : Visibility.Hidden;
            currentUser.IsActive = true;
            UserService.Update(userId, currentUser);

        }
        protected override void OnClosed(EventArgs e)
        {
            //Ha bezár gombra mentünk, átállítja az IsActice mezőt false-ra  
            if (System.IO.File.Exists("currentUserDb.db3"))
            {
                var db = new SQLiteConnection("currentUserDb.db3");
                CurrentUser currentUser = db!.Get<CurrentUser>(1);
                User user = UserService!.Get(currentUser.userId).Result;
                user.IsActive = false;
                _ = UserService!.Update(user!.Id, user);
                db.Update(currentUser);
                db!.Close();
                base.OnClosed(e);
            }
        }
    }
}
