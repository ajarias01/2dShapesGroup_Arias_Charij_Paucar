# 2D Shapes Group - Estructura del Proyecto

## 📋 Descripción General

Proyecto WinForms .NET 10 que implementa un sistema universal para el cálculo y visualización de 20 figuras geométricas 2D, organizadas en 4 grupos principales con soporte para cálculo de perímetro, área, y dibujo personalizado.

## 🏗️ Estructura del Proyecto

### Carpeta: **Interfaces/**

**IShape.cs**
- Contrato base para todas las figuras
- Métodos: `GetInputLabels()`, `SetParameters()`, `CalculatePerimeter()`, `CalculateArea()`, `Draw()`
- Propiedad: `Name`

**IShapeGroups.cs**
- 4 interfaces específicas por grupo:
  - `IBasicPolygon` - Polígonos básicos (5 figuras)
  - `ICurvedShape` - Formas curvas (4 figuras)
  - `IIrregularShape` - Formas irregulares (4 figuras)
  - `ISpecialShape` - Formas especiales (7 figuras)
- Comentarios extensos sobre la lógica matemática de cada grupo

### Carpeta: **Graphics/**

**ShapeGraphicsHelper.cs**
- Fábrica centralizada de componentes gráficos:
  - `CreateSolidBrush()` - Pinceles sólidos
  - `CreateLinearGradient()` - Gradientes lineales
  - `CreatePen()` - Plumas con estilos
- Métodos utilitarios:
  - `ApplyHighQuality()` - Anti-alias y suavizado
  - `FitCentered()` - Centrado con aspect ratio
  - `FitSquare()` - Ajuste cuadrado
  - `Lighten()`, `Darken()` - Manipulación de colores
  - `FillAndStrokePath()` - Relleno y contorno

### Carpeta: **Models/**

**BasicPolygons.cs** (5 figuras)
- `Square` - Cuadrado
- `Rectangle` - Rectángulo
- `Triangle` - Triángulo (Fórmula de Herón)
- `Parallelogram` - Paralelogramo
- `Trapeze` - Trapecio

**CurvedShapes.cs** (4 figuras)
- `Circle` - Círculo
- `Ellipse` - Elipse (Aproximación de Ramanujan)
- `Semicircle` - Semicírculo
- `Crescent` - Media Luna

**IrregularShapes.cs** (4 figuras)
- `Star` - Estrella (n puntas, radios variable)
- `Scalene` - Triángulo Escaleno
- `Kite` - Cometa
- `Cross` - Cruz

**SpecialShapes.cs** (7 figuras)
- `Pentagon` - Pentágono regular
- `Hexagon` - Hexágono regular
- `Octagon` - Octágono regular
- `Rhombus` - Rombo
- `PieSector` - Sector Circular (Pie)
- `Trefoil` - Trébol (3 hojas)
- `Heart` - Corazón (Bézier)

**ShapeRegistry.cs**
- Registro singleton de todas las figuras
- `GetShape(name)` - Obtiene instancia por nombre
- `GetAllShapeNames()` - Listado completo
- `GetShapesByGroup(group)` - Figuras por grupo
- Fácil extensión: solo registrar nueva clase

### Carpeta: **Forms/**

**FrmHome.cs** / **FrmHome.Designer.cs**
- Formulario principal con MenuStrip
- Menú > Shapes > 4 subgrupos > figuras individuales
- Click en cualquier figura abre `FrmAllShapes` pre-seleccionada

**FrmAllShapes.cs** / **FrmAllShapes.Designer.cs**
- Formulario universal para TODAS las figuras
- **Layout de 3 paneles**:
  - **Panel Izquierdo (Inputs)**: TextBoxes dinámicos para parámetros
  - **Panel Central (Graphic)**: Canvas con PictureBox
  - **Panel Derecho (Outputs)**: Perímetro y Área

- **Controles inferiores**:
  - Botón "Calcular" - Valida entrada, calcula, redibuja
  - Botón "Limpiar" - Limpia todos los valores
  - Botón "Salir" - Cierra formulario

- **Selectores de color**:
  - Color de relleno (por defecto: LightBlue)
  - Color de contorno (por defecto: Black)

## 🎯 Principios SOLID Aplicados

| Principio | Aplicación |
|-----------|-----------|
| **S** (Single) | Cada clase tiene una responsabilidad única |
| **O** (Open/Closed) | Agregar figuras sin tocar código existente |
| **L** (Liskov) | Cualquier `IShape` es intercambiable en `FrmAllShapes` |
| **I** (Interface) | Interfaces segregadas por grupo específico |
| **D** (Dependency) | `FrmAllShapes` depende de `IShape`, nunca de clases concretas |

## 📐 Fórmulas Matemáticas Implementadas

### Polígonos Básicos
- **Triángulo**: Fórmula de Herón: A = √(s(s-a)(s-b)(s-c)), s = p/2
- **Trapecio**: A = (b₁+b₂)h/2

### Formas Curvas
- **Elipse**: Aproximación de Ramanujan para perímetro
- **Semicírculo**: A = πr²/2, P = πr + 2r

### Formas Especiales
- **Polígonos Regulares**: A = (n·lado²)/(4·tan(π/n))
- **Sector Circular**: A = r²θ/2 (θ en radianes)

## 🔧 Cómo Extender el Proyecto

### Agregar una nueva figura:

1. **Crear la clase en el archivo del grupo correspondiente**:
   ```csharp
   public class NuevaFigura : IBasicPolygon
   {
       public string Name => "Nueva Figura";
       public List<string> GetInputLabels() { ... }
       public void SetParameters(double[] parameters) { ... }
       public double CalculatePerimeter() { ... }
       public double CalculateArea() { ... }
       public void Draw(System.Drawing.Graphics g, ...) { ... }
   }
   ```

2. **Registrar en ShapeRegistry.cs**:
   ```csharp
   _shapes["Nueva Figura"] = () => new NuevaFigura();
   ```

3. **Agregar al menú en FrmHome.Designer.cs** (automático si usa el registro)

## 📦 Dependencias

- `.NET 10`
- `System.Drawing` (GDI+)
- `System.Windows.Forms`

## 🎨 Diseño de Interfaz

```
┌─────────────────────────────────────────────────┐
│ FrmHome - MenuBar                               │
│ Shapes ▼                                        │
│ ├─ Basic Polygons ▶ (Cuadrado, Rectángulo, ...) │
│ ├─ Curved Shapes ▶ (Círculo, Elipse, ...)      │
│ ├─ Irregular Shapes ▶ (Estrella, Cometa, ...)  │
│ └─ Special Shapes ▶ (Pentágono, Rombo, ...)    │
│                                                 │
│ [Clic en figura → FrmAllShapes]                 │
└─────────────────────────────────────────────────┘

┌──────┬──────────────────────┬──────────┐
│      │                      │          │
│Inputs│   Canvas Graphics    │ Outputs  │
│      │                      │ Perímetro│
│TextBox       [DIBUJO]       │ Área     │
│TextBox         de la        │ Color ▼  │
│TextBox        figura        │ Color ▼  │
│              (PictureBox)   │          │
│      │                      │          │
├──────┴──────────────────────┴──────────┤
│ [Calcular]  [Limpiar]  [Salir]        │
└──────────────────────────────────────────┘
```

## 📝 TODO - Próximas Implementaciones

- [ ] Implementar cálculos en cada clase de figura
- [ ] Implementar métodos `Draw()` para visualización
- [ ] Mejorar `InitializeInputs()` en FrmAllShapes
- [ ] Mejorar `RedrawCanvas()` con validaciones
- [ ] Agregar cálculos numéricos para formas complejas (Corazón, Trébol)
- [ ] Persistencia de datos (guardar figuras calculadas)
- [ ] Exportar gráficos a imagen

## 🏃 Cómo Ejecutar

1. Abrir solución en Visual Studio
2. Compilar (debe compiling sin errores)
3. F5 o "Iniciar"
4. Seleccionar figura del menú
5. Ingresar parámetros
6. Clic en "Calcular"
7. Ver resultado y gráfico
