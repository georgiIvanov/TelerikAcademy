using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Engine
    {
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<GameObject> staticObjects;
        Racket playerRacket;
        int SleepMSec;

        public Engine(IRenderer renderer, IUserInterface userInterface, int sleepTime)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
            this.SleepMSec = sleepTime;
        }

        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is MovingObject)
            {
                this.AddMovingObject(obj as MovingObject);
            }
            else
            {
                if (obj is Racket)
                {
                    AddRacket(obj);

                }
                else
                {
                    this.AddStaticObject(obj);
                }
            }
        }

        private void AddRacket(GameObject obj)
        {
            //TODO: we should remove the previous racket from this.allObjects
            this.playerRacket = obj as Racket;
            staticObjects.Add(playerRacket);
        }

        public virtual void MovePlayerRacketLeft()
        {
            this.playerRacket.MoveLeft();
        }

        public virtual void MovePlayerRacketRight()
        {
            this.playerRacket.MoveRight();
        }

        public virtual void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();

                System.Threading.Thread.Sleep(SleepMSec);

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                //this.renderer.EnqueueForRendering(playerRacket);

                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }
            }
        }
    }
}
