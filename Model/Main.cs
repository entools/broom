using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Entools.View;
using Entools.ViewModel;
using EntoolsBroomRevit.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Entools.Model
{
    class Main
    {
        public void MainClass(ExternalCommandData revit)
        {
            var uiApplication = revit.Application;
            var uidoc = uiApplication.ActiveUIDocument;
            var doc = uidoc.Document;

            NewMainWindowViewModel newMainWindowViewModel = new NewMainWindowViewModel();
            newMainWindowViewModel.ViewsObservableCollectionLeft = RevitModelClass.GetListViews(doc);
            newMainWindowViewModel.ViewsObservableCollectionRight = new ObservableCollection<CollectionClass>();
            newMainWindowViewModel.RevitModel = new RevitModelClass(uiApplication);

            using (var view = new NewMainWindow())
            {
                view.DataContext = newMainWindowViewModel;
                view.ShowDialog();
            }
        }

        public IList<Element> AllElnew(Document doc, BuiltInCategory name)
        {
            ElementCategoryFilter filter = new ElementCategoryFilter(name);
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            IList<Element> list = collector.WherePasses(filter).WhereElementIsNotElementType().ToElements();

            return list;
        }


        public void Cleaner(Document doc, List<ElementId> delta)
        {
            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Delete");

                foreach (ElementId e in delta)
                {
                    try
                    {
                        doc.Delete(e);
                    }
                    catch// (Exception) // ex)
                    {
                        //TaskDialog.Show("Error", "Can not delet " + e.Name);
                    }
                }

                tx.Commit();
            }
        }


        public List<ElementId> Checker(string name, string[] words, ElementId id)
        {
            List<ElementId> delta = new List<ElementId>();
            bool flag = false;

            foreach (var word in words)
            {
                if (name == word)
                {
                    flag = true;
                }
            }

            if (flag != true)
            {
                delta.Add(id);
            }

            return delta;
        }


        public void Analyze(ExternalCommandData revit)
        {
            UIApplication uiapp = revit.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<Element> views = new List<Element>();

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

            string names = Properties.Settings.Default["names_"].ToString();

            string[] separators = { "\n" };
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
                //DelView(revit);
            }

            //---Version_2.0---//
            //-----------------//

            if (1 == 0)
            {
                //Delete_RVT_link(revit);
            }

            if (1 == 0)
            {
                //DeleteImportsNotLinks(revit);
            }

            //-----------------//
            //---Version_2.0---//
        }


        public void DelView(Document doc, string names)
        {
            List<Element> views = new List<Element>();
            List<ElementId> delta = new List<ElementId>();

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

            string[] separators = { "\n" };
            string[] words = names.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (Element e in views)
            {
                string name = e.Name;
                ElementId id = e.Id;
                delta.AddRange(Checker(name, words, id));
            }

            Cleaner(doc, delta);

            TaskDialog.Show("Report", "Deleted views.");
        }

        //---Version_2.0---//
        //-----------------//


        public void Delete_RVT_link(ExternalCommandData revit)
        {
            UIApplication uiapp = revit.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<ElementId> delta = new List<ElementId>();

            string names = Properties.Settings.Default["names_rvt"].ToString();

            string[] separators = { "\n" };
            string[] words = names.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            List<RevitLinkType> links = new FilteredElementCollector(doc)
                .OfClass(typeof(RevitLinkType)).Cast<RevitLinkType>().ToList();

            foreach (Element e in links)
            {
                string name = e.Name;
                ElementId id = e.Id;
                delta.AddRange(Checker(name, words, id));
            }

            Cleaner(doc, delta);

            TaskDialog.Show("Report", "Deleted rvt-link.");
        }


        public void DeleteImportsNotLinks(ExternalCommandData revit)
        {
            UIApplication uiapp = revit.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            IList<ElementId> categoryIds = new List<ElementId>();

            foreach (ImportInstance link in new FilteredElementCollector(doc)
                .OfClass(typeof(ImportInstance)).Cast<ImportInstance>())

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


    }
}
