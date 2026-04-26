namespace _2dShapesGroup.Forms
{
    partial class FrmAllShapes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlInputs;
        private System.Windows.Forms.Panel pnlGraphic;
        private System.Windows.Forms.Panel pnlOutputs;
        private System.Windows.Forms.Panel pnlButtons;

        private System.Windows.Forms.PictureBox picGraphic;
        private System.Windows.Forms.Label lblPerimeter;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnChooseColor;
        private System.Windows.Forms.Button btnChooseOutlineColor;
        private System.Windows.Forms.Label lblFillColor;
        private System.Windows.Forms.Label lblOutlineColor;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Panel Principal - Inputs
            pnlInputs = new System.Windows.Forms.Panel();
            pnlInputs.Dock = System.Windows.Forms.DockStyle.Left;
            pnlInputs.Width = 200;
            pnlInputs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlInputs.AutoScroll = true;

            // Panel Central - Graphic
            pnlGraphic = new System.Windows.Forms.Panel();
            pnlGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlGraphic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            picGraphic = new System.Windows.Forms.PictureBox();
            picGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            picGraphic.BackColor = System.Drawing.Color.White;
            picGraphic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pnlGraphic.Controls.Add(picGraphic);

            // Panel Derecho - Outputs
            pnlOutputs = new System.Windows.Forms.Panel();
            pnlOutputs.Dock = System.Windows.Forms.DockStyle.Right;
            pnlOutputs.Width = 200;
            pnlOutputs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlOutputs.Padding = new System.Windows.Forms.Padding(10);

            lblPerimeter = new System.Windows.Forms.Label();
            lblPerimeter.Text = "Perímetro: 0";
            lblPerimeter.Dock = System.Windows.Forms.DockStyle.Top;
            lblPerimeter.Height = 40;
            lblPerimeter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblPerimeter.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            lblArea = new System.Windows.Forms.Label();
            lblArea.Text = "Área: 0";
            lblArea.Dock = System.Windows.Forms.DockStyle.Top;
            lblArea.Height = 40;
            lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblArea.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            lblFillColor = new System.Windows.Forms.Label();
            lblFillColor.Text = "Color Relleno:";
            lblFillColor.Dock = System.Windows.Forms.DockStyle.Top;
            lblFillColor.Height = 20;
            lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            btnChooseColor = new System.Windows.Forms.Button();
            btnChooseColor.Text = "Seleccionar";
            btnChooseColor.Dock = System.Windows.Forms.DockStyle.Top;
            btnChooseColor.Height = 30;
            btnChooseColor.Click += BtnChooseColor_Click;

            lblOutlineColor = new System.Windows.Forms.Label();
            lblOutlineColor.Text = "Color Contorno:";
            lblOutlineColor.Dock = System.Windows.Forms.DockStyle.Top;
            lblOutlineColor.Height = 20;
            lblOutlineColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            btnChooseOutlineColor = new System.Windows.Forms.Button();
            btnChooseOutlineColor.Text = "Seleccionar";
            btnChooseOutlineColor.Dock = System.Windows.Forms.DockStyle.Top;
            btnChooseOutlineColor.Height = 30;
            btnChooseOutlineColor.Click += BtnChooseOutlineColor_Click;

            pnlOutputs.Controls.Add(btnChooseOutlineColor);
            pnlOutputs.Controls.Add(lblOutlineColor);
            pnlOutputs.Controls.Add(btnChooseColor);
            pnlOutputs.Controls.Add(lblFillColor);
            pnlOutputs.Controls.Add(lblArea);
            pnlOutputs.Controls.Add(lblPerimeter);

            // Panel Bottom - Buttons
            pnlButtons = new System.Windows.Forms.Panel();
            pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlButtons.Height = 60;
            pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlButtons.Padding = new System.Windows.Forms.Padding(5);

            btnCalculate = new System.Windows.Forms.Button();
            btnCalculate.Text = "Calcular";
            btnCalculate.Width = 80;
            btnCalculate.Location = new System.Drawing.Point(5, 5);
            btnCalculate.Click += BtnCalculate_Click;

            btnReset = new System.Windows.Forms.Button();
            btnReset.Text = "Limpiar";
            btnReset.Width = 80;
            btnReset.Location = new System.Drawing.Point(90, 5);
            btnReset.Click += BtnReset_Click;

            btnExit = new System.Windows.Forms.Button();
            btnExit.Text = "Salir";
            btnExit.Width = 80;
            btnExit.Location = new System.Drawing.Point(175, 5);
            btnExit.Click += BtnExit_Click;

            pnlButtons.Controls.Add(btnCalculate);
            pnlButtons.Controls.Add(btnReset);
            pnlButtons.Controls.Add(btnExit);

            // Main Form
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(pnlGraphic);
            this.Controls.Add(pnlOutputs);
            this.Controls.Add(pnlInputs);
            this.Controls.Add(pnlButtons);
            this.Text = "2D Shapes - Figura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(800, 400);

            ResumeLayout(false);
        }

        #endregion
    }
}
