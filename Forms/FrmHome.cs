using System;
using System.Windows.Forms;
using ShapesApp.Forms.BasicPolygons;
using ShapesApp.Forms.CurvedShapes;
using ShapesApp.Forms.IrregularStars;
using ShapesApp.Forms.SpecialShapes;

namespace ShapesApp.Forms
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
        }

        private void HideMainPanelAndCloseOthers()
        {
            pnlMain.Visible = false;
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        // Basic Polygons
        private void miHexagonToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmHexagon frm = new FrmHexagon(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miParallelogramToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmParallelogram frm = new FrmParallelogram(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miPentagonToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmPentagon frm = new FrmPentagon(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miRectangleShapeToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmRectangleShape frm = new FrmRectangleShape(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miRhombusToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmRhombus frm = new FrmRhombus(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miSquareToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmSquare frm = new FrmSquare(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miTrapezeToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmTrapeze frm = new FrmTrapeze(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miTriangleToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmTriangle frm = new FrmTriangle(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        // Curved Shapes
        private void miCircleToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmCircle frm = new FrmCircle(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miCrescentToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmCrescent frm = new FrmCrescent(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miEllipseToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmEllipse frm = new FrmEllipse(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miSemicircleToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmSemicircle frm = new FrmSemicircle(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        // Irregular Stars
        private void miCrossToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmCross frm = new FrmCross(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miKiteToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmKite frm = new FrmKite(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miPieToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmPie frm = new FrmPie(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miScaleneToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmScalene frm = new FrmScalene(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miStarToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmStar frm = new FrmStar(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miTrefoilToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmTrefoil frm = new FrmTrefoil(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        // Special Shapes
        private void miArrowToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmArrow frm = new FrmArrow(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miCloudToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmCloud frm = new FrmCloud(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miHeartToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmHeart frm = new FrmHeart(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }

        private void miOctagonToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            HideMainPanelAndCloseOthers();
            FrmOctagon frm = new FrmOctagon(); 
            frm.MdiParent = this; 
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(); 
        }
    }
}