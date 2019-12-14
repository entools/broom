using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Entools.Model;
using MaterialDesignThemes.Wpf;

namespace Entools.View
{
    /// <summary>
    /// Логика взаимодействия для NewMainVindow.xaml
    /// </summary>
    public partial class NewMainWindow : Window, IDisposable
    {
        public NewMainWindow()
        {
            InitializeMaterialDesign();
            InitializeComponent();
        }
        private void InitializeMaterialDesign()
        {
            // Create dummy objects to force the MaterialDesign assemblies to be loaded
            // from this assembly, which causes the MaterialDesign assemblies to be searched
            // relative to this assembly's path. Otherwise, the MaterialDesign assemblies
            // are searched relative to Eclipse's path, so they're not found.
            var card = new Card();
            var hue = new MaterialDesignColors.Hue("Dummy", Colors.Black, Colors.White);
            var dummy = typeof(MaterialDesignThemes.Wpf.Theme);
            var dummy1 = typeof(Dragablz.TabablzControl);
        }

        public void Dispose()
        {
            //Dispose();
            //GC.SuppressFinalize(this);
        }

        //private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        //{
            
        //    Close();

        //}
    }
}
