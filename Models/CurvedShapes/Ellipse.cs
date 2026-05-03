using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.CurvedShapes
{
    /// <summary>
    /// Un óvalo definido por semiejes a (horizontal) y b (vertical).
    /// Parámetros: semieje a, semieje b
    /// Perímetro ≈ π × [3(a+b) − √((3a+b)(a+3b))]  (aproximación de Ramanujan)
    /// Área      = π × a × b
    /// Dibujo   : rectángulo delimitador escalado por la relación a:b, luego elipse inscrita.
    /// </summary>
    public class Ellipse : IShape
    {
        public string Name => "Ellipse";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Semi-axis a", 90.0), ("Semi-axis b", 50.0) };

        public double Perimeter(double[] v)
        {
            double a = v[0], b = v[1];
            // Ramanujan approximation: π × [3(a+b) − √((3a+b)(a+3b))]
            return Math.PI * (3 * (a + b) - Math.Sqrt((3 * a + b) * (a + 3 * b)));
        }
        public double Area(double[] v) => Math.PI * v[0] * v[1];

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            RectangleF r = ShapeGraphics.PaddedRect(b, (float)v[0] * 2, (float)v[1] * 2);
            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillEllipse(brush, r);
            g.DrawEllipse(pen, r);
        }
    }
}
