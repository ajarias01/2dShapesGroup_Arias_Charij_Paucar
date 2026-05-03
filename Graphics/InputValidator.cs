using System;
using System.Windows.Forms;

namespace _2dShapesGroup.Graphics
{
    /// <summary>
    /// Clase auxiliar para validar entradas numéricas en cuadros de texto.
    /// Asegura que solo se permitan números positivos.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Valida que un cuadro de texto contenga un número positivo válido.
        /// Retorna el valor analizado si es válido, o null si no es válido.
        /// </summary>
        public static double? ValidatePositiveNumber(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            if (!double.TryParse(text, System.Globalization.NumberStyles.Any, 
                System.Globalization.CultureInfo.InvariantCulture, out double val))
                return null;

            if (val <= 0)
                return null;

            return val;
        }

        /// <summary>
        /// Maneja el evento KeyPress para permitir solo entrada numérica y punto decimal.
        /// Previene que se ingrese números negativos.
        /// </summary>
        public static void HandleNumberInputKeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is not TextBox textBox)
                return;

            // Permite caracteres de control (retroceso, eliminar, etc.)
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permite dígitos
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permite un punto decimal
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                // Verifica si el punto decimal ya existe
                if (!textBox.Text.Contains(".") && !textBox.Text.Contains(","))
                {
                    // Reemplaza coma con punto para consistencia
                    if (e.KeyChar == ',')
                        e.KeyChar = '.';
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
                return;
            }

            // Rechaza todos los otros caracteres (incluyendo el signo menos)
            e.Handled = true;
        }
    }
}
