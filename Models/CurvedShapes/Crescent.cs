using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.CurvedShapes
{
    /// <summary>
    /// Una luna (semiluna) formada restando un círculo más pequeño de uno más grande,
    /// desplazado horizontalmente para crear la forma de media luna.
    /// Parámetros: radio exterior R, radio interior r (r &lt; R)
    /// Área ≈ π × (R² − r²) / 2  (aproximado para la media luna estándar)
    /// Perímetro ≈ π × (R + r)   (arco exterior + arco interior)
    /// Dibujo    : usa un GraphicsPath con AddEllipse para el círculo exterior y
    ///             el círculo interior desplazado, combinado con FillMode.Alternate
    ///             para recortar la región interior.
    /// </summary>
    public class Crescent : IShape
    {
        public string Name => "Crescent";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Outer radius R", 70.0), ("Inner radius r", 50.0) };

        public double Perimeter(double[] v) => Math.PI * (v[0] + v[1]);
        public double Area(double[] v) => Math.PI * (v[0] * v[0] - v[1] * v[1]) / 2;

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float R = (float)Math.Max(v[0], v[1] + 1);
            float r = (float)v[1];

            float side = Math.Min(b.Width, b.Height) - 24;
            float baseScale = side / (R * 2);

            // Size scale driven by the outer radius input: clamp to [10% – 100%] of available space
            float sizeScale = Math.Clamp((float)v[0] / 100f, 0.1f, 1f);
            float scale = baseScale * sizeScale;

            float cx = b.X + b.Width / 2f;
            float cy = b.Y + b.Height / 2f;

            // Cuadro delimitador del círculo exterior (centrado)
            RectangleF outer = new(cx - R * scale, cy - R * scale,
                                   R * 2 * scale, R * 2 * scale);

            // Círculo interior desplazado hacia la derecha para que la media luna se abra hacia la izquierda
            float offset = (R - r) * 0.95f * scale;
            RectangleF inner = new(cx - r * scale + offset, cy - r * scale,
                                   r * 2 * scale, r * 2 * scale);

            using var path  = new GraphicsPath(FillMode.Alternate);
            path.AddEllipse(outer);   // límite exterior
            path.AddEllipse(inner);   // recorte interior (el modo Alternate lo recorta)

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen = ShapeGraphics.CreateBorderPen();
            g.FillPath(brush, path);
            g.DrawPath(pen, path);
        }
    }
}
