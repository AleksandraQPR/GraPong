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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektGrupowy
{
    /// <summary>
    /// Interaction logic for PlayArea.xaml
    /// </summary>
    public partial class PlayArea : Window
    {
        //private Storyboard myStoryboard;
        Random randomX = new Random();      
        Random randomY = new Random();
        private int goBallDirectionX;
        private int goBallDirectionY;

        private double goX;
        private double goY;

        public PlayArea()
        {
            InitializeComponent();
            //this.Loaded += ChallengePage_Loaded;

            goBallDirectionX = randomX.Next(0,2);    // losowa liczba 0 lub 1
            goBallDirectionY = randomY.Next(0,2);    // losowa liczba 0 lub 1

            BallMovingTimer();   
        }

        private void BallMovingTimer()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 5);   // czas w milisekundach
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (goBallDirectionX == 0)
                goX = Canvas.GetLeft(ball) - 5;
            else
                goX = Canvas.GetLeft(ball) + 5;

            if (goBallDirectionY == 0)
                goY = Canvas.GetTop(ball) + 5;
            else
                goY = Canvas.GetTop(ball) - 5;

            if (goX > 0 && goX < areaOfGame.ActualWidth && goY > 0 && goY < areaOfGame.ActualHeight)
            {
                Canvas.SetLeft(ball, goX);
                Canvas.SetTop(ball, goY);
            }
            else if (goX <= 0)
                goBallDirectionX = 1;
            else if (goX >= areaOfGame.ActualWidth)
                goBallDirectionX = 0;
            else if (goY <= 0)
                goBallDirectionY = 0;
            else
                goBallDirectionY = 1;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Ruch na dół lewej paletki
            if (e.Key == Key.S)
            {
                double goDownL = Canvas.GetTop(paddleLeft) + 5;
                if (goDownL < (areaOfGame.ActualHeight - paddleLeft.ActualHeight))
                    Canvas.SetTop(paddleLeft, goDownL);
            }
            // Ruch do góry lewej paletki
            if (e.Key == Key.W)
            {
                double goUpL = Canvas.GetTop(paddleLeft) - 5;
                if (goUpL > 0)
                    Canvas.SetTop(paddleLeft, goUpL);
            }
            // Ruch na dół prawej paletki
            if (e.Key == Key.Down)
            {
                double goDownP = Canvas.GetTop(paddleRight) + 5;
                if (goDownP < (areaOfGame.ActualHeight - paddleRight.ActualHeight))
                    Canvas.SetTop(paddleRight, goDownP);
            }
            // Ruch do góry prawej paletki
            if (e.Key == Key.Up)
            {
                double goUpP = Canvas.GetTop(paddleRight) - 5;
                if (goUpP > 0)
                    Canvas.SetTop(paddleRight, goUpP);
            }
        }
    }
}
