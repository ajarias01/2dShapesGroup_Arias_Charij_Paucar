# Ejemplos de Implementación - Figuras Geométricas

## 📋 Plantilla Base

Todas las figuras siguen este patrón:

```csharp
public class NombreFigura : IInterfaceCorrespondiente
{
    // 1. Propiedades privadas para almacenar parámetros
    private double parameter1;
    private double parameter2;

    // 2. Propiedad Name
    public string Name => "Nombre Descriptivo";

    // 3. Obtener labels de entrada
    public List<string> GetInputLabels()
    {
        return new List<string> { "Etiqueta 1", "Etiqueta 2" };
    }

    // 4. Establecer parámetros desde el formulario
    public void SetParameters(double[] parameters)
    {
        if (parameters.Length < 2) throw new ArgumentException("Se requieren 2 parámetros");

        parameter1 = parameters[0];
        parameter2 = parameters[1];
    }

    // 5. Calcular perímetro
    public double CalculatePerimeter()
    {
        return 2 * (parameter1 + parameter2);
    }

    // 6. Calcular área
    public double CalculateArea()
    {
        return parameter1 * parameter2;
    }

    // 7. Dibujar la figura
    public void Draw(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, 
                     System.Drawing.Brush fillBrush, System.Drawing.Pen pen)
    {
        ShapeGraphicsHelper.ApplyHighQuality(g);

        // Ajustar bounds si es necesario
        Rectangle adjustedBounds = ShapeGraphicsHelper.FitCentered(bounds, 1f);

        // Crear ruta gráfica
        using (var path = new System.Drawing.Drawing2D.GraphicsPath())
        {
            // Dibujar la forma
            path.AddRectangle(adjustedBounds);

            // Aplicar relleno y contorno
            ShapeGraphicsHelper.FillAndStrokePath(g, path, fillBrush, pen);
        }
    }
}
```

---

## 🟦 Ejemplo 1: Square (Cuadrado)

```csharp
/// <summary>
/// Cuadrado: lado = lado
/// Perímetro = 4*a, Área = a²
/// </summary>
public class Square : IBasicPolygon
{
    private double side;

    public string Name => "Cuadrado";

    public List<string> GetInputLabels() => new List<string> { "Lado" };

    public void SetParameters(double[] parameters)
    {
        if (parameters.Length < 1) 
            throw new ArgumentException("Se requiere el lado");
        side = parameters[0];
    }

    public double CalculatePerimeter() => 4 * side;

    public double CalculateArea() => side * side;

    public void Draw(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, 
                     System.Drawing.Brush fillBrush, System.Drawing.Pen pen)
    {
        ShapeGraphicsHelper.ApplyHighQuality(g);

        // Ajustar a cuadrado
        Rectangle squareBounds = ShapeGraphicsHelper.FitSquare(bounds);

        // Dibujar cuadrado
        ShapeGraphicsHelper.FillAndStrokePath(g, 
            new System.Drawing.Drawing2D.GraphicsPath()
            {
                // Crear ruta
            },
            fillBrush, pen);

        // Alternativa más simple:
        g.FillRectangle(fillBrush, squareBounds);
        g.DrawRectangle(pen, squareBounds);
    }
}
```

---

## 🔺 Ejemplo 2: Triangle (Triángulo - Fórmula de Herón)

```csharp
/// <summary>
/// Triángulo: 3 lados
/// Perímetro = a+b+c
/// Área = √(s(s-a)(s-b)(s-c)) donde s = (a+b+c)/2 [Fórmula de Herón]
/// </summary>
public class Triangle : IBasicPolygon
{
    private double sideA, sideB, sideC;

    public string Name => "Triángulo";

    public List<string> GetInputLabels() => 
        new List<string> { "Lado A", "Lado B", "Lado C" };

    public void SetParameters(double[] parameters)
    {
        if (parameters.Length < 3) 
            throw new ArgumentException("Se requieren 3 lados");

        sideA = parameters[0];
        sideB = parameters[1];
        sideC = parameters[2];

        // Validar desigualdad triangular
        if (sideA + sideB <= sideC || 
            sideB + sideC <= sideA || 
            sideC + sideA <= sideB)
            throw new ArgumentException("Lados no forman un triángulo válido");
    }

    public double CalculatePerimeter() => sideA + sideB + sideC;

    public double CalculateArea()
    {
        // Fórmula de Herón
        double s = (sideA + sideB + sideC) / 2;
        double area = Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
        return area;
    }

    public void Draw(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, 
                     System.Drawing.Brush fillBrush, System.Drawing.Pen pen)
    {
        ShapeGraphicsHelper.ApplyHighQuality(g);

        Rectangle adjustedBounds = ShapeGraphicsHelper.FitSquare(bounds);

        // Calcular puntos del triángulo
        int x = adjustedBounds.X + adjustedBounds.Width / 2;
        int y = adjustedBounds.Y + adjustedBounds.Height / 2;
        int halfWidth = adjustedBounds.Width / 2;
        int halfHeight = adjustedBounds.Height / 2;

        System.Drawing.Point[] points = new[]
        {
            new System.Drawing.Point(x, y - halfHeight),           // Arriba
            new System.Drawing.Point(x + halfWidth, y + halfHeight), // Abajo derecha
            new System.Drawing.Point(x - halfWidth, y + halfHeight)  // Abajo izquierda
        };

        g.FillPolygon(fillBrush, points);
        g.DrawPolygon(pen, points);
    }
}
```

---

## ⭕ Ejemplo 3: Circle (Círculo)

```csharp
/// <summary>
/// Círculo: radio constante
/// Perímetro = 2πr (circunferencia)
/// Área = πr²
/// </summary>
public class Circle : ICurvedShape
{
    private double radius;

    public string Name => "Círculo";

    public List<string> GetInputLabels() => new List<string> { "Radio" };

    public void SetParameters(double[] parameters)
    {
        if (parameters.Length < 1) 
            throw new ArgumentException("Se requiere el radio");
        radius = parameters[0];
    }

    public double CalculatePerimeter() => 2 * Math.PI * radius;

    public double CalculateArea() => Math.PI * radius * radius;

    public void Draw(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, 
                     System.Drawing.Brush fillBrush, System.Drawing.Pen pen)
    {
        ShapeGraphicsHelper.ApplyHighQuality(g);

        // Ajustar a cuadrado (el círculo debe estar dentro de un cuadrado)
        Rectangle circleBounds = ShapeGraphicsHelper.FitSquare(bounds);

        // Dibujar círculo
        g.FillEllipse(fillBrush, circleBounds);
        g.DrawEllipse(pen, circleBounds);
    }
}
```

---

## ⬭ Ejemplo 4: Ellipse (Elipse - Ramanujan)

```csharp
/// <summary>
/// Elipse: dos semi-ejes
/// Perímetro ≈ π(a+b)(1+3h/(10+√(4-3h))) [Aproximación de Ramanujan]
///   donde h = ((a-b)/(a+b))²
/// Área = πab
/// </summary>
public class Ellipse : ICurvedShape
{
    private double semiMajor;  // a: semi-eje mayor
    private double semiMinor;  // b: semi-eje menor

    public string Name => "Elipse";

    public List<string> GetInputLabels() => 
        new List<string> { "Semi-eje Mayor", "Semi-eje Menor" };

    public void SetParameters(double[] parameters)
    {
        if (parameters.Length < 2) 
            throw new ArgumentException("Se requieren 2 semi-ejes");

        semiMajor = parameters[0];
        semiMinor = parameters[1];

        // El mayor debe ser >= al menor
        if (semiMajor < semiMinor)
            (semiMajor, semiMinor) = (semiMinor, semiMajor);
    }

    public double CalculatePerimeter()
    {
        // Aproximación de Ramanujan para perímetro de elipse
        double a = semiMajor;
        double b = semiMinor;

        double h = Math.Pow((a - b) / (a + b), 2);
        double perimeter = Math.PI * (a + b) * (1 + 3 * h / (10 + Math.Sqrt(4 - 3 * h)));

        return perimeter;
    }

    public double CalculateArea() => Math.PI * semiMajor * semiMinor;

    public void Draw(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, 
                     System.Drawing.Brush fillBrush, System.Drawing.Pen pen)
    {
        ShapeGraphicsHelper.ApplyHighQuality(g);

        // La elipse se ajusta al rectángulo disponible
        Rectangle ellipseBounds = ShapeGraphicsHelper.FitCentered(bounds, 
            (float)semiMajor / semiMinor);

        g.FillEllipse(fillBrush, ellipseBounds);
        g.DrawEllipse(pen, ellipseBounds);
    }
}
```

---

## ⭐ Ejemplo 5: Star (Estrella - n Puntas)

```csharp
/// <summary>
/// Estrella: n puntas con radios exterior e interior
/// Perímetro: suma de lados de las puntas
/// Área: cálculo mediante triángulos
/// </summary>
public class Star : IIrregularShape
{
    private int points = 5;         // Número de puntas
    private double radiusOuter;     // Radio exterior
    private double radiusInner;     // Radio interior

    public string Name => "Estrella";

    public List<string> GetInputLabels() => 
        new List<string> { "Puntas (3-12)", "Radio Exterior", "Radio Interior" };

    public void SetParameters(double[] parameters)
    {
        if (parameters.Length < 3) 
            throw new ArgumentException("Se requieren 3 parámetros");

        points = (int)parameters[0];
        radiusOuter = parameters[1];
        radiusInner = parameters[2];

        if (points < 3 || points > 12)
            throw new ArgumentException("Las puntas deben estar entre 3 y 12");

        if (radiusInner >= radiusOuter)
            throw new ArgumentException("Radio interior debe ser menor que exterior");
    }

    public double CalculatePerimeter()
    {
        // Simplificación: aproximar como suma de lados
        double angleIncrement = Math.PI / points;
        double perimeter = 0;

        for (int i = 0; i < points * 2; i++)
        {
            double angle1 = i * angleIncrement;
            double angle2 = (i + 1) * angleIncrement;

            double r1 = (i % 2 == 0) ? radiusOuter : radiusInner;
            double r2 = ((i + 1) % 2 == 0) ? radiusOuter : radiusInner;

            double x1 = r1 * Math.Cos(angle1);
            double y1 = r1 * Math.Sin(angle1);
            double x2 = r2 * Math.Cos(angle2);
            double y2 = r2 * Math.Sin(angle2);

            perimeter += Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        return perimeter;
    }

    public double CalculateArea()
    {
        // Aproximar como suma de triángulos
        double angleIncrement = Math.PI / points;
        double area = 0;

        for (int i = 0; i < points * 2; i++)
        {
            double r = (i % 2 == 0) ? radiusOuter : radiusInner;
            double angle = i * angleIncrement;
            double nextAngle = (i + 1) * angleIncrement;

            // Área de sector de círculo
            area += 0.5 * r * r * (nextAngle - angle);
        }

        return area;
    }

    public void Draw(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, 
                     System.Drawing.Brush fillBrush, System.Drawing.Pen pen)
    {
        ShapeGraphicsHelper.ApplyHighQuality(g);

        Rectangle squareBounds = ShapeGraphicsHelper.FitSquare(bounds);
        int centerX = squareBounds.X + squareBounds.Width / 2;
        int centerY = squareBounds.Y + squareBounds.Height / 2;

        System.Drawing.Point[] starPoints = new System.Drawing.Point[points * 2];
        double angleIncrement = Math.PI / points;

        for (int i = 0; i < points * 2; i++)
        {
            double angle = i * angleIncrement - Math.PI / 2;
            double radius = (i % 2 == 0) ? radiusOuter : radiusInner;

            // Escalar al tamaño del bounds
            double scaledRadius = radius / radiusOuter * (squareBounds.Width / 2);

            int x = (int)(centerX + scaledRadius * Math.Cos(angle));
            int y = (int)(centerY + scaledRadius * Math.Sin(angle));

            starPoints[i] = new System.Drawing.Point(x, y);
        }

        g.FillPolygon(fillBrush, starPoints);
        g.DrawPolygon(pen, starPoints);
    }
}
```

---

## 🔷 Ejemplo 6: Pentagon (Pentágono Regular)

```csharp
/// <summary>
/// Pentágono regular: 5 lados iguales
/// Perímetro = 5 * lado
/// Área = (5 * lado²) / (4 * tan(π/5))
/// </summary>
public class Pentagon : ISpecialShape
{
    private double side;

    public string Name => "Pentágono";

    public List<string> GetInputLabels() => new List<string> { "Lado" };

    public void SetParameters(double[] parameters)
    {
        if (parameters.Length < 1) 
            throw new ArgumentException("Se requiere el lado");
        side = parameters[0];
    }

    public double CalculatePerimeter() => 5 * side;

    public double CalculateArea()
    {
        // Fórmula: A = (5 * a²) / (4 * tan(π/5))
        return (5 * side * side) / (4 * Math.Tan(Math.PI / 5));
    }

    public void Draw(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, 
                     System.Drawing.Brush fillBrush, System.Drawing.Pen pen)
    {
        ShapeGraphicsHelper.ApplyHighQuality(g);

        Rectangle squareBounds = ShapeGraphicsHelper.FitSquare(bounds);
        int centerX = squareBounds.X + squareBounds.Width / 2;
        int centerY = squareBounds.Y + squareBounds.Height / 2;
        double radius = squareBounds.Width / 2;

        System.Drawing.Point[] pentagonPoints = new System.Drawing.Point[5];

        for (int i = 0; i < 5; i++)
        {
            double angle = 2 * Math.PI * i / 5 - Math.PI / 2;
            int x = (int)(centerX + radius * Math.Cos(angle));
            int y = (int)(centerY + radius * Math.Sin(angle));
            pentagonPoints[i] = new System.Drawing.Point(x, y);
        }

        g.FillPolygon(fillBrush, pentagonPoints);
        g.DrawPolygon(pen, pentagonPoints);
    }
}
```

---

## 💗 Ejemplo 7: Heart (Corazón - Bézier Simplificado)

```csharp
/// <summary>
/// Corazón: Usando curvas Bézier
/// Perímetro y Área: Cálculo numérico aproximado
/// </summary>
public class Heart : ISpecialShape
{
    private double size;

    public string Name => "Corazón";

    public List<string> GetInputLabels() => new List<string> { "Tamaño" };

    public void SetParameters(double[] parameters)
    {
        if (parameters.Length < 1) 
            throw new ArgumentException("Se requiere el tamaño");
        size = parameters[0];
    }

    public double CalculatePerimeter()
    {
        // Aproximación numérica
        return size * 12;
    }

    public double CalculateArea()
    {
        // Aproximación numérica
        return size * size * 0.6;
    }

    public void Draw(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, 
                     System.Drawing.Brush fillBrush, System.Drawing.Pen pen)
    {
        ShapeGraphicsHelper.ApplyHighQuality(g);

        Rectangle squareBounds = ShapeGraphicsHelper.FitSquare(bounds);

        using (var path = new System.Drawing.Drawing2D.GraphicsPath())
        {
            int cx = squareBounds.X + squareBounds.Width / 2;
            int cy = squareBounds.Y + squareBounds.Height / 2;
            int w = squareBounds.Width;
            int h = squareBounds.Height;

            // Dibujar corazón simplificado (dos círculos + triángulo)
            // Semicírculo superior izquierdo
            path.AddArc(cx - w/4 - w/8, cy - h/4, w/4, h/4, 0, 180);

            // Semicírculo superior derecho
            path.AddArc(cx + w/8, cy - h/4, w/4, h/4, 0, 180);

            // Línea a la punta inferior
            path.AddLine(cx + w/8 + w/8, cy + h/4, cx, cy + h/2);

            // Línea de vuelta
            path.AddLine(cx, cy + h/2, cx - w/8 - w/8, cy + h/4);

            path.CloseFigure();

            ShapeGraphicsHelper.FillAndStrokePath(g, path, fillBrush, pen);
        }
    }
}
```

---

## 📝 Notas Importantes

1. **Validación de Parámetros**: Siempre validar que sean positivos y válidos
2. **Fórmulas Matemáticas**: Usar `Math` namespace para operaciones
3. **Dibujo**: Usar `ShapeGraphicsHelper` para consistencia
4. **Rendimiento**: Cachear cálculos complejos si es necesario
5. **Escalado**: Considerar el bounds al dibujar para adaptabilidad
6. **Antialiasing**: Siempre llamar a `ApplyHighQuality(g)`

## ✅ Checklist para Nueva Figura

- [ ] Crear clase en archivo correspondiente
- [ ] Heredar de interfaz correcta (IBasicPolygon, etc.)
- [ ] Implementar Name propiedad
- [ ] Implementar GetInputLabels()
- [ ] Implementar SetParameters() con validación
- [ ] Implementar CalculatePerimeter()
- [ ] Implementar CalculateArea()
- [ ] Implementar Draw() con ShapeGraphicsHelper
- [ ] Registrar en ShapeRegistry.cs
- [ ] Probar entrada de datos
- [ ] Probar cálculos
- [ ] Probar visualización
