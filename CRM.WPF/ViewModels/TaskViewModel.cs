﻿using CRM.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.WPF.ViewModels
{
    public class TaskViewModel:ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();

        public TaskViewModel()
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.OwnTask);
        }
    }
}
