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
using System.Windows.Shapes;

namespace TPU_Schedule_to_Google_Calendar.Google_Calendar
{
    /// <summary>
    /// Логика взаимодействия для AuthenticationForm.xaml
    /// </summary>
    public partial class AuthenticationForm : Window
    {
        public AuthenticationForm()
        {
            InitializeComponent();

        }

        private void ok_button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
