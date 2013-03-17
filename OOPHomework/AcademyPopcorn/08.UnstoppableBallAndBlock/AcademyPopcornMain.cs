using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                engine.AddObject(new Block(new MatrixCoords(startRow, i)));
            }

            CreateFieldBorders(engine, startRow, startCol, endCol);

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 2),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        private static void CreateFieldBorders(Engine engine, int startRow, int startCol, int endCol)
        {
            for (int i = startRow; i < WorldRows; i++)
            {
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(i, startCol)));
            }

            for (int i = startRow; i < WorldRows; i++)
            {
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1)));
            }

            for (int i = startCol; i <= endCol; i++)
            {
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(startRow - 1, i)));
            }
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 50);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
