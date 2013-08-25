using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BattleGame.Server.Models
{
    [DataContract(Name = "BattleUnit")]
    public class UnitModel
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "owner")]
        public string Owner { get; set; }

        [DataMember(Name = "mode")]
        public string Mode { get; set; }

        [DataMember(Name = "position")]
        public PositionModel Position { get; set; }

        [DataMember(Name = "attack")]
        public int Attack { get; set; }

        [DataMember(Name = "armor")]
        public int Armor { get; set; }

        [DataMember(Name = "range")]
        public int Range { get; set; }

        [DataMember(Name = "speed")]
        public int Speed { get; set; }

        [DataMember(Name = "hitPoints")]
        public int HitPoints { get; set; }
    }
}