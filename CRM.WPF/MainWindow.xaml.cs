
using System.Windows;

using CRM.Domain.Models;
using CRM.Domain.Services;
using CRM.EntityFramework;
using CRM.EntityFramework.Services;

namespace CRM.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public IDataService<User>? UserService;
        public User currentUser { get; set; }
        public  MainWindow(int userId)
        {
   
            InitializeComponent();
            Application.Current.MainWindow = this;
            UserService = new GenericDataService<User>(new CRM_DbContextFactory());
            currentUser = UserService!.Get(userId).Result;

        }
    }
}
