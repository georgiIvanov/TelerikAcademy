using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("sharo", AnimalSex.male, 18);
            Console.WriteLine(dog.ToString());

            Frog frog = new Frog("Kermit", AnimalSex.male, 20);
            Console.WriteLine(frog.ToString());

            Cat regularCat = new Cat("CAT", AnimalSex.female, 4);
            Console.WriteLine(regularCat.ToString());

            Kitten kitten = new Kitten("kittie", AnimalSex.female, 1);
            //Kitten kitten = new Kitten("kittie", AnimalSex.male, 1); - this will explode
            Console.WriteLine(kitten.ToString());

            Tomcat tomcat = new Tomcat("Topcat", AnimalSex.male, 2);
            //Tomcat tomcat = new Tomcat("Topcat", AnimalSex.female, 2); - this too will explode
            Console.WriteLine(tomcat.ToString());


            //sounds
            Console.WriteLine();
            Console.WriteLine(dog.ProduceSound());
            Console.WriteLine(frog.ProduceSound());
            Console.WriteLine(regularCat.ProduceSound());
            Console.WriteLine(kitten.ProduceSound());
            Console.WriteLine(tomcat.ProduceSound());
        }
    }

    interface ISound
    {
        string ProduceSound();
    }

    enum AnimalSex
    {
        male,
        female
    }

    abstract class Animal
    {
        int age;
        string name;
        AnimalSex sex;

        public Animal(string name, AnimalSex sex, int age)
        {
            this.name = name;
            this.sex = sex;
            this.age = age;
        }

        public override string ToString()
        {
            string result = age.ToString() + " " + name+ " " + sex.ToString();
            return result;
        }
        
    }

    class Dog : Animal, ISound
    {
        public Dog(string name, AnimalSex sex, int age)
            : base(name, sex, age)
        {
            
        }

        public string ProduceSound()
        {
            return "Bark, Bark";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    class Frog : Animal, ISound
    {
        public Frog(string name, AnimalSex sex, int age)
            : base(name, sex, age)
        {

        }

        public string ProduceSound()
        {
            return "Frog sound";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    class Cat : Animal, ISound
    {
        public Cat(string name, AnimalSex sex, int age)
            : base(name, sex, age)
        {

        }

        public string ProduceSound()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    class Kitten : Cat, ISound
    {
        public Kitten(string name, AnimalSex sex, int age)
            : base(name, sex, age)
        {
            if (sex != AnimalSex.female)
            {
                throw new ArgumentException("Kittens must be female");
            }
        }

        new public string ProduceSound()
        {
            return "Kitten Meow";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    class Tomcat : Cat, ISound
    {
        public Tomcat(string name, AnimalSex sex, int age)
            : base(name, sex, age)
        {
            if (sex != AnimalSex.male)
            {
                throw new ArgumentException("Tomcats must be male");
            }
        }

        new public string ProduceSound()
        {
            return "Tomcat Meow";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

}
