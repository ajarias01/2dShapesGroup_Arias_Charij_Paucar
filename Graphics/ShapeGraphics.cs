using System.Drawing;
using System.Drawing.Drawing2D;

namespace _2dShapesGroup.Graphics
{
    /// <summary>
    /// Centralizes all GDI+ resources (brushes, pens, fonts) used when drawing shapes.
    /// Single Responsibility: resource creation and disposal only — no shape logic here.
    /// Open/Closed: add new palettes without touching shape classes.
    /// </summary>
    public static class ShapeGraphics
    {
        // ── Palette ──────────────────────────────────────────────────────
        /// <summary>Primary fill color for every shape.</summary>
        public static readonly Color FillColor   = Color.FromArgb(70, 130, 210);   // blue
        /// <summary>Secondary / accent color (stars, trefoil, etc.).</summary>
        public static readonly Color AccentColor = Color.FromArgb(220, 80, 80);    // red
        /// <summary>Outline color.</summary>
        public static readonly Color BorderColor = Color.FromArgb(30, 60, 130);

        // ── Factory methods ───────────────────────────────────────────────
        /// <summary>Returns a solid fill brush. Caller must dispose.</summary>
        public static SolidBrush CreateFillBrush()
            => new SolidBrush(FillColor);

        /// <summary>Returns an accent fill brush. Caller must dispose.</summary>
        public static SolidBrush CreateAccentBrush()
            => new SolidBrush(AccentColor);

        /// <summary>Returns the standard outline pen (2 px). Caller must dispose.</summary>
        public static Pen CreateBorderPen()
            => new Pen(BorderColor, 2f) { LineJoin = LineJoin.Round };

        /// <summary>Returns a thinner outline pen (1 px). Caller must dispose.</summary>
        public static Pen CreateThinPen()
            => new Pen(BorderColor, 1f);

        // ── Rendering helpers ─────────────────────────────────────────────
        /// <summary>
        /// Applies anti-aliasing to the supplied <see cref="System.Drawing.Graphics"/> context
        /// and returns the previous smoothing mode so the caller can restore it if needed.
        /// </summary>
        public static SmoothingMode EnableAntiAlias(System.Drawing.Graphics g)
        {
            var previous = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            return previous;
        }

        /// <summary>
        /// Computes a centered, square sub-rectangle inside <paramref name="bounds"/>
        /// with optional padding so shapes never touch the panel edges.
        /// </summary>
        public static RectangleF PaddedSquare(RectangleF bounds, float inputSize = 100f, float padding = 12f)
        {
            float side = System.Math.Min(bounds.Width, bounds.Height) - padding * 2;
            if (side < 4) side = 4;
            
            // Adjust size based on input size, but constrain to a min and max scale
            float scale = Math.Clamp(inputSize / 100f, 0.1f, 1f); 
            side *= scale;

            float x = bounds.X + (bounds.Width  - side) / 2f;
            float y = bounds.Y + (bounds.Height - side) / 2f;
            return new RectangleF(x, y, side, side);
        }

        /// <summary>
        /// Computes a centered rectangle that respects an aspect ratio
        /// defined by <paramref name="w"/> × <paramref name="h"/>.
        /// </summary>
        public static RectangleF PaddedRect(RectangleF bounds,
                                            float w, float h,
                                            float inputSize = 100f,
                                            float padding = 12f)
        {
            float availW = bounds.Width  - padding * 2;
            float availH = bounds.Height - padding * 2;
            float scale  = System.Math.Min(availW / w, availH / h);
            
            // Adjust based on input size. If size is large, ensure we don't exceed max bound scale
            float sizeScale = Math.Clamp(inputSize / 100f, 0.1f, 1f);

            float fw = w * scale * sizeScale;
            float fh = h * scale * sizeScale;
            float x = bounds.X + (bounds.Width  - fw) / 2f;
            float y = bounds.Y + (bounds.Height - fh) / 2f;
            return new RectangleF(x, y, fw, fh);
        }
    }
}
