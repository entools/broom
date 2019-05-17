using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace Revit.Model
{
    class RevitModelClass
    {
        #region Fields
        private static UIApplication _uiApplication;
        private static Application _application;
        private Document _document;
        private readonly UIDocument _uiDocument;
        #endregion

    }
}
