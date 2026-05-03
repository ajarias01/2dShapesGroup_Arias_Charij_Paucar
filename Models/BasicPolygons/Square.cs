using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.BasicPolygons
{
    /// <summary>
    /// A regular quadrilateral with four equal sides.
    /// Parameters: side (a)
    /// Perimeter = 4 × a
    /// Area      = a²
    /// Drawing   : axis-aligned square centered in the panel.
    /// </summary>
    public class Square : IShape
    {
        public string Name => "Square";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Side (a)", 80.0) };

        public double Perimeter(double[] v) => 4 * v[0];
        public double Area(double[] v)      => v[0] * v[0];

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            RectangleF r = ShapeGraphics.PaddedSquare(b, (float)v[0]);
            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillRectangle(brush, r);
            g.DrawRectangle(pen, r.X, r.Y, r.Width, r.Height);
        }
    }
}
