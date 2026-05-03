using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.SpecialShapes
{
    /// <summary>
    /// A right-pointing arrow polygon.
    /// Parameters: total width (w), total height (h), shaft height ratio (ratio 0..1)
    /// Area      = shaft_area + triangle_head_area
    ///           = (w × ratio × h) + (0.5 × head_width × h)
    ///             where head_width is the arrowhead base.
    /// Perimeter = sum of the 7 outer edges.
    /// Drawing   : 7-vertex polygon.
    /// </summary>
    public class Arrow : IShape
    {
        public string Name => "Arrow";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Width (w)", 120.0), ("Height (h)", 70.0), ("Shaft ratio", 0.4) };

        public double Perimeter(double[] v)
        {
            double w  = v[0], h = v[1], ratio = v[2];
            double sw = w * (1 - 0.35);           // shaft length (without head)
            double sh = h * ratio;                 // shaft height
            double headH = h;
            double headW = w * 0.35;
            // 7 segments: top-shaft, shaft-to-head-top, head diagonal, bottom-tip, head diagonal, head-to-shaft-bot, bottom-shaft
            return 2 * sw + 2 * (headH - sh) + 2 * Math.Sqrt(headW * headW + headH * headH) + sh * 0;
        }

        public double Area(double[] v)
        {
            double w  = v[0], h = v[1], ratio = v[2];
            double sh = h * ratio;
            double sw = w * 0.65;
            double headW = w * 0.35;
            return sw * sh + 0.5 * headW * h;
        }

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float w  = (float)v[0], h = (float)v[1];
            float ratio = (float)Math.Max(0.1, Math.Min(0.9, v[2]));

            float padding = 12f;
            float scaleX  = (b.Width  - padding * 2) / Math.Max(w, 1);
            float scaleY  = (b.Height - padding * 2) / Math.Max(h, 1);
            float scale   = Math.Min(scaleX, scaleY);

            float ws = w * scale, hs = h * scale;
            float ox = b.X + (b.Width  - ws) / 2f;
            float oy = b.Y + (b.Height - hs) / 2f;

            float shaftEnd  = ws * 0.65f;           // x where shaft ends / head begins
            float shaftTop  = oy + hs * (1 - ratio) / 2f;
            float shaftBot  = oy + hs * (1 + ratio) / 2f;

            PointF[] pts =
            {
                new(ox,           shaftTop),         // shaft top-left
                new(ox + shaftEnd, shaftTop),         // shaft top-right (head start)
                new(ox + shaftEnd, oy),               // head top-outer
                new(ox + ws,      oy + hs / 2f),     // arrow tip
                new(ox + shaftEnd, oy + hs),          // head bottom-outer
                new(ox + shaftEnd, shaftBot),         // shaft bottom-right
                new(ox,           shaftBot),          // shaft bottom-left
            };

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillPolygon(brush, pts);
            g.DrawPolygon(pen, pts);
        }
    }
}
