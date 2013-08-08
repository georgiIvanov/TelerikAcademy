using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _03.StringSearchCountLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StringSearchCount : IStringSearchCount
    {
        public int TimesStringFound(string text, string searched)
        {
            int foundCount = 0, lastIndex = 0;

            lastIndex = text.IndexOf(searched);
            while (lastIndex != -1)
            {
                foundCount++;
                lastIndex = text.IndexOf(searched, lastIndex + 1);
            }

            return foundCount;


        }
    }
}
