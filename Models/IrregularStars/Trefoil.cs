using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.IrregularStars
{
    /// <summary>
    /// Three circles arranged symmetrically around a central point, overlapping
    /// to form a three-leaf clover.
    /// Parameters: lobe radius r
    /// Area      ≈ 3 × π × r²  (three full circles, overlap ignored for simplicity)
    /// Perimeter ≈ 3 × 2π × r  (three full arcs)
    /// Drawing   : three ellipses placed at 120° intervals around center.
    /// </summary>
    public class Trefoil : IShape
    {
        public string Name => "Trefoil";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Lobe radius r", 40.0) };

        public double Perimeter(double[] v) => 3 * 2 * Math.PI * v[0];
        public double Area(double[] v) => 3 * Math.PI * v[0] * v[0];

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float r = (float)v[0];
            float sq = Math.Min(b.Width, b.Height) - 24;

            // Each lobe circle fits within half the square
            float baseScale = sq / (r * 4);

            // Size scale driven by the lobe radius input: clamp to [10% – 100%] of available space
            float sizeScale = Math.Clamp((float)v[0] / 100f, 0.1f, 1f);
            float rs = r * baseScale * sizeScale;   // scaled lobe radius

            float cx = b.X + b.Width / 2f;
            float cy = b.Y + b.Height / 2f;

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen = ShapeGraphics.CreateBorderPen();

            // Three lobes at 90°, 210°, 330° (top, bottom-left, bottom-right)
            double[] angles = { -Math.PI / 2, -Math.PI / 2 + 2 * Math.PI / 3, -Math.PI / 2 + 4 * Math.PI / 3 };
            foreach (double angle in angles)
            {
                float lx = cx + (float)(rs * Math.Cos(angle)) - rs;
                float ly = cy + (float)(rs * Math.Sin(angle)) - rs;
                g.FillEllipse(brush, lx, ly, rs * 2, rs * 2);
                g.DrawEllipse(pen, lx, ly, rs * 2, rs * 2);
            }
        }
    }
}
