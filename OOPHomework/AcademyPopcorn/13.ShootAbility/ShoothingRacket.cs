using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ShoothingRacket : Racket
    {
        private bool isShoot = false;

        public ShoothingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }
        public void Shoot()
        {
            isShoot = true;
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (isShoot)
            {
                isShoot = false;
                return new Bullet[] { new Bullet(this.topLeft) };
            }
            return new Bullet[] { };
        }
    }
}
