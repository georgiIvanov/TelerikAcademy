using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class EngineExpanded : Engine
    {
        public EngineExpanded(IRenderer renderer, IUserInterface userInterface, int sleepTime)
            : base(renderer, userInterface, sleepTime)
        {

        }

        public void ShootPlayerRacket()
        {
            if (this.playerRacket is ShoothingRacket)
             {
                 (this.playerRacket as ShoothingRacket).Shoot();
            }
        }
    }
}
