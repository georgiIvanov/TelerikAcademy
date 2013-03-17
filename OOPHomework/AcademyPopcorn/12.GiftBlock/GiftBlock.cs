using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            base.body = new char[,] { { '@' } };
        }
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                return new Gift[] { new Gift(this.topLeft) };
            }
            return new Gift[] { };
        }
    }
}
