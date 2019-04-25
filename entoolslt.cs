
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit;
//using System.Diagnostics;
using System.IO;
using System.Windows.Media;
//using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Events;


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
                CreateRibbonEntoolsPanel(application);
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
        //    List<RibbonPanel> myPanels = application.GetRibbonPanels();
        //    Autodesk.Revit.UI.ComboBox comboboxLevel = (Autodesk.Revit.UI.ComboBox)(myPanels[0].GetItems()[2]);
        //    Autodesk.Revit.UI.TextBox textBox = myPanels[0].GetItems()[5] as Autodesk.Revit.UI.TextBox;
            return Autodesk.Revit.UI.Result.Succeeded;
        }

        private void CreateRibbonEntoolsPanel(UIControlledApplication application)
        {
            // create a Ribbon panel which contains three stackable buttons and one single push button.
            String tabName = "EnToolsLt";
            application.CreateRibbonTab(tabName);

            RibbonPanel ribbonBoQPanel = application.CreateRibbonPanel(tabName, "Broom module");

            PushButtonData list = new PushButtonData("Broom", "Broom", AddInPath, "Revit.SDK.Entools.Ribbon.CS.Broom")
            {
                ToolTip = "txt"
            };

            PushButton billButton = ribbonBoQPanel.AddItem(list) as PushButton;

            billButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\broom_24.png"), UriKind.Absolute));
            billButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\broom_20.png"), UriKind.Absolute));


            //ribbonBoQPanel.AddItem(billButton.GetType());
            //ribbonBoQPanel.AddSeparator();
            //ribbonBoQPanel.AddItem(ribbonSchemePanel);//.AddSeparator();
            //ribbonBoQPanel.AddSeparator();
            //ribbonBoQPanel.AddSlideOut();




            //PushButtonData settings_wpf = new PushButtonData("Settings", "Settings", AddInPath, "Revit.SDK.Entools.Ribbon.CS.SettingsDialogWPF")
            //{ ToolTip = "txt" };
            //PushButton setButton = ribbonBoQPanel.AddItem(settings_wpf) as PushButton;
            //setButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\settings_24.png"), UriKind.Absolute));
            //setButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\settings_20.png"), UriKind.Absolute));
            //setButton.ToolTip = "*";

            //PushButtonData export = new PushButtonData("Export", "Export", AddInPath, "Revit.SDK.Entools.Ribbon.CS.ExportData")
            //{ ToolTip = "export data to BD" };

            //markerButton = ribbonHydroPanel.AddItem(export) as PushButton;
            //markerButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\export_24.png"), UriKind.Absolute));
            //markerButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\export_20.png"), UriKind.Absolute));

            //PushButtonData import = new PushButtonData("Import", "Import", AddInPath, "Revit.SDK.Entools.Ribbon.CS.ImportData")
            //{ ToolTip = "import data from BD" };

            //markerButton = ribbonHydroPanel.AddItem(import) as PushButton;
            //markerButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\import_24.png"), UriKind.Absolute));
            //markerButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\import_20.png"), UriKind.Absolute));

            //PushButtonData size = new PushButtonData("Size", "Size", AddInPath, "Revit.SDK.Entools.Ribbon.CS.ImportSize")
            //{ ToolTip = "import data from BD" };

            //PushButton sizeButton = ribbonHydroPanel.AddItem(size) as PushButton;
            //sizeButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\size_24.png"), UriKind.Absolute));
            //sizeButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\size_20.png"), UriKind.Absolute));

            ////public partial class MainPage : Page, Autodesk.Revit.UI.IDockablePaneProvider
            ////ribbonHydroPanel.AddSeparator();

            //PushButtonData hexpar = new PushButtonData("Par", "Par", AddInPath, "Revit.SDK.Entools.Ribbon.CS.AddSharedParameter")
            //{ ToolTip = "txt" };
            //PushButton hexButton = ribbonMillPanel.AddItem(hexpar) as PushButton;
            //hexButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\hex_24.png"), UriKind.Absolute));
            //hexButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\hex_20.png"), UriKind.Absolute));


            //PushButtonData mill = new PushButtonData("Mill", "Mill", AddInPath, "Revit.SDK.Entools.Ribbon.CS.Mill");
            //billButton = ribbonMillPanel.AddItem(mill) as PushButton;
            //billButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\mill_24.png"), UriKind.Absolute));
            //billButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\mill_20.png"), UriKind.Absolute));




            //PushButtonData items = new PushButtonData("Items", "Items", AddInPath, "Revit.SDK.Entools.Ribbon.CS.Items");
            //PushButton itemsButton = ribbonMillPanel.AddItem(items) as PushButton;
            //itemsButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\items_24.png"), UriKind.Absolute));
            //itemsButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\items_20.png"), UriKind.Absolute));

            //PushButtonData scheme = new PushButtonData("Scheme", "Scheme", AddInPath, "Revit.SDK.Entools.Ribbon.CS.Schemes");
            //billButton = ribbonSchemePanel.AddItem(scheme) as PushButton;
            //billButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\scheme_24.png"), UriKind.Absolute));
            //billButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\scheme_20.png"), UriKind.Absolute));

            //PushButtonData info = new PushButtonData("Info", "Info", AddInPath, "Revit.SDK.Entools.Ribbon.CS.Info");
            //billButton = ribbonInfoPanel.AddItem(info) as PushButton;
            //billButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\info_24.png"), UriKind.Absolute));
            //billButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\info_20.png"), UriKind.Absolute));

            //PushButtonData rules = new PushButtonData("Rule", "Rule", AddInPath, "Revit.SDK.Samples.Ribbon.CS.Rules");
            //billButton = ribbonMillPanel.AddItem(rules) as PushButton;
            //billButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\rule.png"), UriKind.Absolute));
            //billButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\rule.png"), UriKind.Absolute));

            //PushButtonData broom = new PushButtonData("Broom", "Broom", AddInPath, "Revit.SDK.Samples.Ribbon.CS.Broom");
            //billButton = ribbonMillPanel.AddItem(broom) as PushButton;
            //billButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\broom.png"), UriKind.Absolute));
            //billButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\broom.png"), UriKind.Absolute));
           

            //PushButtonData settingsbr = new PushButtonData("Settings", "Settings", AddInPath, "Revit.SDK.Samples.Ribbon.CS.SettingsDialogbr");
            //billButton = ribbonMillPanel.AddItem(settingsbr) as PushButton;
            //billButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\settings.png"), UriKind.Absolute));
            //billButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "entools_img\\settings.png"), UriKind.Absolute));

            //ribbonSamplePanel.AddSeparator();

            //ToggleButton toggleButton = radioButtonGroup.AddItem(new ToggleButtonData("List", "List", AddInPath, "Revit.SDK.Samples.Ribbon.CS.List"));
            //toggleButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "list.png"), UriKind.Absolute));
            //toggleButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "list.png"), UriKind.Absolute));

            //toggleButton = radioButtonGroup.AddItem(new ToggleButtonData("Settingssp", "Settingssp", AddInPath, "Revit.SDK.Samples.Ribbon.CS.SettingsDialogsp"));
            //toggleButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "settings.png"), UriKind.Absolute));
            //toggleButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "settings.png"), UriKind.Absolute));

            //toggleButton = radioButtonGroup.AddItem(new ToggleButtonData("Mill", "Mill", AddInPath, "Revit.SDK.Samples.Ribbon.CS.Mill"));
            //toggleButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "settings.png"), UriKind.Absolute));
            //toggleButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "settings.png"), UriKind.Absolute));

            //toggleButton = radioButtonGroup.AddItem(new ToggleButtonData("Mill2", "Mill2", AddInPath, "Revit.SDK.Samples.Ribbon.CS.Mill2"));
            //toggleButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "settings.png"), UriKind.Absolute));
            //toggleButton.Image = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "settings.png"), UriKind.Absolute));

            //ribbonSamplePanel_MEP.AddSeparator();

            //ribbonSamplePanel_MEP.AddSlideOut();
        }





    }
}
