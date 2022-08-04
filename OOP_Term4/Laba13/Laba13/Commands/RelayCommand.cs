using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laba13.Commands
{
    // Для использования команд
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        // Событие CanExecuteChanged вызывается при изменении условий, указывающий, может ли команда выполняться.
        // Для этого используется событие CommandManager.RequerySuggested.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        // определяет, может ли команда выполняться
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        // выполняет логику команды
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
