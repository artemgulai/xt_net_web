using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Round
    {
        private double _radius;

        public Round()
        {
            XCenter = 0;
            YCenter = 0;
            _radius = 1;
        }

        public Round(double xCenter,double yCenter,double radius)
        {
            XCenter = xCenter;
            YCenter = yCenter;
            if (radius == 0)
                throw new ArgumentException("Radius should be greater than 0.");
            Radius = radius;
        }

        public double XCenter { set; get; }

        public double YCenter { set; get; }

        public double Radius
        {
            set
            {
                if (value != 0)
                    _radius = Math.Abs(value);
                else
                    throw new ArgumentException("Radius should be greater than 0.");
            }
            get => _radius;
        }

        public double Area
        {
            get => Math.PI * Math.Pow(_radius,2);
        }

        public double Length
        {
            get => 2 * Math.PI * _radius;
        }

        public void ShowPosition()
        {
            Console.WriteLine($"x: {XCenter}, y: {YCenter}");
        }

        public void MoveTo(double x,double y)
        {
            XCenter = x;
            YCenter = y;
        }

        public void MoveToRel(double dx,double dy)
        {
            XCenter += dx;
            YCenter += dy;
        }

        public override string ToString()
        {
            return $"xCenter = {XCenter}, yCenter = {YCenter}, radius = {Radius}" +
                Environment.NewLine + $"Area = {Area}, Length = {Length}.";
        }
    }

    class RoundDemo
    {
        public static void ChangeRoundCenter(Round round)
        {
            Console.WriteLine("Trying to change xCenter to 0.5 and yCenter to -2.6.");
            round.XCenter = 0.5;
            round.YCenter = -2.6;
            Console.WriteLine(round);
            Console.ReadLine();
        }

        private static void ChangeRound(Round round)
        {
            Console.WriteLine("Trying to change Radius to 0:");
            try
            {
                round.Radius = 0;
            } 
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Trying to change Radius to Radius * 2:");
            round.Radius = round.Radius * 2;
            Console.WriteLine(round);
        }

        public static void Demo()
        {
            Round round = null;
            while (true)
            {
                double xCenter;
                Console.WriteLine("Enter the XCenter:");
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,CultureInfo.InvariantCulture,out xCenter))
                {
                    Console.WriteLine("Wrong input. Try again.");
                }

                double yCenter;
                Console.WriteLine("Enter the YCenter:");
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,CultureInfo.InvariantCulture,out yCenter))
                {
                    Console.WriteLine("Wrong input. Try again.");
                }

                double radius;
                Console.WriteLine("Enter the radius:");
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,CultureInfo.InvariantCulture,out radius))
                {
                    Console.WriteLine("Wrong input. Try again.");
                }

                try
                {
                    round = new Round(xCenter,yCenter,radius);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message + " Try again.");
                }
            }

            Console.WriteLine("Round has been created." + Environment.NewLine + round.ToString());
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();

            ChangeRoundCenter(round);
            ChangeRound(round);
            Console.ReadLine();
        }
    }
}
