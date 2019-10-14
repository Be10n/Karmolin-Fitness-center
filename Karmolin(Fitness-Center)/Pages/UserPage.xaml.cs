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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            DgridUsers.AutoGenerateColumns = false;
            DgridUsers.ItemsSource = AppData.dataBase.User.ToList();
            
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateText();
        }

        private void UpdateText()
        {
            var ListServ = AppData.dataBase.User.ToList();
            if (TextBoxSearch.Text !="")
            {
                ListServ = ListServ.Where(p => p.Name.ToLower().Contains(TextBoxSearch.Text.ToLower())).ToList();
            }
            DgridUsers.ItemsSource = ListServ;
        }
    }
}
