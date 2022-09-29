using CRM.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using CRM.Domain.Models;
using CRM.LocalDb;
using SQLite;

namespace CRM.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

           if (System.IO.File.Exists("currentUserDb.db3"))
            {
               
                SQLiteConnection connection = new SQLiteConnection("currentUserDb.db3");
                
                    CurrentUser currentUser = connection.Get<CurrentUser>(1);
                    
                    Window window = new MainWindow(currentUser.userId);
                    window.DataContext = new MainViewModel();
                connection.Close();
                    window.Show();
             
            }
            else
            {
                Window window = new Login();
                window.Show();

            }

     
            base.OnStartup(e);
        }
       
       
    }

  
}
