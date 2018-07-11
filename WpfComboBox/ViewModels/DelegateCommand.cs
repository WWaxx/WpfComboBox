﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfComboBox.ViewModels
{
    class DelegateCommand : ICommand
    {
        Action<object> _Execute;
        Func<object, bool> _CanExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecute == null || _CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _Execute(parameter);
        }
    }
}
