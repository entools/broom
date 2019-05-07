using System.Windows;
using System.Windows.Input;
using Autodesk.Revit.UI;
using System.Text.RegularExpressions;
using Revit.SDK.Entools.Ribbon.CS;

namespace Revit
{
    /// <summary>
    /// Логика взаимодействия для UserControl2.xaml
    /// </summary>

    public partial class UserControl2 : Window
    {
        bool com = false;
        public UserControl2(ExternalCommandData revit)
        {
            InitializeComponent();
            tbSettingText.Text = Revit.Properties.Settings.Default["names"].ToString();

            //wins.Name = "txt";
            wins.ShowDialog();
            Broom broom = new Broom();

            if (com == true)
            {
                broom.Analyze(revit);
            }
        }


        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            wins.Close();
        }


        private void Button_OK(object sender, RoutedEventArgs e)
        {
            com = true;
            Revit.Properties.Settings.Default["names"] = tbSettingText.Text;
            Revit.Properties.Settings.Default.Save();
            wins.Close();
        }

    }
}