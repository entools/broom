using EntoolsBroomRevit.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
                return _pushCommand ?? (_pushCommand = new RelayCommand(o =>
                    {
                        try
                        {
                            RevitModelClass.ShowSelectedView(ViewsObservableCollectionRight);
                        }
                        catch
                        {

                        }
                    }));
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

        private bool _delRvtLinks;
        private bool _delCadLinks;
        private bool _delCadImports;

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

        public bool DelRvtLinks
        {
            get => _delRvtLinks;
            set
            {
                _delRvtLinks = value;
                OnPropertyChanged();


            }
        }
        public bool DelCadLinks
        {
            get => _delCadLinks;
            set
            {
                _delCadLinks = value;
                OnPropertyChanged();


            }
        }
        public bool DelCadImports
        {
            get => _delCadImports;
            set
            {
                _delCadImports = value;
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