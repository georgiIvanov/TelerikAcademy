using System;

namespace Methods
{
    class Methods
    {
        static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("All sides should be positive.");
            }
            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
            return area;
        }

        static string DigitAsWord(int number)
        {
            if (number < 0 || number > 9)
            {
                throw new ArgumentOutOfRangeException("number", "Parameter must be between 0 and 9");
            }

            string digitAsString = string.Empty;
            switch (number)
            {
                case 0: digitAsString = "zero"; 
                    break;
                case 1: digitAsString = "one"; 
                    break;
                case 2: digitAsString = "two"; 
                    break;
                case 3: digitAsString = "three"; 
                    break;
                case 4: digitAsString = "four"; 
                    break;
                case 5: digitAsString = "five"; 
                    break;
                case 6: digitAsString = "six"; 
                    break;
                case 7: digitAsString = "seven"; 
                    break;
                case 8: digitAsString = "eight"; 
                    break;
                case 9: digitAsString = "nine"; 
                    break;
            }

            return digitAsString;
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Input array is null or empty");
            }

            int maxValue = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (maxValue < elements[i])
                {
                    maxValue = elements[i];
                }
            }
            return maxValue;
        }

        static void PrintAsNumber(double number, string format)
        {
            if (format.Length > 1)
            {
                throw new ArgumentException(string.Format("\"{0}\" - unsupported formatting.", format));
            }

            bool invalidFormat = true;

            if (format == "f")
            {
                Console.WriteLine("{0:F2}", number);
                invalidFormat = false;
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
                invalidFormat = false;
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
                invalidFormat = false;
            }

            if (invalidFormat)
            {
                throw new ArgumentException(string.Format("\"{0}\" - invalid formatting.", format));
            }
        }


        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static void CheckOrientation(double x1, double y1, double x2, double y2, out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = (y1 == y2);
            isVertical = (x1 == x2);
        }

        static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(DigitAsWord(9));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));

            bool horizontal, vertical;
            CheckOrientation(3, -1, 3, 2.5, out horizontal, out vertical);
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov",
                "From Sofia, born at 17.03.1992");

            Student stella = new Student("Stella", "Markova",
                "From Vidin, gamer, high results, born at 03.11.1993");

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
