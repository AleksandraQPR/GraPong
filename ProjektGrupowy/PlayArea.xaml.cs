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
        private double ballSpeed;
        private double p1Speed;
        private double p2Speed;
        private int pointLimit;

        const double paddleOffset = 12;

        Random randomX = new Random();      // losowy wybór początkowego kierunku piłki na osi X
        Random randomY = new Random();      // losowy wybór początkowego kierunku piłki na osi Y
        private int goBallDirectionX;
        private int goBallDirectionY;

        private double goX;
        private double goY;

        private double startPositionBallLeft;
        private double startPositionBallTop;

        System.Windows.Threading.DispatcherTimer ballTimer;
        System.Windows.Threading.DispatcherTimer gameTimer;

        System.Windows.Threading.DispatcherTimer paddleLeftUpTimer;
        System.Windows.Threading.DispatcherTimer paddleLeftDownTimer;
        System.Windows.Threading.DispatcherTimer paddleRightUpTimer;
        System.Windows.Threading.DispatcherTimer paddleRightDownTimer;

        private int pointLeft = 0;
        private int pointRight = 0;

        public PlayArea(double ballSpeed, double p1Speed, double p2Speed,
            Color ballColor, Color p1Color, Color p2Color, int pointLimit, int timeLimit)
        {
            InitializeComponent();
            this.ballSpeed = ballSpeed;
            this.p1Speed = p1Speed;
            this.p2Speed = p2Speed;
            ball.Fill = new SolidColorBrush(ballColor);
            paddleLeft.Fill = new SolidColorBrush(p1Color);
            paddleRight.Fill = new SolidColorBrush(p2Color);
            this.pointLimit = pointLimit;
            progressBar.Maximum = timeLimit;

            CreatingGameTimer();
            CraatingMovingBallTimer();
            CraatingMovingUpLeftPaddelTimer();
            CraatingMovingDownLeftPaddelTimer();
            CraatingMovingDownRightPaddelTimer();
            CraatingMovingUpRightPaddelTimer();

            this.Loaded += ChallengePage_Loaded;    // wczytanie strony, aby można było pobrać parametry kontrolek
        }

        private void CreatingGameTimer()
        {
            gameTimer = new System.Windows.Threading.DispatcherTimer();
            gameTimer.Tick += new EventHandler(gameTimer_Tick);
            gameTimer.Interval = new TimeSpan(0, 0, 0, 1);   // czas w sekundach
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Value += 1;
            if (progressBar.Value >= progressBar.Maximum || pointLeft >= pointLimit || pointRight >= pointLimit)
                StopTheGame();
        }

        private void StopTheGame()
        {
            gameTimer.Stop();
            StopMovingBall();
            GameOverInfo.Visibility = Visibility.Visible;
        }

        void ChallengePage_Loaded(object sender, RoutedEventArgs e)
        {
            SetStartPositionOfPaddels();
            StartMovingBall();
            gameTimer.Start();
        }

        private void CraatingMovingDownLeftPaddelTimer()
        {
            paddleLeftDownTimer = new System.Windows.Threading.DispatcherTimer();
            paddleLeftDownTimer.Tick += new EventHandler(paddleLeftDownTimer_Tick);
            paddleLeftDownTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);   // czas w milisekundach
        }

        private void paddleLeftDownTimer_Tick(object sender, EventArgs e)
        {
            double goDownL = Canvas.GetTop(paddleLeft) + p1Speed;
            if (goDownL < (areaOfGame.ActualHeight - paddleLeft.ActualHeight))
                Canvas.SetTop(paddleLeft, goDownL);
        }

        private void CraatingMovingUpLeftPaddelTimer()
        {
            paddleLeftUpTimer = new System.Windows.Threading.DispatcherTimer();
            paddleLeftUpTimer.Tick += new EventHandler(paddleLeftUpTimer_Tick);
            paddleLeftUpTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);   // czas w milisekundach
        }

        private void paddleLeftUpTimer_Tick(object sender, EventArgs e)
        {
            double goUpL = Canvas.GetTop(paddleLeft) - p1Speed;
            if (goUpL > 0)
                Canvas.SetTop(paddleLeft, goUpL);
        }

        private void CraatingMovingDownRightPaddelTimer()
        {
            paddleRightDownTimer = new System.Windows.Threading.DispatcherTimer();
            paddleRightDownTimer.Tick += new EventHandler(paddleRightDownTimer_Tick);
            paddleRightDownTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);   // czas w milisekundach
        }

        private void paddleRightDownTimer_Tick(object sender, EventArgs e)
        {
            double goDownP = Canvas.GetTop(paddleRight) + p2Speed;
            if (goDownP < (areaOfGame.ActualHeight - paddleRight.ActualHeight))
                Canvas.SetTop(paddleRight, goDownP);
        }

        private void CraatingMovingUpRightPaddelTimer()
        {
            paddleRightUpTimer = new System.Windows.Threading.DispatcherTimer();
            paddleRightUpTimer.Tick += new EventHandler(paddleRightUpTimer_Tick);
            paddleRightUpTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);   // czas w milisekundach
        }

        private void paddleRightUpTimer_Tick(object sender, EventArgs e)
        {
            double goUpP = Canvas.GetTop(paddleRight) - p2Speed;
            if (goUpP > 0)
                Canvas.SetTop(paddleRight, goUpP);
        }

        private void SetStartPositionOfPaddels()
        {
            Canvas.SetLeft(paddleLeft, paddleOffset);
            Canvas.SetTop(paddleLeft, areaOfGame.ActualHeight / 2 - paddleLeft.Height / 2);

            Canvas.SetLeft(paddleRight, areaOfGame.ActualWidth - paddleOffset - paddleRight.Width);
            Canvas.SetTop(paddleRight, areaOfGame.ActualHeight / 2 - paddleRight.Height / 2);
        }

        private void StartMovingBall()
        {
            startPositionBallLeft = areaOfGame.ActualWidth / 2 - ball.Width;
            startPositionBallTop = areaOfGame.ActualHeight / 2 - ball.Height;

            Canvas.SetLeft(ball, startPositionBallLeft);
            Canvas.SetTop(ball, startPositionBallTop);
            goBallDirectionX = randomX.Next(0, 2);    // losowa liczba 0 lub 1
            goBallDirectionY = randomY.Next(0, 2);    // losowa liczba 0 lub 1
            ballTimer.Start();

        }

        private void CraatingMovingBallTimer()
        {
            ballTimer = new System.Windows.Threading.DispatcherTimer();
            ballTimer.Tick += new EventHandler(ballTimer_Tick);
            ballTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);   // czas w milisekundach
        }

        private void setNewPosition()
        {
            if (goBallDirectionX == 0)      // piłka przemieszcza się w lewo
                goX = Canvas.GetLeft(ball) - ballSpeed;
            else                            // piłka przemieszcza się w prawo
                goX = Canvas.GetLeft(ball) + ballSpeed;

            if (goBallDirectionY == 0)      // piłka przemieszcza się na dół
                goY = Canvas.GetTop(ball) + ballSpeed;
            else                            // piłka przemieszcza się do góry
                goY = Canvas.GetTop(ball) - ballSpeed;
        }

        private void ballTimer_Tick(object sender, EventArgs e)
        {
            setNewPosition();

            if (goX > 0 && goX < areaOfGame.ActualWidth - ball.ActualWidth && goY > 0 &&
                goY < areaOfGame.ActualHeight - ball.ActualHeight)
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
                PointForRightPlayer();
                StartMovingBall();
            }
            else if (goX >= areaOfGame.ActualWidth - ball.ActualWidth)
            {
                StopMovingBall();
                PointForLeftPlayer();
                StartMovingBall();
            }

            else if (goY <= 0)
                goBallDirectionY = 0;
            else
                goBallDirectionY = 1;
        }

        private void StopMovingBall()
        {
            ballTimer.Stop();
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

        private void PointForLeftPlayer()
        {
            pointLeft++;
            resultPointers.Text = pointLeft + " : " + pointRight;
        }

        private void PointForRightPlayer()
        {
            pointRight++;
            resultPointers.Text = pointLeft + " : " + pointRight;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Ruch na dół lewej paletki
            if (e.Key == Key.S)
            {
                paddleLeftDownTimer.Start();
            }
            // Ruch do góry lewej paletki
            if (e.Key == Key.W)
            {
                paddleLeftUpTimer.Start();
            }
            // Ruch na dół prawej paletki
            if (e.Key == Key.Down)
            {
                paddleRightDownTimer.Start();
            }
            // Ruch do góry prawej paletki
            if (e.Key == Key.Up)
            {
                paddleRightUpTimer.Start();
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S)
            {
                paddleLeftDownTimer.Stop();
            }
            if (e.Key == Key.W)
            {
                paddleLeftUpTimer.Stop();
            }
            if (e.Key == Key.Down)
            {
                paddleRightDownTimer.Stop();
            }
            if (e.Key == Key.Up)
            {
                paddleRightUpTimer.Stop();
            }
         }
    }
}
