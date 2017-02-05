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

namespace ProjektGrupowy
{
    /// <summary>
    /// Interaction logic for PlayArea.xaml
    /// </summary>
    public partial class PlayArea : Window
    {
        public PlayArea()
        {
            InitializeComponent();
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
