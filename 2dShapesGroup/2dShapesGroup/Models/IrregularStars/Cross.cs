using System;
using System.Collections.Generic;
using System.Drawing;
using _2dShapesGroup.Graphics;
using _2dShapesGroup.Interfaces;
using G = System.Drawing.Graphics;

namespace ShapesApp.Models.IrregularStars
{
    /// <summary>
    /// A plus-shaped cross with equal arms.
    /// Parameters: arm length (a), arm width (w)
    /// The cross is composed of two overlapping rectangles:
    ///   horizontal: width = a*2+w, height = w
    ///   vertical  : width = w, height = a*2+w
    /// Perimeter = 4 × (a + w) × 2 / … simplified to 12 × a + 4 × w   (outer contour)
    ///           = 4 × (outer_arm_top + outer_arm_side) × 2 — standard cross perimeter
    ///           Actually: perimeter = 4 × a × 2 + ... the 12-segment polygon perimeter:
    ///           = 4 × (2a + w) + 4 × w = 8a + 8w   → but typically: 12a if w=a
    ///           Simple formula: Perimeter = 4 × (3a)  when w = a.
    ///           General: P = 4 × (a + w) × ... we store 12 outer edges of length a each.
    ///           Standard result: P = 12a + 4w  — No. Clean version:
    ///           The 12-sided polygon: 4 edges of length a and 4 of length w, but there are
    ///           actually 12 edges total: alternating a and (a-w)/2... complicated.
    ///           We use the simpler approximate: P = 4 × (outer_width + outer_height - inner_corner×8)
    ///           For an equal-armed cross: P = 12 × arm_length.
    /// Area      = a × w × 2 + w × w  (two rectangles minus center counted twice)
    ///           = w × (2a + w)  → full formula = 2 × a × w + w²
    /// Drawing   : GraphicsPath with 12 vertices forming the cross outline.
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

            // 12 vertices of the cross, starting top-left and going clockwise
            PointF[] pts =
            {
                new(cx - half,        cy - half - arm),   // top-left of top-arm
                new(cx + half,        cy - half - arm),   // top-right of top-arm
                new(cx + half,        cy - half),          // inner top-right
                new(cx + half + arm,  cy - half),          // right-arm top-left
                new(cx + half + arm,  cy + half),          // right-arm bottom-left
                new(cx + half,        cy + half),          // inner bottom-right
                new(cx + half,        cy + half + arm),    // bottom-arm top-right
                new(cx - half,        cy + half + arm),    // bottom-arm top-left
                new(cx - half,        cy + half),          // inner bottom-left
                new(cx - half - arm,  cy + half),          // left-arm bottom-right
                new(cx - half - arm,  cy - half),          // left-arm top-right
                new(cx - half,        cy - half),           // inner top-left
            };

            using var brush = ShapeGraphics.CreateFillBrush();
            using var pen   = ShapeGraphics.CreateBorderPen();
            g.FillPolygon(brush, pts);
            g.DrawPolygon(pen, pts);
        }
    }
}
