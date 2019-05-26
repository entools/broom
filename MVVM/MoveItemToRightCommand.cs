using EntoolsBroom.Annotations;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EntoolsBroom.ViewModel;

namespace EntoolsBroom.ViewModel
{
    class MoveItemToRightCommand : ICommand
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
            var selectedItem = _viewModel.GetCell;

            _viewModel.ViewsObservableCollectionRight.Add(selectedItem);

            _viewModel.ViewsObservableCollectionLeft.Remove(selectedItem);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public MoveItemToRightCommand(NewMainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }


    }
}
