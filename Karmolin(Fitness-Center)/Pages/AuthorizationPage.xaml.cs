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
using System.Windows.Threading;

namespace Karmolin_Fitness_Center_.Pages
{
    /// <summary>
    /// Interaction logic for AutarizationPage.xaml
    /// </summary>
    public partial class AutarizationPage : Page
    {
        private int _triesCount = 0;
        private DispatcherTimer _blockTimer = new DispatcherTimer();
        private DateTime _startDate = new DateTime();
        public AutarizationPage()
        {
            InitializeComponent();
            _blockTimer.Interval = TimeSpan.FromSeconds(1);
            _blockTimer.Tick += _BlockTimer_Tick;
        }

        private void _BlockTimer_Tick(object sender, EventArgs e)
        {
            var difference = DateTime.Now - _startDate;
            if (difference.TotalSeconds > 60)
            {
                ButtonLogin.IsEnabled = true;
                _blockTimer.Stop();
                ButtonLogin.Content = Properties.Resources.ActionLogin;
            }
            else
            {
                ButtonLogin.Content = (60 - difference.TotalSeconds).ToString("N0");
            }
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text == "" ||
                PasswordBoxPassword.Password == "")
            {
                MessageBox.Show("All field are required",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                _triesCount++;
                if (_triesCount >= 3)
                {
                    ButtonLogin.IsEnabled = false;
                    _startDate = DateTime.Now;
                    _blockTimer.Start();
                    _BlockTimer_Tick(null, null);
                }
            }
            var currentUser = AppData.dataBase.User.ToList()
                .Where(p => p.Login == TextBoxLogin.Text && p.Password == PasswordBoxPassword.Password).FirstOrDefault();
            if (currentUser != null)
            {
                if (currentUser.RoleID == "A")
                {
                    AppData.MainFrame.Navigate(new Pages.AdminPages.AdminMenuPage());
                }
                else
                {
                    MessageBox.Show("You cannot use this system!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }

        private void dispatherTimer_Tick(object sender, EventArgs e)
        {

            LabelTimer.Content = DateTime.Now.Second;
        }
    }
}
