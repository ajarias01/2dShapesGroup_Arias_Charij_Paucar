using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.SpecialShapes
{
    /// <summary>
    /// Una forma de corazón construida a partir de dos arcos cúbicos de Bézier.
    /// Parámetros: tamaño (factor de escala)
    /// Área      ≈ (13π/2) × r²   para un cardioide unitario; escalado aproximadamente aquí.
    /// Perímetro ≈ 8√2 × r        (longitud de arco aproximada).
    /// Dibujo   : GraphicsPath usando AddBezier para los dos lóbulos.
    ///            La ruta se normaliza a un cuadrado unitario y se escala para ajustarse.
    /// </summary>
    public class Heart : IShape
    {
        public string Name => "Heart";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Size (s)", 80.0) };

        public double Perimeter(double[] v) => 8 * Math.Sqrt(2) * v[0] / 80.0 * 60;
        public double Area(double[] v)      => Math.PI * 0.5 * (v[0] / 80.0) * (v[0] / 80.0) * 5000;

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float size = (float)v[0];
            float padding = 12f;
            float availableSize = Math.Min(b.Width, b.Height) - padding * 2;

            // Scale size to fit within available space
            float scale = Math.Min(size / 100f, availableSize / 200f);
            float cx    = b.X + b.Width  / 2f;
            float cy    = b.Y + b.Height / 2f;

            // Corazón definido en coordenadas lógicas (centrado en 0,0):
            //   arriba     = (0,  -90)
            //   punta-derecha del lóbulo derecho = (100, -60)
            //   abajo  = (0,   90)
            //   punta-izquierda del lóbulo izquierdo   = (-100, -60)
            // Lo construimos con dos arcos de Bézier:

            using var path = new GraphicsPath();

            PointF T(float x, float y) => new(cx + x * scale, cy + y * scale);

            // Lóbulo derecho (arriba → punta-derecha → abajo)
            path.AddBezier(
                T(0, -40),      // inicio: centro-superior (la depresión)
                T(100, -90),    // control 1
                T(130, 40),     // control 2
                T(0, 90)        // fin: punta inferior
            );

            // Lóbulo izquierdo (abajo → punta-izquierda → arriba)
            path.AddBezier(
                T(0, 90),       // inicio: punta inferior
                T(-130, 40),    // control 1
                T(-100, -90),   // control 2
                T(0, -40)       // fin: centro-superior
            );

            path.CloseFigure();

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillPath(brush, path);
            g.DrawPath(pen,   path);
        }
    }
}
