
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
//using System.Diagnostics;
using System.IO;
//using System.Collections;
using Autodesk.Revit.UI;
using System.Threading;
using System.Windows;
using Autodesk.Revit.UI.Selection;
//using DialogResult = System.Windows.Forms.DialogResult;
using Revit.Properties;
using System.Globalization;
//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Sheets.v4;
//using Google.Apis.Sheets.v4.Data;
//using Google.Apis.Services;
//using Google.Apis.Util.Store;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Plumbing;
using RvtOperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;
//using Google.Apis.Auth;
//using Google.Apis.Drive.v3;
//using Google.Apis.Drive.v3.Data;
using File = System.IO.File;
//using System.Net;

namespace Revit.SDK.Entools.Ribbon.CS
{
    /// <summary>
    /// Implements the Revit add-in interface IExternalCommand,Move walls, Y direction
    /// </summary>
    /// 
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]

    public class DelView : IExternalCommand
    {

        #region IExternalCommand Members Implementation
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,
                                             ref string message,
                                             ElementSet elements)
        {
    //        UIApplication uiapp = revit.Application;
    //        UIDocument uidoc = uiapp.ActiveUIDocument;
    //        Document doc = uidoc.Document;

    //        ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_Views);
    //        FilteredElementCollector collector = new FilteredElementCollector(doc);
    //        IList<Element> list = collector.WherePasses(filter).WhereElementIsNotElementType().ToElements();

    //        TaskDialog.Show("m", "e.Name");

    //        using (Transaction tx = new Transaction(doc))
    //        {
    //            tx.Start("Delete view");
    //            foreach (Element e in list)
    //            {
    //                //TaskDialog.Show("m", e.Name);
    //            }
    //            tx.Commit();
    //        }

            return Autodesk.Revit.UI.Result.Succeeded;
            throw new NotImplementedException();
        }
        #endregion IExternalCommand Members Implementation
    }



    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]



    public class Broom : IExternalCommand
    {



        public static Autodesk.Revit.DB.Document DbDoc;
        private ExternalCommandData revit_;
        
        public void DelView()

        {
            TaskDialog.Show("m", "e.Name");
            Broom.DbDoc = revit_.Application.ActiveUIDocument.Document;
            //UIApplication uiapp = DbDoc.Application;
            //UIApplication uiapp = revit_.Application;
            //UIDocument uidoc = uiapp.ActiveUIDocument;
            //Document doc = uidoc.Document;

            //ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_Views);
            //FilteredElementCollector collector = new FilteredElementCollector(DbDoc);
            //IList<Element> list = collector.WherePasses(filter).WhereElementIsNotElementType().ToElements();

            

            //using (Transaction tx = new Transaction(DbDoc))
            //{
            //    tx.Start("Delete view");
            //    foreach (Element e in list)
            //    {
            //        //TaskDialog.Show("m", e.Name);
            //    }
            //    tx.Commit();
            //}
            //return Autodesk.Revit.UI.Result.Succeeded;
            throw new NotImplementedException();
        }






        #region IExternalCommand Members Implementation
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,
                                             ref string message,
                                             ElementSet elements)
        {


            try
            {
                SelectionManager manager = new SelectionManager(revit);               
                UserControl2 userControl = new UserControl2();
                //TaskDialog.Show("*","*");
                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception ex)
            {
                // If any error, give error information and return failed
                message = ex.Message;
                return Autodesk.Revit.UI.Result.Failed;
            }


            //return Autodesk.Revit.UI.Result.Succeeded;
            throw new NotImplementedException();
        }
        #endregion IExternalCommand Members Implementation
    }
}
