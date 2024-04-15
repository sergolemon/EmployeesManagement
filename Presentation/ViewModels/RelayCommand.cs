using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class RelayCommand<TParam> : ICommand
    {
        private Action<TParam> execute;
        private Predicate<TParam>? canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<TParam> execute, Predicate<TParam>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute((TParam)parameter);
        }

        public void Execute(object parameter)
        {
            execute((TParam)parameter);
        }
    }
}
