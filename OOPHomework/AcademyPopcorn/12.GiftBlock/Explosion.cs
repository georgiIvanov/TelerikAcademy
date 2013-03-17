using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class Explosion : MovingObject
    {
        public Explosion(MatrixCoords topLeft, char[,] image, MatrixCoords speed)
            : base(topLeft, image, speed)
        {
            this.IsDestroyed = true;
        }
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }
        public override void Update()
        {
            this.IsDestroyed = true;
        }
    }
}
