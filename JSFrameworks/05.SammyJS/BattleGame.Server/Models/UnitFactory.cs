using BattleGame.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Server.Models
{
    public class UnitFactory
    {
        private const string WarriorType = "warrior";
        private const int WarriorHitPoints = 15;
        private const int WarriorAttack = 8;
        private const int WarriorArmor = 3;
        private const int WarriorRange = 1;
        private const int WarriorSpeed = 2;

        private const string RangerType = "ranger";
        private const int RangerHitPoints = 10;
        private const int RangerAttack = 8;
        private const int RangerArmor = 1;
        private const int RangerRange = 3;
        private const int RangerSpeed = 1;

        private static Unit GetRanger(UnitType type, int x, int y)
        {
            var ranger = new Unit()
            {
                PositionX = x,
                PositionY = y,
                HitPoints = RangerHitPoints,
                Attack = RangerAttack,
                Armor = RangerArmor,
                Range = RangerRange,
                Speed = RangerSpeed,
                UnitType = type
            };
            return ranger;
        }

        private static Unit GetWarrior(UnitType type, int x, int y)
        {
            var warrior = new Unit()
            {
                PositionX = x,
                PositionY = y,
                HitPoints = WarriorHitPoints,
                Attack = WarriorAttack,
                Armor = WarriorArmor,
                Range = WarriorRange,
                Speed = WarriorSpeed,
                UnitType = type
            };
            return warrior;
        }

        public static Unit GetUnit(UnitType unitType, int x, int y)
        {
            if (unitType.Value == WarriorType)
            {
                return GetWarrior(unitType,x, y);
            }
            else if (unitType.Value == RangerType)
            {
                return GetRanger(unitType, x, y);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Unit type", "No such unit type");
            }
        }

    }
}
