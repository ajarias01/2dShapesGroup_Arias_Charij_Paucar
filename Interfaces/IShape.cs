using System.Collections.Generic;
using System.Drawing;

namespace _2dShapesGroup.Interfaces
{
    /// <summary>
    /// Contract that every 2-D shape must fulfill.
    /// Single Responsibility: defines the minimum surface for a drawable, measurable shape.
    /// Open/Closed: new shapes extend this interface without modifying existing code.
    /// </summary>
    public interface IShape
    {
        // ── Identity ─────────────────────────────────────────────────────
        /// <summary>Human-readable name shown in the UI.</summary>
        string Name { get; }

        // ── Parameters ───────────────────────────────────────────────────
        /// <summary>
        /// Ordered list of input descriptors (label + default value).
        /// The form builds its text-boxes dynamically from this list.
        /// Example: [("Width (a)", 80), ("Height (b)", 50)]
        /// </summary>
        IReadOnlyList<(string Label, double DefaultValue)> Parameters { get; }

        // ── Math ─────────────────────────────────────────────────────────
        /// <summary>Calculates the perimeter given the current parameter values.</summary>
        double Perimeter(double[] values);

        /// <summary>Calculates the area given the current parameter values.</summary>
        double Area(double[] values);

        // ── Drawing ──────────────────────────────────────────────────────
        /// <summary>
        /// Draws the shape inside <paramref name="bounds"/> using the supplied graphics context.
        /// Implementations must scale the figure to fit the available rectangle.
        /// </summary>
        void Draw(System.Drawing.Graphics g, RectangleF bounds, double[] values);
    }
}
