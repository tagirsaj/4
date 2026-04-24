using OOP_lab4;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_lab4
{
    public partial class Form1 : Form // Обязательно наследование от Form!
    {
        private MyStorage storage = new MyStorage();
        private string currentTool = "Circle";

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // Чтобы форма ловила нажатия клавиш [cite: 98]

            // Если вы НЕ создавали кнопки в дизайнере, раскомментируйте SetupUI()
            // SetupUI(); 
        }

        // Обработка выбора инструмента (Круг/Квадрат)
        private void Tool_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton btn)
            {
                currentTool = btn.Tag.ToString();
                // Визуально отмечаем выбранную кнопку
                foreach (ToolStripItem item in toolStrip1.Items)
                    if (item is ToolStripButton b) b.Checked = (b == btn);
            }
        }

        private void pbCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            bool hitAny = false;
            foreach (var shape in storage.All())
            {
                if (shape.IsHit(e.Location))
                {
                    // Если Ctrl не нажат, снимаем выделение с других [cite: 58]
                    if (Control.ModifierKeys != Keys.Control) storage.UnselectAll();
                    shape.IsSelected = !shape.IsSelected;
                    hitAny = true;
                    break;
                }
            }

            if (!hitAny)
            {
                if (Control.ModifierKeys != Keys.Control) storage.UnselectAll();

                // Создание новой фигуры [cite: 98]
                Shape newShape = (currentTool == "Circle") ? new Circle() : new RectangleShape();
                newShape.X = e.X - newShape.Size / 2;
                newShape.Y = e.Y - newShape.Size / 2;
                storage.Add(newShape);
            }
            Refresh();
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in storage.All()) shape.Draw(e.Graphics);
        }

        // Управление клавиатурой: перемещение и удаление [cite: 98]
        protected override void OnKeyDown(KeyEventArgs e)
        {
            int dx = 0, dy = 0;
            if (e.KeyCode == Keys.Left) dx = -5;
            if (e.KeyCode == Keys.Right) dx = 5;
            if (e.KeyCode == Keys.Up) dy = -5;
            if (e.KeyCode == Keys.Down) dy = 5;

            if (dx != 0 || dy != 0)
            {
                foreach (var s in storage.All())
                    if (s.IsSelected && s.CanMove(dx, dy, pbCanvas.Size)) // Проверка границ [cite: 100]
                    {
                        s.X += dx; s.Y += dy;
                    }
            }

            if (e.KeyCode == Keys.Delete) storage.RemoveSelected(); // Удаление [cite: 58]

            Refresh();
        }
    }
}