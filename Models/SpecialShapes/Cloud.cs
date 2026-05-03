using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.SpecialShapes
{
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

            float sizeScale = Math.Clamp(Math.Max(w, h) / 100f, 0.1f, 1f);
            scale *= sizeScale;

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
