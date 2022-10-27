using CRM.Domain.Models;
using CRM.LocalDb;

using SQLite;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CRM.WPF.ViewModels
{
    public class NewTaskViewModel:ViewModelBase
    {
        public List<string> Categories = new List<string>
        {
            "Programozás",
            "Tesztelés",
            "Karbantartás"
        };
        private readonly User activeUser;
      
   
        public NewTaskViewModel()
        {
            activeUser = currentUser;
          
        }


        public bool savewTask(string taskName, int category, DateTime deadline, string description, bool isPlanning)
        {
            if(taskName == "")
            {
                MessageBox.Show("Nins megadva a név az új feladatnak!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
            else if (category == -1)
            {
                MessageBox.Show("Nins kiválasztva feladat kategória!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
            else if (deadline< DateTime.Now)
            {
                MessageBox.Show("A határidő dátuma nem lehet korábban mint a jelenlegi dátum!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
            else if(description == "")
            {
                MessageBox.Show("Nincs megadva leírás a feladathoz!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                Domain.Models.Task newTask = new Domain.Models.Task
                {

                    TaskName = taskName,
                    TaskDescription = description,
                    DeadLine = deadline,
                    Category = Categories[category],
                    CreateDate = DateTime.Now,
                    CreatedUserId = activeUser.Id,
                    TaskStatusId = isPlanning == true ? 1 :2,
                    CloseDate = DateTime.Parse("0001-01-01 00:00:00")



                };
                TaskService!.Create(newTask);
                MessageBox.Show("Sikeresen létrehozta egy új feladatot!", "Sikeres létrehozás!", MessageBoxButton.OK, MessageBoxImage.Information);

                return true;
            }
        }
    }
}
