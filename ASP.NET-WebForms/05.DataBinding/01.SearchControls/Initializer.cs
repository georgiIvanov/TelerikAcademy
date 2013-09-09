using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.SearchControls
{
    public static class Initializer
    {
        public static IList<Producer> Producers { get; set; }

        public static IList<Extra> Extras { get; set; }

        public static IList<string> EngineTypes { get; set; }
    }
}