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

namespace ProjektGrupowy
{
    /// <summary>
    /// Interaction logic for ekranO.xaml
    /// </summary>
    public partial class ekranO : Window
    {

        Options op;
        Options tmpop;

        public ekranO()
        {
            tmpop = new Options();
            InitializeComponent();

           // ballSpeedSlider.Value = tmpop.BallSpeed;
            //p1SpeedSlider.Value = tmpop.P1Speed;
            //p2SpeedSlider.Value = tmpop.P2Speed;

        }

        internal Options Op
        {
            get
            {
                return op;
            }

            set
            {
                op = value;
                ballSpeedSlider.Value = op.BallSpeed;
                p1SpeedSlider.Value = op.P1Speed;
                p2SpeedSlider.Value = op.P2Speed;

            }
        }

        private void ballSpeedSliderValue(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tmpop.BallSpeed = ballSpeedSlider.Value;
        }

        private void p1SpeedSliderValue(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tmpop.P1Speed = p1SpeedSlider.Value;
        }

        private void p2SpeedSliderValue(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tmpop.P2Speed = p2SpeedSlider.Value;
        }

        private bool verifyInt(TextBox text)
        {
            try
            {
                int tmp = Convert.ToInt32(text.Text);
            }
            catch
            {
                return false;
            }
            return true;
        }

        

        private void closeWindow()
        {
            //MainWindow M = new MainWindow();
            this.Close();
            //M.Show();
        }

        private void applySettings_Click(object sender, RoutedEventArgs e)
        {
            // podmiana 
            if (verifyInt(pointLimit) && verifyInt(timeLimit))
            {
                tmpop.PointLimit = Convert.ToInt32(pointLimit.Text);
                tmpop.TimeLimit = Convert.ToInt32(timeLimit.Text);

                //op = tmpop;
                //przypisanie opcji
                op.BallColor = tmpop.BallColor;
                op.BallSpeed = tmpop.BallSpeed;
                op.P1Color = tmpop.P1Color;
                op.P1Speed = tmpop.P1Speed;
                op.P2Color = tmpop.P2Color;
                op.P2Speed = tmpop.P2Speed;
                op.PointLimit = tmpop.PointLimit;
                op.TimeLimit = tmpop.TimeLimit;
                // powrot do ekranu glownego
                closeWindow();
            }
        }

        private void discardSettings_Click(object sender, RoutedEventArgs e)
        {
            // powrot do ekranu glownego
             closeWindow();
           
        }

        private void p1col1_Checked(object sender, RoutedEventArgs e)
        {
            tmpop.P1Color = (Color)ColorConverter.ConvertFromString("#FFFFFF");
        }

        private void p1col2_Checked(object sender, RoutedEventArgs e)
        {
            tmpop.P1Color = (Color)ColorConverter.ConvertFromString("#FFB208");
        }

        private void p2col1_Checked(object sender, RoutedEventArgs e)
        {
            tmpop.P2Color = (Color)ColorConverter.ConvertFromString("#FFFFFF");
        }

        private void p2col2_Checked(object sender, RoutedEventArgs e)
        {
            tmpop.P2Color = (Color)ColorConverter.ConvertFromString("#FFB208");
        }

        private void ballcol1_Checked(object sender, RoutedEventArgs e)
        {
            tmpop.BallColor = (Color)ColorConverter.ConvertFromString("#FFFFFF");
        }

        private void ballcol2_Checked(object sender, RoutedEventArgs e)
        {
            tmpop.BallColor = (Color)ColorConverter.ConvertFromString("#FFB208");
        }
    }
}
