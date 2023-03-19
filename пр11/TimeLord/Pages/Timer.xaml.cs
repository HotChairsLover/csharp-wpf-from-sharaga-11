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

namespace TimeLord.Pages
{
    /// <summary>
    /// Логика взаимодействия для Timer.xaml
    /// </summary>
    public partial class Timer : Page
    {

        public DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public float full_second = 0;
        public bool start_stopwatch = false;
        public Timer()
        {
            InitializeComponent();

            dispatcherTimer.Tick += TimerSecond;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }

        private void TimerSecond(object sender, EventArgs e)
        {
            if (full_second > 0)
            {
                full_second--;

                float hours = (int)(full_second / 60 / 60);
                float minuts = (int)(full_second / 60) - (hours * 60);
                float seconds = full_second - (hours * 60 * 60) - (minuts * 60);

                string s_seconds = seconds.ToString();
                if (seconds < 10)
                {
                    s_seconds = "0" + seconds;
                }

                string s_minuts = minuts.ToString();
                if (minuts < 10)
                {
                    s_minuts = "0" + minuts;
                }
                string s_hours = hours.ToString();
                if (hours < 10)
                {
                    s_hours = "0" + hours;
                }

                time.Content = s_hours + ":" + s_minuts + ":" + s_seconds;
            }
            else
            {
                dispatcherTimer.Stop();
                start_stopwatch = false;
                start.Content = "Начать";
            }
        }

        private void StartStopwatch(object sender, RoutedEventArgs e)
        {
            if (start_stopwatch == false)
            {
                int hours = 0;
                int minutes = 0;
                int seconds = 0;
                try
                {
                    hours = Convert.ToInt32(hour.Text);
                    minutes = Convert.ToInt32(min.Text);
                    seconds = Convert.ToInt32(sec.Text);
                    full_second = (hours * 60 * 60) + (minutes * 60) + seconds;
                    dispatcherTimer.Start();
                    start_stopwatch = true;
                    start.Content = "Стоп";
                }
                catch
                {
                    MessageBox.Show("Часы, минуты и секунды должны быть цифрой");
                }
            }

            else
            {
                dispatcherTimer.Stop();
                start_stopwatch = false;
                start.Content = "Начать";
            }
        }
    }
}
