﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Revit.Model;

namespace EntoolsBroom.ViewModel
{
    class NewMainWindowViewModel : ModelBase
    {
        #region Commands

        public ICommand MoveToRightCommand
        {
            get
            {
                if (_moveToRightCommand == null)
                    _moveToRightCommand = new MoveItemToRightCommand(this);
                return _moveToRightCommand;

            }
        }

        public ICommand MoveToLeftCommand
        {
            get
            {
                if (_moveToLeftCommand == null)
                    _moveToLeftCommand = new MoveItemToLeftCommand(this);
                return _moveToLeftCommand;
            }
        }
        public ICommand PushCommand
        {
            get
            {
                if (_pushCommand == null)
                    _pushCommand = new RelayCommand(o=> RevitModelClass.ShowSelectedView(ViewsObservableCollectionRight));
                return _pushCommand;
            }
        }

        #endregion



        #region Fields

        private ObservableCollection<CollectionClass> _viewsObservableCollectionLeft;
        private ObservableCollection<CollectionClass> _viewsObservableCollectionRight;
        private ICommand _moveToRightCommand;
        private ICommand _moveToLeftCommand;
        private ICommand _pushCommand;
        private CollectionClass _getCell;

        #endregion

        #region Propierties

        public CollectionClass GetCell
        {
            get => _getCell;
            set
            {
                _getCell = value;
                OnPropertyChanged();
            }
        }


        internal RevitModelClass RevitModel { get; set; }


        public ObservableCollection<CollectionClass> ViewsObservableCollectionLeft
        {
            get => _viewsObservableCollectionLeft;
            set
            {
                _viewsObservableCollectionLeft = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CollectionClass> ViewsObservableCollectionRight
        {
            get => _viewsObservableCollectionRight;
            set
            {
                _viewsObservableCollectionRight = value;
                OnPropertyChanged();
            }
        }
        #endregion

    }
    public class CollectionClass
    {
        public string View { get; set; }
    }

}
