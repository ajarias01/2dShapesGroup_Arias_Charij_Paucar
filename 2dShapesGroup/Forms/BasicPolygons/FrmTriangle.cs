using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using _2dShapesGroup.Interfaces;
using ShapesApp.Models.BasicPolygons;


namespace ShapesApp.Forms.BasicPolygons
{
    public partial class FrmTriangle : Form
    {
        private IShape _currentShape;
        private List<TextBox> _inputBoxes = new();
        private double[] _currentValues = Array.Empty<double>();

        public FrmTriangle()
        {
            InitializeComponent();
            _currentShape = new Triangle();
            RebuildInputPanel(_currentShape);
            picGraphic.Paint += PicGraphic_Paint;
            lblShapeName.Text = _currentShape.Name;
            lblGroupName.Text = "Group: Basic Polygons";
            Calculate();
        }

        private void RebuildInputPanel(IShape shape)
        {
            pnlInputs.Controls.Clear();
            _inputBoxes.Clear();
            int y = 8;
            foreach (var param in shape.Parameters)
            {
                var lbl = new Label { Text = param.Label + ":", Location = new Point(8, y + 3), AutoSize = true, Font = new Font("Segoe UI", 9f) };
                var txt = new TextBox { Text = param.DefaultValue.ToString("0.##"), Location = new Point(160, y), Width = 80, Font = new Font("Segoe UI", 9f) };
                txt.TextChanged += (s, e) => Calculate();

                pnlInputs.Controls.Add(lbl);
                pnlInputs.Controls.Add(txt);
                _inputBoxes.Add(txt);
                y += 34;
            }
        }

        private void Calculate()
        {
            if (_currentShape is null) return;
            _currentValues = new double[_inputBoxes.Count];
            for (int i = 0; i < _inputBoxes.Count; i++)
            {
                if (!double.TryParse(_inputBoxes[i].Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double val) || val <= 0) return;
                _currentValues[i] = val;
            }
            lblPerimeterValue.Text = $"{_currentShape.Perimeter(_currentValues):F4}";
            lblAreaValue.Text = $"{_currentShape.Area(_currentValues):F4}";
            picGraphic.Invalidate();
        }

        private void PicGraphic_Paint(object sender, PaintEventArgs e)
        {
            if (_currentShape is null || _currentValues.Length == 0) return;
            e.Graphics.Clear(picGraphic.BackColor);
            _currentShape.Draw(e.Graphics, new RectangleF(0, 0, picGraphic.Width, picGraphic.Height), _currentValues);
        }

        private void BtnCalculate_Click(object sender, EventArgs e) => Calculate();
        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (_currentShape is null) return;
            for (int i = 0; i < _inputBoxes.Count && i < _currentShape.Parameters.Count; i++)
                _inputBoxes[i].Text = _currentShape.Parameters[i].DefaultValue.ToString("0.##");
            Calculate();
        }
        private void BtnExit_Click(object sender, EventArgs e) => Close();
    }
}
