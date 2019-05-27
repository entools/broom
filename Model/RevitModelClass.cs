using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using EntoolsBroom.ViewModel;
using Application = Autodesk.Revit.ApplicationServices.Application;
using EntoolsBroom.Model;

namespace EntoolsBroomRevit.Model
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
        /// <summary>
        /// Показать список выдов из правой датагрид
        /// </summary>
        public static void ShowSelectedView(ObservableCollection<CollectionClass> ViewsObservableCollectionRight)
        {
            string name = null;

            for (int i = 0; i < ViewsObservableCollectionRight.Count; i++)
            {
                name += ViewsObservableCollectionRight[i].View + "\n";
            }


            EntoolsBroom.Properties.Settings.Default["names_"] = name;
            EntoolsBroom.Properties.Settings.Default.Save();

            Broom broom = new Broom();
            broom.DelView(_document, name);

        }
        #endregion
    }
}
