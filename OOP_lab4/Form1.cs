using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_Lab4
{
    public partial class Form1 : Form
    {
        private MyStorage storage;
        private ToolStrip toolStrip;
        private ToolStripButton btnCircle;
        private ToolStripButton btnRectangle;
        private PictureBox pbCanvas;
        private string currentTool = "Circle";

        public Form1()
        {
            SetupUI();
            storage = new MyStorage();
        }

        private void SetupUI()
        {
            this.Text = "Визуальный редактор - Этап 2 (Только рисование)";
            this.Size = new Size(800, 600);

            toolStrip = new ToolStrip();
            btnCircle = new ToolStripButton("Круг") { Tag = "Circle", Checked = true };
            btnRectangle = new ToolStripButton("Квадрат") { Tag = "Rectangle" };

            btnCircle.Click += Tool_Click;
            btnRectangle.Click += Tool_Click;

            toolStrip.Items.Add(btnCircle);
            toolStrip.Items.Add(btnRectangle);

            pbCanvas = new PictureBox();
            pbCanvas.Dock = DockStyle.Fill;
            pbCanvas.BackColor = Color.White;
            pbCanvas.Paint += Canvas_Paint;
            pbCanvas.MouseClick += Canvas_MouseClick;

            this.Controls.Add(pbCanvas);
            this.Controls.Add(toolStrip);
        }

        private void Tool_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            currentTool = btn.Tag.ToString();

            btnCircle.Checked = (currentTool == "Circle");
            btnRectangle.Checked = (currentTool == "Rectangle");
        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            Shape newShape = null;
            if (currentTool == "Circle")
                newShape = new Circle(e.X, e.Y, 50);
            else if (currentTool == "Rectangle")
                newShape = new RectangleShape(e.X, e.Y, 50);

            if (newShape != null)
            {
                storage.Add(newShape);
                pbCanvas.Invalidate();
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < storage.Count; i++)
            {
                storage[i].Draw(e.Graphics);
            }
        }
    }
}