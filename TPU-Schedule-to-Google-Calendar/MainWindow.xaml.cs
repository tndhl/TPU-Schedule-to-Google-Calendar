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

using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace TPU_Schedule_to_Google_Calendar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (Properties.Settings.Default.RefreshToken == String.Empty)
            {
                WelcomeScreen WelcomeScreen = new WelcomeScreen();

                this.Hide();
                WelcomeScreen.ShowDialog();

                if (WelcomeScreen.DialogResult.HasValue && WelcomeScreen.DialogResult.Value)
                {
                    this.Show();
                }
            }

            Google_Calendar.Calendar CalendarService = new Google_Calendar.Calendar();

            listBox1.DisplayMemberPath = "Summary";

            foreach (CalendarListEntry calendar in CalendarService.getCalendarList())
            {
                listBox1.Items.Add(calendar);
            }
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
