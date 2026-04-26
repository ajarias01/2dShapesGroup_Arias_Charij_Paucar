namespace _2dShapesGroup.Interfaces
{
    /// <summary>
    /// Interface para polígonos básicos (4 o menos lados).
    /// Incluye: Cuadrado, Rectángulo, Triángulo, Paralelogramo, Trapecio.
    /// 
    /// Lógica matemática:
    /// - Cuadrado: Perímetro = 4*a, Área = a²
    /// - Rectángulo: Perímetro = 2(l+a), Área = l*a
    /// - Triángulo: Perímetro = a+b+c, Área = √(s(s-a)(s-b)(s-c)) [Fórmula de Herón, s=p/2]
    /// - Paralelogramo: Perímetro = 2(a+b), Área = base*altura
    /// - Trapecio: Perímetro = a+b+c+d, Área = (base1+base2)*altura/2
    /// </summary>
    public interface IBasicPolygon : IShape
    {
        // Métodos adicionales específicos para polígonos básicos pueden agregarse aquí
    }

    /// <summary>
    /// Interface para formas curvas.
    /// Incluye: Círculo, Elipse, Semicírculo, Media Luna.
    /// 
    /// Lógica matemática:
    /// - Círculo: Perímetro = 2πr, Área = πr²
    /// - Elipse: Perímetro ≈ π(a+b)(1+3h/(10+√(4-3h))) [Ramanujan], Área = πab
    ///   donde h = (a-b)²/(a+b)²
    /// - Semicírculo: Perímetro = πr + 2r, Área = πr²/2
    /// - Media Luna (Crescent): Perímetro = 2πr, Área = r²(π/2 - 1)
    /// </summary>
    public interface ICurvedShape : IShape
    {
        // Métodos adicionales específicos para formas curvas pueden agregarse aquí
    }

    /// <summary>
    /// Interface para formas irregulares.
    /// Incluye: Estrella (n puntas), Escaleno, Cometa, Cruz.
    /// 
    /// Lógica matemática:
    /// - Estrella (n puntas): Perímetro = suma de lados, Área = depende de radios exterior/interior
    /// - Triángulo Escaleno: Perímetro = a+b+c, Área = √(s(s-a)(s-b)(s-c)) [Herón]
    /// - Cometa: Perímetro = 2(a+b), Área = (d1*d2)/2 [d1, d2 = diagonales]
    /// - Cruz: Perímetro = suma de lados, Área = suma de rectángulos componentes
    /// </summary>
    public interface IIrregularShape : IShape
    {
        // Métodos adicionales específicos para formas irregulares pueden agregarse aquí
    }

    /// <summary>
    /// Interface para formas especiales.
    /// Incluye: Pentágono, Hexágono, Octágono, Rombo, Sector Circular, Trébol, Corazón.
    /// 
    /// Lógica matemática:
    /// - Polígono regular (n-lados): Perímetro = n*lado, Área = (n*lado²)/(4*tan(π/n))
    /// - Rombo: Perímetro = 4*lado, Área = (d1*d2)/2 [d1, d2 = diagonales]
    /// - Sector Circular: Perímetro = 2r + arco = 2r + rθ, Área = (θ/(2π))*πr² = r²θ/2
    /// - Trébol: Combinación de círculos, Área = suma de segmentos
    /// - Corazón: Curva Bézier, cálculo numérico
    /// </summary>
    public interface ISpecialShape : IShape
    {
        // Métodos adicionales específicos para formas especiales pueden agregarse aquí
    }
}
