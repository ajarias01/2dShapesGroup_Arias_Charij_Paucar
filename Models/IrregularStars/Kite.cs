using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.IrregularStars
{
    /// <summary>
    /// A quadrilateral with two pairs of adjacent sides equal.
    /// Parameters: top half-width (w), top height (h1), bottom height (h2)
    /// Perimeter = 2 × √(w²+h1²) + 2 × √(w²+h2²)
    /// Area      = w × (h1 + h2)  (= d1×d2/2 where d1=2w, d2=h1+h2)
    /// Drawing   : diamond-like shape with the top portion shorter than the bottom.
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

            float sizeScale = Math.Clamp(Math.Max(logW, logH) / 100f, 0.1f, 1f);
            scale *= sizeScale;

            float sw = logW * scale, sh = logH * scale;
            float ox  = b.X + (b.Width  - sw) / 2f + w * scale;
            float oy  = b.Y + (b.Height - sh) / 2f;

            PointF[] pts =
            {
                new(ox,             oy),                    // top
                new(ox + w * scale, oy + h1 * scale),       // right (middle)
                new(ox,             oy + sh),               // bottom
                new(ox - w * scale, oy + h1 * scale)        // left (middle)
            };

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillPolygon(brush, pts);
            g.DrawPolygon(pen, pts);
        }
    }
}
