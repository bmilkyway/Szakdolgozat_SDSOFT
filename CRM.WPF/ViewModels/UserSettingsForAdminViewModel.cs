using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using CRM.Domain.Models;

namespace CRM.WPF.ViewModels
{
    public class UserSettingsForAdminViewModel:ViewModelBase
    {
        public List<User> users { get; set; }
        public UserSettingsForAdminViewModel()
        {
            users = UserService!.GetAllUser().Result.ToList();
        }
        /// <summary>
        /// Felhasználó törlése
        /// A felhasználó nem kerül tényleges törtlésre, csupán "Törölt" státuszt kap, ezután már nem tud belépni a fiókjába a felhasználó
        /// </summary>
        /// <param name="user">Törölni kívánt felhasználó</param>
        /// <param name="selectedIndex">Kiválasztott felhasználó indexe a listában</param>
        /// <returns></returns>
        public bool deleteSelectedUser(User user, int selectedIndex)
        {
            if (MessageBox.Show("Biztos törli a kijelölt felhasználót?\nA törlés után az adatokat nem lehet visszaállítani!", "Figyelem!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                users.Remove(users[selectedIndex]);
                user.PermissionId = 5;
                UserService!.Update(user.Id, user);
                return true;
            }
                return false;
        }
        /// <summary>
        /// Felhasználó adatainak módosítása
        /// </summary>
        /// <param name="user">Módosítani kívánt felhasználó</param>
        /// <param name="name">Felhasználó neve</param>
        /// <param name="email">Felhasználó email címe</param>
        /// <param name="username">Felhasználó felhasználóneve</param>
        /// <param name="permissionId">Jogosultság</param>
        /// <param name="lbUsers">Felhasználókat tartalmazó lista, ezt azért adjuk át, hogy a művelet után egyből frissíteni lehessen a listát</param>
        /// <returns></returns>
        public bool modifySelectedUser(User user, string name, string email, string username, int permissionId, ListBox lbUsers)
        {

            if (permissionId == 1 && user.PermissionId != 1)
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

