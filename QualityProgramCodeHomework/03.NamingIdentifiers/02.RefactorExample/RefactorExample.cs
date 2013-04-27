using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RefactorExample
{
    class RefactorExample
    {
        static void Main(string[] args)
        {
            HumanGenerator humanGenerator = new HumanGenerator();

            humanGenerator.CreateHuman(24);
            humanGenerator.CreateHuman(23);
        }
    }

    class HumanGenerator
    {
        enum Gender { male, female };

        class Human
        {
            public Gender gender { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public void CreateHuman(int age)
        {
            Human newHuman = new Human();
            newHuman.Age = age;
            if (age % 2 == 0)
            {
                newHuman.Name = "Ash";
                newHuman.gender = Gender.male;
            }
            else
            {
                newHuman.Name = "Misty";
                newHuman.gender = Gender.female;
            }
        }
    }

}
