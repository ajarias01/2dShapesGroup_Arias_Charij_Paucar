using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.SpecialShapes
{
    /// <summary>
    /// A regular 8-sided polygon.
    /// Parameters: side length (a)
    /// Perimeter = 8 × a
    /// Area      = 2(1 + √2) × a²
    /// Drawing   : 8 vertices on a circle, flat-top (rotated π/8).
    /// </summary>
    public class Octagon : IShape
    {
        public string Name => "Octagon";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Side (a)", 60.0) };

        public double Perimeter(double[] v) => 8 * v[0];
        public double Area(double[] v)      => 2 * (1 + Math.Sqrt(2)) * v[0] * v[0];

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            RectangleF sq = ShapeGraphics.PaddedSquare(b, (float)v[0]);
            float cx = sq.X + sq.Width / 2f;
            float cy = sq.Y + sq.Height / 2f;
            float r  = sq.Width / 2f;

            // 8 vertices; start at -π/2 + π/8 for flat-top orientation
            PointF[] pts = new PointF[8];
            for (int i = 0; i < 8; i++)
            {
                double angle = -Math.PI / 2 + Math.PI / 8 + 2 * Math.PI * i / 8;
                pts[i] = new PointF(cx + r * (float)Math.Cos(angle),
                                    cy + r * (float)Math.Sin(angle));
            }

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillPolygon(brush, pts);
            g.DrawPolygon(pen, pts);
        }
    }
}
