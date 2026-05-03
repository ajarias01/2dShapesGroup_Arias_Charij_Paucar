using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.IrregularStars
{
    /// <summary>
    /// Un triángulo con todos los lados de diferentes longitudes (escaleno).
    /// Las mismas matemáticas que el triángulo del Grupo 1; colocado aquí para coincidir con el diseño de la imagen.
    /// Parámetros: lado a, lado b, lado c
    /// Perímetro = a + b + c
    /// Área      = fórmula de Herón
    /// Dibujo   : coordenadas derivadas mediante la regla del coseno, luego escaladas para ajustarse.
    /// </summary>
    public class Scalene : IShape
    {
        public string Name => "Scalene";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Side a", 100.0), ("Side b", 70.0), ("Side c", 50.0) };

        public double Perimeter(double[] v) => v[0] + v[1] + v[2];

        public double Area(double[] v)
        {
            double s = Perimeter(v) / 2;
            double a2 = s * (s - v[0]) * (s - v[1]) * (s - v[2]);
            return a2 > 0 ? Math.Sqrt(a2) : 0;
        }

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            double a = v[0], bv = v[1], c = v[2];
            double cosA = (a * a + c * c - bv * bv) / (2 * a * c);
            cosA = Math.Max(-1, Math.Min(1, cosA));
            double sinA = Math.Sqrt(1 - cosA * cosA);

            PointF pA = new(0, 0);
            PointF pB = new((float)a, 0);
            PointF pC = new((float)(c * cosA), -(float)(c * sinA));

            float minX = Math.Min(pA.X, Math.Min(pB.X, pC.X));
            float minY = Math.Min(pA.Y, Math.Min(pB.Y, pC.Y));
            float maxX = Math.Max(pA.X, Math.Max(pB.X, pC.X));
            float maxY = Math.Max(pA.Y, Math.Max(pB.Y, pC.Y));

            float shapeW = maxX - minX, shapeH = maxY - minY;
            float padding = 12f;
            float scaleX = (b.Width  - padding * 2) / Math.Max(shapeW, 1);
            float scaleY = (b.Height - padding * 2) / Math.Max(shapeH, 1);
            float scale  = Math.Min(scaleX, scaleY);

            float drawW = shapeW * scale, drawH = shapeH * scale;
            float offX = b.X + (b.Width  - drawW) / 2f;
            float offY = b.Y + (b.Height - drawH) / 2f;

            PointF[] pts =
            {
                new((pA.X - minX) * scale + offX, (pA.Y - minY) * scale + offY),
                new((pB.X - minX) * scale + offX, (pB.Y - minY) * scale + offY),
                new((pC.X - minX) * scale + offX, (pC.Y - minY) * scale + offY)
            };

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillPolygon(brush, pts);
            g.DrawPolygon(pen, pts);
        }
    }
}
