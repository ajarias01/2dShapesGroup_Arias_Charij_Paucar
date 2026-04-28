using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.CurvedShapes
{
    /// <summary>
    /// A perfectly round closed curve with constant radius r.
    /// Parameters: radius (r)
    /// Perimeter (circumference) = 2π × r
    /// Area                      = π × r²
    /// Drawing: inscribed in a padded square using FillEllipse on a square rect.
    /// </summary>
    public class Circle : IShape
    {
        public string Name => "Circle";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Radius (r)", 60.0) };

        public double Perimeter(double[] v) => 2 * Math.PI * v[0];
        public double Area(double[] v)      => Math.PI * v[0] * v[0];

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            RectangleF sq = ShapeGraphics.PaddedSquare(b);
            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillEllipse(brush, sq);
            g.DrawEllipse(pen, sq);
        }
    }
}
