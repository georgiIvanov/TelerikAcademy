using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class TrailObject : GameObject
    {
        int turnsAlive;

        public TrailObject(MatrixCoords topLeft, int turnsAlive)
            : base(topLeft, new char[,] { { '.' } })
        {
            this.turnsAlive = turnsAlive;
        }


        public override void Update()
        {
            turnsAlive--;
            if (turnsAlive == 0)
            {
                IsDestroyed = true;
            }
        }

    }
}
