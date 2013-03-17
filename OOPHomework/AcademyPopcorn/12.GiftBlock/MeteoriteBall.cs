using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball 
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body = new char[,] { {'*'} };
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            return new TrailObject[]{ new TrailObject(base.topLeft, 3) };
        }
    }
}
