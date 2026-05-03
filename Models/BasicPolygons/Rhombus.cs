using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.BasicPolygons
{
    /// <summary>
    /// A quadrilateral with all four sides equal and diagonals bisecting at 90°.
    /// Parameters: diagonal d1 (horizontal), diagonal d2 (vertical)
    /// Perimeter = 2 × √(d1² + d2²)
    /// Area      = (d1 × d2) / 2
    /// Drawing   : diamond shape from the four midpoints of d1 and d2.
    /// </summary>
    public class Rhombus : IShape
    {
        public string Name => "Rhombus";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Diagonal d1", 100.0), ("Diagonal d2", 70.0) };

        public double Perimeter(double[] v) => 2 * Math.Sqrt(v[0] * v[0] + v[1] * v[1]);
        public double Area(double[] v)      => v[0] * v[1] / 2;

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float d1 = (float)v[0], d2 = (float)v[1];
            RectangleF r = ShapeGraphics.PaddedRect(b, d1, d2);
            float cx = r.X + r.Width / 2f;
            float cy = r.Y + r.Height / 2f;

            PointF[] pts =
            {
                new(cx,          r.Y),            // top
                new(r.X + r.Width, cy),           // right
                new(cx,          r.Y + r.Height), // bottom
                new(r.X,         cy)              // left
            };

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillPolygon(brush, pts);
            g.DrawPolygon(pen, pts);
        }
    }
}
