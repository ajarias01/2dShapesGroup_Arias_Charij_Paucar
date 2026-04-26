# FrmAllShapes - Layout y Componentes

## 📐 Layout General

```
┌─────────────────────────────────────────────────────────────────────────┐
│  2D Shapes - [Nombre Figura]                               [_] [□] [X]  │
├─────────────────────────────────────────────────────────────────────────┤
│                                                                          │
│  ┌─────────────────┬──────────────────────────┬──────────────────────┐  │
│  │                 │                          │                      │  │
│  │  PANEL INPUTS   │    PANEL GRAPHIC         │  PANEL OUTPUTS       │  │
│  │  (200px width)  │    (Fill Panel)          │  (200px width)       │  │
│  │                 │                          │                      │  │
│  │ □ Label1:       │                          │  ┌──────────────────┤  │
│  │   [TextBox]     │                          │  │ Perímetro: 0.00  │  │
│  │                 │                          │  └──────────────────┤  │
│  │ □ Label2:       │     [CANVAS DRAWING]     │  ┌──────────────────┤  │
│  │   [TextBox]     │                          │  │ Área: 0.00       │  │
│  │                 │       de la FIGURA       │  └──────────────────┤  │
│  │ □ Label3:       │                          │  ┌──────────────────┤  │
│  │   [TextBox]     │      (PictureBox)        │  │ Color Relleno:   │  │
│  │                 │                          │  │ [Seleccionar ▼]  │  │
│  │ ... dinámicos   │                          │  └──────────────────┤  │
│  │                 │                          │  ┌──────────────────┤  │
│  │                 │                          │  │ Color Contorno:  │  │
│  │                 │                          │  │ [Seleccionar ▼]  │  │
│  │                 │                          │  └──────────────────┤  │
│  │                 │                          │                      │  │
│  └─────────────────┴──────────────────────────┴──────────────────────┘  │
│                                                                          │
├──────────────────────────────────────────────────────────────────────────┤
│  [Calcular]  [Limpiar]  [Salir]                     (60px height)       │
└──────────────────────────────────────────────────────────────────────────┘
```

## 🎨 Panel Inputs (Izquierda)

**Propiedades:**
- `Dock: DockStyle.Left`
- `Width: 200px`
- `BorderStyle: FixedSingle`
- `AutoScroll: true`

**Contenido (Dinámico):**
- Se genera según `_currentShape.GetInputLabels()`
- Un `Label` + `TextBox` por parámetro
- Guardados en lista `_inputControls`

**Ejemplo de contenido:**
```
Para Rectángulo:
  Label "Largo:"
    TextBox [_________]
  Label "Ancho:"
    TextBox [_________]

Para Triángulo:
  Label "Lado A:"
    TextBox [_________]
  Label "Lado B:"
    TextBox [_________]
  Label "Lado C:"
    TextBox [_________]
```

## 🖼️ Panel Graphic (Centro)

**Propiedades:**
- `Dock: DockStyle.Fill`
- `BorderStyle: FixedSingle`
- Contiene `PictureBox` anidado

**PictureBox:**
- `Dock: DockStyle.Fill`
- `BackColor: White`
- `SizeMode: CenterImage`
- Mostrará el dibujo de la figura

**Proceso de Dibujo:**
```csharp
private void RedrawCanvas()
{
    Rectangle graphicArea = pnlGraphic.ClientRectangle;
    Bitmap bitmap = new Bitmap(graphicArea.Width, graphicArea.Height);

    using (Graphics g = Graphics.FromImage(bitmap))
    {
        ShapeGraphicsHelper.ApplyHighQuality(g);

        // Limpiar
        g.Clear(Color.White);

        // Dibujar figura
        _currentShape.Draw(g, bounds, fillBrush, outlinePen);
    }

    picGraphic.Image = bitmap;
}
```

## 📊 Panel Outputs (Derecha)

**Propiedades:**
- `Dock: DockStyle.Right`
- `Width: 200px`
- `BorderStyle: FixedSingle`
- `Padding: 10px`

**Componentes:**

### Label "Perímetro: 0.00"
- `Height: 40px`
- `Font: Arial, 12pt, Bold`
- `TextAlign: MiddleCenter`
- `Dock: DockStyle.Top`

### Label "Área: 0.00"
- `Height: 40px`
- `Font: Arial, 12pt, Bold`
- `TextAlign: MiddleCenter`
- `Dock: DockStyle.Top`

### Label "Color Relleno:"
- `Height: 20px`
- `TextAlign: MiddleLeft`
- `Dock: DockStyle.Top`

### Button "Seleccionar Color Relleno"
- `Height: 30px`
- `Dock: DockStyle.Top`
- Click → `ColorDialog` → Actualizar `_fillColor` → Redibujar

### Label "Color Contorno:"
- `Height: 20px`
- `TextAlign: MiddleLeft`
- `Dock: DockStyle.Top`

### Button "Seleccionar Color Contorno"
- `Height: 30px`
- `Dock: DockStyle.Top`
- Click → `ColorDialog` → Actualizar `_outlineColor` → Redibujar

## 🔘 Panel Buttons (Abajo)

**Propiedades:**
- `Dock: DockStyle.Bottom`
- `Height: 60px`
- `BorderStyle: FixedSingle`
- `Padding: 5px`

**Botones:**

### Button "Calcular"
- `Width: 80px`
- `Location: (5, 5)`
- **Acción:**
  ```csharp
  private void BtnCalculate_Click(object sender, EventArgs e)
  {
      // 1. Obtener valores de TextBox
      double[] parameters = _inputControls
          .Select(tb => double.Parse(tb.Text))
          .ToArray();

      // 2. Validar parámetros
      if (!ValidateParameters(parameters)) return;

      // 3. Establecer parámetros en figura
      _currentShape.SetParameters(parameters);

      // 4. Calcular
      double perimeter = _currentShape.CalculatePerimeter();
      double area = _currentShape.CalculateArea();

      // 5. Mostrar resultados
      lblPerimeter.Text = $"Perímetro: {perimeter:F2}";
      lblArea.Text = $"Área: {area:F2}";

      // 6. Redibujar
      RedrawCanvas();
  }
  ```

### Button "Limpiar"
- `Width: 80px`
- `Location: (90, 5)`
- **Acción:**
  ```csharp
  private void BtnReset_Click(object sender, EventArgs e)
  {
      // Limpiar inputs
      foreach (var tb in _inputControls)
          tb.Text = "";

      // Limpiar outputs
      lblPerimeter.Text = "Perímetro: 0";
      lblArea.Text = "Área: 0";

      // Limpiar canvas
      picGraphic.Image = null;
  }
  ```

### Button "Salir"
- `Width: 80px`
- `Location: (175, 5)`
- **Acción:** `this.Close();`

## 🎯 Flujo de Uso

1. **Carga:**
   ```
   FrmHome → OpenShapeForm("Círculo")
          → FrmAllShapes(shapeName)
          → LoadShape("Círculo")
          → ShapeRegistry.GetShape("Círculo")
          → InitializeInputs()
               → Circle.GetInputLabels() → ["Radio"]
               → Crear 1 TextBox
          → RedrawCanvas() → Dibujo inicial
   ```

2. **Entrada de datos:**
   ```
   Usuario digita en TextBox:
   Radio: [5]
   ```

3. **Cálculo:**
   ```
   Click "Calcular"
   → Obtener 5.0
   → circle.SetParameters([5.0])
   → perimeter = 2π*5 = 31.42
   → area = π*5² = 78.54
   → Mostrar en labels
   → Redibujar con círculo
   ```

4. **Visualización:**
   ```
   Panel Outputs muestra:
   Perímetro: 31.42
   Área: 78.54

   Canvas muestra círculo azul con contorno negro
   ```

5. **Personalización (Opcional):**
   ```
   Click "Seleccionar" (Color Relleno)
   → ColorDialog
   → Usuario elige color verde
   → _fillColor = Green
   → RedrawCanvas()
   → Círculo aparece verde
   ```

## 📋 Estados y Validaciones

### Estados Posibles:
1. **Inicial**: Figura sin parámetros
2. **Parámetros Ingresados**: Valores en TextBox pero no calculados
3. **Calculado**: Resultados mostrados y figura dibujada
4. **Error**: Validación fallida (valores inválidos)

### Validaciones:
```csharp
private bool ValidateParameters(double[] parameters)
{
    if (parameters.Length != _currentShape.GetInputLabels().Count)
        return false;

    foreach (double param in parameters)
    {
        if (double.IsNaN(param) || param <= 0)
            return false;
    }

    // Validaciones específicas por figura
    return true;
}
```

## 🎨 Colores por Defecto

- **Relleno:** `Color.LightBlue` (RGB: 173, 216, 230)
- **Contorno:** `Color.Black` (RGB: 0, 0, 0)
- **Fondo Canvas:** `Color.White`

## 📐 Tamaños Recomendados

```
Forma completa:
├─ Ancho mínimo: 800px
├─ Alto mínimo: 400px
└─ Tamaño por defecto: 1000px x 600px

Distribución:
├─ Panel Inputs: 200px (20% del ancho)
├─ Panel Graphic: 600px (60% del ancho)
├─ Panel Outputs: 200px (20% del ancho)
└─ Panel Buttons: 60px (alto fijo)
```

## 🔗 Integración con ShapeGraphicsHelper

```csharp
// En RedrawCanvas():
ShapeGraphicsHelper.ApplyHighQuality(g);

// Crear pinceles y plumas:
Brush fillBrush = ShapeGraphicsHelper.CreateSolidBrush(_fillColor);
Pen outlinePen = ShapeGraphicsHelper.CreatePen(_outlineColor, 2f);

// Dibujar figura:
_currentShape.Draw(g, bounds, fillBrush, outlinePen);

// Ajustar tamaño:
Rectangle adjustedBounds = ShapeGraphicsHelper.FitSquare(bounds);
```
