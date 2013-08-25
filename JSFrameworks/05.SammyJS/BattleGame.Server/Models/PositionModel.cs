using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BattleGame.Server.Models
{
    [DataContract(Name ="Position")]
    public class PositionModel
    {
        [DataMember(Name = "x")]
        public long X { get; set; }

        [DataMember(Name = "y")]
        public long Y { get; set; }
    }
}