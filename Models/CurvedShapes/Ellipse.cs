using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.CurvedShapes
{
    /// <summary>
    /// An oval defined by semi-axes a (horizontal) and b (vertical).
    /// Parameters: semi-axis a, semi-axis b
    /// Perimeter ≈ π × [3(a+b) − √((3a+b)(a+3b))]  (Ramanujan's approximation)
    /// Area      = π × a × b
    /// Drawing   : bounding rectangle scaled by a:b ratio, then ellipse inscribed.
    /// </summary>
    public class Ellipse : IShape
    {
        public string Name => "Ellipse";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Semi-axis a", 90.0), ("Semi-axis b", 50.0) };

        public double Perimeter(double[] v)
        {
            double a = v[0], b = v[1];
            // Ramanujan approximation: π × [3(a+b) − √((3a+b)(a+3b))]
            return Math.PI * (3 * (a + b) - Math.Sqrt((3 * a + b) * (a + 3 * b)));
        }
        public double Area(double[] v) => Math.PI * v[0] * v[1];

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float maxDim = (float)Math.Max(v[0], v[1]) * 2;
            RectangleF r = ShapeGraphics.PaddedRect(b, (float)v[0] * 2, (float)v[1] * 2, maxDim);
            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillEllipse(brush, r);
            g.DrawEllipse(pen, r);
        }
    }
}
