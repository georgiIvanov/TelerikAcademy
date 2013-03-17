using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnpassableBlock : Block
    {
        public const char image= '[';
        const string collisionGroupString = "unpassableBlock";

        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = image;

        }

        public override string GetCollisionGroupString()
        {
            return collisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {

        }

    }
}
