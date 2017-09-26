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
        // Ragnarok Online OST: Peaceful Forest - by soundTeMP
        private SoundPlayer peacefulForest = new SoundPlayer("sounds\\peacefulForest.wav");

        // How Far I'll Go ft. Auli'i Cravalho (Moana Theme) - by Lin-Manuel Miranda, transcribed by LyricWulf
        private SoundPlayer moanaTheme = new SoundPlayer("sounds\\moanaTheme.wav");

        // Toccata and Fugue in D Minor on Organ - by J.S. Bach
        private SoundPlayer fugenInD = new SoundPlayer("sounds\\toccataandfugueinD.wav");

        // Hedwig's Theme - by John Williams, performed by Roman Cooperman
        private SoundPlayer hpTheme = new SoundPlayer("sounds\\hpTheme.wav");

        // Canon in D - by Pachelbel, performed by Lee Galloway
        private SoundPlayer canonInD = new SoundPlayer("sounds\\canoninD.wav");

        // Moonlight Sonata No. 14 - Beethoven
        private SoundPlayer sonataNo14 = new SoundPlayer("sounds\\moonlightsonata14.wav");

        // Storyboard counter, to see which storyboard is next in line
        private int SBcounter = 0;

        public MainWindow()
        {
            InitializeComponent(); // Initialize
            peacefulForest.Play(); // Play .wav file
            
            // Change the background to the forest image
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\Jennykuma\Desktop\Fourth Year 2017-2018\CPSC 581\CPSC-581\P0\ButtonP0_JennyLe\ButtonP0_JennyLe\images\walkingtrail.png")));

            Storyboard lisaSB = this.Resources["lisa_storyboard"] as Storyboard; // Create the storyboard object
            lisaSB.Begin(); // Play the storyboard

        }

        private void Corgi_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SBcounter == 0) // If corgi is clicked
            {
                moanaTheme.Play(); // Play .wav file
                Storyboard stickersSB = this.Resources["stickers_storyboard"] as Storyboard; // Create storyboard object
                stickersSB.Begin(); // Play the storyboard
                SBcounter++; // Update the counter to go onto the next storyboard

            } else if (SBcounter == 1)
            {
                fugenInD.Play(); // Play .wav file

                // Change the background to the camping image
                this.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\Jennykuma\Desktop\Fourth Year 2017-2018\CPSC 581\CPSC-581\P0\ButtonP0_JennyLe\ButtonP0_JennyLe\images\camping.png")));

                Storyboard stickers2SB = this.Resources["stickers2_storyboard"] as Storyboard; // Create the storyboard object
                stickers2SB.Begin(); // Play the storyboard
                SBcounter++; // Update the counter

            } else if (SBcounter == 2)
            {
                hpTheme.Play(); // Play .wav file

                // Change the background to the grand staircase image
                this.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\Jennykuma\Desktop\Fourth Year 2017-2018\CPSC 581\CPSC-581\P0\ButtonP0_JennyLe\ButtonP0_JennyLe\images\grandstaircase.png")));

                Storyboard stickers3SB = this.Resources["stickers3_storyboard"] as Storyboard; // Create the storyboard object
                stickers3SB.Begin(); // Play the storyboard
                SBcounter++; // Update the counter

            } else if (SBcounter == 3)
            {
                canonInD.Play(); // Play the .wav file

                // Change the background to the space image
                this.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\Jennykuma\Desktop\Fourth Year 2017-2018\CPSC 581\CPSC-581\P0\ButtonP0_JennyLe\ButtonP0_JennyLe\images\space.png")));

                Storyboard stickers4SB = this.Resources["stickers4_storyboard"] as Storyboard; // Create the storyboard object
                stickers4SB.Begin(); // Play the storyboard
                SBcounter++; // Update the counter

            } else if (SBcounter == 4)
            {
                // Change the image to the yarn image
                this.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\Jennykuma\Desktop\Fourth Year 2017-2018\CPSC 581\CPSC-581\P0\ButtonP0_JennyLe\ButtonP0_JennyLe\images\yarn.png")));

                Storyboard stickers5SB = this.Resources["stickers5_storyboard"] as Storyboard; // Create the storyboard object
                stickers5SB.Begin(); // Play the storyboard
                SBcounter++; // Update the counter

            } else if (SBcounter == 5)
            {
                sonataNo14.Play(); // Play the .wav file

                // Change the background to the underwater image
                this.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\Jennykuma\Desktop\Fourth Year 2017-2018\CPSC 581\CPSC-581\P0\ButtonP0_JennyLe\ButtonP0_JennyLe\images\underwater.png")));

                Storyboard endSB = this.Resources["end_storyboard"] as Storyboard; // Create the storyboard object
                endSB.Begin(); // Play the storyboard
                SBcounter++; // Update the counter

            } else if (SBcounter == 6)
            {
                Storyboard resetSB = this.Resources["reset_storyboard"] as Storyboard; // Create the storyboard object
                resetSB.Begin(); // Reset all the stickers
                SBcounter = 0; // Reset the counter

                DispatcherTimer timer = new DispatcherTimer(); // Create the dispatchertimer object
                timer.Interval = TimeSpan.FromMilliseconds(2000); // Create an interval of 2000 milliseconds
                timer.Tick += Timer_Tick; // Add to the timer
                timer.Start(); // Start the timer
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender; // Typecast the sender object to dispatchertimer
            peacefulForest.Play(); // Play the .wav file

            // Change the background to the forest image
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\Jennykuma\Desktop\Fourth Year 2017-2018\CPSC 581\CPSC-581\P0\ButtonP0_JennyLe\ButtonP0_JennyLe\images\walkingtrail.png")));

            Storyboard lisaSB = this.Resources["lisa_storyboard"] as Storyboard; // Create the storyboard object
            lisaSB.Begin(); // Play the storyboard
            timer.Stop(); // Stop the timer so it doesn't repeat 
        }

        private void Corgi_MouseEnter(object sender, MouseEventArgs e)
        {
            // Change the image of the corgi when the mouse is on top of it (on the pixels)
            corgi.Source = new BitmapImage(new Uri(@"/images/corgi_mouthclosed.png", UriKind.Relative));
        }

        private void Corgi_MouseLeave(object sender, MouseEventArgs e)
        {
            // Change the image of the corgi when the mouse leaves the image (not on the pixels)
            corgi.Source = new BitmapImage(new Uri(@"/images/corgi_new.png", UriKind.Relative));
        }
    }
}
