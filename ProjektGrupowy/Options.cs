using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GraProjektowa
{
    class Options
    {
        double ballSpeed = 1;
        double p1Speed = 1;
        double p2Speed = 1;

        Color ballColor;
        Color p1Color;
        Color p2Color;

        int pointLimit = 10;
        int timeLimit = 60;


        public double BallSpeed
        {
            get
            {
                return ballSpeed;
            }

            set
            {
                ballSpeed = value;
            }
        }

        public double P1Speed
        {
            get
            {
                return p1Speed;
            }

            set
            {
                p1Speed = value;
            }
        }

        public double P2Speed
        {
            get
            {
                return p2Speed;
            }

            set
            {
                p2Speed = value;
            }
        }

        public Color BallColor
        {
            get
            {
                return ballColor;
            }

            set
            {
                ballColor = value;
            }
        }

        public Color P1Color
        {
            get
            {
                return p1Color;
            }

            set
            {
                p1Color = value;
            }
        }

        public Color P2Color
        {
            get
            {
                return p2Color;
            }

            set
            {
                p2Color = value;
            }
        }

        public int PointLimit
        {
            get
            {
                return pointLimit;
            }

            set
            {
                pointLimit = value;
            }
        }

        public int TimeLimit
        {
            get
            {
                return timeLimit;
            }

            set
            {
                timeLimit = value;
            }
        }
    }
}
