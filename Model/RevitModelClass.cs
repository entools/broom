using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using EntoolsBroom.ViewModel;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace Revit.Model
{
    public class RevitModelClass
    {
        #region Fields
        private static UIApplication _uiApplication;
        private static Application _application;
        private static Document _document;
        private readonly UIDocument _uiDocument;
        #endregion

        public RevitModelClass(UIApplication uiapp)
        {
            _uiApplication = uiapp;
            _application = _uiApplication.Application;
            _uiDocument = _uiApplication.ActiveUIDocument;
            _document = _uiDocument.Document;

        }


        #region Public Methods
        public static ObservableCollection<CollectionClass> GetListViews(Document document)
        {
            IEnumerable<View> getViews = new FilteredElementCollector(document).OfClass(typeof(View)).Cast<View>();
            var tempCollection = new ObservableCollection<CollectionClass>();
            if (getViews != null)
                foreach (View view in getViews)
                    if (view != null)
                        tempCollection.Add(new CollectionClass { View = view.Name });
                    else
                        tempCollection.Add(new CollectionClass { View = "Views not found" });
            return tempCollection;
        }

        public static void MoveRowToRightDataGrid(string getRowList, 
            ObservableCollection<CollectionClass> viewsObservableCollectionLeft, 
            ObservableCollection<CollectionClass> viewsObservableCollectionRight)
        {
            CollectionClass selectedRow = new CollectionClass{View = getRowList};
            viewsObservableCollectionRight.Add(selectedRow);
            viewsObservableCollectionLeft.Remove(selectedRow);
        }
        #endregion
    }
}
