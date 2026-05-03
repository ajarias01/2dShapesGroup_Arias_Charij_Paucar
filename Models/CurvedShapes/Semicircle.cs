using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.CurvedShapes
{
    /// <summary>
    /// La mitad de un círculo — un borde plano (diámetro) más un arco curvo.
    /// Parámetros: radio (r)
    /// Perímetro = π × r + 2r  (arco + diámetro)
    /// Área      = π × r² / 2
    /// Dibujo   : DrawPie con startAngle=180°, sweepAngle=180° (mitad superior).
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
            float radius = (float)v[0];
            float diameter = radius * 2;

            // Centra el semicírculo horizontalmente, lo posiciona en la porción superior
            float x = b.X + (b.Width - diameter) / 2f;
            float y = b.Y + (b.Height - radius) / 2f;

            // Rectángulo delimitador del círculo completo para DrawPie
            RectangleF fullCircle = new(x, y, diameter, diameter);

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            // Comienza a los 180° (izquierda), barre 180° en sentido de las manecillas → semicírculo superior
            g.FillPie(brush, fullCircle, 180f, 180f);
            g.DrawPie(pen,   fullCircle, 180f, 180f);
        }
    }
}
