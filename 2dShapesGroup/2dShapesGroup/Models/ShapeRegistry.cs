using System.Collections.Generic;
using _2dShapesGroup.Interfaces;
using ShapesApp.Models.BasicPolygons;
using ShapesApp.Models.CurvedShapes;
using ShapesApp.Models.IrregularStars;
using ShapesApp.Models.SpecialShapes;

namespace _2dShapesGroup.Models
{
    // ════════════════════════════════════════════════════════════════════
    //  SHAPE REGISTRY
    //  Single Responsibility : only knows which shapes belong to each group.
    //  Open/Closed            : add a new group or shape here; no other class changes.
    //  Dependency Inversion   : returns IShape — callers never depend on concrete types.
    // ════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Central directory of all 20 shapes organized into 4 groups.
    /// The form layer calls <see cref="GetAll"/> to build menus and galleries
    /// without knowing any concrete shape type.
    /// </summary>
    public static class ShapeRegistry
    {
        // ── Group names ───────────────────────────────────────────────────
        public const string GroupBasicPolygons  = "Basic Polygons";
        public const string GroupCurvedShapes   = "Curved Shapes";
        public const string GroupIrregularStars = "Irregular / Stars";
        public const string GroupSpecialShapes  = "Special Shapes";

        // ── Registry ──────────────────────────────────────────────────────
        /// <summary>
        /// Returns an ordered dictionary:
        ///   key   → group display name
        ///   value → ordered list of shape instances for that group
        /// </summary>
        public static IReadOnlyDictionary<string, List<IShape>> GetAll()
        {
            // Using a plain Dictionary preserves insertion order in .NET 5+
            return new Dictionary<string, List<IShape>>
            {
                [GroupBasicPolygons] = new List<IShape>
                {
                    new Square(),
                    new RectangleShape(),
                    new Triangle(),
                    new Pentagon(),
                    new Hexagon(),
                    new Parallelogram(),
                    new Trapeze(),
                    new Rhombus()
                },

                [GroupCurvedShapes] = new List<IShape>
                {
                    new Circle(),
                    new Ellipse(),
                    new Semicircle(),
                    new Crescent()
                },

                [GroupIrregularStars] = new List<IShape>
                {
                    new Star(),
                    new Scalene(),
                    new Trefoil(),
                    new Cross(),
                    new Kite(),
                    new Pie()
                },

                [GroupSpecialShapes] = new List<IShape>
                {
                    new Octagon(),
                    new Heart(),
                    new Arrow(),
                    new Cloud()
                }
            };
        }
    }
}
