using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laba6_7.Command
{
    // класс переключения команд
    class RelayCommand : ICommand
    {
        // переменная делегата, который может указывать на метод, принимающий переменную типа object, возвращающий void
        private Action<object> execute;

        // переменная делегата, который может указывать на метод, принимающий переменную типа object, возвращающий bool
        private Func<object, bool> canExecute;

        // Событие CanExecuteChanged вызывается при изменении условий, указывающий, может ли команда выполняться. 
        // Для этого используется событие CommandManager.RequerySuggested.
        public event EventHandler CanExecuteChanged {
            // С помощью специальных акссесоров add/remove мы можем управлять добавлением и удалением обработчиков. 
            // Аксессор add вызывается при добавлении обработчика, то есть при операции +=. 
            // Добавляемый обработчик доступен через ключевое слово value.
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

            // Событие CommandManager.RequerySuggested возникает всякий раз, когда CommandManager считает, что изменилось что-то, 
            // что повлияет на возможность выполнения команд. Например, это может быть смена фокуса.
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        // метод, определяющий может ли команда выполнятся 
        public bool CanExecute(object parameter)
        {
            // таким образом, команда может выполняться, если был создан объект класса RelayCommand без передачи второго параметра в конструктор
            // либо проверяется возможность запуска команды в по логике переданной в переменную canExecute
            return this.canExecute == null || this.canExecute(parameter);
        }

        // метод выполняющий логику команды
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
