using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class IndestructibleBlock : Block
    {
        public const char Symbol = '|';
        public new const string CollisionGroupString = "indestructibleBlock";

        public IndestructibleBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = IndestructibleBlock.Symbol;
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            //base.RespondToCollision(collisionData);
        }
    }
}
