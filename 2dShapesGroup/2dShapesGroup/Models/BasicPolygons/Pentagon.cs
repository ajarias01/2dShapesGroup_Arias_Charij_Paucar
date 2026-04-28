using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.BasicPolygons
{
    /// <summary>
    /// A regular 5-sided polygon.
    /// Parameters: side length (a)
    /// Perimeter = 5 × a
    /// Area      = (a² / 4) × √(5(5 + 2√5))
    /// Drawing   : 5 vertices equally spaced on a circle of radius R,
    ///             where R = a / (2 sin(π/5)).
    /// </summary>
    public class Pentagon : IShape
    {
        public string Name => "Pentagon";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Side (a)", 80.0) };

        public double Perimeter(double[] v) => 5 * v[0];
        public double Area(double[] v)      => v[0] * v[0] / 4 * Math.Sqrt(5 * (5 + 2 * Math.Sqrt(5)));

        public void Draw(G g, RectangleF b, double[] v)
            => PolygonHelper.DrawRegularPolygon(g, b, 5);
    }
}
