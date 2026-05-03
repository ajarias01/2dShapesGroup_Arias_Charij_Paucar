using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.IrregularStars
{
    /// <summary>
    /// A circular sector — a "pie slice" defined by radius and angle.
    /// Parameters: radius (r), central angle θ (degrees)
    /// Arc length (perimeter curved part) = r × θ_radians
    /// Perimeter = 2r + r × θ_radians
    /// Area      = r² × θ_radians / 2
    /// Drawing   : GDI+ DrawPie/FillPie, centered in the panel.
    /// </summary>
    public class Pie : IShape
    {
        public string Name => "Pie";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Radius (r)", 70.0), ("Angle θ (°)", 120.0) };

        public double Perimeter(double[] v)
        {
            double rad = v[1] * Math.PI / 180;
            return 2 * v[0] + v[0] * rad;
        }
        public double Area(double[] v)
        {
            double rad = v[1] * Math.PI / 180;
            return v[0] * v[0] * rad / 2;
        }

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            RectangleF sq = ShapeGraphics.PaddedSquare(b, (float)v[0]);
            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            // Start at top (-90°) so the sector opens downward/rightward nicely
            float sweep = (float)Math.Min(v[1], 359.9);
            g.FillPie(brush, sq, -90f, sweep);
            g.DrawPie(pen,   sq, -90f, sweep);
        }
    }
}
