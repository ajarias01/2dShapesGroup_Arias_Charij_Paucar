using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.BasicPolygons
{
    /// <summary>
    /// Un cuadrilátero con dos pares de lados paralelos.
    /// Parámetros: base (a), lado (b), ángulo de inclinación θ (grados, predeterminado 60°)
    /// Perímetro = 2(a + b)
    /// Área      = a × b × sin(θ)
    /// Dibujo   : 4 vértices con desplazamiento horizontal = b × cos(θ).
    /// </summary>
    public class Parallelogram : IShape
    {
        public string Name => "Parallelogram";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Base (a)", 100.0), ("Side (b)", 60.0), ("Angle θ (°)", 60.0) };

        public double Perimeter(double[] v) => 2 * (v[0] + v[1]);
        public double Area(double[] v) => v[0] * v[1] * Math.Sin(v[2] * Math.PI / 180);

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            double a = Math.Max(v[0], 1);
            double bv = Math.Max(v[1], 1);
            double deg = v[2];
            double rad = deg * Math.PI / 180;

            // Coordenadas lógicas (sin escala)
            double offset = bv * Math.Cos(rad);
            double height = bv * Math.Sin(rad);

            // Cuadro delimitador de la forma en el espacio lógico
            double logW = a + Math.Abs(offset);
            double logH = height;

            float padding = 12f;
            float scaleX = (b.Width - padding * 2) / (float)Math.Max(logW, 1);
            float scaleY = (b.Height - padding * 2) / (float)Math.Max(logH, 1);
            float scale = Math.Min(scaleX, scaleY);

            // Size scale driven by the base input (a): clamp to [10% – 100%] of available space
            float sizeScale = Math.Clamp((float)v[0] / 100f, 0.1f, 1f);
            scale *= sizeScale;

            float sw = (float)(logW * scale);
            float sh = (float)(logH * scale);
            float ox = b.X + (b.Width - sw) / 2f;
            float oy = b.Y + (b.Height - sh) / 2f;

            float off = (float)(offset * scale);
            float w = (float)(a * scale);
            float h = (float)(height * scale);

            // Abajo-izquierda, abajo-derecha, arriba-derecha, arriba-izquierda
            PointF[] pts =
            {
                new(ox,           oy + h),
                new(ox + w,       oy + h),
                new(ox + w + off, oy),
                new(ox + off,     oy)
            };

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen = ShapeGraphics.CreateBorderPen();
            g.FillPolygon(brush, pts);
            g.DrawPolygon(pen, pts);
        }
    }
}
