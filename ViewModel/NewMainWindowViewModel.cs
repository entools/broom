using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Revit.Model;
using SpecificationHVAC.ViewModel;

namespace EntoolsBroom.ViewModel
{
    class NewMainWindowViewModel : ModelBase
    {
        #region Commands

        public ICommand CommandButton
        {
            get
            {
                return _command;
            }
        }

        #endregion



        #region Fields

        private ObservableCollection<CollectionClass> _viewsObservableCollection;
        private ICommand _command;
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


        public ObservableCollection<CollectionClass> ViewsObservableCollection
        {
            get => _viewsObservableCollection;
            set
            {
                _viewsObservableCollection = value;
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
