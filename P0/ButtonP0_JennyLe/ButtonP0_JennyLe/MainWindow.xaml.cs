using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ButtonP1_JennyLe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SoundPlayer sonataNo14 = new SoundPlayer("sounds\\moonlightsonata14.wav");
        private int SBcounter = 0;
        public MainWindow()
        {
            InitializeComponent();
            sonataNo14.Play();
            Storyboard lisaSB = this.Resources["lisa_storyboard"] as Storyboard;
            lisaSB.Begin();

        }

        private void Corgi_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SBcounter == 0)
            {
                Storyboard stickersSB = this.Resources["stickers_storyboard"] as Storyboard;
                stickersSB.Begin();
                SBcounter++;
            } else if (SBcounter == 1)
            {
                Storyboard stickers2SB = this.Resources["stickers2_storyboard"] as Storyboard;
                stickers2SB.Begin();
                SBcounter++;
            } else if (SBcounter == 2)
            {
                Storyboard stickers3SB = this.Resources["stickers3_storyboard"] as Storyboard;
                stickers3SB.Begin();
                SBcounter++;
            } else if (SBcounter == 3)
            {
                Storyboard stickers4SB = this.Resources["stickers4_storyboard"] as Storyboard;
                stickers4SB.Begin();
                SBcounter++;
            } else if (SBcounter == 4)
            {
                Storyboard stickers5SB = this.Resources["stickers5_storyboard"] as Storyboard;
                stickers5SB.Begin();
                SBcounter++;
            } else if (SBcounter == 5)
            {
                Storyboard endSB = this.Resources["end_storyboard"] as Storyboard;
                endSB.Begin();
                SBcounter++;
            } else if (SBcounter == 6)
            {
                Storyboard resetSB = this.Resources["reset_storyboard"] as Storyboard;
                resetSB.Begin();
                SBcounter = 0;
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(2000);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            Storyboard lisaSB = this.Resources["lisa_storyboard"] as Storyboard;
            lisaSB.Begin();
            timer.Stop();
        }

        private void Corgi_MouseEnter(object sender, MouseEventArgs e)
        {
            corgi.Source = new BitmapImage(new Uri(@"/images/corgi_mouthclosed.png", UriKind.Relative));
        }

        private void Corgi_MouseLeave(object sender, MouseEventArgs e)
        {
            corgi.Source = new BitmapImage(new Uri(@"/images/corgi_new.png", UriKind.Relative));
        }
    }
}
