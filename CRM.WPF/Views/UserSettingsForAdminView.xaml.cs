using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CRM.Domain.Models;
using CRM.WPF.ViewModels;

namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for UserSettingsForAdminView.xaml
    /// </summary>
    public partial class UserSettingsForAdminView : UserControl
    {
        /// <summary>
        /// Felhasználói jogosultságokat tartalmazó lista
        /// </summary>
        private readonly List<string> permissions = new List<string>() { "Admin", "Projektfelelős", "Irodai dolgozó" };
       
        /// <summary>
        /// View-hoz tartozó viewModel
        /// </summary>
        private UserSettingsForAdminViewModel userSettingsForAdminViewModel;
        private User? selectedUserData;
        public UserSettingsForAdminView()
        {
            InitializeComponent();
            userSettingsForAdminViewModel = new UserSettingsForAdminViewModel();
            btnDelete.IsEnabled = false;
            btnModify.IsEnabled = false;
            cbPermission.ItemsSource = permissions;
            lbAllUsers.ItemsSource = userSettingsForAdminViewModel.users;
        }
        /// <summary>
        /// Kiválasztott felhasználó adatainak mentése
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveSelectedUserModify(object sender, RoutedEventArgs e)
        {

            if (lbAllUsers.SelectedIndex != -1)
                if (userSettingsForAdminViewModel.modifySelectedUser(selectedUserData!, txtName.Text, txtEmail.Text, txtUserName.Text, cbPermission.SelectedIndex + 1, lbAllUsers))
                {
                    lbAllUsers.ItemsSource = userSettingsForAdminViewModel.users;
                    lbAllUsers.Items.Refresh();
                    MessageBox.Show("Sikeresen mentette a felhaszálót!");
                }
                else
                {
                    txtEmail.Text = selectedUserData!.Email;
                    txtUserName.Text = selectedUserData!.UserName;
                    txtName.Text = selectedUserData!.Name;
                    cbPermission.SelectedIndex = selectedUserData!.PermissionId - 1;
                }

        }
        /// <summary>
        /// Kiválasztott felhasználó törlése
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectedUserDelete(object sender, RoutedEventArgs e)
        {
            if (lbAllUsers.SelectedIndex != -1)
                if (userSettingsForAdminViewModel.deleteSelectedUser(selectedUserData!, lbAllUsers.SelectedIndex))
                {
                    txtEmail.Text = "";
                    txtUserName.Text = "";
                    txtName.Text = "";
                    cbPermission.SelectedIndex = -1;
                    lbAllUsers.ItemsSource = null;
                    lbAllUsers.Items.Clear();
                    lbAllUsers.ItemsSource = userSettingsForAdminViewModel.users;
                    lbAllUsers.Items.Refresh();
                    MessageBox.Show("Sikeresen törölte a felhasználót");
                }
        }
        /// <summary>
        /// Kiválasztott felhasználó adatainak részletes megjelenítése
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectedUser(object sender, SelectionChangedEventArgs e)
        {
            if (lbAllUsers.SelectedIndex != -1)
            {
                btnModify.IsEnabled = true;
                btnDelete.IsEnabled = true;
                selectedUserData = userSettingsForAdminViewModel.users[lbAllUsers.SelectedIndex];
                txtName.Text = selectedUserData.Name;
                txtUserName.Text = selectedUserData.UserName;
                txtEmail.Text = selectedUserData.Email;
                switch (selectedUserData.PermissionId)
                {
                    case 1:
                        {
                            btnDelete.IsEnabled = false;
                            cbPermission.SelectedIndex = 0;
                            break;
                        }
                    case 2:
                        {
                            cbPermission.SelectedIndex = 1;
                            break;
                        }
                    case 3:
                        {
                            cbPermission.SelectedIndex = 2;
                            break;
                        }
                }
            }
        }
    }
}
