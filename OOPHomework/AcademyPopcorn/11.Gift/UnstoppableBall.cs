using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnstoppableBall : Ball
    {
        public const char image = '^';
        public new const string CollisionGroupString = "unstoppableBall";
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body[0, 0] = image;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return  otherCollisionGroupString == "racket" || 
                    otherCollisionGroupString == "block" ||
                    otherCollisionGroupString == "unpassableBlock" || 
                    otherCollisionGroupString == "indestructibleBlock";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            for (int i = 0; i < collisionData.hitObjectsCollisionGroupStrings.Count; i++)
            {
                if (collisionData.hitObjectsCollisionGroupStrings[i] == "unpassableBlock" ||
                    collisionData.hitObjectsCollisionGroupStrings[i] == "racket" ||
                    collisionData.hitObjectsCollisionGroupStrings[i] == "indestructibleBlock")
                {
                    if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                    {
                        this.Speed.Row *= -1;
                    }
                    if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                    {
                        this.Speed.Col *= -1;
                    }
                }
            }
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }
    }
}
