using NXOpen;
using NXOpen.UF;
using System;
using System.Globalization;

using Point = NXProject.Structs.Point;

namespace NXProject.Models
{
    public class Screw : IModel
    {
        public string Name { get; set; }

        private double _headDiameter;
        private double _headLength;

        private double _innerHoleDiameter;
        private double _headChampferAngle = 45;

        private double _fullShaftLength;
        private double _shaftDiameter;
        private double _threadOffest;

        private double _pushDiameter;
        private double _pushRadius;
        private double _pushLength;

        private double _roundingRadius;

        private double _champferOffset;
        private double _champferAngle = 45;

        private double ShaftLength => _fullShaftLength - _pushLength;
        private double ThreadLength => ShaftLength - _threadOffest;

        public Screw(string name, double headDiameter, double headLength, double innerHoleDiameter, double fullShaftLength, double shaftDiameter, double threadOffset, double pushDiameter, double pushRadius, double pushLength, double roundingRadius, double champferOffset, double headChanpferAngle = 45, double champferAngle = 45)
        {
            Name = name;

            _headDiameter = headDiameter;
            _headLength = headLength;
            _innerHoleDiameter = innerHoleDiameter;
            _headChampferAngle = headChanpferAngle;

            _fullShaftLength = fullShaftLength;
            _shaftDiameter = shaftDiameter;
            _threadOffest = threadOffset;

            _pushDiameter = pushDiameter;
            _pushRadius = pushRadius;
            _pushLength = pushLength;

            _roundingRadius = roundingRadius;
            _champferOffset = champferOffset;
            _champferAngle = champferAngle;
        }

        public void Draw(UFSession session, string filename)
        {
            var sessionDrawer = new SessionDrawer(session);
            sessionDrawer.AddModel(filename);

            DrawScrewHead(sessionDrawer, new Structs.Point(0, 0, 0));
            DrawScrewShaft(sessionDrawer, new Point(0, 0, _headLength));
            DrawPushPart(sessionDrawer, new Point(0, 0, _headLength + ShaftLength));

            sessionDrawer.SaveModel();
        }

        private void DrawScrewHead(SessionDrawer sessionDrawer, Point origin)
        {
            Tag[] circle = new Tag[] { sessionDrawer.DrawCircle(_headDiameter / 2, origin) };
            Tag[] outCircle = sessionDrawer.Extrude(circle, new double[] { 0, 0, 1 }, "0.0", new string[] { "0", _headLength.ToString(CultureInfo.InvariantCulture) }, FeatureSigns.Nullsign);

            Tag[] innerCircle = new Tag[] { sessionDrawer.DrawCircleX(_innerHoleDiameter / 2, new Point(_headDiameter / 2, 0, _headLength / 2)) };
            Tag[] outInnerCircle = sessionDrawer.Extrude(innerCircle, new double[] { -1, 0, 0 }, "0.0", new string[] { "0", _headDiameter.ToString(CultureInfo.InvariantCulture) }, FeatureSigns.Negative);

            sessionDrawer.Session.Modl.AskFeatBody(outCircle[0], out Tag model);
            sessionDrawer.Session.Modl.AskBodyEdges(model, out Tag[] edgeArray);

            sessionDrawer.Session.Modl.AskListItem(edgeArray, 2, out Tag champferEdge1);
            sessionDrawer.MakeChamfer(new Tag[] { champferEdge1 }, _champferAngle, _champferOffset);

            sessionDrawer.Session.Modl.AskListItem(edgeArray, 3, out Tag champferEdge2);
            sessionDrawer.MakeChamfer(new Tag[] { champferEdge2 }, _champferAngle, _champferOffset);
        }

        private void DrawScrewShaft(SessionDrawer sessionDrawer, Point origin)
        {
            Tag[] circle = new Tag[] { sessionDrawer.DrawCircle(_shaftDiameter / 2, origin) };
            Tag[] outCircle = sessionDrawer.Extrude(circle, new double[] { 0, 0, 1 }, "0.0", new string[] { "0", ShaftLength.ToString(CultureInfo.InvariantCulture) }, FeatureSigns.Positive);

            sessionDrawer.Session.Modl.AskFeatBody(outCircle[0], out Tag model);

            sessionDrawer.Session.Modl.AskBodyFaces(model, out Tag[] facesArray);
            sessionDrawer.Session.Modl.AskListItem(facesArray, 6, out Tag threadFace);
            sessionDrawer.Session.Modl.AskListItem(facesArray, 7, out Tag startFace);
            sessionDrawer.MakeThread(_shaftDiameter + 1, _shaftDiameter - 1, _shaftDiameter, new double[] { 0, 0, -1 }, ThreadLength, 2, threadFace, startFace);

            sessionDrawer.Session.Modl.AskBodyEdges(model, out Tag[] edgeArray);
            sessionDrawer.Session.Modl.AskListItem(edgeArray, 6, out Tag champferEdge);
            sessionDrawer.MakeChamfer(new Tag[] { champferEdge }, _champferAngle, _champferOffset);
        }

        private void DrawPushPart(SessionDrawer sessionDrawer, Point origin)
        {
            Tag[] sketch = new Tag[4];

            Point point1 = new Point(origin.X, origin.Y + _pushDiameter / 2, origin.Z);
            Point point3 = new Point(origin.X, origin.Y, origin.Z + _pushLength);

            Point radCenter = new Point(origin.X, origin.Y, origin.Z - (_pushRadius - _pushLength));
            double z = radCenter.Z + Math.Sqrt(_pushRadius * _pushRadius - (_pushDiameter / 2 - radCenter.Y) * (_pushDiameter / 2 - radCenter.Y));
            Point point2 = new Point(origin.X, point1.Y, z);
            double angle = Math.Atan((_pushDiameter / 2) / (z - radCenter.Z));

            sketch[0] = sessionDrawer.DrawLine(origin, point1);
            sketch[1] = sessionDrawer.DrawLine(point1, point2);
            sketch[2] = sessionDrawer.DrawArcRotY(0, angle, _pushRadius, Math.PI / 2, radCenter);
            sketch[3] = sessionDrawer.DrawLine(point3, origin);

            Tag[] pushPart = sessionDrawer.Revolve(sketch, new string[] { "0", "360" }, origin, new double[] { 0.0, 0.0, 1.0 }, FeatureSigns.Positive);

            sessionDrawer.Session.Modl.AskFeatBody(pushPart[0], out Tag model);
            sessionDrawer.Session.Modl.AskBodyEdges(model, out Tag[] edgeArray);
            sessionDrawer.Session.Modl.AskListItem(edgeArray, 1, out Tag roundingEdge);
            sessionDrawer.MakeRounding(new Tag[] { roundingEdge }, _roundingRadius / 2);
        }

        public double Length { set => _fullShaftLength = value; }

        public override string ToString()
        {
            return string
                .Format(
                "Head Diameter (D) = {0}\r\n" +
                "Head Length(h) = {1}\r\n" +
                "Inner Hole Diameter (d2) = {2}\r\n" +
                "Full Shaft Length (L) = {3}\r\n" +
                "Shaft Diameter (d) = {4}\r\n" +
                "Thread Offset = {5}\r\n" +
                "Push Diameter (d1) = {6}\r\n" +
                "Push Radius (R1) = {7}\r\n" +
                "Push Length (l) = {8}\r\n" +
                "Rounding Radius (r) = {9}", _headDiameter, _headLength, _innerHoleDiameter, _fullShaftLength, _shaftDiameter, _threadOffest, _pushDiameter, _pushRadius, _pushLength, _roundingRadius);
        }
    }
}
