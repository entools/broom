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
using EntoolsBroom.Model;

namespace EntoolsBroom.View
{
    /// <summary>
    /// Логика взаимодействия для NewMainVindow.xaml
    /// </summary>
    public partial class NewMainWindow : Window, IDisposable
    {
        public NewMainWindow()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            //Dispose();
            //GC.SuppressFinalize(this);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            
            Close();

        }
    }
}
