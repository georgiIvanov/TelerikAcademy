using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.SearchControls
{
    public class Producer
    {
        public Producer(string name, IEnumerable<string> models)
        {
            this.Name = name;
            this.Models = models.ToList();
        }
        public string Name { get; private set; }

        public List<string> Models { get; private set; }
    }
}