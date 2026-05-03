namespace ShapesApp.Forms
{
    partial class FrmHome
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();

            this.tsmiBasicPolygons = new System.Windows.Forms.ToolStripMenuItem();
            this.miHexagonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miParallelogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miPentagonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miRectangleShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miRhombusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miSquareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miTrapezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miTriangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.tsmiCurvedShapes = new System.Windows.Forms.ToolStripMenuItem();
            this.miCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miCrescentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miEllipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miSemicircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.tsmiIrregularStars = new System.Windows.Forms.ToolStripMenuItem();
            this.miCrossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miKiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miPieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miScaleneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miStarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miTrefoilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.tsmiSpecialShapes = new System.Windows.Forms.ToolStripMenuItem();
            this.miArrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miCloudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miHeartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miOctagonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();

            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // menuStrip
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(90)))), ((int)(((byte)(160)))));
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.menuStrip.ForeColor = System.Drawing.Color.White;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiBasicPolygons,
            this.tsmiCurvedShapes,
            this.tsmiIrregularStars,
            this.tsmiSpecialShapes});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 4, 0, 4);
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(882, 33);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";

            // tsmiFile
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.tsmiFile.ForeColor = System.Drawing.Color.White;
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(48, 25);
            this.tsmiFile.Text = "File";

            // tsmiExit
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tsmiExit.Size = new System.Drawing.Size(175, 26);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);

            // tsmiBasicPolygons
            this.tsmiBasicPolygons.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHexagonToolStripMenuItem,
            this.miParallelogramToolStripMenuItem,
            this.miPentagonToolStripMenuItem,
            this.miRectangleShapeToolStripMenuItem,
            this.miRhombusToolStripMenuItem,
            this.miSquareToolStripMenuItem,
            this.miTrapezeToolStripMenuItem,
            this.miTriangleToolStripMenuItem});
            this.tsmiBasicPolygons.ForeColor = System.Drawing.Color.White;
            this.tsmiBasicPolygons.Name = "tsmiBasicPolygons";
            this.tsmiBasicPolygons.Size = new System.Drawing.Size(124, 25);
            this.tsmiBasicPolygons.Text = "Basic Polygons";

            // Basic Polygon items
            this.miHexagonToolStripMenuItem.Name = "miHexagonToolStripMenuItem";
            this.miHexagonToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.miHexagonToolStripMenuItem.Text = "Hexagon";
            this.miHexagonToolStripMenuItem.Click += new System.EventHandler(this.miHexagonToolStripMenuItem_Click);

            this.miParallelogramToolStripMenuItem.Name = "miParallelogramToolStripMenuItem";
            this.miParallelogramToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.miParallelogramToolStripMenuItem.Text = "Parallelogram";
            this.miParallelogramToolStripMenuItem.Click += new System.EventHandler(this.miParallelogramToolStripMenuItem_Click);

            this.miPentagonToolStripMenuItem.Name = "miPentagonToolStripMenuItem";
            this.miPentagonToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.miPentagonToolStripMenuItem.Text = "Pentagon";
            this.miPentagonToolStripMenuItem.Click += new System.EventHandler(this.miPentagonToolStripMenuItem_Click);

            this.miRectangleShapeToolStripMenuItem.Name = "miRectangleShapeToolStripMenuItem";
            this.miRectangleShapeToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.miRectangleShapeToolStripMenuItem.Text = "Rectangle";
            this.miRectangleShapeToolStripMenuItem.Click += new System.EventHandler(this.miRectangleShapeToolStripMenuItem_Click);

            this.miRhombusToolStripMenuItem.Name = "miRhombusToolStripMenuItem";
            this.miRhombusToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.miRhombusToolStripMenuItem.Text = "Rhombus";
            this.miRhombusToolStripMenuItem.Click += new System.EventHandler(this.miRhombusToolStripMenuItem_Click);

            this.miSquareToolStripMenuItem.Name = "miSquareToolStripMenuItem";
            this.miSquareToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.miSquareToolStripMenuItem.Text = "Square";
            this.miSquareToolStripMenuItem.Click += new System.EventHandler(this.miSquareToolStripMenuItem_Click);

            this.miTrapezeToolStripMenuItem.Name = "miTrapezeToolStripMenuItem";
            this.miTrapezeToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.miTrapezeToolStripMenuItem.Text = "Trapeze";
            this.miTrapezeToolStripMenuItem.Click += new System.EventHandler(this.miTrapezeToolStripMenuItem_Click);

            this.miTriangleToolStripMenuItem.Name = "miTriangleToolStripMenuItem";
            this.miTriangleToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.miTriangleToolStripMenuItem.Text = "Triangle";
            this.miTriangleToolStripMenuItem.Click += new System.EventHandler(this.miTriangleToolStripMenuItem_Click);

            // tsmiCurvedShapes
            this.tsmiCurvedShapes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCircleToolStripMenuItem,
            this.miCrescentToolStripMenuItem,
            this.miEllipseToolStripMenuItem,
            this.miSemicircleToolStripMenuItem});
            this.tsmiCurvedShapes.ForeColor = System.Drawing.Color.White;
            this.tsmiCurvedShapes.Name = "tsmiCurvedShapes";
            this.tsmiCurvedShapes.Size = new System.Drawing.Size(128, 25);
            this.tsmiCurvedShapes.Text = "Curved Shapes";

            // Curved Shapes items
            this.miCircleToolStripMenuItem.Name = "miCircleToolStripMenuItem";
            this.miCircleToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.miCircleToolStripMenuItem.Text = "Circle";
            this.miCircleToolStripMenuItem.Click += new System.EventHandler(this.miCircleToolStripMenuItem_Click);

            this.miCrescentToolStripMenuItem.Name = "miCrescentToolStripMenuItem";
            this.miCrescentToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.miCrescentToolStripMenuItem.Text = "Crescent";
            this.miCrescentToolStripMenuItem.Click += new System.EventHandler(this.miCrescentToolStripMenuItem_Click);

            this.miEllipseToolStripMenuItem.Name = "miEllipseToolStripMenuItem";
            this.miEllipseToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.miEllipseToolStripMenuItem.Text = "Ellipse";
            this.miEllipseToolStripMenuItem.Click += new System.EventHandler(this.miEllipseToolStripMenuItem_Click);

            this.miSemicircleToolStripMenuItem.Name = "miSemicircleToolStripMenuItem";
            this.miSemicircleToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.miSemicircleToolStripMenuItem.Text = "Semicircle";
            this.miSemicircleToolStripMenuItem.Click += new System.EventHandler(this.miSemicircleToolStripMenuItem_Click);

            // tsmiIrregularStars
            this.tsmiIrregularStars.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCrossToolStripMenuItem,
            this.miKiteToolStripMenuItem,
            this.miPieToolStripMenuItem,
            this.miScaleneToolStripMenuItem,
            this.miStarToolStripMenuItem,
            this.miTrefoilToolStripMenuItem});
            this.tsmiIrregularStars.ForeColor = System.Drawing.Color.White;
            this.tsmiIrregularStars.Name = "tsmiIrregularStars";
            this.tsmiIrregularStars.Size = new System.Drawing.Size(126, 25);
            this.tsmiIrregularStars.Text = "Irregular Stars";

            // Irregular Stars items
            this.miCrossToolStripMenuItem.Name = "miCrossToolStripMenuItem";
            this.miCrossToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.miCrossToolStripMenuItem.Text = "Cross";
            this.miCrossToolStripMenuItem.Click += new System.EventHandler(this.miCrossToolStripMenuItem_Click);

            this.miKiteToolStripMenuItem.Name = "miKiteToolStripMenuItem";
            this.miKiteToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.miKiteToolStripMenuItem.Text = "Kite";
            this.miKiteToolStripMenuItem.Click += new System.EventHandler(this.miKiteToolStripMenuItem_Click);

            this.miPieToolStripMenuItem.Name = "miPieToolStripMenuItem";
            this.miPieToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.miPieToolStripMenuItem.Text = "Pie";
            this.miPieToolStripMenuItem.Click += new System.EventHandler(this.miPieToolStripMenuItem_Click);

            this.miScaleneToolStripMenuItem.Name = "miScaleneToolStripMenuItem";
            this.miScaleneToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.miScaleneToolStripMenuItem.Text = "Scalene";
            this.miScaleneToolStripMenuItem.Click += new System.EventHandler(this.miScaleneToolStripMenuItem_Click);

            this.miStarToolStripMenuItem.Name = "miStarToolStripMenuItem";
            this.miStarToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.miStarToolStripMenuItem.Text = "Star";
            this.miStarToolStripMenuItem.Click += new System.EventHandler(this.miStarToolStripMenuItem_Click);

            this.miTrefoilToolStripMenuItem.Name = "miTrefoilToolStripMenuItem";
            this.miTrefoilToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.miTrefoilToolStripMenuItem.Text = "Trefoil";
            this.miTrefoilToolStripMenuItem.Click += new System.EventHandler(this.miTrefoilToolStripMenuItem_Click);

            // tsmiSpecialShapes
            this.tsmiSpecialShapes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miArrowToolStripMenuItem,
            this.miCloudToolStripMenuItem,
            this.miHeartToolStripMenuItem,
            this.miOctagonToolStripMenuItem});
            this.tsmiSpecialShapes.ForeColor = System.Drawing.Color.White;
            this.tsmiSpecialShapes.Name = "tsmiSpecialShapes";
            this.tsmiSpecialShapes.Size = new System.Drawing.Size(126, 25);
            this.tsmiSpecialShapes.Text = "Special Shapes";

            // Special Shapes items
            this.miArrowToolStripMenuItem.Name = "miArrowToolStripMenuItem";
            this.miArrowToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.miArrowToolStripMenuItem.Text = "Arrow";
            this.miArrowToolStripMenuItem.Click += new System.EventHandler(this.miArrowToolStripMenuItem_Click);

            this.miCloudToolStripMenuItem.Name = "miCloudToolStripMenuItem";
            this.miCloudToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.miCloudToolStripMenuItem.Text = "Cloud";
            this.miCloudToolStripMenuItem.Click += new System.EventHandler(this.miCloudToolStripMenuItem_Click);

            this.miHeartToolStripMenuItem.Name = "miHeartToolStripMenuItem";
            this.miHeartToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.miHeartToolStripMenuItem.Text = "Heart";
            this.miHeartToolStripMenuItem.Click += new System.EventHandler(this.miHeartToolStripMenuItem_Click);

            this.miOctagonToolStripMenuItem.Name = "miOctagonToolStripMenuItem";
            this.miOctagonToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.miOctagonToolStripMenuItem.Text = "Octagon";
            this.miOctagonToolStripMenuItem.Click += new System.EventHandler(this.miOctagonToolStripMenuItem_Click);

            // lblInstructions
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblInstructions.Location = new System.Drawing.Point(32, 141);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(571, 80);
            this.lblInstructions.TabIndex = 2;
            this.lblInstructions.Text = "Select a shape group from the menu to open a geometric shape.";

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.lblSubtitle.Location = new System.Drawing.Point(110, 83);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(146, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "20 geometric shapes";

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.lblTitle.Location = new System.Drawing.Point(107, 37);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(167, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Shapes App";

            // picLogo
            this.picLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(90)))), ((int)(((byte)(160)))));
            this.picLogo.Location = new System.Drawing.Point(32, 37);
            this.picLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(59, 69);
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;

            // pnlMain
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.pnlMain.Controls.Add(this.picLogo);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblSubtitle);
            this.pnlMain.Controls.Add(this.lblInstructions);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 33);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(23, 27, 23, 27);
            this.pnlMain.Size = new System.Drawing.Size(882, 520);
            this.pnlMain.TabIndex = 1;

            // FrmHome
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shapes App - Home";
            this.Load += new System.EventHandler(this.FrmHome_Load);

            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;

        private System.Windows.Forms.ToolStripMenuItem tsmiBasicPolygons;
        private System.Windows.Forms.ToolStripMenuItem miHexagonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miParallelogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miPentagonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miRectangleShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miRhombusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miSquareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miTrapezeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miTriangleToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem tsmiCurvedShapes;
        private System.Windows.Forms.ToolStripMenuItem miCircleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miCrescentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miEllipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miSemicircleToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem tsmiIrregularStars;
        private System.Windows.Forms.ToolStripMenuItem miCrossToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miKiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miPieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miScaleneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miStarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miTrefoilToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem tsmiSpecialShapes;
        private System.Windows.Forms.ToolStripMenuItem miArrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miCloudToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miHeartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miOctagonToolStripMenuItem;

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlMain;
    }
}
