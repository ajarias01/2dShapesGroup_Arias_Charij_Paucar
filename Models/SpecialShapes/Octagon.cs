using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using ShapesApp.Models.BasicPolygons;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.SpecialShapes
{
    /// <summary>
    /// Un polígono regular de 8 lados.
    /// Parámetros: longitud del lado (a)
    /// Perímetro = 8 × a
    /// Área      = 2(1 + √2) × a²
    /// Dibujo   : 8 vértices en un círculo, orientación plana (rotado π/8).
    /// </summary>
    public class Octagon : IShape
    {
        public string Name => "Octagon";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Side (a)", 60.0) };

        public double Perimeter(double[] v) => 8 * v[0];
        public double Area(double[] v)      => 2 * (1 + Math.Sqrt(2)) * v[0] * v[0];

        public void Draw(G g, RectangleF b, double[] v)
            => PolygonHelper.DrawRegularPolygon(g, b, 8, v[0]);
    }
}
