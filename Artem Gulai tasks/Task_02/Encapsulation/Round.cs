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
        private Double _radius;

        public Round()
        {
            XCenter = 0;
            YCenter = 0;
            _radius = 1;
        }

        public Round(Double xCenter,Double yCenter,Double radius)
        {
            XCenter = xCenter;
            YCenter = yCenter;
            if (radius == 0)
                throw new ArgumentException("Radius should be greater than 0.");
            Radius = radius;
        }

        public Double XCenter { set; get; }

        public Double YCenter { set; get; }

        public Double Radius
        {
            set
            {
                if (value != 0)
                    _radius = Math.Abs(value);
                else
                    Console.WriteLine("Radius should be greater than 0.");
            }
            get => _radius;
        }

        public Double Area
        {
            get => Math.PI * Math.Pow(_radius,2);
        }

        public Double Length
        {
            get => 2 * Math.PI * _radius;
        }

        public void ShowPosition()
        {
            Console.WriteLine($"x: {XCenter}, y: {YCenter}");
        }

        public void MoveTo(Double x, Double y)
        {
            XCenter = x;
            YCenter = y;
        }

        public void MoveToRel(Double dx, Double dy)
        {
            XCenter += dx;
            YCenter += dy;
        }

        public override String ToString()
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
            round.Radius = 0;
            Console.WriteLine("Trying to change Radius to Radius * 2:");
            round.Radius = round.Radius * 2;
            Console.WriteLine(round);
        }

        public static void Demo()
        {
            Round round = null;
            while (true)
            {
                Double xCenter;
                Console.WriteLine("Enter the XCenter:");
                while (!Double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,CultureInfo.InvariantCulture,out xCenter))
                {
                    Console.WriteLine("Wrong input. Try again.");
                }

                Double yCenter;
                Console.WriteLine("Enter the YCenter:");
                while (!Double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,CultureInfo.InvariantCulture,out yCenter))
                {
                    Console.WriteLine("Wrong input. Try again.");
                }

                Double radius;
                Console.WriteLine("Enter the radius:");
                while (!Double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,CultureInfo.InvariantCulture,out radius))
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
