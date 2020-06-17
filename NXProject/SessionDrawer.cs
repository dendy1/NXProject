using System;
using System.Globalization;
using NXOpen;
using NXOpen.UF;
using Point = NXProject.Structs.Point;

namespace NXProject
{
    class SessionDrawer
    {
        private UFSession _theSession;

        public UFSession Session => _theSession;

        public enum FunctionType
        {
            TAN,
            CTG
        }

        public SessionDrawer(UFSession session)
        {
            _theSession = session;
        }

        public void AddModel(string filename)
        {
            _theSession.Part.New(filename, 1, out _);
        }

        public void SaveModel()
        {
            _theSession.Part.Save();
        }

        public Tag DrawLine(Point startPoint, Point endPoint)
        {
            UFCurve.Line line = new UFCurve.Line();
            line.start_point = startPoint.Array;
            line.end_point = endPoint.Array;
            
            Tag sketchPart;
            _theSession.Curve.CreateLine(ref line, out sketchPart);

            return sketchPart;
        }

        public Tag DrawArc(double startAngle, double endAngle, double radius, Point center)
        {
            UFCurve.Arc arc = new UFCurve.Arc();
            Tag wcs_tag, matrix_tag;
            arc.start_angle = startAngle;
            arc.end_angle = endAngle;
            arc.arc_center = center.Array;
            arc.radius = radius;

            _theSession.Csys.AskWcs(out wcs_tag);
            _theSession.Csys.AskMatrixOfObject(wcs_tag, out matrix_tag);
            arc.matrix_tag = matrix_tag;
            Tag sketchPart;
            _theSession.Curve.CreateArc(ref arc, out sketchPart);
            return sketchPart;
        }

        public Tag DrawArcRotX(double startAngle, double endAngle, double radius, double angle, Point center)
        {
            UFCurve.Arc arc = new UFCurve.Arc();
            double[] matrix = new double[9];
            double[] rotAxis = new double[3] { 1.0, 0.0, 0.0 };

            _theSession.Mtx3.RotateAboutAxis(rotAxis, angle, matrix);
            arc.arc_center = new double[3];
            _theSession.Mtx3.VecMultiply(center.Array, matrix, arc.arc_center);
            _theSession.Csys.CreateMatrix(matrix, out arc.matrix_tag);
            arc.start_angle = startAngle;
            arc.end_angle = endAngle;
            arc.radius = radius;

            Tag sketchPart;
            _theSession.Curve.CreateArc(ref arc, out sketchPart);
            return sketchPart;
        }

        public Tag DrawArcRotY(double startAngle, double endAngle, double radius, double angle, Point center)
        {
            UFCurve.Arc arc = new UFCurve.Arc();
            double[] matrix = new double[9];
            double[] rotAxis = new double[3] { 0.0, 1.0, 0.0 };

            _theSession.Mtx3.RotateAboutAxis(rotAxis, angle, matrix);
            arc.arc_center = new double[3];
            _theSession.Mtx3.VecMultiply(center.Array, matrix, arc.arc_center);
            _theSession.Csys.CreateMatrix(matrix, out arc.matrix_tag);
            arc.start_angle = startAngle;
            arc.end_angle = endAngle;
            arc.radius = radius;

            Tag sketchPart;
            _theSession.Curve.CreateArc(ref arc, out sketchPart);
            return sketchPart;
        }

        public Tag DrawCircle(double radius, Point center)
        {
            return DrawArc(0, 2 * Math.PI, radius, center);
        }

        public Tag DrawCircleX(double radius, Point center)
        {
            return DrawArcRotY(0, 2 * Math.PI, radius, Math.PI / 2, center);
        }

        public Tag DrawCircleY(double radius, Point center)
        {
            return DrawArcRotX(0, 2 * Math.PI, radius, Math.PI / 2, center);
        }

        public Tag[] DrawRectangle(double width, double heigth, Point center)
        {
            Tag[] rectangle = new Tag[4];

            Point p1 = new Point(center.X - width / 2, center.Y - heigth / 2, center.Z);
            Point p2 = new Point(center.X - width / 2, center.Y + heigth / 2, center.Z);
            Point p3 = new Point(center.X + width / 2, center.Y + heigth / 2, center.Z);
            Point p4 = new Point(center.X + width / 2, center.Y - heigth / 2, center.Z);

            rectangle[0] = DrawLine(p1, p2);
            rectangle[1] = DrawLine(p2, p3);
            rectangle[2] = DrawLine(p3, p4);
            rectangle[3] = DrawLine(p4, p1);

            return rectangle;
        }

        public Tag[] Extrude(Tag[] sketch, double[] direction, string taperAngle, string[] limit, FeatureSigns sign)
        {
            Tag[] output;
            _theSession.Modl.CreateExtruded(sketch, taperAngle, limit, new double[3], direction, sign, out output);
            return output;
        }

        public Tag[] Revolve(Tag[] sketch, string[] limit, Point refPoint, double[] direction, FeatureSigns sign)
        {
            Tag[] output;
            _theSession.Modl.CreateRevolved(sketch, limit, refPoint.Array, direction, sign, out output);
            return output;
        }

        public Tag MakeChamfer(Tag[] tags, double angle, double offset)
        {
            Tag output;
            _theSession.Modl.CreateChamfer(3, offset.ToString(CultureInfo.InvariantCulture), offset.ToString(CultureInfo.InvariantCulture), angle.ToString(CultureInfo.InvariantCulture), tags, out output);
            return output;
        }

        public Tag MakeRounding(Tag[] tags, double radius)
        {
            Tag output;
            _theSession.Modl.CreateBlend(radius.ToString(CultureInfo.InvariantCulture), tags, 0, 0, 0, 0.0, out output);
            return output;
        }

        public void MakeThread(double majorDiameter, double minorDiameter, double diameter, double[] direction, double length, double step, Tag cylFace, Tag startFace)
        {
            Tag output;
            UFModl.SymbThreadData threadData = new UFModl.SymbThreadData();
            threadData.length = length.ToString();
            threadData.minor_dia = minorDiameter.ToString(CultureInfo.InvariantCulture);
            threadData.major_dia = majorDiameter.ToString(CultureInfo.InvariantCulture);
            threadData.include_instances = UFConstants.UF_MODL_INCL_INSTANCES;
            threadData.cyl_face = cylFace;
            threadData.start_face = startFace;
            threadData.axis_direction = direction;
            threadData.rotation = UFConstants.UF_MODL_RIGHT_HAND;
            threadData.num_starts = 10;
            threadData.form = "Metric";
            threadData.tapped_dia = diameter.ToString(CultureInfo.InvariantCulture);
            threadData.pitch = step.ToString(CultureInfo.InvariantCulture);
            threadData.angle = "60";
            _theSession.Modl.CreateSymbThread(ref threadData, out output);
        }
    }
}
