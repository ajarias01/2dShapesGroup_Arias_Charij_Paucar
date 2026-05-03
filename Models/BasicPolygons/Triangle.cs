using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.BasicPolygons
{
    /// <summary>
    /// A three-sided polygon with arbitrary side lengths.
    /// Parameters: side a, side b, side c
    /// Perimeter = a + b + c
    /// Area      = √[s(s−a)(s−b)(s−c)]  where s = (a+b+c)/2  (Heron's formula)
    /// Drawing   : vertex A at origin, B along x-axis; C found via cosine rule.
    ///             The triangle is then scaled and centered in the panel.
    /// </summary>
    public class Triangle : IShape
    {
        public string Name => "Triangle";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Side a", 80.0), ("Side b", 80.0), ("Side c", 80.0) };

        public double Perimeter(double[] v) => v[0] + v[1] + v[2];

        public double Area(double[] v)
        {
            double s = Perimeter(v) / 2;
            double area2 = s * (s - v[0]) * (s - v[1]) * (s - v[2]);
            return area2 > 0 ? Math.Sqrt(area2) : 0;
        }

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            double a = v[0], bv = v[1], c = v[2];

            // Place A=(0,0), B=(a,0), then find C via cosine rule
            double cosA = (a * a + c * c - bv * bv) / (2 * a * c);
            cosA = Math.Max(-1, Math.Min(1, cosA));
            double sinA = Math.Sqrt(1 - cosA * cosA);

            PointF pA = new(0, 0);
            PointF pB = new((float)a, 0);
            PointF pC = new((float)(c * cosA), -(float)(c * sinA));

            // Normalize to fit bounds
            float minX = (float)Math.Min(pA.X, Math.Min(pB.X, pC.X));
            float minY = (float)Math.Min(pA.Y, Math.Min(pB.Y, pC.Y));
            float maxX = (float)Math.Max(pA.X, Math.Max(pB.X, pC.X));
            float maxY = (float)Math.Max(pA.Y, Math.Max(pB.Y, pC.Y));

            float shapeW = maxX - minX, shapeH = maxY - minY;
            float padding = 12f;
            float scaleX = (b.Width  - padding * 2) / Math.Max(shapeW, 1);
            float scaleY = (b.Height - padding * 2) / Math.Max(shapeH, 1);
            float scale  = Math.Min(scaleX, scaleY);

            float sizeScale = Math.Clamp((float)Math.Max(Math.Max(v[0], v[1]), v[2]) / 100f, 0.1f, 1f);
            scale *= sizeScale;

            PointF[] pts = { Scale(pA), Scale(pB), Scale(pC) };

            // Center in panel
            float drawW = shapeW * scale, drawH = shapeH * scale;
            float offX = b.X + (b.Width  - drawW) / 2f;
            float offY = b.Y + (b.Height - drawH) / 2f;
            for (int i = 0; i < pts.Length; i++)
                pts[i] = new PointF(pts[i].X + offX, pts[i].Y + offY);

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillPolygon(brush, pts);
            g.DrawPolygon(pen, pts);

            PointF Scale(PointF p) => new((p.X - minX) * scale, (p.Y - minY) * scale);
        }
    }
}
