using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.BasicPolygons
{
    /// <summary>
    /// A quadrilateral with opposite sides equal and all angles 90°.
    /// Parameters: width (a), height (b)
    /// Perimeter = 2(a + b)
    /// Area      = a × b
    /// Drawing   : rectangle scaled to fit, preserving aspect ratio a:b.
    /// </summary>
    public class RectangleShape : IShape
    {
        public string Name => "Rectangle";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Width (a)", 100.0), ("Height (b)", 60.0) };

        public double Perimeter(double[] v) => 2 * (v[0] + v[1]);
        public double Area(double[] v)      => v[0] * v[1];

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            double w = Math.Max(v[0], 1), h = Math.Max(v[1], 1);
            float maxDim = (float)Math.Max(w, h);
            RectangleF r = ShapeGraphics.PaddedRect(b, (float)w, (float)h, maxDim);
            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillRectangle(brush, r);
            g.DrawRectangle(pen, r.X, r.Y, r.Width, r.Height);
        }
    }
}
