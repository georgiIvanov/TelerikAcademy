using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Model
{
    public class CardAccount
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public int CardPIN { get; set; }
        public decimal CardCash { get; set; }
    }
}
