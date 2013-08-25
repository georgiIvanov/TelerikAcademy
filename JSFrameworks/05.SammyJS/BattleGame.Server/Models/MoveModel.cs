using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BattleGame.Server.Models
{
    [DataContract(Name="Move")]
    public class MoveModel
    {
        [DataMember(Name="unitId")]
        public int UnitId { get; set; }

        [DataMember(Name="position")]
        public PositionModel Position { get; set; }
    }
}