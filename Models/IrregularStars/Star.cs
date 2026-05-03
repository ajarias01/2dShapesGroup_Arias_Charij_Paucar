using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.IrregularStars
{
    /// <summary>
    /// Un polígono estrella regular con n puntas.
    /// Parámetros: número de puntas n, radio exterior R, radio interior r
    /// La estrella se construye alternando vértices en los círculos exterior e interior.
    /// Perímetro ≈ 2n × longitud_lado  (aproximado; lado = cuerda entre puntos adyacentes exterior/interior)
    /// Área      ≈ (n × R² × sin(2π/n)) / 2 − (n × r² × sin(2π/n)) / 2
    /// Dibujo   : 2n vértices alternando en círculos R e r.
    /// </summary>
    public class Star : IShape
    {
        public string Name => "Star";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[]
            {
                ("Points (n)", 5.0),
                ("Outer radius R", 70.0),
                ("Inner radius r", 30.0)
            };

        public double Perimeter(double[] v)
        {
            int n    = (int)Math.Max(v[0], 3);
            double R = v[1], r = v[2];
            double angle = Math.PI / n;   // half the angle between a point and a valley
            // Side length from outer tip to inner valley (law of cosines on the triangle)
            double side = Math.Sqrt(R * R + r * r - 2 * R * r * Math.Cos(angle));
            return 2 * n * side;
        }

        public double Area(double[] v)
        {
            int n    = (int)Math.Max(v[0], 3);
            double R = v[1], r = v[2];
            double theta = 2 * Math.PI / n;
            // Shoelace on the 2n alternating vertices
            return n / 2.0 * (R * R - r * r) * Math.Sin(theta);
        }

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            int    n    = (int)Math.Max(v[0], 3);
            double R    = v[1], r = v[2];

            float sq    = Math.Min(b.Width, b.Height) - 24;
            float scale = sq / (float)(R * 2);
            float cx    = b.X + b.Width  / 2f;
            float cy    = b.Y + b.Height / 2f;

            PointF[] pts = new PointF[2 * n];
            for (int i = 0; i < 2 * n; i++)
            {
                // Vértices exteriores en índices pares, interiores en impares
                double radius = (i % 2 == 0) ? R : r;
                double angle  = -Math.PI / 2 + Math.PI * i / n;
                pts[i] = new PointF(cx + (float)(radius * scale * Math.Cos(angle)),
                                    cy + (float)(radius * scale * Math.Sin(angle)));
            }

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillPolygon(brush, pts);
            g.DrawPolygon(pen, pts);
        }
    }
}
