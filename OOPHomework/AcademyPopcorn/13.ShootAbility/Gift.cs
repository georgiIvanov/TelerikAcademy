using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class Gift : MovingObject
    {
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { 'G' } }, new MatrixCoords(1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                return new ShoothingRacket[] { new ShoothingRacket(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col), 6) };
            }
            return new ShoothingRacket[] { };
        }
    }
}
