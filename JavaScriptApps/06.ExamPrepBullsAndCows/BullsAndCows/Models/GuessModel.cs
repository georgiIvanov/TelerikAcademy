using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BullsAndCows.Models
{
    [DataContract]
    public class GuessModel
    {
        [DataMember(Name="number")]
        public int Number { get; set; }

        [DataMember(Name = "gameId")]
        public int GameId { get; set; }
    }


    [DataContract]
    public class GuessDetailsModel
    {
        [DataMember(Name = "number")]
        public long Number { get; set; }

        [DataMember(Name = "cows")]
        public long Cows { get; set; }

        [DataMember(Name = "bulls")]
        public long Bulls { get; set; }
    }
}