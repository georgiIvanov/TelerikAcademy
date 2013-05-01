using System;

namespace Cohesion_and_Coupling
{
    class UtilsExamples
    {
        static void Main()
        {
            // Will throw an exception because there is no file extension
            // Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                MeasurementsUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                MeasurementsUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Parallelepiped parallelepiped = new Parallelepiped(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", MeasurementsUtils.CalcVolume(
                parallelepiped.Width, parallelepiped.Height, parallelepiped.Depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", MeasurementsUtils.CalcDiagonalXYZ(
                parallelepiped.Width, parallelepiped.Height, parallelepiped.Depth));
            Console.WriteLine("Diagonal XY = {0:f2}", MeasurementsUtils.CalcDiagonalXY(
                parallelepiped.Width, parallelepiped.Height));
            Console.WriteLine("Diagonal XZ = {0:f2}", MeasurementsUtils.CalcDiagonalXZ(
                parallelepiped.Width, parallelepiped.Depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", MeasurementsUtils.CalcDiagonalYZ(
                parallelepiped.Height, parallelepiped.Depth));
        }
    }
}
