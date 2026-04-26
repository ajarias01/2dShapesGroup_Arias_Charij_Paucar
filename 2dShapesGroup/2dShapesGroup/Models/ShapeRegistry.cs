using System;
using System.Collections.Generic;
using _2dShapesGroup.Interfaces;
using _2dShapesGroup.Models;

namespace _2dShapesGroup.Models
{
    /// <summary>
    /// Registro centralizado de todas las figuras disponibles.
    /// Agregar una nueva figura solo requiere:
    /// 1. Crear la clase que implemente IShape
    /// 2. Registrarla aquí en el constructor
    /// </summary>
    public static class ShapeRegistry
    {
        private static Dictionary<string, Func<IShape>> _shapes = new();

        static ShapeRegistry()
        {
            // Basic Polygons
            _shapes["Cuadrado"] = () => new Square();
            _shapes["Rectángulo"] = () => new Rectangle();
            _shapes["Triángulo"] = () => new Triangle();
            _shapes["Paralelogramo"] = () => new Parallelogram();
            _shapes["Trapecio"] = () => new Trapeze();

            // Curved Shapes
            _shapes["Círculo"] = () => new Circle();
            _shapes["Elipse"] = () => new Ellipse();
            _shapes["Semicírculo"] = () => new Semicircle();
            _shapes["Media Luna"] = () => new Crescent();

            // Irregular Shapes
            _shapes["Estrella"] = () => new Star();
            _shapes["Triángulo Escaleno"] = () => new Scalene();
            _shapes["Cometa"] = () => new Kite();
            _shapes["Cruz"] = () => new Cross();

            // Special Shapes
            _shapes["Pentágono"] = () => new Pentagon();
            _shapes["Hexágono"] = () => new Hexagon();
            _shapes["Octágono"] = () => new Octagon();
            _shapes["Rombo"] = () => new Rhombus();
            _shapes["Sector Circular"] = () => new PieSector();
            _shapes["Trébol"] = () => new Trefoil();
            _shapes["Corazón"] = () => new Heart();
        }

        /// <summary>
        /// Obtiene una instancia de una figura por nombre.
        /// </summary>
        public static IShape GetShape(string name)
        {
            if (_shapes.TryGetValue(name, out var factory))
                return factory();

            throw new ArgumentException($"Forma no encontrada: {name}");
        }

        /// <summary>
        /// Obtiene los nombres de todas las figuras registradas.
        /// </summary>
        public static IEnumerable<string> GetAllShapeNames()
        {
            return _shapes.Keys;
        }

        /// <summary>
        /// Obtiene todas las figuras de un grupo específico.
        /// </summary>
        public static IEnumerable<string> GetShapesByGroup(ShapeGroup group)
        {
            var shapes = new List<string>();

            switch (group)
            {
                case ShapeGroup.BasicPolygons:
                    shapes.AddRange(new[] { "Cuadrado", "Rectángulo", "Triángulo", "Paralelogramo", "Trapecio" });
                    break;

                case ShapeGroup.CurvedShapes:
                    shapes.AddRange(new[] { "Círculo", "Elipse", "Semicírculo", "Media Luna" });
                    break;

                case ShapeGroup.IrregularShapes:
                    shapes.AddRange(new[] { "Estrella", "Triángulo Escaleno", "Cometa", "Cruz" });
                    break;

                case ShapeGroup.SpecialShapes:
                    shapes.AddRange(new[] { "Pentágono", "Hexágono", "Octágono", "Rombo", "Sector Circular", "Trébol", "Corazón" });
                    break;
            }

            return shapes;
        }
    }

    /// <summary>
    /// Enumeración de grupos de figuras.
    /// </summary>
    public enum ShapeGroup
    {
        BasicPolygons,
        CurvedShapes,
        IrregularShapes,
        SpecialShapes
    }
}
