namespace NXProject.Structs
{
    public struct Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        public static Point operator -(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        public static Point operator *(Point p, double a) => new Point(p.X * a, p.Y * a, p.Z * a);
        public static Point operator /(Point p, double a) => new Point(p.X / a, p.Y / a, p.Z / a);

        public double[] Array => new double[] { X, Y, Z };
    }
}
