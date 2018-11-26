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

namespace Sneg.Screens
{
    /// <summary>
    /// Interaction logic for PostGameScreen.xaml
    /// </summary>
    public partial class PostGameScreen : Window
    {
        public int endScore;
        public Uri konnaMouKa = new Uri("Assets\\konna_monu_ka.mp3", UriKind.Relative);
        public Uri naniGaShitai = new Uri("Assets\\nani_ga_shitai.mp3", UriKind.Relative);
        public PostGameScreen(int score)
        {

            InitializeComponent();
            endScore = score;

            theSnegSpeaks(endScore);
            endScoreLabel.Content = "Your final score: " + endScore.ToString();

        }

        private void closeGameBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception exc)
            {
                this.Close();
            }
            
        }

        private void retryBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new MainWindow().Show();
                this.Close();
            }
            catch(Exception exc)
            {
                this.Close();
            }
        }

        private void theSnegSpeaks(int score)
        {
            if ((score % 2) == 0)
            {
                audioElement.Source = konnaMouKa;
            }
            else
            {
                audioElement.Source = naniGaShitai;
            }
            //audioElement.Volume = 1.0;
            audioElement.Play();
        }
    }
}
