using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BattleGame.Server.Models
{
    [DataContract(Name = "BattleField")]
    public class BattleFieldModel
    {

        [DataMember(Name = "gameId")]
        public int GameId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "red")]
        public UserInGameModel Red { get; set; }

        [DataMember(Name = "blue")]
        public UserInGameModel Blue { get; set; }

        [DataMember(Name = "turn")]
        public long Turn { get; set; }

        [DataMember(Name = "inTurn")]
        public string PlayerInTurn { get; set; }
    }
}