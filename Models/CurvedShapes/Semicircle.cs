using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.CurvedShapes
{
    /// <summary>
    /// Half of a circle — a flat edge (diameter) plus a curved arc.
    /// Parameters: radius (r)
    /// Perimeter = π × r + 2r  (arc + diameter)
    /// Area      = π × r² / 2
    /// Drawing   : DrawPie with startAngle=180°, sweepAngle=180° (upper half).
    /// </summary>
    public class Semicircle : IShape
    {
        public string Name => "Semicircle";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Radius (r)", 60.0) };

        public double Perimeter(double[] v) => Math.PI * v[0] + 2 * v[0];
        public double Area(double[] v)      => Math.PI * v[0] * v[0] / 2;

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            // Semicircle has a 2:1 aspect ratio (width is 2r, height is r)
            RectangleF r = ShapeGraphics.PaddedRect(b, 2, 1);

            // FillPie / DrawPie require the full circle bounding box.
            // Since we draw the top half (180 to 360 degrees), the drawn part
            // occupies the top half of this bounding box.
            // Therefore, the bounding box needs to be twice as tall, and shifted
            // down so that the top half aligns exactly with 'r'.
            RectangleF fullCircle = new(r.X, r.Y, r.Width, r.Height * 2);

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            // Start at 180° (left), sweep 180° clockwise → upper semicircle
            g.FillPie(brush, fullCircle, 180f, 180f);
            g.DrawPie(pen,   fullCircle, 180f, 180f);
        }
    }
}
