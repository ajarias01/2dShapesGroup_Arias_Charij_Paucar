using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.BasicPolygons
{
    /// <summary>
    /// A regular 6-sided polygon.
    /// Parameters: side length (a)
    /// Perimeter = 6 × a
    /// Area      = (3√3 / 2) × a²
    /// Drawing   : 6 vertices on a circle, flat-top orientation (rotated 30°).
    /// </summary>
    public class Hexagon : IShape
    {
        public string Name => "Hexagon";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Side (a)", 70.0) };

        public double Perimeter(double[] v) => 6 * v[0];
        public double Area(double[] v) => 3 * Math.Sqrt(3) / 2 * v[0] * v[0];

        public void Draw(G g, RectangleF b, double[] v)
            => PolygonHelper.DrawRegularPolygon(g, b, 6, (float)v[0]);
    }
}
