﻿using System;
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
        Random randomX = new Random();      // losowy wybór początkowego kierunku piłki na osi X
        Random randomY = new Random();      // losowy wybór początkowego kierunku piłki na osi Y
        private int goBallDirectionX;
        private int goBallDirectionY;

        private double goX;
        private double goY;

        private double startPositionBallLeft;
        private double startPositionBallTop;

        System.Windows.Threading.DispatcherTimer dispatcherTimer;

        public PlayArea()
        {
            InitializeComponent();
            CraatingMovingBallTimer();
            this.Loaded += ChallengePage_Loaded;    // wczytanie strony, aby można było pobrać parametry kontrolek

        }
        void ChallengePage_Loaded(object sender, RoutedEventArgs e)
        {
            StartMovingBall();
        }

        private void StartMovingBall()
        {
            startPositionBallLeft = areaOfGame.ActualWidth / 2;
            startPositionBallTop = areaOfGame.ActualHeight / 2;

            Canvas.SetLeft(ball, startPositionBallLeft);
            Canvas.SetTop(ball, startPositionBallTop);
            goBallDirectionX = randomX.Next(0, 2);    // losowa liczba 0 lub 1
            goBallDirectionY = randomY.Next(0, 2);    // losowa liczba 0 lub 1
            dispatcherTimer.Start();

        }

        private void CraatingMovingBallTimer()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);   // czas w milisekundach
        }

        private void setNewPosition()
        {
            if (goBallDirectionX == 0)      // piłka przemieszcza się w lewo
                goX = Canvas.GetLeft(ball) - 5;
            else                            // piłka przemieszcza się w prawo
                goX = Canvas.GetLeft(ball) + 5;

            if (goBallDirectionY == 0)      // piłka przemieszcza się na dół
                goY = Canvas.GetTop(ball) + 5;
            else                            // piłka przemieszcza się do góry
                goY = Canvas.GetTop(ball) - 5;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            setNewPosition();

            if (goX > 0 && goX < areaOfGame.ActualWidth && goY > 0 && goY < areaOfGame.ActualHeight)
            {
                if (ColisionDetectionLeft(paddleLeft, ball) == true)
                {
                    goBallDirectionX = 1;
                    setNewPosition();
                }
                if (ColisionDetectionRight(paddleRight, ball) == true)
                {
                    goBallDirectionX = 0;
                    setNewPosition();
                }

                Canvas.SetLeft(ball, goX);
                Canvas.SetTop(ball, goY);
            }
            
            else if (goX <= 0)
            {
                StopMovingBall();
                StartMovingBall();
            }
            else if (goX >= areaOfGame.ActualWidth)
            {
                StopMovingBall();
                StartMovingBall();
            }

            else if (goY <= 0)
                goBallDirectionY = 0;
            else
                goBallDirectionY = 1;
        }

        private void StopMovingBall()
        {
            dispatcherTimer.Stop();
        }

       private bool ColisionDetectionLeft(Rectangle paddle, Ellipse ball)
        {
            double paddleBottom = Canvas.GetTop(paddle) + paddle.Height;
            double paddleTop = Canvas.GetTop(paddle);
            double paddleLeft = Canvas.GetLeft(paddle);
            double paddleRight = Canvas.GetLeft(paddle) + paddle.Width;

            double ballBottom = Canvas.GetTop(ball) + ball.Height;
            double ballTop = Canvas.GetTop(ball);
            double ballLeft = Canvas.GetLeft(ball);
            double ballRight = Canvas.GetLeft(ball) + ball.Width;

            // Kolizja z lewej strony
            if (ballLeft <= paddleRight && ballBottom >= paddleTop && ballTop <= paddleBottom)
                return true;
            else
                return false;
        }

        private bool ColisionDetectionRight(Rectangle paddle, Ellipse ball)
        {
            double paddleBottom = Canvas.GetTop(paddle) + paddle.Height;
            double paddleTop = Canvas.GetTop(paddle);
            double paddleLeft = Canvas.GetLeft(paddle);
            double paddleRight = Canvas.GetLeft(paddle) + paddle.Width;

            double ballBottom = Canvas.GetTop(ball) + ball.Height;
            double ballTop = Canvas.GetTop(ball);
            double ballLeft = Canvas.GetLeft(ball);
            double ballRight = Canvas.GetLeft(ball) + ball.Width;

            // Kolizja z prawej strony
            if (ballRight >= paddleLeft && ballBottom >= paddleTop && ballTop <= paddleBottom)
                return true;
            else
                return false;
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
