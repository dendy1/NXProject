using NXOpen;
using NXOpen.UF;
using System;
using System.Globalization;

using Point = NXProject.Structs.Point;

namespace NXProject.Models
{
    public class Bolt : IModel
    {
        public string Name { get; set; }

        private double _headHeight;
        private double _headDiameter;
        private double _headWidth;
        private double _headSliceAngle = 30;

        private double _shaftLength;
        private double _shaftDiameter;
        private double _threadLength;

        private double _roundingRadius;

        private double _champferOffset;
        private double _champferAngle = 45;

        public Bolt(string name, double headHeigth, double headDiameter, double headWidth, double shaftLength, double shaftDiameter, double threadLength, double roundingRadius, double champferOffset, double headSliceAngle = 30, double champferAngle = 45)
        {
            Name = name;

            _headHeight = headHeigth;
            _headDiameter = headDiameter;
            _headWidth = headWidth;
            _shaftLength = shaftLength;
            _shaftDiameter = shaftDiameter;
            _threadLength = threadLength;
            _roundingRadius = roundingRadius;
            _champferOffset = champferOffset;
            _headSliceAngle = headSliceAngle;
            _champferAngle = champferAngle;
        }

        public void Draw(UFSession session, string filename)
        {
            var sessionDrawer = new SessionDrawer(session);
            sessionDrawer.AddModel(filename);

            DrawBoltHead(sessionDrawer, new Point(0, 0, 0));
            DrawBoltShaft(sessionDrawer, new Point(0, 0, _headHeight));

            sessionDrawer.SaveModel();
        }

        private void DrawBoltHead(SessionDrawer sessionDrawer, Point origin)
        {
            Tag[] rectangle = sessionDrawer.DrawRectangle(_headWidth, _headDiameter, origin);
            Tag[] outRectangle = sessionDrawer.Extrude(rectangle, new double[] { 0, 0, 1 }, "0.0", new string[] { "0", _headHeight.ToString(CultureInfo.InvariantCulture) }, FeatureSigns.Nullsign);

            var s = _headWidth / 2 * Math.Tan(_headSliceAngle * Math.PI / 180);
            Point p11 = new Point(0, _headDiameter / 2, 0);
            Point p12 = new Point(0, _headDiameter / 2, _headHeight);
            Point p13 = new Point(_headWidth / 2, _headDiameter / 2 - s, _headHeight);
            Point p14 = new Point(_headWidth / 2, _headDiameter / 2 - s, 0);

            Tag[] rect1 = new Tag[] { sessionDrawer.DrawLine(p11, p12), sessionDrawer.DrawLine(p12, p13), sessionDrawer.DrawLine(p13, p14), sessionDrawer.DrawLine(p14, p11) };
            Tag[] outRect1 = sessionDrawer.Extrude(rect1, new double[] { 1, 0, 0 }, "0.0", new string[] { "0", _headHeight.ToString(CultureInfo.InvariantCulture) }, FeatureSigns.Negative);

            Point p21 = new Point(0, -_headDiameter / 2, 0);
            Point p22 = new Point(0, -_headDiameter / 2, _headHeight);
            Point p23 = new Point(-_headWidth / 2, -_headDiameter / 2 + s, _headHeight);
            Point p24 = new Point(-_headWidth / 2, -_headDiameter / 2 + s, 0);

            Tag[] rect2 = new Tag[] { sessionDrawer.DrawLine(p21, p22), sessionDrawer.DrawLine(p22, p23), sessionDrawer.DrawLine(p23, p24), sessionDrawer.DrawLine(p24, p21) };
            Tag[] outRect2 = sessionDrawer.Extrude(rect2, new double[] { -1, 0, 0 }, "0.0", new string[] { "0", _headHeight.ToString(CultureInfo.InvariantCulture) }, FeatureSigns.Negative);
        }

        private void DrawBoltShaft(SessionDrawer sessionDrawer, Point origin)
        {
            Tag[] circle = new Tag[] { sessionDrawer.DrawLine(new Point(0, _shaftDiameter / 2, 0), new Point(0, _shaftDiameter / 2, _shaftLength)) };
            Tag[] outCircle = sessionDrawer.Revolve(circle, new string[] { "0", "360" }, new Point(0, 0, 0), new double[] { 0, 0, 1 }, FeatureSigns.Positive);

            sessionDrawer.Session.Modl.AskFeatBody(outCircle[0], out Tag model);

            sessionDrawer.Session.Modl.AskBodyFaces(model, out Tag[] facesArray);
            sessionDrawer.Session.Modl.AskListItem(facesArray, 9, out Tag threadFace);
            sessionDrawer.Session.Modl.AskListItem(facesArray, 10, out Tag startFace);
            sessionDrawer.MakeThread(_shaftDiameter + 1, _shaftDiameter - 1, _shaftDiameter, new double[] { 0, 0, -1 }, _threadLength, 2, threadFace, startFace);

            sessionDrawer.Session.Modl.AskBodyEdges(model, out Tag[] edgeArray);

            sessionDrawer.Session.Modl.AskListItem(edgeArray, 20, out Tag roundingEdge1);
            sessionDrawer.MakeRounding(new Tag[] { roundingEdge1 }, _roundingRadius);

            sessionDrawer.Session.Modl.AskListItem(edgeArray, 21, out Tag roundingEdge2);
            sessionDrawer.MakeRounding(new Tag[] { roundingEdge2 }, _roundingRadius);

            sessionDrawer.Session.Modl.AskListItem(edgeArray, 22, out Tag champferEdge);
            sessionDrawer.MakeChamfer(new Tag[] { champferEdge }, _champferAngle, _champferOffset);
        }

        public double Length { set => _shaftLength = value; }

        public override string ToString()
        {
            return string
                .Format(
                "Head Diameter (H) = {0}\r\n" +
                "Head Height (h) = {1}\r\n" +
                "Head Width (B) = {2}\r\n" +
                "Shaft Length (L) = {3}\r\n" +
                "Shaft Diameter (d) = {4}\r\n" +
                "Thread Length (l) = {5}\r\n" +
                "Rounding Radius (r) = {6}\r\n" +
                "Champfer Offset (c) = {7}", _headDiameter, _headHeight, _headWidth, _shaftLength, _shaftDiameter, _threadLength, _roundingRadius, _champferOffset);
        }
    }
}
