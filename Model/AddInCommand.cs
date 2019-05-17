using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using EntoolsBroom;
using EntoolsBroom.View;

namespace EntoolsBroom.Model
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


        public void Analyze(ExternalCommandData revit)
        {
            UIApplication uiapp = revit.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<Element> views = new List<Element>() { };

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

            string names = EntoolsBroom.Properties.Settings.Default["names"].ToString();

            string[] separators = { "|" };
            string[] words = names.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string report_warning = "";

            foreach (var word in words)
            {
                bool warning = true;
                foreach (Element e in views)
                {
                    if (word == e.Name)
                    {
                        warning = false;
                        break;
                    }
                }
                if (warning == true)
                {
                    report_warning = report_warning + word + "\n";
                }
            }

            bool dialog = true;

            if (report_warning != "")
            {
                TaskDialog td = new TaskDialog("Report");
                td.Title = "Report";
                //td.MainInstruction = "View's name:";
                td.MainContent = "View's name:\n"
                    + report_warning 
                    + "do not exist in the project."
                    + "Do you want to continue?"
                    ;

                td.CommonButtons = 
                    TaskDialogCommonButtons.No | 
                    TaskDialogCommonButtons.Yes;

                TaskDialogResult taskDialogResult = td.Show();

                if (taskDialogResult == TaskDialogResult.No)
                {
                    dialog = false;
                }
            }
            if (dialog == true)
            {
                DelView(revit);
            }

            //---Version_2.0---//
            //-----------------//

            if (1 == 0)
            {
                Delete_RVT_link(revit);
            }

            if (1 == 0)
            {
                DeleteImportsNotLinks(revit);
            }

            //-----------------//
            //---Version_2.0---//
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

            string names = EntoolsBroom.Properties.Settings.Default["names"].ToString();
            int i = 0;
            bool flag = false;

            string[] separators = { "|" };//, " " };
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

        //---Version_2.0---//
        //-----------------//

        public void DeleteImportsNotLinks(ExternalCommandData revit)
        {
            UIApplication uiapp = revit.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            //ist<Element> delta = new List<Element>() { };

            //string names = Revit.Properties.Settings.Default["names_cad"].ToString();
            //int i = 0;
            //bool flag = false;

            //string[] separators = { "|" };
            //string[] words = names.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            IList<ElementId> categoryIds = new List<ElementId>();

            foreach (ImportInstance link in new FilteredElementCollector(doc)
                .OfClass(typeof(ImportInstance))
                .Cast<ImportInstance>())

            {
                ElementId catId = link.Category.Id;
                if (!categoryIds.Contains(catId))
                    categoryIds.Add(catId);
            }

            using (Transaction t = new Transaction(doc, "Delete Import Categories"))
            {
                t.Start();
                doc.Delete(categoryIds);
                t.Commit();
            }
            TaskDialog.Show("Report", "Deleted CAD-link.");
        }


        public void Delete_RVT_link(ExternalCommandData revit)
        {
            UIApplication uiapp = revit.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<Element> delta = new List<Element>() { };

            string names = EntoolsBroom.Properties.Settings.Default["names_rvt"].ToString();
            int i = 0;
            bool flag = false;

            string[] separators = { "|" };
            string[] words = names.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            List<RevitLinkType> links = new FilteredElementCollector(doc).OfClass(typeof(RevitLinkType)).Cast<RevitLinkType>().ToList();

            foreach (Element e in links)
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

            foreach (RevitLinkType link in delta)
            {
                using (Transaction t = new Transaction(doc, "Delete RVT Link"))
                {
                    t.Start();
                    doc.Delete(link.Id);
                    i++;
                    t.Commit();
                }
            }
            TaskDialog.Show("Report", "Deleted " + i.ToString() + " rvt-link.");
        }

        //-----------------//
        //---Version_2.0---//


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