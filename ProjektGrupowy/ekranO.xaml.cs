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
    public partial class ekranO : Page
    {

        Options op;
        Options tmpop;

        public ekranO()
        {
            InitializeComponent();
            tmpop = new Options();
            ballSpeedSlider.Value = tmpop.BallSpeed;
            p1SpeedSlider.Value = tmpop.P1Speed;
            p2SpeedSlider.Value = tmpop.P2Speed;
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
            }
        }

        private void ballSpeedSliderValue(object sender, RangeBaseValueChangedEventArgs e)
        {
            tmpop.BallSpeed = ballSpeedSlider.Value;
        }

        private void p1SpeedSliderValue(object sender, RangeBaseValueChangedEventArgs e)
        {
            tmpop.P1Speed = p1SpeedSlider.Value;
        }

        private void p2SpeedSliderValue(object sender, RangeBaseValueChangedEventArgs e)
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

        private void applySettings_Click(object sender, RoutedEventArgs e)
        {
            // podmiana 
            if (verifyInt(pointLimit) && verifyInt(timeLimit))
            {
                tmpop.PointLimit = Convert.ToInt32(pointLimit.Text);
                tmpop.TimeLimit = Convert.ToInt32(timeLimit.Text);
            }
            op = tmpop;
            // powrot do ekranu glownego
        }

        private void discardSettings_Click(object sender, RoutedEventArgs e)
        {
            // powrot do ekranu glownego
        }

    }
}
