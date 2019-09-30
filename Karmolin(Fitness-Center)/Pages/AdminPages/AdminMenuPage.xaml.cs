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

namespace Karmolin_Fitness_Center_.Pages.AdminPages
{
    /// <summary>
    /// Interaction logic for AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        public AdminMenuPage()
        {
            InitializeComponent();
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new Pages.UserPage());
        }

        private void ButtonSale_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new Pages.SalePage());
        }

        private void ButtonAttendance_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new Pages.AttendancePage());
        }

        private void ButtonSubscriptions_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new Pages.SubscriptionPage());
        }
    }
}
