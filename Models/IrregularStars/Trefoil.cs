using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.IrregularStars
{
    /// <summary>
    /// Tres círculos dispuestos simétricamente alrededor de un punto central, superpuestos
    /// para formar un trébol de tres hojas.
    /// Parámetros: radio del lóbulo r
    /// Área      ≈ 3 × π × r²  (tres círculos completos, superposición ignorada por simplicidad)
    /// Perímetro ≈ 3 × 2π × r  (tres arcos completos)
    /// Dibujo   : tres elipses colocadas a intervalos de 120° alrededor del centro.
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
            float r   = (float)v[0];
            float padding = 12f;
            float availableSize = Math.Min(b.Width, b.Height) - padding * 2;

            // Scale radius to fit within available space (diameter of trefoil ≈ 4r)
            float maxSize = availableSize / 4f;
            float rs = Math.Min(r, maxSize);

            float cx  = b.X + b.Width  / 2f;
            float cy  = b.Y + b.Height / 2f;

            using var brush = ShapeGraphics.CreateFillBrush();

            // Tres lóbulos a 90°, 210°, 330° (arriba, abajo-izquierda, abajo-derecha)
            double[] angles = { -Math.PI / 2, -Math.PI / 2 + 2 * Math.PI / 3, -Math.PI / 2 + 4 * Math.PI / 3 };
            foreach (double angle in angles)
            {
                float lx = cx + (float)(rs * Math.Cos(angle)) - rs;
                float ly = cy + (float)(rs * Math.Sin(angle)) - rs;
                g.FillEllipse(brush, lx, ly, rs * 2, rs * 2);
            }
        }
    }
}
