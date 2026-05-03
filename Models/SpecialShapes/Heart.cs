using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.SpecialShapes
{
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
}
