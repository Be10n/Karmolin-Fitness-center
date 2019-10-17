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

namespace Karmolin_Fitness_Center_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool a = false;
        public MainWindow()
        {
            if (Properties.Settings.Default.CurrentCulture == "")
            {
                Properties.Settings.Default.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
                Properties.Settings.Default.Save();
            }
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.CurrentCulture);

            InitializeComponent();
            a = true;
            if (Properties.Settings.Default.CurrentCulture == "ru-Ru")
            {
                ComboLanguage.SelectedIndex = 0;
            }
            else
            {
                ComboLanguage.SelectedIndex = 1;
            }
            AppData.MainFrame = MainFrame;
            AppData.MainFrame.Navigate(new Pages.AutarizationPage());
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.MainFrame.CanGoBack)
                AppData.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            var page = MainFrame.Content as Page;
            if(page.Title == "Authorization")
            {
                ButtonBack.Visibility = Visibility.Collapsed;
            }
            else
            {
                ButtonBack.Visibility = Visibility.Visible;
            }
            Title = page.Title;
            Hedder.Text = page.Title; 
        }


        private void ComboLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (a)
            {

                if (ComboLanguage.SelectedIndex == 0)
                {
                    Properties.Settings.Default.CurrentCulture = "ru-Ru";
                }
                else
                {
                    Properties.Settings.Default.CurrentCulture = "en-Us";
                }
                Properties.Settings.Default.Save();

                if (MessageBox.Show(Properties.Resources.MessageContent, Properties.Resources.MessageQuestion, MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                    MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                    System.Diagnostics.Process.Start
                        (App.ResourceAssembly.Location);

                }
            }
            else
            {
                a = true;
            }

        }
    }
}
