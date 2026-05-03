using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.SpecialShapes
{
    /// <summary>
    /// Un polígono con forma de flecha apuntando hacia la derecha.
    /// Parámetros: ancho total (w), alto total (h), relación de altura del eje (ratio 0..1)
    /// Área      = área_eje + área_triángulo_cabeza
    ///           = (w × ratio × h) + (0.5 × ancho_cabeza × h)
    ///             donde ancho_cabeza es la base de la punta de flecha.
    /// Perímetro = suma de los 7 bordes exteriores.
    /// Dibujo   : polígono de 7 vértices.
    /// </summary>
    public class Arrow : IShape
    {
        public string Name => "Arrow";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Width (w)", 120.0), ("Height (h)", 70.0), ("Shaft ratio", 0.4) };

        public double Perimeter(double[] v)
        {
            double w = v[0], h = v[1], ratio = v[2];
            ratio = Math.Max(0.1, Math.Min(0.9, ratio));

            double shaftEnd = w * 0.65;
            double shaftTop = h * (1 - ratio) / 2;
            double shaftBot = h * (1 + ratio) / 2;
            double headBase = w * 0.35;

            // Calculate the 7 edges:
            // 1. Top left vertical: from (0, shaftTop) to (shaftEnd, shaftTop)
            double edge1 = shaftEnd;

            // 2. Diagonal from (shaftEnd, shaftTop) to (w, h/2)
            double dx2 = w - shaftEnd;
            double dy2 = h / 2 - shaftTop;
            double edge2 = Math.Sqrt(dx2 * dx2 + dy2 * dy2);

            // 3. Diagonal from (w, h/2) to (shaftEnd, shaftBot)
            double dx3 = w - shaftEnd;
            double dy3 = shaftBot - h / 2;
            double edge3 = Math.Sqrt(dx3 * dx3 + dy3 * dy3);

            // 4. Bottom right vertical: from (shaftEnd, shaftBot) to (0, shaftBot)
            double edge4 = shaftEnd;

            // 5. Left vertical: from (0, shaftBot) to (0, shaftTop)
            double edge5 = shaftBot - shaftTop;

            // 6. Right diagonal at head: from (shaftEnd, shaftBot) to (w, h/2) [already counted as edge3]
            // 7. Left diagonal at head: from (shaftEnd, shaftTop) to (w, h/2) [already counted as edge2]

            // Actually, the polygon has these edges in order:
            // (0, shaftTop) -> (shaftEnd, shaftTop) -> (w, h/2) -> (shaftEnd, shaftBot) -> (0, shaftBot) -> back to start
            // That's 5 unique vertices, but we need 7. Let me reconsider the polygon structure.

            // The 7-point polygon from Draw():
            // 0: (0, shaftTop)
            // 1: (shaftEnd, shaftTop)
            // 2: (w, shaftTop_outer) = (w, 0) when head starts
            // 3: (w, h/2) - tip
            // 4: (w, shaftBot_outer) = (w, h)
            // 5: (shaftEnd, shaftBot)
            // 6: (0, shaftBot)

            double shaftHeight = shaftBot - shaftTop;

            // Edge from point 0 to 1: horizontal
            double e1 = shaftEnd;

            // Edge from point 1 to 2: vertical
            double e2 = shaftTop;

            // Edge from point 2 to 3: diagonal
            double dx23 = w - shaftEnd;
            double dy23 = h / 2 - 0;
            double e3 = Math.Sqrt(dx23 * dx23 + dy23 * dy23);

            // Edge from point 3 to 4: diagonal
            double dx34 = w - shaftEnd;
            double dy34 = h - h / 2;
            double e4 = Math.Sqrt(dx34 * dx34 + dy34 * dy34);

            // Edge from point 4 to 5: vertical
            double e5 = h - shaftBot;

            // Edge from point 5 to 6: horizontal
            double e6 = shaftEnd;

            // Edge from point 6 to 0: vertical
            double e7 = shaftHeight;

            return e1 + e2 + e3 + e4 + e5 + e6 + e7;
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
