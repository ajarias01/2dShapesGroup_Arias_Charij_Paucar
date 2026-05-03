using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.BasicPolygons
{
    /// <summary>
    /// Un cuadrilátero con los cuatro lados iguales y diagonales que se bisecan a 90°.
    /// Parámetros: diagonal d1 (horizontal), diagonal d2 (vertical)
    /// Perímetro = 2 × √(d1² + d2²)
    /// Área      = (d1 × d2) / 2
    /// Dibujo   : forma de diamante desde los cuatro puntos medios de d1 y d2.
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
            RectangleF r = ShapeGraphics.PaddedRect(b, d1, d2, Math.Max(d1, d2));
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
