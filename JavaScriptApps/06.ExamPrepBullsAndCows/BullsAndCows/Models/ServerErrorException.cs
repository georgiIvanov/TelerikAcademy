using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Models
{
    public class ServerErrorException : Exception
    {
        public ServerErrorException() : base()
        {
        }

        public ServerErrorException(string msg) : base(msg)
        {
        }

        public ServerErrorException(string msg, string errCode) : base(msg)
        {
            this.ErrorCode = errCode;
        }

        public string ErrorCode { get; set; }
    }
}