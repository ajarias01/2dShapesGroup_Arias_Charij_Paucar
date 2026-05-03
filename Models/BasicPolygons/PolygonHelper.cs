using System;
using System.Drawing;
using _2dShapesGroup.Graphics;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.BasicPolygons
{
    /// <summary>
    /// Utilidades auxiliares para dibujar polígonos regulares.
    /// </summary>
    internal static class PolygonHelper
    {
        /// <summary>
        /// Dibuja un polígono regular de n lados (n-gon) dentro de un cuadrado con relleno.
        /// </summary>
        public static void DrawRegularPolygon(G g, RectangleF b, int n, double sideLength = 0)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float cx = b.X + b.Width / 2f;
            float cy = b.Y + b.Height / 2f;

            float r;
            if (sideLength > 0)
            {
                // Calcula el radio a partir de la longitud del lado para un polígono regular
                // r = lado / (2 * sin(π/n))
                r = (float)(sideLength / (2 * Math.Sin(Math.PI / n)));

                // Limita el radio para que quepa en el área rellenada
                float maxRadius = (Math.Min(b.Width, b.Height) - 24) / 2f;
                r = Math.Min(r, maxRadius);
            }
            else
            {
                // Comportamiento anterior
                RectangleF sq = ShapeGraphics.PaddedSquare(b);
                cx = sq.X + sq.Width / 2f;
                cy = sq.Y + sq.Height / 2f;
                r = sq.Width / 2f;
            }

            PointF[] pts = new PointF[n];
            for (int i = 0; i < n; i++)
            {
                // Comienza en la parte superior (−π/2), va en sentido de las manecillas del reloj
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
