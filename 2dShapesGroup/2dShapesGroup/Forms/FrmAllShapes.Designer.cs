namespace ShapesApp.Forms
{
    partial class FrmAllShapes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlTopBar = new Panel();
            lblSelectShape = new Label();
            cmbShape = new ComboBox();
            lblShapeName = new Label();
            lblGroupName = new Label();
            pnlContent = new Panel();
            pnlLeft = new Panel();
            lblEntradas = new Label();
            pnlInputs = new Panel();
            lblProceso = new Label();
            pnlButtons = new Panel();
            btnCalculate = new Button();
            btnReset = new Button();
            btnExit = new Button();
            pnlGraphic = new Panel();
            lblGrafico = new Label();
            picGraphic = new PictureBox();
            pnlOutputs = new Panel();
            lblSalidas = new Label();
            lblPerimeter = new Label();
            lblPerimeterValue = new Label();
            lblArea = new Label();
            lblAreaValue = new Label();
            pnlTopBar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlGraphic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picGraphic).BeginInit();
            pnlOutputs.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.FromArgb(230, 235, 245);
            pnlTopBar.Controls.Add(lblSelectShape);
            pnlTopBar.Controls.Add(cmbShape);
            pnlTopBar.Controls.Add(lblShapeName);
            pnlTopBar.Controls.Add(lblGroupName);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Padding = new Padding(10, 8, 10, 8);
            pnlTopBar.Size = new Size(700, 52);
            pnlTopBar.TabIndex = 1;
            pnlTopBar.Paint += pnlTopBar_Paint;
            // 
            // lblSelectShape
            // 
            lblSelectShape.AutoSize = true;
            lblSelectShape.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSelectShape.ForeColor = Color.FromArgb(40, 40, 80);
            lblSelectShape.Location = new Point(10, 16);
            lblSelectShape.Name = "lblSelectShape";
            lblSelectShape.Size = new Size(61, 21);
            lblSelectShape.TabIndex = 0;
            lblSelectShape.Text = "Shape:";
            // 
            // cmbShape
            // 
            cmbShape.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbShape.Font = new Font("Segoe UI", 9.5F);
            cmbShape.Location = new Point(77, 13);
            cmbShape.Name = "cmbShape";
            cmbShape.Size = new Size(220, 29);
            cmbShape.TabIndex = 1;
            cmbShape.SelectedIndexChanged += CmbShape_SelectedIndexChanged;
            // 
            // lblShapeName
            // 
            lblShapeName.AutoSize = true;
            lblShapeName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblShapeName.ForeColor = Color.FromArgb(30, 90, 160);
            lblShapeName.Location = new Point(295, 8);
            lblShapeName.Name = "lblShapeName";
            lblShapeName.Size = new Size(0, 25);
            lblShapeName.TabIndex = 2;
            // 
            // lblGroupName
            // 
            lblGroupName.AutoSize = true;
            lblGroupName.Font = new Font("Segoe UI", 8.5F);
            lblGroupName.ForeColor = Color.FromArgb(100, 100, 130);
            lblGroupName.Location = new Point(297, 30);
            lblGroupName.Name = "lblGroupName";
            lblGroupName.Size = new Size(0, 20);
            lblGroupName.TabIndex = 3;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(220, 225, 240);
            pnlContent.Controls.Add(pnlLeft);
            pnlContent.Controls.Add(pnlGraphic);
            pnlContent.Controls.Add(pnlOutputs);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 52);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(10);
            pnlContent.Size = new Size(700, 380);
            pnlContent.TabIndex = 0;
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(232, 236, 248);
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlLeft.Controls.Add(lblEntradas);
            pnlLeft.Controls.Add(pnlInputs);
            pnlLeft.Controls.Add(lblProceso);
            pnlLeft.Controls.Add(pnlButtons);
            pnlLeft.Location = new Point(10, 10);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(280, 360);
            pnlLeft.TabIndex = 0;
            // 
            // lblEntradas
            // 
            lblEntradas.AutoSize = true;
            lblEntradas.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEntradas.ForeColor = Color.FromArgb(40, 40, 80);
            lblEntradas.Location = new Point(10, 10);
            lblEntradas.Name = "lblEntradas";
            lblEntradas.Size = new Size(76, 21);
            lblEntradas.TabIndex = 0;
            lblEntradas.Text = "Entradas";
            // 
            // pnlInputs
            // 
            pnlInputs.AutoScroll = true;
            pnlInputs.BackColor = Color.Transparent;
            pnlInputs.Location = new Point(8, 35);
            pnlInputs.Name = "pnlInputs";
            pnlInputs.Size = new Size(260, 220);
            pnlInputs.TabIndex = 1;
            // 
            // lblProceso
            // 
            lblProceso.AutoSize = true;
            lblProceso.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblProceso.ForeColor = Color.FromArgb(40, 40, 80);
            lblProceso.Location = new Point(10, 262);
            lblProceso.Name = "lblProceso";
            lblProceso.Size = new Size(70, 21);
            lblProceso.TabIndex = 2;
            lblProceso.Text = "Proceso";
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.Transparent;
            pnlButtons.Controls.Add(btnCalculate);
            pnlButtons.Controls.Add(btnReset);
            pnlButtons.Controls.Add(btnExit);
            pnlButtons.Location = new Point(8, 285);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(260, 40);
            pnlButtons.TabIndex = 3;
            // 
            // btnCalculate
            // 
            btnCalculate.Font = new Font("Segoe UI", 9F);
            btnCalculate.Location = new Point(0, 0);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(80, 30);
            btnCalculate.TabIndex = 0;
            btnCalculate.Text = "Calcular";
            btnCalculate.Click += BtnCalculate_Click;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 9F);
            btnReset.Location = new Point(88, 0);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(80, 30);
            btnReset.TabIndex = 1;
            btnReset.Text = "Resetear";
            btnReset.Click += BtnReset_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 9F);
            btnExit.Location = new Point(176, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(80, 30);
            btnExit.TabIndex = 2;
            btnExit.Text = "Salir";
            btnExit.Click += BtnExit_Click;
            // 
            // pnlGraphic
            // 
            pnlGraphic.BackColor = Color.FromArgb(232, 236, 248);
            pnlGraphic.BorderStyle = BorderStyle.FixedSingle;
            pnlGraphic.Controls.Add(lblGrafico);
            pnlGraphic.Controls.Add(picGraphic);
            pnlGraphic.Location = new Point(300, 10);
            pnlGraphic.Name = "pnlGraphic";
            pnlGraphic.Size = new Size(380, 230);
            pnlGraphic.TabIndex = 1;
            // 
            // lblGrafico
            // 
            lblGrafico.AutoSize = true;
            lblGrafico.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblGrafico.ForeColor = Color.FromArgb(40, 40, 80);
            lblGrafico.Location = new Point(8, 8);
            lblGrafico.Name = "lblGrafico";
            lblGrafico.Size = new Size(65, 21);
            lblGrafico.TabIndex = 0;
            lblGrafico.Text = "Gráfico";
            // 
            // picGraphic
            // 
            picGraphic.BackColor = Color.White;
            picGraphic.BorderStyle = BorderStyle.FixedSingle;
            picGraphic.Location = new Point(8, 30);
            picGraphic.Name = "picGraphic";
            picGraphic.Size = new Size(360, 190);
            picGraphic.TabIndex = 1;
            picGraphic.TabStop = false;
            // 
            // pnlOutputs
            // 
            pnlOutputs.BackColor = Color.FromArgb(232, 236, 248);
            pnlOutputs.BorderStyle = BorderStyle.FixedSingle;
            pnlOutputs.Controls.Add(lblSalidas);
            pnlOutputs.Controls.Add(lblPerimeter);
            pnlOutputs.Controls.Add(lblPerimeterValue);
            pnlOutputs.Controls.Add(lblArea);
            pnlOutputs.Controls.Add(lblAreaValue);
            pnlOutputs.Location = new Point(300, 250);
            pnlOutputs.Name = "pnlOutputs";
            pnlOutputs.Size = new Size(380, 120);
            pnlOutputs.TabIndex = 2;
            // 
            // lblSalidas
            // 
            lblSalidas.AutoSize = true;
            lblSalidas.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSalidas.ForeColor = Color.FromArgb(40, 40, 80);
            lblSalidas.Location = new Point(8, 8);
            lblSalidas.Name = "lblSalidas";
            lblSalidas.Size = new Size(64, 21);
            lblSalidas.TabIndex = 0;
            lblSalidas.Text = "Salidas";
            // 
            // lblPerimeter
            // 
            lblPerimeter.AutoSize = true;
            lblPerimeter.Font = new Font("Segoe UI", 9.5F);
            lblPerimeter.ForeColor = Color.FromArgb(40, 40, 80);
            lblPerimeter.Location = new Point(8, 36);
            lblPerimeter.Name = "lblPerimeter";
            lblPerimeter.Size = new Size(81, 21);
            lblPerimeter.TabIndex = 1;
            lblPerimeter.Text = "Perímetro:";
            // 
            // lblPerimeterValue
            // 
            lblPerimeterValue.AutoSize = true;
            lblPerimeterValue.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPerimeterValue.ForeColor = Color.FromArgb(30, 90, 160);
            lblPerimeterValue.Location = new Point(110, 36);
            lblPerimeterValue.Name = "lblPerimeterValue";
            lblPerimeterValue.Size = new Size(26, 21);
            lblPerimeterValue.TabIndex = 2;
            lblPerimeterValue.Text = "—";
            // 
            // lblArea
            // 
            lblArea.AutoSize = true;
            lblArea.Font = new Font("Segoe UI", 9.5F);
            lblArea.ForeColor = Color.FromArgb(40, 40, 80);
            lblArea.Location = new Point(8, 65);
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(45, 21);
            lblArea.TabIndex = 3;
            lblArea.Text = "Área:";
            // 
            // lblAreaValue
            // 
            lblAreaValue.AutoSize = true;
            lblAreaValue.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAreaValue.ForeColor = Color.FromArgb(30, 90, 160);
            lblAreaValue.Location = new Point(110, 65);
            lblAreaValue.Name = "lblAreaValue";
            lblAreaValue.Size = new Size(26, 21);
            lblAreaValue.TabIndex = 4;
            lblAreaValue.Text = "—";
            // 
            // FrmAllShapes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(200, 210, 235);
            ClientSize = new Size(700, 432);
            Controls.Add(pnlContent);
            Controls.Add(pnlTopBar);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAllShapes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shapes App — All Shapes";
            Load += FrmAllShapes_Load;
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlButtons.ResumeLayout(false);
            pnlGraphic.ResumeLayout(false);
            pnlGraphic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picGraphic).EndInit();
            pnlOutputs.ResumeLayout(false);
            pnlOutputs.PerformLayout();
            ResumeLayout(false);
        }

        // ── Helper: flat-style button ──────────────────────────────────
        private static void ApplyButtonStyle(Button btn, Color backColor)
        {
            btn.BackColor   = backColor;
            btn.ForeColor   = Color.White;
            btn.FlatStyle   = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor      = Cursors.Hand;
        }

        #endregion

        // ── Control declarations ──────────────────────────────────────────
        private Panel           pnlTopBar;
        private Label           lblSelectShape;
        private ComboBox        cmbShape;
        private Label           lblShapeName;
        private Label           lblGroupName;

        private Panel           pnlContent;

        private Panel           pnlLeft;
        private Label           lblEntradas;
        private Panel           pnlInputs;
        private Label           lblProceso;
        private Panel           pnlButtons;
        private Button          btnCalculate;
        private Button          btnReset;
        private Button          btnExit;

        private Panel           pnlGraphic;
        private Label           lblGrafico;
        private PictureBox      picGraphic;

        private Panel           pnlOutputs;
        private Label           lblSalidas;
        private Label           lblPerimeter;
        private Label           lblPerimeterValue;
        private Label           lblArea;
        private Label           lblAreaValue;
    }
}
