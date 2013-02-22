using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01.Point3D
{
    class SaveLoadPaths
    {
        static void Main(string[] args)
        {
            Point3D[] pointsToAdd = new Point3D[5];
            Random rng = new Random();

            for (int i = 0; i < pointsToAdd.Length; i++)
            {
                pointsToAdd[i] = new Point3D(rng.Next(1, 200), rng.Next(1, 200), rng.Next(1, 200));
            }

            Path.AddPoints(pointsToAdd);

            PathStorage.SavePath("paths.txt");
            PathStorage.LoadPath("paths.txt", 1);
            
            foreach (var item in Path.GetPoints())
            {
                Console.WriteLine(item);
            }
        } 
    }

    static class PathStorage
    {
        /// <summary>
        /// Loads one path from a text file and puts it in Path, everything previously loaded is cleared
        /// </summary>
        /// <param name="fileName">text file from which to load</param>
        /// <param name="indexOfPath">which path to load, starts from 1</param>
        static public void LoadPath(string fileName, int indexOfPath)
        {
            if (!fileName.EndsWith(".txt"))
            {
                throw new ArgumentException("file must be .txt");
            }
            Path.ClearPath();
            StreamReader sr = new StreamReader(fileName);
            StringBuilder sb = new StringBuilder();
            using (sr)
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line == "-")
                    {
                        indexOfPath--;
                        if (indexOfPath == 0)
                        {
                            break;
                        }
                        else
                        {
                            sb.Clear();
                        }
                    }
                    sb.AppendLine(line);
                }
            }

            if (indexOfPath > 0)
            {
                throw new ArgumentOutOfRangeException("Index is more than current saved paths.");
            }

            string[] coordinates = sb.ToString().Split();
            int x = 0, y = 0, z = 0;
            for (int i = 0, coordinate = 0; i < coordinates.Length; i++)
            {
                if (coordinate == 0 && int.TryParse(coordinates[i], out x))
                {
                    coordinate++;
                    continue;
                }
                else if (coordinate == 1)
                {
                    int.TryParse(coordinates[i], out y); 
                    coordinate++;
                    continue;
                }
                else if (coordinate == 2)
                {
                    int.TryParse(coordinates[i], out z);
                    coordinate = 0;
                    Path.AddPoint(new Point3D(x, y, z));
                }
            }
        }

        static public void SavePath(string fileName)
        {
            if (!fileName.EndsWith(".txt"))
            {
                fileName = fileName + ".txt";
            }

            StreamWriter sw = new StreamWriter(fileName, true);

            using (sw)
            {
                foreach (var point in Path.GetPoints())
                {
                    sw.WriteLine(point.ToString());
                }
                sw.WriteLine("-");
            }
        }
    }

    static class Path
    {
        static List<Point3D> points = new List<Point3D>();


        public static List<Point3D> GetPoints()
        {
            return points;
        }

        public static void ClearPath()
        {
            points.Clear();
        }

        public static void AddPoints(Point3D[] points)
        {
            foreach (var item in points)
            {
                Path.points.Add(item);
            }
        }

        public static void AddPoint(Point3D point)
        {
            points.Add(point);
        }
    }

    struct Point3D
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        private static readonly Point3D zeroPoint = new Point3D(0, 0, 0);

        static public Point3D GetZeroPoint
        {
            get
            {
                return zeroPoint;
            }
        }

        public Point3D(int x, int y, int z)
            : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return x.ToString() + " " + y.ToString() + " " + z.ToString();
        }
    }
}
