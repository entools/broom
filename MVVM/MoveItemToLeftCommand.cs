using EntoolsBroom.Annotations;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EntoolsBroom.ViewModel;

namespace EntoolsBroom.ViewModel
{
    class MoveItemToLeftCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        private readonly NewMainWindowViewModel _viewModel;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (_viewModel.GetCell != null)
            {
                var selectedItem = _viewModel.GetCell;
                _viewModel.ViewsObservableCollectionLeft.Add(selectedItem);
                _viewModel.ViewsObservableCollectionRight.Remove(selectedItem);
            }

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public MoveItemToLeftCommand(NewMainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }


    }
}
