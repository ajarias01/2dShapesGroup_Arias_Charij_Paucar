using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.BasicPolygons
{
    /// <summary>
    /// Un cuadrilátero con exactamente un par de lados paralelos.
    /// Parámetros: base superior (a), base inferior (b), altura (h)
    /// Perímetro = a + b + 2 × lado,  donde lado = √[h² + ((b−a)/2)²]
    /// Área      = (a + b) / 2 × h
    /// Dibujo   : trapecio isósceles — parte superior centrada sobre la inferior.
    /// </summary>
    public class Trapeze : IShape
    {
        public string Name => "Trapeze";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Top base (a)", 60.0), ("Bottom base (b)", 100.0), ("Height (h)", 60.0) };

        public double Perimeter(double[] v)
        {
            double leg = Math.Sqrt(v[2] * v[2] + Math.Pow((v[1] - v[0]) / 2, 2));
            return v[0] + v[1] + 2 * leg;
        }
        public double Area(double[] v) => (v[0] + v[1]) / 2 * v[2];

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float a = (float)v[0], bv = (float)v[1], h = (float)v[2];

            float logW = bv, logH = h;
            float padding = 12f;
            float scaleX  = (b.Width  - padding * 2) / Math.Max(logW, 1);
            float scaleY  = (b.Height - padding * 2) / Math.Max(logH, 1);
            float scale   = Math.Min(scaleX, scaleY);

            float sw = bv  * scale;
            float sh = h   * scale;
            float aw = a   * scale;
            float ox = b.X + (b.Width  - sw) / 2f;
            float oy = b.Y + (b.Height - sh) / 2f;

            PointF[] pts =
            {
                new(ox + (sw - aw) / 2f, oy),          // top-left
                new(ox + (sw + aw) / 2f, oy),          // top-right
                new(ox + sw,             oy + sh),      // bottom-right
                new(ox,                  oy + sh)       // bottom-left
            };

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillPolygon(brush, pts);
            g.DrawPolygon(pen, pts);
        }
    }
}
