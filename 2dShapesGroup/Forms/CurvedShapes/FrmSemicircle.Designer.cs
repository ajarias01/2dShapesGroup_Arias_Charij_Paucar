namespace ShapesApp.Forms.CurvedShapes
{
    partial class FrmSemicircle
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            pnlTopBar = new System.Windows.Forms.Panel();
            lblShapeName = new System.Windows.Forms.Label();
            lblGroupName = new System.Windows.Forms.Label();
            pnlContent = new System.Windows.Forms.Panel();
            pnlLeft = new System.Windows.Forms.Panel();
            lblEntradas = new System.Windows.Forms.Label();
            pnlInputs = new System.Windows.Forms.Panel();
            lblProceso = new System.Windows.Forms.Label();
            pnlButtons = new System.Windows.Forms.Panel();
            btnCalculate = new System.Windows.Forms.Button();
            btnReset = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            pnlGraphic = new System.Windows.Forms.Panel();
            lblGrafico = new System.Windows.Forms.Label();
            picGraphic = new System.Windows.Forms.PictureBox();
            pnlOutputs = new System.Windows.Forms.Panel();
            lblSalidas = new System.Windows.Forms.Label();
            lblPerimeter = new System.Windows.Forms.Label();
            lblPerimeterValue = new System.Windows.Forms.Label();
            lblArea = new System.Windows.Forms.Label();
            lblAreaValue = new System.Windows.Forms.Label();
            pnlTopBar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlGraphic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(picGraphic)).BeginInit();
            pnlOutputs.SuspendLayout();
            SuspendLayout();
            // pnlTopBar
            pnlTopBar.BackColor = System.Drawing.Color.FromArgb(230, 235, 245);
            pnlTopBar.Controls.Add(lblShapeName);
            pnlTopBar.Controls.Add(lblGroupName);
            pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTopBar.Location = new System.Drawing.Point(0, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            pnlTopBar.Size = new System.Drawing.Size(700, 52);
            // lblShapeName
            lblShapeName.AutoSize = true;
            lblShapeName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblShapeName.ForeColor = System.Drawing.Color.FromArgb(30, 90, 160);
            lblShapeName.Location = new System.Drawing.Point(12, 8);
            lblShapeName.Name = "lblShapeName";
            lblShapeName.Size = new System.Drawing.Size(0, 25);
            // lblGroupName
            lblGroupName.AutoSize = true;
            lblGroupName.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblGroupName.ForeColor = System.Drawing.Color.FromArgb(100, 100, 130);
            lblGroupName.Location = new System.Drawing.Point(14, 30);
            lblGroupName.Name = "lblGroupName";
            lblGroupName.Size = new System.Drawing.Size(0, 20);
            // pnlContent
            pnlContent.BackColor = System.Drawing.Color.FromArgb(220, 225, 240);
            pnlContent.Controls.Add(pnlLeft);
            pnlContent.Controls.Add(pnlGraphic);
            pnlContent.Controls.Add(pnlOutputs);
            pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlContent.Location = new System.Drawing.Point(0, 52);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new System.Windows.Forms.Padding(10);
            pnlContent.Size = new System.Drawing.Size(700, 380);
            // pnlLeft
            pnlLeft.BackColor = System.Drawing.Color.FromArgb(232, 236, 248);
            pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlLeft.Controls.Add(lblEntradas);
            pnlLeft.Controls.Add(pnlInputs);
            pnlLeft.Controls.Add(lblProceso);
            pnlLeft.Controls.Add(pnlButtons);
            pnlLeft.Location = new System.Drawing.Point(10, 10);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new System.Drawing.Size(280, 360);
            // lblEntradas
            lblEntradas.AutoSize = true;
            lblEntradas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblEntradas.ForeColor = System.Drawing.Color.FromArgb(40, 40, 80);
            lblEntradas.Location = new System.Drawing.Point(10, 10);
            lblEntradas.Name = "lblEntradas";
            lblEntradas.Size = new System.Drawing.Size(76, 21);
            lblEntradas.Text = "Entradas";
            // pnlInputs
            pnlInputs.AutoScroll = true;
            pnlInputs.BackColor = System.Drawing.Color.Transparent;
            pnlInputs.Location = new System.Drawing.Point(8, 35);
            pnlInputs.Name = "pnlInputs";
            pnlInputs.Size = new System.Drawing.Size(260, 220);
            // lblProceso
            lblProceso.AutoSize = true;
            lblProceso.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblProceso.ForeColor = System.Drawing.Color.FromArgb(40, 40, 80);
            lblProceso.Location = new System.Drawing.Point(10, 262);
            lblProceso.Name = "lblProceso";
            lblProceso.Size = new System.Drawing.Size(70, 21);
            lblProceso.Text = "Proceso";
            // pnlButtons
            pnlButtons.BackColor = System.Drawing.Color.Transparent;
            pnlButtons.Controls.Add(btnCalculate);
            pnlButtons.Controls.Add(btnReset);
            pnlButtons.Controls.Add(btnExit);
            pnlButtons.Location = new System.Drawing.Point(8, 285);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new System.Drawing.Size(260, 40);
            // btnCalculate
            btnCalculate.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnCalculate.Location = new System.Drawing.Point(0, 0);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new System.Drawing.Size(80, 30);
            btnCalculate.Text = "Calcular";
            btnCalculate.Click += new System.EventHandler(BtnCalculate_Click);
            // btnReset
            btnReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnReset.Location = new System.Drawing.Point(88, 0);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(80, 30);
            btnReset.Text = "Resetear";
            btnReset.Click += new System.EventHandler(BtnReset_Click);
            // btnExit
            btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnExit.Location = new System.Drawing.Point(176, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(80, 30);
            btnExit.Text = "Salir";
            btnExit.Click += new System.EventHandler(BtnExit_Click);
            // pnlGraphic
            pnlGraphic.BackColor = System.Drawing.Color.FromArgb(232, 236, 248);
            pnlGraphic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlGraphic.Controls.Add(lblGrafico);
            pnlGraphic.Controls.Add(picGraphic);
            pnlGraphic.Location = new System.Drawing.Point(300, 10);
            pnlGraphic.Name = "pnlGraphic";
            pnlGraphic.Size = new System.Drawing.Size(390, 260);
            // lblGrafico
            lblGrafico.AutoSize = true;
            lblGrafico.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblGrafico.ForeColor = System.Drawing.Color.FromArgb(40, 40, 80);
            lblGrafico.Location = new System.Drawing.Point(10, 10);
            lblGrafico.Name = "lblGrafico";
            lblGrafico.Size = new System.Drawing.Size(65, 21);
            lblGrafico.Text = "Gráfico";
            // picGraphic
            picGraphic.BackColor = System.Drawing.Color.White;
            picGraphic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picGraphic.Location = new System.Drawing.Point(10, 35);
            picGraphic.Name = "picGraphic";
            picGraphic.Size = new System.Drawing.Size(365, 210);
            // pnlOutputs
            pnlOutputs.BackColor = System.Drawing.Color.FromArgb(232, 236, 248);
            pnlOutputs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlOutputs.Controls.Add(lblSalidas);
            pnlOutputs.Controls.Add(lblPerimeter);
            pnlOutputs.Controls.Add(lblPerimeterValue);
            pnlOutputs.Controls.Add(lblArea);
            pnlOutputs.Controls.Add(lblAreaValue);
            pnlOutputs.Location = new System.Drawing.Point(300, 280);
            pnlOutputs.Name = "pnlOutputs";
            pnlOutputs.Size = new System.Drawing.Size(390, 90);
            // lblSalidas
            lblSalidas.AutoSize = true;
            lblSalidas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblSalidas.ForeColor = System.Drawing.Color.FromArgb(40, 40, 80);
            lblSalidas.Location = new System.Drawing.Point(10, 10);
            lblSalidas.Name = "lblSalidas";
            lblSalidas.Size = new System.Drawing.Size(62, 21);
            lblSalidas.Text = "Salidas";
            // lblPerimeter
            lblPerimeter.AutoSize = true;
            lblPerimeter.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblPerimeter.Location = new System.Drawing.Point(10, 35);
            lblPerimeter.Name = "lblPerimeter";
            lblPerimeter.Size = new System.Drawing.Size(76, 20);
            lblPerimeter.Text = "Perimetro:";
            // lblPerimeterValue
            lblPerimeterValue.AutoSize = true;
            lblPerimeterValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblPerimeterValue.Location = new System.Drawing.Point(90, 35);
            lblPerimeterValue.Name = "lblPerimeterValue";
            lblPerimeterValue.Size = new System.Drawing.Size(18, 20);
            lblPerimeterValue.Text = "0";
            // lblArea
            lblArea.AutoSize = true;
            lblArea.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblArea.Location = new System.Drawing.Point(10, 60);
            lblArea.Name = "lblArea";
            lblArea.Size = new System.Drawing.Size(43, 20);
            lblArea.Text = "Area:";
            // lblAreaValue
            lblAreaValue.AutoSize = true;
            lblAreaValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblAreaValue.Location = new System.Drawing.Point(90, 60);
            lblAreaValue.Name = "lblAreaValue";
            lblAreaValue.Size = new System.Drawing.Size(18, 20);
            lblAreaValue.Text = "0";
            // FrmSemicircle
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(700, 432);
            Controls.Add(pnlContent);
            Controls.Add(pnlTopBar);
            Name = "FrmSemicircle";
            Text = "Semicircle";
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlButtons.ResumeLayout(false);
            pnlGraphic.ResumeLayout(false);
            pnlGraphic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(picGraphic)).EndInit();
            pnlOutputs.ResumeLayout(false);
            pnlOutputs.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblShapeName;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblEntradas;
        private System.Windows.Forms.Panel pnlInputs;
        private System.Windows.Forms.Label lblProceso;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlGraphic;
        private System.Windows.Forms.Label lblGrafico;
        private System.Windows.Forms.PictureBox picGraphic;
        private System.Windows.Forms.Panel pnlOutputs;
        private System.Windows.Forms.Label lblSalidas;
        private System.Windows.Forms.Label lblPerimeter;
        private System.Windows.Forms.Label lblPerimeterValue;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblAreaValue;
    }
}
