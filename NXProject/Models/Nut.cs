using System;
using System.Globalization;
using NXOpen;
using NXOpen.UF;
using Point = NXProject.Structs.Point;

namespace NXProject.Models
{
    public class Nut : IModel
    {
        public string Name { get; set; }

        private double _nutDiameter;
        private double _nutHeigth;
        private double _nutChampferOffset;
        private double _nutChampferAngle = 45;

        private double _mainHoleDiameter;

        private double _holeDiameter;
        private double _holeLength;
        private double _holeChampferOffset;
        private double _holeChampferAngle = 45;

        public Nut(string name, double nutDiameter, double nutHeight, double nutChampferOffset, double mainHoleDiameter, double holeDiameter, double holeLength, double holeChampferOffset, double nutChampferAngle = 45, double holeChampferAngle = 45)
        {
            Name = name;

            _nutDiameter = nutDiameter;
            _nutHeigth = nutHeight;
            _nutChampferOffset = nutChampferOffset;
            _nutChampferAngle = nutChampferAngle;
            _mainHoleDiameter = mainHoleDiameter;
            _holeDiameter = holeDiameter;
            _holeLength = holeLength;
            _holeChampferOffset = holeChampferOffset;
            _holeChampferAngle = holeChampferAngle;
        }

        public void Draw(UFSession session, string filename)
        {
            var sessionDrawer = new SessionDrawer(session);
            sessionDrawer.AddModel(filename);

            MakeNut(sessionDrawer, new Point(0, 0, 0));
            MakeHoles(sessionDrawer, new Point(0, 0, 0));

            sessionDrawer.SaveModel();
        }

        private void MakeNut(SessionDrawer sessionDrawer, Point origin)
        {
            Tag[] circle = new Tag[] { sessionDrawer.DrawCircle(_nutDiameter / 2, origin) };
            Tag[] outCircle = sessionDrawer.Extrude(circle, new double[] { 0, 0, 1 }, "0.0", new string[] { "0", _nutHeigth.ToString(CultureInfo.InvariantCulture) }, FeatureSigns.Nullsign);

            sessionDrawer.Session.Modl.AskFeatBody(outCircle[0], out Tag model);
            sessionDrawer.Session.Modl.AskBodyEdges(model, out Tag[] edgeArray);
            sessionDrawer.Session.Modl.AskListItem(edgeArray, 0, out Tag champferEdge1);
            sessionDrawer.MakeChamfer(new Tag[] { champferEdge1 }, _nutChampferAngle, _nutChampferOffset);

            sessionDrawer.Session.Modl.AskListItem(edgeArray, 1, out Tag champferEdge2);
            sessionDrawer.MakeChamfer(new Tag[] { champferEdge2 }, _nutChampferAngle, _nutChampferOffset);

            Tag[] holeCircle = new Tag[] { sessionDrawer.DrawCircle(_mainHoleDiameter / 2, origin) };
            Tag[] holeOutCircle = sessionDrawer.Extrude(holeCircle, new double[] { 0, 0, 1 }, "0.0", new string[] { "0", _nutHeigth.ToString(CultureInfo.InvariantCulture) }, FeatureSigns.Negative);
            
            sessionDrawer.Session.Modl.AskBodyFaces(model, out Tag[] facesArray);
            sessionDrawer.Session.Modl.AskListItem(facesArray, 2, out Tag threadFace);
            sessionDrawer.Session.Modl.AskListItem(facesArray, 0, out Tag startFace);
            sessionDrawer.MakeThread(_mainHoleDiameter + 1, _mainHoleDiameter - 1, _mainHoleDiameter, new double[] { 0, 0, -1 }, _nutHeigth, 1, threadFace, startFace);
        }

        private void MakeHoles(SessionDrawer sessionDrawer, Point origin)
        {
            Tag[] c1 = new Tag[] { sessionDrawer.DrawCircleX(_holeDiameter / 2, new Point(_nutDiameter / 2, 0, _nutHeigth / 2)) };
            Tag[] oc1 = sessionDrawer.Extrude(c1, new double[] { -1, 0, 0 }, "0.0", new string[] { "0", _holeLength.ToString(CultureInfo.InvariantCulture) }, FeatureSigns.Negative);

            Tag[] c2 = new Tag[] { sessionDrawer.DrawCircleX(_holeDiameter / 2, new Point(-_nutDiameter / 2, 0, _nutHeigth / 2)) };
            Tag[] oc2 = sessionDrawer.Extrude(c2, new double[] { 1, 0, 0 }, "0.0", new string[] { "0", _holeLength.ToString(CultureInfo.InvariantCulture) }, FeatureSigns.Negative);

            Tag[] c3 = new Tag[] { sessionDrawer.DrawCircleY(_holeDiameter / 2, new Point(0, _nutDiameter / 2, _nutHeigth / 2)) };
            Tag[] oc3 = sessionDrawer.Extrude(c3, new double[] { 0, -1, 0 }, "0.0", new string[] { "0", _holeLength.ToString(CultureInfo.InvariantCulture) }, FeatureSigns.Negative);

            Tag[] c4 = new Tag[] { sessionDrawer.DrawCircleY(_holeDiameter / 2, new Point(0, -_nutDiameter / 2, _nutHeigth / 2)) };
            Tag[] oc4 = sessionDrawer.Extrude(c4, new double[] { 0, 1, 0 }, "0.0", new string[] { "0", _holeLength.ToString(CultureInfo.InvariantCulture) }, FeatureSigns.Negative);
        }

        public override string ToString()
        {
            return string
                .Format(
                "Nut Diameter (D) = {0}\r\n" +
                "Nut Heigth (H) = {1}\r\n" +
                "Nut Champfer Offset (c) = {2}\r\n" +
                "Main Hole Diameter (d) = {3}\r\n" +
                "Little Hole Diameter (d1) = {4}\r\n" +
                "Little Hole Length (h) = {5}\r\n", _nutDiameter, _nutHeigth, _nutChampferOffset, _mainHoleDiameter, _holeDiameter, _holeLength);
        }
    }
}
