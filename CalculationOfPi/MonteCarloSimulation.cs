using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationOfPi
{
    internal class MonteCarloSimulation
    {
        public static void Simulation()
        {
            string option = "";
            do
            {
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine("Opcija 1: unos broja slucajno generisanih vrijednosti");
                Console.WriteLine("Opcija 2: unos broja decimala koje treba da se poklope sa pravom vrijednoscu");
                Console.WriteLine("Opcija x: kraj");
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine("Unesite opciju -> ");
                option = Console.ReadLine();
                if (option == "1")
                {
                    Option1();
                }
                else if (option == "2")
                {
                    Option2();
                }
                else if (option.ToLower() != "x")
                {
                    Console.WriteLine("Nepoznata opcija!");
                }
            } while (option.ToLower() != "x");
        }

        private static void Option1()
        {
            string numberOfPointsString = "";
            int numberOfPoints;
            Console.WriteLine("Unesite broj slucajno generisanih vrijednosti -> ");
            numberOfPointsString = Console.ReadLine();

            if (!int.TryParse(numberOfPointsString, out numberOfPoints) || numberOfPoints < 1)
            {
                Console.WriteLine("Niste unijeli pozitivan cijeli broj!");
                return;
            }

            Random rand = new Random();
            int numberOfPointsCircle = 0;
            for (int i = 0; i < numberOfPoints; i++)
            {
                double x = rand.NextDouble();
                double y = rand.NextDouble();
                if (Math.Sqrt(x * x + y * y) <= 1)
                    numberOfPointsCircle++;
            }

            double calculatedPi = 4.0 * numberOfPointsCircle / numberOfPoints;

            Console.WriteLine("Izracunati broj Pi: " + calculatedPi);
            Console.WriteLine("Pravi broj Pi: " + Math.PI);
        }

        private static void Option2()
        {
            string numberOfDecimalsString = "";
            int numberOfDecimals;
            Console.WriteLine("Unesite broj decimala koje treba da se poklope sa pravom vrijednoscu -> ");
            numberOfDecimalsString = Console.ReadLine();

            if (!int.TryParse(numberOfDecimalsString, out numberOfDecimals) || numberOfDecimals < 1)
            {
                Console.WriteLine("Niste unijeli pozitivan cijeli broj!");
                return;
            }

            Random rand = new Random();
            int numberOfPointsCircle = 0;
            int numberOfPointsTotal = 0;
            double epsilon = Math.Pow(10, -numberOfDecimals);
            double calculatedPi;
            do
            {
                double x = rand.NextDouble();
                double y = rand.NextDouble();

                if (Math.Sqrt(x * x + y * y) <= 1)
                    numberOfPointsCircle++;

                numberOfPointsTotal++;

                calculatedPi = 4.0 * numberOfPointsCircle / numberOfPointsTotal;
            } while (Math.Abs(calculatedPi - Math.PI) >= epsilon);

            Console.WriteLine("Broj slucajno generisanih vrijednosti: " + numberOfPointsTotal);
            Console.WriteLine("Izracunati broj Pi: " + calculatedPi);
            Console.WriteLine("Pravi broj Pi: " + Math.PI);
        }
    }
}
