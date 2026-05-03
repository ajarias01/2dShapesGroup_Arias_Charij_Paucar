using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.BasicPolygons
{
    /// <summary>
    /// Un polígono regular de 6 lados.
    /// Parámetros: longitud del lado (a)
    /// Perímetro = 6 × a
    /// Área      = (3√3 / 2) × a²
    /// Dibujo   : 6 vértices en un círculo, orientación plana (rotado 30°).
    /// </summary>
    public class Hexagon : IShape
    {
        public string Name => "Hexagon";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Side (a)", 70.0) };

        public double Perimeter(double[] v) => 6 * v[0];
        public double Area(double[] v)      => 3 * Math.Sqrt(3) / 2 * v[0] * v[0];

        public void Draw(G g, RectangleF b, double[] v)
            => PolygonHelper.DrawRegularPolygon(g, b, 6, v[0]);
    }
}
