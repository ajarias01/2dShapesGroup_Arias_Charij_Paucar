using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.IrregularStars
{
    /// <summary>
    /// Una cruz en forma de signo más con brazos iguales.
    /// Parámetros: longitud del brazo (a), ancho del brazo (w)
    /// La cruz se compone de dos rectángulos superpuestos:
    ///   horizontal: ancho = a*2+w, alto = w
    ///   vertical  : ancho = w, alto = a*2+w
    /// Perímetro = 4 × (a + w) × 2 / … simplificado a 12 × a + 4 × w   (contorno exterior)
    ///           = 4 × (parte_superior_brazo_exterior + parte_lateral_brazo_exterior) × 2 — perímetro de cruz estándar
    ///           En realidad: perímetro = 4 × a × 2 + ... el perímetro del polígono de 12 segmentos:
    ///           = 4 × (2a + w) + 4 × w = 8a + 8w   → pero típicamente: 12a si w=a
    ///           Fórmula simple: Perímetro = 4 × (3a)  cuando w = a.
    ///           General: P = 4 × (a + w) × ... almacenamos 12 bordes exteriores de longitud a cada uno.
    ///           Resultado estándar: P = 12a + 4w  — No. Versión limpia:
    ///           El polígono de 12 lados: 4 bordes de longitud a y 4 de longitud w, pero hay
    ///           en realidad 12 bordes totales: alternando a y (a-w)/2... complicado.
    ///           Usamos la aproximación más simple: P = 4 × (ancho_exterior + alto_exterior - esquina_interior×8)
    ///           Para una cruz con brazos iguales: P = 12 × longitud_brazo.
    /// Área      = a × w × 2 + w × w  (dos rectángulos menos el centro contado dos veces)
    ///           = w × (2a + w)  → fórmula completa = 2 × a × w + w²
    /// Dibujo   : GraphicsPath con 12 vértices formando el contorno de la cruz.
    /// </summary>
    public class Cross : IShape
    {
        public string Name => "Cross";
        public IReadOnlyList<(string Label, double DefaultValue)> Parameters =>
            new[] { ("Arm length (a)", 50.0), ("Arm width (w)", 30.0) };

        // Perimeter of the 12-sided cross outline
        public double Perimeter(double[] v) => 4 * (2 * v[0] + v[1]);

        // Area = 2 rectangles (a×w + w×a) + center square (w×w) minus center counted twice
        // = 2 × (a × w) + w²   but since the vertical arm already contains the center:
        // Area = horizontal_rect_area + vertical_rect_area - center_square_area
        //      = (2a+w)×w + (2a+w)×w - w×w  ... wrong because center is shared.
        // Correct: Area = 2 × (arm_length × arm_width) + arm_width²
        public double Area(double[] v) => 2 * v[0] * v[1] + v[1] * v[1];

        public void Draw(G g, RectangleF b, double[] v)
        {
            ShapeGraphics.EnableAntiAlias(g);
            float a = (float)v[0], w = (float)v[1];
            float total = 2 * a + w;   // full extent in both directions

            float padding = 12f;
            float sq   = Math.Min(b.Width, b.Height) - padding * 2;
            float scale = sq / total;
            float a_s  = a * scale;
            float w_s  = w * scale;

            float cx = b.X + b.Width  / 2f;
            float cy = b.Y + b.Height / 2f;
            float half = w_s / 2f;
            float arm  = a_s;

            // 12 vértices de la cruz, comenzando en la esquina superior-izquierda y avanzando en sentido de las agujas del reloj
            PointF[] pts =
            {
                new(cx - half,        cy - half - arm),   // superior-izquierda del brazo superior
                new(cx + half,        cy - half - arm),   // superior-derecha del brazo superior
                new(cx + half,        cy - half),          // interior superior-derecha
                new(cx + half + arm,  cy - half),          // brazo-derecha superior-izquierda
                new(cx + half + arm,  cy + half),          // brazo-derecha inferior-izquierda
                new(cx + half,        cy + half),          // interior inferior-derecha
                new(cx + half,        cy + half + arm),    // brazo-inferior superior-derecha
                new(cx - half,        cy + half + arm),    // brazo-inferior superior-izquierda
                new(cx - half,        cy + half),          // interior inferior-izquierda
                new(cx - half - arm,  cy + half),          // brazo-izquierda inferior-derecha
                new(cx - half - arm,  cy - half),          // brazo-izquierda superior-derecha
                new(cx - half,        cy - half),           // interior superior-izquierda
            };

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillPolygon(brush, pts);
            g.DrawPolygon(pen, pts);
        }
    }
}
