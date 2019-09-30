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

namespace Karmolin_Fitness_Center_.Pages
{
    /// <summary>
    /// Interaction logic for SubscriptionPage.xaml
    /// </summary>
    public partial class SubscriptionPage : Page
    {
        public SubscriptionPage()
        {
            InitializeComponent();
            DgridSubscriptions.AutoGenerateColumns = false;
            DgridSubscriptions.ItemsSource = AppData.dataBase.Subscriptions.ToList();
        }
    }
}
