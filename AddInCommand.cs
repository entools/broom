
using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace Revit.SDK.Entools.Ribbon.CS
{
    /// <summary>
    /// Implements the Revit add-in interface IExternalCommand,Move walls, Y direction
    /// </summary>
    /// 

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]

    public class Broom : IExternalCommand
    {
        public IList<Element> AllElnew(Document doc, BuiltInCategory name)
        {
            ElementCategoryFilter filter = new ElementCategoryFilter(name);
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            IList<Element> list = collector.WherePasses(filter).WhereElementIsNotElementType().ToElements();
            return list;
        }


        public void DelView(ExternalCommandData revit)
        {
            UIApplication uiapp = revit.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
 
            List<Element> views = new List<Element>() { };
            List<Element> delta = new List<Element>() { };

            List<BuiltInCategory> cats = new List<BuiltInCategory>()
            {
                BuiltInCategory.OST_Views,
                BuiltInCategory.OST_Schedules,
                BuiltInCategory.OST_Sheets,
            };

            foreach (BuiltInCategory cat in cats)
            {
                IList<Element> elements = AllElnew(doc, cat);
                views.AddRange(elements.ToList());
            }

            string names = Revit.Properties.Settings.Default["names"].ToString();
            int i = 0;
            bool flag = false;

            string[] separators = { ",", " " };
            string[] words = names.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (Element e in views)
            {
                foreach (var word in words)
                {
                    if (e.Name == word)
                    {
                        flag = true;
                    }
                }

                if (flag == true)
                {
                    flag = false;
                }
                else
                {
                    delta.Add(e);
                }
            }

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Delete view");
                foreach (Element e in delta)
                {
                    try
                    {
                        doc.Delete(e.Id);
                        i++;
                    }
                    catch// (Exception) // ex)
                    {
                        //TaskDialog.Show("Error", "Can not delet " + e.Name);
                    }
                }                
                tx.Commit();
            }

            TaskDialog.Show("Report","Deleted " + i.ToString() + " views.");

            //return Autodesk.Revit.UI.Result.Succeeded;
            //throw new NotImplementedException();
        }

 
        #region IExternalCommand Members Implementation
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,
                                             ref string message,
                                             ElementSet elements)
        {
            try
            {
                SelectionManager manager = new SelectionManager(revit);               
                UserControl2 userControl = new UserControl2(revit);

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