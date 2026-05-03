using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.BasicPolygons
{
    /// <summary>
    /// Un cuadrilátero regular con cuatro lados iguales.
    /// Parámetros: lado (a)
    /// Perímetro = 4 × a
    /// Área      = a²
    /// Dibujo   : cuadrado alineado con los ejes centrado en el panel.
    /// </summary>
    public class Square : IShape
    {
        public string Name => "Square";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Side (a)", 80.0) };

        public double Perimeter(double[] v) => 4 * v[0];
        public double Area(double[] v)      => v[0] * v[0];

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float side = (float)v[0];
            float padding = 12f;
            float availableSize = Math.Min(b.Width, b.Height) - padding * 2;

            // Limita el lado para que quepa dentro del espacio disponible
            float sideScaled = Math.Min(side, availableSize);

            float x = b.X + (b.Width - sideScaled) / 2f;
            float y = b.Y + (b.Height - sideScaled) / 2f;

            RectangleF r = new RectangleF(x, y, sideScaled, sideScaled);

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillRectangle(brush, r);
            g.DrawRectangle(pen, r.X, r.Y, r.Width, r.Height);
        }
    }
}
