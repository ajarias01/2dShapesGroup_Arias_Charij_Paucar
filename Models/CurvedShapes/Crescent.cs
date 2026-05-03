using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.CurvedShapes
{
    /// <summary>
    /// A crescent (lune) formed by subtracting a smaller circle from a larger one,
    /// offset horizontally to create the moon-like shape.
    /// Parameters: outer radius R, inner radius r (r &lt; R)
    /// Area ≈ π × (R² − r²) / 2  (approximate for the standard crescent)
    /// Perimeter ≈ π × (R + r)   (arc of outer + arc of inner)
    /// Drawing    : uses a GraphicsPath with AddEllipse for outer circle and
    ///              the offset inner circle, combined with FillMode.Alternate
    ///              to punch out the inner region.
    /// </summary>
    public class Crescent : IShape
    {
        public string Name => "Crescent";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Outer radius R", 70.0), ("Inner radius r", 50.0) };

        public double Perimeter(double[] v) => Math.PI * (v[0] + v[1]);
        public double Area(double[] v) => Math.PI * (v[0] * v[0] - v[1] * v[1]) / 2;

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float R = (float)Math.Max(v[0], v[1] + 1);
            float r = (float)v[1];

            float side = Math.Min(b.Width, b.Height) - 24;
            float baseScale = side / (R * 2);

            // Size scale driven by the outer radius input: clamp to [10% – 100%] of available space
            float sizeScale = Math.Clamp((float)v[0] / 100f, 0.1f, 1f);
            float scale = baseScale * sizeScale;

            float cx = b.X + b.Width / 2f;
            float cy = b.Y + b.Height / 2f;

            // Outer circle bounding box (centered)
            RectangleF outer = new(cx - R * scale, cy - R * scale,
                                   R * 2 * scale, R * 2 * scale);

            // Inner circle offset to the right so the crescent opens leftward
            float offset = (R - r) * 0.8f * scale;
            RectangleF inner = new(cx - r * scale + offset, cy - r * scale,
                                   r * 2 * scale, r * 2 * scale);

            using var path = new GraphicsPath(FillMode.Alternate);
            path.AddEllipse(outer);   // outer boundary
            path.AddEllipse(inner);   // inner cutout (Alternate mode punches it out)

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen = ShapeGraphics.CreateBorderPen();
            g.FillPath(brush, path);
            g.DrawPath(pen, path);
        }
    }
}
