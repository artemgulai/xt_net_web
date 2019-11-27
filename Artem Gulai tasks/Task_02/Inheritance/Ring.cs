using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Ring : Round
    {
        private double _innerRadius;

        public Ring() : base()
        {
            _innerRadius = Radius / 2;
        }

        public Ring(double xCenter,double yCenter,double radius,double innerRadius) : base(xCenter,yCenter,radius)
        {
            if (Math.Abs(innerRadius) == 0)
                throw new ArgumentException("Inner radius should be greater than 0.");
            if (Math.Abs(innerRadius) >= Radius)
                throw new ArgumentException("Inner radius should be less than outer one.");
            _innerRadius = Math.Abs(innerRadius);
        }

        public new double Radius
        {
            get => base.Radius;
            set
            {
                if (Math.Abs(value) > _innerRadius)
                    base.Radius = value;
                else
                    throw new ArgumentException("Outer radius should be greater than inner one.");
            }
        }

        public double InnerRadius
        {
            get => _innerRadius;
            set
            {
                if (Math.Abs(value) == 0)
                    throw new ArgumentException("Inner radius should be greater than 0.");
                else if (Math.Abs(value) >= Radius)
                    throw new ArgumentException("Inner radius should be less than outer one.");
                else
                    _innerRadius = Math.Abs(value);
            }
        }

        public new double Area
        {
            get => Math.PI * Math.Abs((Math.Pow(Radius,2) - Math.Pow(_innerRadius,2)));
        }

        public new double Length
        {
            get => Math.PI * 2 * (Radius + _innerRadius);
        }

        public override string ToString()
        {
            return $"xCenter = {XCenter}, yCenter = {YCenter}, outerRadius = {Radius}, innerRadius = {InnerRadius}" +
                Environment.NewLine + $"Area = {Area}, Length = {Length}.";
        }
    }

    class RingDemo
    {
        public static void ChangeRing(Ring ring)
        {
            Console.WriteLine("Trying to change innerRadius to 0:");
            try
            {
                ring.InnerRadius = 0;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Trying to change innerRadius to outerRadius + 2:");
            try
            {
                ring.InnerRadius = ring.Radius + 2;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Trying to change innerRadius to outerRadius * 0.8:");
            try
            {
                ring.InnerRadius = ring.Radius * 0.8;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(ring);
            Console.ReadLine();

            Console.WriteLine("Trying to change outerRadius to 0:");
            try
            {
                ring.Radius = 0;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Trying to change outerRadius to innerRadius * 0.8:");
            try
            {
                ring.Radius = ring.InnerRadius * 0.8;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Trying to change outerRadius to innerRadius * 1.2:");
            try
            {
                ring.Radius = ring.InnerRadius * 1.2;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(ring);
            Console.ReadLine();
        }

        public static void Demo()
        {
            Ring ring = null;
            double xCenter, yCenter, radius, innerRadius;
            Console.WriteLine("Ring Demo. You have to enter values until the input is correct.");
            while (true)
            {
                Console.WriteLine("Enter xCenter");
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,CultureInfo.InvariantCulture,out xCenter))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter yCenter");
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,CultureInfo.InvariantCulture,out yCenter))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter outer radius");
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,CultureInfo.InvariantCulture,out radius))
                    Console.WriteLine("Wrong input. Try again.");

                Console.WriteLine("Enter inner radius");
                while (!double.TryParse(Console.ReadLine(),System.Globalization.NumberStyles.Any,CultureInfo.InvariantCulture,out innerRadius))
                    Console.WriteLine("Wrong input. Try again.");

                try
                {
                    ring = new Ring(xCenter,yCenter,radius,innerRadius);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Try again.");
                }
            }

            Console.WriteLine("Ring is created." + Environment.NewLine + ring.ToString());
            Console.ReadLine();

            RoundDemo.ChangeRoundCenter(ring);
            ChangeRing(ring);
        }
    }
}
