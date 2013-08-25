using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BattleGame.Server.Models
{
    [DataContract(Name = "Message")]
    public class MessageModel
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "gameId")]
        public int GameId { get; set; }

        [DataMember(Name = "gameTitle")]
        public string GameTitle { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }
    }
}