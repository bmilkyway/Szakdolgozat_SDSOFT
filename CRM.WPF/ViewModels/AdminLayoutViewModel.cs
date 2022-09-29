using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using CRM.Domain.Models;

namespace CRM.WPF.ViewModels
{
    public class AdminLayoutViewModel:ViewModelBase
    {

        
       public List<User> users { get; set; }
        public AdminLayoutViewModel()
        {
            users = UserService!.GetAll().Result.ToList();
        }

        public bool deleteSelectedUser(User user,int selectedIndex)
        {   
            if(MessageBox.Show("Biztos törli a kijelölt felhasználót?\nA törlés után az adatokat nem lehet visszaállítani!", "Figyelem!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                users.Remove(users[selectedIndex]);
                UserService!.Delete(user.Id);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool modifySelectedUser(User user, string name, string email, string username, int permissionId ,ListBox lbUsers)
        { 
          
            if (permissionId == 1 && user.PermissionId!=1)
            {
                if (MessageBox.Show("Biztos szeretne adminisztrátori jogot adni a kiválasztot felhasználónak?\nA későbbiekben a felhasználót már nem lehet törölni amíg admini jogosultságot birtokol!", "Figyelem!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    user.Name = name;
                    user.Email = email;
                    user.UserName = username;
                    user.PermissionId = permissionId;
                    UserService!.Update(user.Id, user);
                    lbUsers.Items.Refresh();
                    return true;
                }
                else return false;
            }
            else
            {
                user.Name = name;
                user.Email = email;
                user.UserName = username;
                user.PermissionId = permissionId;
                UserService!.Update(user.Id, user);
                lbUsers.Items.Refresh();

                return true;
            }
            
        }
    }
}
