using Entools.Annotations;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Entools.ViewModel;

namespace Entools.ViewModel
{
    public class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public RelayCommand(Action<object> execute): this(execute, null)
        {

        }


        private RelayCommand([CanBeNull] Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new System.ArgumentNullException("execute//выполнить");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

    }
}
