using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using _2dShapesGroup.Interfaces;
using _2dShapesGroup.Models;
using ShapesApp.Models;

namespace ShapesApp.Forms
{
    // ════════════════════════════════════════════════════════════════════
    //  FrmAllShapes
    //  A single reusable form that can display any of the 20 shapes.
    //  Single Responsibility : only orchestrates input ↔ math ↔ drawing.
    //  Open/Closed           : adding a new shape never requires modifying this form.
    // ════════════════════════════════════════════════════════════════════

    public partial class FrmAllShapes : Form
    {
        // ── State ─────────────────────────────────────────────────────────
        private IShape? _currentShape;
        private List<TextBox> _inputBoxes = new();
        private double[] _currentValues = Array.Empty<double>();

        // ── Constructor ───────────────────────────────────────────────────
        public FrmAllShapes()
        {
            InitializeComponent();

            // Populate the shape selector
            PopulateShapeSelector();

            // Wire up paint event for the graphic panel
            picGraphic.Paint += PicGraphic_Paint;

            // Default: first shape in the registry
            if (cmbShape.Items.Count > 0)
                cmbShape.SelectedIndex = 0;
        }

        // ── Public API: pre-select a shape (called from FrmHome) ──────────
        public void SelectShape(IShape shape)
        {
            for (int i = 0; i < cmbShape.Items.Count; i++)
            {
                if (cmbShape.Items[i] is ShapeEntry entry && entry.Shape.Name == shape.Name)
                {
                    cmbShape.SelectedIndex = i;
                    return;
                }
            }
        }

        // ── Populate combo with all shapes (grouped) ──────────────────────
        private void PopulateShapeSelector()
        {
            cmbShape.Items.Clear();
            var registry = ShapeRegistry.GetAll();
            foreach (var kvp in registry)
                foreach (var shape in kvp.Value)
                    cmbShape.Items.Add(new ShapeEntry(kvp.Key, shape));
        }

        // ── Combo selection changed → rebuild input panel ─────────────────
        private void CmbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbShape.SelectedItem is not ShapeEntry entry) return;

            _currentShape = entry.Shape;
            lblShapeName.Text = _currentShape.Name;
            lblGroupName.Text = $"Group: {entry.GroupName}";

            RebuildInputPanel(_currentShape);
            Calculate();
        }

        // ── Build text-boxes dynamically from IShape.Parameters ──────────
        private void RebuildInputPanel(IShape shape)
        {
            // Clear old controls
            pnlInputs.Controls.Clear();
            _inputBoxes.Clear();

            int y = 8;
            foreach (var (label, defaultVal) in shape.Parameters)
            {
                var lbl = new Label
                {
                    Text = label + ":",
                    Location = new Point(8, y + 3),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9f)
                };

                var txt = new TextBox
                {
                    Text = defaultVal.ToString("0.##"),
                    Location = new Point(160, y),
                    Width = 80,
                    Font = new Font("Segoe UI", 9f)
                };
                txt.TextChanged += (s, e) => Calculate();

                pnlInputs.Controls.Add(lbl);
                pnlInputs.Controls.Add(txt);
                _inputBoxes.Add(txt);

                y += 34;
            }
        }

        // ── Parse inputs → compute → refresh UI ──────────────────────────
        private void Calculate()
        {
            if (_currentShape is null) return;

            _currentValues = new double[_inputBoxes.Count];
            for (int i = 0; i < _inputBoxes.Count; i++)
            {
                if (!double.TryParse(_inputBoxes[i].Text,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double val) || val <= 0)
                {
                    // Skip redraw on invalid input
                    return;
                }
                _currentValues[i] = val;
            }

            double perimeter = _currentShape.Perimeter(_currentValues);
            double area = _currentShape.Area(_currentValues);

            lblPerimeterValue.Text = $"{perimeter:F4}";
            lblAreaValue.Text = $"{area:F4}";

            picGraphic.Invalidate();   // triggers Paint → Draw
        }

        // ── GDI+ paint for the preview panel ─────────────────────────────
        private void PicGraphic_Paint(object? sender, PaintEventArgs e)
        {
            if (_currentShape is null || _currentValues.Length == 0) return;
            e.Graphics.Clear(picGraphic.BackColor);
            _currentShape.Draw(e.Graphics,
                               new RectangleF(0, 0, picGraphic.Width, picGraphic.Height),
                               _currentValues);
        }

        // ── Button handlers ───────────────────────────────────────────────
        private void BtnCalculate_Click(object sender, EventArgs e) => Calculate();

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (_currentShape is null) return;
            for (int i = 0; i < _inputBoxes.Count && i < _currentShape.Parameters.Count; i++)
                _inputBoxes[i].Text = _currentShape.Parameters[i].DefaultValue.ToString("0.##");
            Calculate();
        }

        private void BtnExit_Click(object sender, EventArgs e) => Close();

        // ── Inner helper class ────────────────────────────────────────────
        private sealed class ShapeEntry
        {
            public string GroupName { get; }
            public IShape Shape { get; }

            public ShapeEntry(string groupName, IShape shape)
            {
                GroupName = groupName;
                Shape = shape;
            }

            public override string ToString() => Shape.Name;
        }

        private void pnlTopBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmAllShapes_Load(object sender, EventArgs e)
        {

        }
    }
}
