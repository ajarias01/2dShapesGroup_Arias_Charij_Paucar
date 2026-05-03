using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.CurvedShapes
{
    /// <summary>
    /// Una curva cerrada perfectamente redonda con radio constante r.
    /// Parámetros: radio (r)
    /// Perímetro (circunferencia) = 2π × r
    /// Área                        = π × r²
    /// Dibujo: inscrito en un cuadrado relleno usando FillEllipse en un rectángulo cuadrado.
    /// </summary>
    public class Circle : IShape
    {
        public string Name => "Circle";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Radius (r)", 60.0) };

        public double Perimeter(double[] v) => 2 * Math.PI * v[0];
        public double Area(double[] v)      => Math.PI * v[0] * v[0];

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float radius = (float)v[0];
            float diameter = radius * 2;
            float x = b.X + (b.Width - diameter) / 2f;
            float y = b.Y + (b.Height - diameter) / 2f;
            RectangleF circle = new RectangleF(x, y, diameter, diameter);
            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillEllipse(brush, circle);
            g.DrawEllipse(pen, circle);
        }
    }
}
