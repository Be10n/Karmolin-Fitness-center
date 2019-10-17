using System;
using System.Collections.Generic;
using System.Globalization;
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
        private Random _random = new Random();
        private int _triesCount = 0;
        private DispatcherTimer _blockTimer = new DispatcherTimer();
        private DateTime _startDate = new DateTime();
        string _capchaText = "";

        public AutarizationPage()

        {
            InitializeComponent();
           

        }

        private void GenerateQuestion()
        {
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

            try
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
                        if (_capchaText == TextBoxCapcha.Text)
                        {
                            AppData.MainFrame.Navigate(new Pages.AdminPages.AdminMenuPage());
                        }
                        else
                        {
                            MessageBox.Show(Properties.Resources.MessageCapcha, Properties.Resources.MessageError, MessageBoxButton.OK, MessageBoxImage.Error);
                            ImageCapcha.Source = Drawing(Convert.ToInt32(ImageCapcha.Width), Convert.ToInt32(ImageCapcha.Height));
                            TextBoxCapcha.Text = "";
                        }

                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.MessageSystem, Properties.Resources.MessageError, MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                else
                {
                    MessageBox.Show(Properties.Resources.MessageUser, Properties.Resources.MessageError, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch { }
        }

        private void dispatherTimer_Tick(object sender, EventArgs e)
        {

            LabelTimer.Content = DateTime.Now.Second;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageCapcha.Source = Drawing(Convert.ToInt32(ImageCapcha.Width), Convert.ToInt32(ImageCapcha.Height));
        }
        private DrawingImage Drawing(int width, int height)
        {
            _capchaText = "";
            Random random = new Random();
            string AllText = "qQWne4oqwiWNoeq0nonIWE0nklnW1ANJncnJk3aLAda5klm";
            for (int i = 0; i < 6; i++)
            {
                _capchaText += AllText[random.Next(AllText.Length)];
            }
            byte[] bytes = new byte[width * height * 100];
            random.NextBytes(bytes);
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(BitmapSource.Create(width, height, 300, 300, PixelFormats.Rgb48, null, bytes, width * 30), new Rect(0, 0, width, height));
                int v = ((height / 4) + (width / 4));
#pragma warning disable CS0618 // Type or member is obsolete
                drawingContext.DrawText(new FormattedText(_capchaText, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), v / 2, Brushes.Black), new Point(width / 7 , height / 7));
#pragma warning restore CS0618 // Type or member is obsolete
            }
            return new DrawingImage(drawingVisual.Drawing);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ImageCapcha.Source = Drawing(Convert.ToInt32(ImageCapcha.Width), Convert.ToInt32(ImageCapcha.Height));
            TextBoxCapcha.Text = "";
        }
    }
}
