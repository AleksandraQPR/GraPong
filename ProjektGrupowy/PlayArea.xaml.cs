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
        private Storyboard myStoryboard;
        Random random = new Random();
        

        public PlayArea()
        {
            InitializeComponent();
            this.Loaded += ChallengePage_Loaded;
        }

        // Należy poczekać aż całe okno sie wgra w celu uzyskania parametrów okna gry
        private void ChallengePage_Loaded(object sender, RoutedEventArgs e)
        {
            double startPositionOfBall_X = areaOfGame.ActualWidth / 2 - ball.ActualWidth / 2;

            BallAnimation(0, areaOfGame.ActualWidth, new PropertyPath(Canvas.LeftProperty));
            BallAnimation(random.Next((int)areaOfGame.ActualHeight), random.Next((int)areaOfGame.ActualHeight), new PropertyPath(Canvas.TopProperty));
        }
        private void BallAnimation(double from, double to, PropertyPath property)
        {
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = from;
            myDoubleAnimation.To = to;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(3));
            myDoubleAnimation.AutoReverse = true;
          //  myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, "ball");
            Storyboard.SetTargetProperty(myDoubleAnimation, property);
            myStoryboard.Begin(ball);
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
