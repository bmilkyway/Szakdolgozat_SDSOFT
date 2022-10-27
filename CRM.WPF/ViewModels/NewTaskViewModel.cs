using System;
using System.Collections.Generic;
using System.Windows;

using CRM.Domain.Models;

namespace CRM.WPF.ViewModels
{
    public class NewTaskViewModel : ViewModelBase
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
            if (taskName == "")
            {
                MessageBox.Show("Nins megadva a név az új feladatnak!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
            else if (category == -1)
            {
                MessageBox.Show("Nins kiválasztva feladat kategória!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
            else if (deadline < DateTime.Now)
            {
                MessageBox.Show("A határidő dátuma nem lehet korábban mint a jelenlegi dátum!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
            else if (description == "")
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
                    DeadLine = deadline.AddHours(23).AddMinutes(59).AddSeconds(59),
                    Category = Categories[category],
                    CreateDate = DateTime.Now,
                    CreatedUserId = activeUser.Id,
                    TaskStatusId = isPlanning == true ? 1 : 2,
                    CloseDate =null,



                };
                TaskService!.Create(newTask);
                MessageBox.Show("Sikeresen létrehozta egy új feladatot!", "Sikeres létrehozás!", MessageBoxButton.OK, MessageBoxImage.Information);

                return true;
            }
        }
    }
}
