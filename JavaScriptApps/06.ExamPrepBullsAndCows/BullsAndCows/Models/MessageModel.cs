using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BullsAndCows.Models
{
    [DataContract]
    public class MessageModel
    {
        [DataMember(Name="text")]
        public string Text { get; set; }

        [DataMember(Name = "gameId")]
        public long GameId { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }
    }
}
