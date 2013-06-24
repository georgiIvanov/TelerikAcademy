using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _02.AcademyTasks
{
    class Program
    {
        static int[] pleasentness;
        static int tasksDone = 1;
        static int variety;
        static bool found = false;

        static void Main(string[] args)
        {
            //SetInput();

            string inputLine = Console.ReadLine();

            string[] numbers = Regex.Split(inputLine, ", ");
            pleasentness = new int[numbers.Length];
            for (int j = 0; j < pleasentness.Length; j++)
            {
                pleasentness[j] = int.Parse(numbers[j]);
            }

            variety = int.Parse(Console.ReadLine());
            FindTasksRecursive(0);

            Console.WriteLine(tasksDone);
        }

        static void FindTasksRecursive(int index)
        {
            if (found)
            {
                return;
            }

            if (index > pleasentness.Length || pleasentness.Length <= index + 1 || pleasentness.Length <= index + 2)
            {
                found = true;
                return;
            }

            if (Math.Abs(pleasentness[index + 1] - pleasentness[index]) >= variety ||
                 Math.Abs(pleasentness[index + 2] - pleasentness[index]) >= variety)
            {
                tasksDone++;
                found = true;
                return;
            }

            tasksDone++;
            FindTasksRecursive(index + 2);

        }

        static void SetInput()
        {
            StreamReader reader = new StreamReader("..\\..\\input.txt");
            using (reader)
            {
                StringReader sr = new StringReader(reader.ReadToEnd());
                Console.SetIn(sr);
            }
        }
    }
}
