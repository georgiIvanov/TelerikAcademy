using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            base.body = new char[,] { { '$' } };
        }
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {

            if (this.IsDestroyed)
            {
                return new Explosion[]  {
                    new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(-1, 0)),
                    new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(1, 0)),
                    new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(0, 1)),
                    new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(0, -1)),
                    new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(1, 1)),
                    new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(1, -1)),
                    new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(-1, 1)),
                    new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(0, 0))
                };
            }
            return new Explosion[] { };
        }
    }
}
