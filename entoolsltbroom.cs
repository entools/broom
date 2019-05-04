using System;
using System.IO;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;

namespace Revit.SDK.Entools.Ribbon.CS
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]

    public class EnToolsLt : IExternalApplication
    {
        static string AddInPath = typeof(EnToolsLt).Assembly.Location;
        static string ButtonIconsFolder = Path.GetDirectoryName(AddInPath);

        public Autodesk.Revit.UI.Result OnStartup(UIControlledApplication application)
        {
            try
            {
                // create customer Ribbon Items
                RibbonPanel panel = application.CreateRibbonPanel("Broom");
                PushButtonData list = new PushButtonData("Broom", "Broom", AddInPath, "Revit.SDK.Entools.Ribbon.CS.Broom")
                {
                    ToolTip = "Delete views and sheets"
                };
                list.LongDescription =
                 "Entools Broom is created to remove unused views," +
                 "legends, sheets and schedules.";

                // Context (F1) Help - new in 2013 
                //string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); 

                string path;
                path = System.IO.Path.GetDirectoryName(
                   System.Reflection.Assembly.GetExecutingAssembly().Location);

                ContextualHelp contextHelp = new ContextualHelp(
                    ContextualHelpType.ChmFile,
                    path + @"\EnToolsBroomHelp.htm"); // hard coding for simplicity. 

                list.SetContextualHelp(contextHelp);

                PushButton billButton = panel.AddItem(list) as PushButton;

                billButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\broom_large.png"), UriKind.Absolute));
                billButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\broom.png"), UriKind.Absolute));

                //CreateRibbonEntoolsPanel(application);
                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("EnToolsLt Sample", ex.ToString());
                return Autodesk.Revit.UI.Result.Failed;
            }
        }

        public Autodesk.Revit.UI.Result OnShutdown(UIControlledApplication application)
        {
            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }
}
