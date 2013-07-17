using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Library;
using System.Data.Entity;
using System.Data.Linq;

namespace _08.Inherit
{
    class Inherit
    {
        public class ExtendedEmployee : Employee
        {
            public EntitySet<Territory> Territory { get; set; }
        }

        static void Main(string[] args)
        {
        }
    }
}
