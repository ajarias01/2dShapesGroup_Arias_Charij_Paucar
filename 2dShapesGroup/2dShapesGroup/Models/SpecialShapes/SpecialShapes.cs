using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.SpecialShapes
{
    // ════════════════════════════════════════════════════════════════════
    //  GROUP 4 — SPECIAL SHAPES
    //  Shapes: Octagon, Heart
    //  (Parallelogram moved to Basic Polygons; cross/pie to Irregular/Stars)
    // ════════════════════════════════════════════════════════════════════

    // ────────────────────────────────────────────────────────────────────
    // OCTAGON
    // ────────────────────────────────────────────────────────────────────
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
            RectangleF sq = ShapeGraphics.PaddedSquare(b);
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

    // ────────────────────────────────────────────────────────────────────
    // HEART  (cardioid approximation via Bézier curves)
    // ────────────────────────────────────────────────────────────────────
    /// <summary>
    /// A heart shape built from two cubic Bézier arcs.
    /// Parameters: size (scale factor)
    /// Area      ≈ (13π/2) × r²   for a unit cardioid; scaled approximately here.
    /// Perimeter ≈ 8√2 × r        (approximate arc length).
    /// Drawing   : GraphicsPath using AddBezier for the two lobes.
    ///             The path is normalized to a unit square then scaled to fit.
    /// </summary>
    public class Heart : IShape
    {
        public string Name => "Heart";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Size (s)", 80.0) };

        public double Perimeter(double[] v) => 8 * Math.Sqrt(2) * v[0] / 80.0 * 60;
        public double Area(double[] v)      => Math.PI * 0.5 * (v[0] / 80.0) * (v[0] / 80.0) * 5000;

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float sq    = Math.Min(b.Width, b.Height) - 24;
            float scale = sq / 200f;   // our heart is defined in a 200×180 logical box
            float cx    = b.X + b.Width  / 2f;
            float cy    = b.Y + b.Height / 2f;

            // Heart defined in logical coords (centered at 0,0):
            //   top     = (0,  -90)
            //   right-tip of right lobe = (100, -60)
            //   bottom  = (0,   90)
            //   left-tip of left lobe   = (-100, -60)
            // We build it with two Bézier arcs:

            using var path = new GraphicsPath();

            PointF T(float x, float y) => new(cx + x * scale, cy + y * scale);

            // Right lobe (top → right-peak → bottom)
            path.AddBezier(
                T(0, -40),      // start: top-center (the dip)
                T(100, -90),    // control 1
                T(130, 40),     // control 2
                T(0, 90)        // end: bottom tip
            );

            // Left lobe (bottom → left-peak → top)
            path.AddBezier(
                T(0, 90),       // start: bottom tip
                T(-130, 40),    // control 1
                T(-100, -90),   // control 2
                T(0, -40)       // end: top-center
            );

            path.CloseFigure();

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillPath(brush, path);
            g.DrawPath(pen,   path);
        }
    }

    // ────────────────────────────────────────────────────────────────────
    // ARROW  (pointing right, bonus special shape)
    // ────────────────────────────────────────────────────────────────────
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

    // ────────────────────────────────────────────────────────────────────
    // CLOUD  (4-circle silhouette on a rectangular base)
    // ────────────────────────────────────────────────────────────────────
    /// <summary>
    /// A cloud silhouette made of overlapping circles on top of a rectangle.
    /// Parameters: width (w), height (h)
    /// Perimeter / Area are approximate (visual shape only).
    /// Drawing   : four overlapping ellipses + bottom rectangle via GraphicsPath.
    /// </summary>
    public class Cloud : IShape
    {
        public string Name => "Cloud";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Width (w)", 120.0), ("Height (h)", 70.0) };

        public double Perimeter(double[] v) => 2 * (v[0] + v[1]);
        public double Area(double[] v)      => v[0] * v[1] * 0.75;

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float w = (float)v[0], h = (float)v[1];
            float padding = 12f;
            float scaleX  = (b.Width  - padding * 2) / Math.Max(w, 1);
            float scaleY  = (b.Height - padding * 2) / Math.Max(h, 1);
            float scale   = Math.Min(scaleX, scaleY);

            float ws = w * scale, hs = h * scale;
            float ox = b.X + (b.Width  - ws) / 2f;
            float oy = b.Y + (b.Height - hs) / 2f;

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();

            // Bottom rectangle (flat base)
            float baseH = hs * 0.4f;
            float baseY = oy + hs - baseH;
            g.FillRectangle(brush, ox, baseY, ws, baseH);

            // Four bumps across the top
            float bumpH = hs * 0.65f;
            float bumpW = ws / 3.5f;
            float[] bumpX = { ox, ox + ws * 0.2f, ox + ws * 0.45f, ox + ws * 0.68f };
            float[] bumpY = { oy + hs * 0.25f, oy, oy + hs * 0.05f, oy + hs * 0.2f };
            float[] bumpW2= { bumpW * 1.1f, bumpW * 1.3f, bumpW * 1.2f, bumpW * 1.1f };
            float[] bumpH2= { bumpH * 0.8f, bumpH, bumpH * 0.9f, bumpH * 0.8f };

            for (int i = 0; i < 4; i++)
                g.FillEllipse(brush, bumpX[i], bumpY[i], bumpW2[i], bumpH2[i]);

            // Outline the base and bumps lightly
            g.DrawRectangle(pen, ox, baseY, ws, baseH);
        }
    }
}
