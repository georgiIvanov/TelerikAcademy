using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settlements.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public int Population { get; set; }
        public Continent Continend { get; set; }
    }
}
