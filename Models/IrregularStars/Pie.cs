using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.IrregularStars
{
    /// <summary>
    /// Un sector circular — una "rebanada de pastel" definida por radio y ángulo.
    /// Parámetros: radio (r), ángulo central θ (grados)
    /// Longitud de arco (parte curva del perímetro) = r × θ_radianes
    /// Perímetro = 2r + r × θ_radianes
    /// Área      = r² × θ_radianes / 2
    /// Dibujo   : GDI+ DrawPie/FillPie, centrado en el panel.
    /// </summary>
    public class Pie : IShape
    {
        public string Name => "Pie";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Radius (r)", 70.0), ("Angle θ (°)", 120.0) };

        public double Perimeter(double[] v)
        {
            double rad = v[1] * Math.PI / 180;
            return 2 * v[0] + v[0] * rad;
        }
        public double Area(double[] v)
        {
            double rad = v[1] * Math.PI / 180;
            return v[0] * v[0] * rad / 2;
        }

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float radius = (float)v[0];
            float diameter = radius * 2;

            // Centra el pastel
            float x = b.X + (b.Width - diameter) / 2f;
            float y = b.Y + (b.Height - diameter) / 2f;
            RectangleF sq = new RectangleF(x, y, diameter, diameter);

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            // Comienza en la parte superior (-90°) para que el sector se abra hacia abajo/derecha adecuadamente
            float sweep = (float)Math.Min(v[1], 359.9);
            g.FillPie(brush, sq, -90f, sweep);
            g.DrawPie(pen,   sq, -90f, sweep);
        }
    }
}
