using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.IrregularStars
{
    /// <summary>
    /// Un cuadrilátero con dos pares de lados adyacentes iguales.
    /// Parámetros: mitad del ancho superior (w), altura superior (h1), altura inferior (h2)
    /// Perímetro = 2 × √(w²+h1²) + 2 × √(w²+h2²)
    /// Área      = w × (h1 + h2)  (= d1×d2/2 donde d1=2w, d2=h1+h2)
    /// Dibujo   : forma de diamante con la parte superior más corta que la inferior.
    /// </summary>
    public class Kite : IShape
    {
        public string Name => "Kite";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Half-width (w)", 50.0), ("Top height (h1)", 40.0), ("Bottom height (h2)", 80.0) };

        public double Perimeter(double[] v)
        {
            double w = v[0], h1 = v[1], h2 = v[2];
            return 2 * Math.Sqrt(w * w + h1 * h1) + 2 * Math.Sqrt(w * w + h2 * h2);
        }
        public double Area(double[] v) => v[0] * (v[1] + v[2]);

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float w = (float)v[0], h1 = (float)v[1], h2 = (float)v[2];
            float logW = w * 2, logH = h1 + h2;
            float padding = 12f;
            float scaleX  = (b.Width  - padding * 2) / Math.Max(logW, 1);
            float scaleY  = (b.Height - padding * 2) / Math.Max(logH, 1);
            float scale   = Math.Min(scaleX, scaleY);

            float sw = logW * scale, sh = logH * scale;
            float ox  = b.X + (b.Width  - sw) / 2f + w * scale;
            float oy  = b.Y + (b.Height - sh) / 2f;

            PointF[] pts =
            {
                new(ox,             oy),                    // arriba
                new(ox + w * scale, oy + h1 * scale),       // derecha (medio)
                new(ox,             oy + sh),               // abajo
                new(ox - w * scale, oy + h1 * scale)        // izquierda (medio)
            };

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillPolygon(brush, pts);
            g.DrawPolygon(pen, pts);
        }
    }
}
