using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuLinks
{
    public class MenuOption
    {
        public MenuOption(string name, string url)
        {
            this.Name = name;
            this.Url = url;
            this.FontColor = "";
        }

        public string Name { get; set; }

        public string FontColor { get; set; }

        public string Url { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}