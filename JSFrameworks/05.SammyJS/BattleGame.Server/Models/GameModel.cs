using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BattleGame.Server.Models
{
    [DataContract(Name = "Game")]
    public class GameModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }
    }

    [DataContract(Name = "Game")]
    public class OpenGameModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "creator")]
        public string Creator { get; set; }
    }
    
    [DataContract(Name = "Game")]
    public class ActiveGameModel : OpenGameModel
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
    }
}