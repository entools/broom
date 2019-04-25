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
using RApplication = Autodesk.Revit.ApplicationServices.Application;
using Revit.Properties;
using System.Text.RegularExpressions;
using Revit.SDK.Entools.Ribbon.CS;

namespace Revit
{
    /// <summary>
    /// Логика взаимодействия для UserControl2.xaml
    /// </summary>
    /// 



    public partial class UserControl2 : Window//UserControl
    {
        //Window win = new Window();
        public UserControl2()//Document doc)
        {
            InitializeComponent();

            //инициализация всех компонентов окна в его конструкторе
            //InitializeComponent();
            //подписываем textBox на событие PreviewTextInput, 
            //с помощью которого можно обрабатывать вводимый текст
            


            tbSettingText.Text = Revit.Properties.Settings.Default["list_syst"].ToString();
            //plumbing_check.IsChecked = Convert.ToBoolean(Revit.Properties.Settings.Default["plumbing"]);
            //accessory_check.IsChecked = Convert.ToBoolean(Revit.Properties.Settings.Default["accecory"]);
            //fitting_check.IsChecked = Convert.ToBoolean(Revit.Properties.Settings.Default["fitting"]);
            //flex_check.IsChecked = Convert.ToBoolean(Revit.Properties.Settings.Default["flex"]);

            //win.Icon = BitmapFrame.Create(iconUri);


            //Uri iconUri = new Uri(@"C:\Users\Bogdan.Mazur\Desktop\PLUGIN\EnToolsLtWPF\CS\entools_img\settings.ico", UriKind.RelativeOrAbsolute);
            //Uri iconUri = new Uri(@"S\entools_img\settings.ico", UriKind.RelativeOrAbsolute);
            //win.Icon = BitmapFrame.Create(iconUri);
            //win.Icon = "pack://application:,,,/Resources/favicon.ico";
            //win.Height = 620;
            //win.Width = 420;
            //win.ShowDialog();
            wins.Name = "txt";
            wins.ShowDialog();
            //Broom broom = new Broom();
            //broom.DelView(doc);

        }





        private void onbtn_click(object sender, RoutedEventArgs e)
        {
            //TaskDialog.Show("Hello", _name);
        }

        public void OnOK()
        {

            //Broom myClass = new Broom();
            //myClass.DelView(doc);
            //myClass.Funcion();
            //TaskDialog.Show("OK", "_name");
        }

        public void OnCancel()
        {
             
            //TaskDialog.Show("OnCancel", _name);

        }

        public void OnRestoreDefaults()
        {
            //TaskDialog.Show("OnRestoreDefaults", _name);
        }

        //String _name;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        public Action CloseAction { get; set; }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {


            wins.Close();
            //Application.Current.Shutdown();
            //Application.Current.Shutdown();
            //OnCancel();
        }


        
        private void Button_OK(object sender, RoutedEventArgs e)
        {

            
            Broom broom = new Broom();
            wins.Close();
            broom.DelView();
            


            //if (tbSettingText.Text != "" && koef_p.Text != "" && koef_i.Text != "" && param1.Text != "" && param2.Text != "" && param3.Text != "" && param4.Text != ""
            //    && param5.Text != "" && param6.Text != "" && param7.Text != "" && param8.Text != "" && param9.Text != "" && param10.Text != "" && token.Text != "" && sheet.Text != "")
            //{
           // Revit.Properties.Settings.Default.Save();
                

            //}



            //ActiveForm.Close();

        }

        private void CheckBox_Plumbings(object sender, RoutedEventArgs e)
        {
            //Plumbing_check.IsChecked = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Apply(object sender, RoutedEventArgs e)
        {
            if (tbSettingText.Text == "")
            {
                tbSettingText.Background = Brushes.LightPink;
            }
            //else
            //{
            //    tbSettingText.Background = Brushes.White;
            //}

            //if (koef_p.Text == "")
            //{
            //    koef_p.Background = Brushes.LightPink;
            //}
            //else
            //{
            //    koef_p.Background = Brushes.White;
            //}

            //if (koef_i.Text == "")
            //{
            //    koef_i.Background = Brushes.LightPink;
            //}
            //else
            //{
            //    koef_i.Background = Brushes.White;
            //}

            //if (param1.Text == "")
            //{
            //    param1.Background = Brushes.LightPink;
            //}
            //else
            //{
            //    param1.Background = Brushes.White;
            //}

            //if (param2.Text == "")
            //{
            //    param2.Background = Brushes.LightPink;
            //}
            //else
            //{
            //    param2.Background = Brushes.White;
            //}

            //if (param3.Text == "")
            //{
            //    param3.Background = Brushes.LightPink;
            //}
            //else
            //{
            //    param3.Background = Brushes.White;
            //}

            //if (param4.Text == "")
            //{
            //    param4.Background = Brushes.LightPink;
            //}
            //else
            //{
            //    param4.Background = Brushes.White;
            //}

            //if (param5.Text == "")
            //{
            //    param5.Background = Brushes.LightPink;
            //}
            //else
            //{
            //    param5.Background = Brushes.White;
            //}

            //if (param6.Text == "")
            //{
            //    param6.Background = Brushes.LightPink;
            //}
            //else
            //{
            //    param6.Background = Brushes.White;
            //}

            //if (param7.Text == "")
            //{
            //    param7.Background = Brushes.LightPink;
            //}
            //else
            //{
            //    param7.Background = Brushes.White;
            //}

            //if (param8.Text == "")
            //{
            //    param8.Background = Brushes.LightPink;
            //}
            //else
            //{
            //    param8.Background = Brushes.White;
            //}
                
            //if (param9.Text == "")
            //{
            //    param9.Background = Brushes.LightPink;
            //}
            //else
            //{
            //    param9.Background = Brushes.White;
            //}

            //if (param10.Text == "")
            //{
            //    param10.Background = Brushes.LightPink;
            //}
            //else
            //{
            //    param10.Background = Brushes.White;
            //}

            //if (sheet.Text == "")
            //{
            //    sheet.Background = Brushes.LightPink;
            //}
            //else
            //{
            //    sheet.Background = Brushes.White;
            //}

            //if (token.Text == "")
            //{
            //    token.Background = Brushes.LightPink;
            //}
            //else
            //{
            //    token.Background = Brushes.White;
            //}



            Revit.Properties.Settings.Default["list_syst"] = tbSettingText.Text;
            //Revit.Properties.Settings.Default["plumbing"] = plumbing_check.IsChecked;
            //Revit.Properties.Settings.Default["accecory"] = accessory_check.IsChecked;
            //Revit.Properties.Settings.Default["fitting"] = fitting_check.IsChecked;
            //Revit.Properties.Settings.Default["flex"] = flex_check.IsChecked;
            //Revit.Properties.Settings.Default["pipe"] = pipe_check.IsChecked;
            //Revit.Properties.Settings.Default["insulation"] = insulation_check.IsChecked;
            //Revit.Properties.Settings.Default["counter"] = counter_check.IsChecked;
            //Revit.Properties.Settings.Default["TD"] = stages.Text;

            //if (koef_p.Text != "")
            //{
            //    Revit.Properties.Settings.Default["koef_p"] = Convert.ToDouble(koef_p.Text);
            //}
            //if (koef_i.Text != "")
            //{
            //    Revit.Properties.Settings.Default["koef_i"] = Convert.ToDouble(koef_i.Text);
            //}            

            //Revit.Properties.Settings.Default["spname1"] = param1.Text;
            //Revit.Properties.Settings.Default["spname2"] = param2.Text;
            //Revit.Properties.Settings.Default["spname3"] = param3.Text;
            //Revit.Properties.Settings.Default["spname4"] = param4.Text;
            //Revit.Properties.Settings.Default["spname5"] = param5.Text;
            //Revit.Properties.Settings.Default["spname6"] = param6.Text;
            //Revit.Properties.Settings.Default["spname7"] = param7.Text;
            //Revit.Properties.Settings.Default["spname8"] = param8.Text;
            //Revit.Properties.Settings.Default["spname9"] = param9.Text;
            //Revit.Properties.Settings.Default["spname10"] = param10.Text;
            //Revit.Properties.Settings.Default["eworkset"] = fworkset.Text;
            //Revit.Properties.Settings.Default["jsonn"] = token.Text;
            //Revit.Properties.Settings.Default["sheet"] = sheet.Text;
            //Revit.Properties.Settings.Default["revit"] = export_gs.IsChecked;
            //Revit.Properties.Settings.Default["gs"] = export_rvt.IsChecked;

            //if (tbSettingText.Text != "" && koef_p.Text != "" && koef_i.Text != "" && param1.Text != "" && param2.Text != "" && param3.Text != "" && param4.Text != ""
            //     && param5.Text != "" && param6.Text != "" && param7.Text != "" && param8.Text != "" && param9.Text != "" && param10.Text != "" && token.Text != "" && sheet.Text != "")
            //{
                Revit.Properties.Settings.Default.Save();
            //}
                

        }


        ////Regex inputRegex = new Regex(@"^[1-3]$");
        //private void NumberValidationTextBox(object sender, TextChangedEventArgs e)
        //{
        //    Regex regex = new Regex("[^0-9]+");
        //    e.Handled = regex.IsMatch(e.Text);
        //}
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
//}
