using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BullsAndCows.Models
{
    [DataContract(Name="Game")]
    public class GameModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "creatorNickname")]
        public string CreatorNickname { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }
    }

    [DataContract(Name = "Game")]
    public class JoinGameModel
    {
        [DataMember(Name="gameId")]
        public int Id { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "number")]
        public int Number { get; set; }
    }

    [DataContract(Name = "Game")]
    public class CreateGameModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "number")]
        public int Number { get; set; }
    }

    [DataContract(Name = "Game")]
    public class GameStateModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "red")]
        public string RedPlayer { get; set; }

        [DataMember(Name = "blue")]
        public string BluePlayer { get; set; }

        [DataMember(Name = "redGuesses")]
        public IEnumerable<GuessDetailsModel> RedPlayerGuesses { get; set; }

        [DataMember(Name = "blueGuesses")]
        public IEnumerable<GuessDetailsModel> BluePlayerGuesses { get; set; }

        [DataMember(Name = "inTurn")]
        public string PlayerInTurn { get; set; }

    }
}