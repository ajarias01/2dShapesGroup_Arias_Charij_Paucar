using System;
using System.Drawing;
using _2dShapesGroup.Graphics;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.BasicPolygons
{
    /// <summary>
    /// Helper utilities for drawing regular polygons.
    /// </summary>
    internal static class PolygonHelper
    {
        /// <summary>
        /// Draws a regular n-sided polygon (n-gon) inside a padded square.
        /// </summary>
        public static void DrawRegularPolygon(G g, RectangleF b, int n)
        {
            ShapeGraphics.EnableAntiAlias(g);
            RectangleF sq = ShapeGraphics.PaddedSquare(b);
            float cx = sq.X + sq.Width / 2f;
            float cy = sq.Y + sq.Height / 2f;
            float r  = sq.Width / 2f;

            PointF[] pts = new PointF[n];
            for (int i = 0; i < n; i++)
            {
                // Start at top (−π/2), go clockwise
                double angle = -Math.PI / 2 + 2 * Math.PI * i / n;
                pts[i] = new PointF(cx + r * (float)Math.Cos(angle),
                                    cy + r * (float)Math.Sin(angle));
            }
            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillPolygon(brush, pts);
            g.DrawPolygon(pen, pts);
        }
    }
}
