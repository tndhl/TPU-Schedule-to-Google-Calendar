using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace TPU_Schedule_to_Google_Calendar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Google_Calendar.Calendar CalendarService = new Google_Calendar.Calendar();

            listBox1.DisplayMember = "Summary";

            foreach (CalendarListEntry calendar in CalendarService.getCalendarList())
            {
                listBox1.Items.Add(calendar);
            }
        }
    }
}
