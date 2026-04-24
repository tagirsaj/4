namespace OOP_lab4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            btnCircle = new ToolStripButton();
            btnSquare = new ToolStripButton();
            pbCanvas = new PictureBox();
            colorDialog1 = new ColorDialog();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCanvas).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnCircle, btnSquare });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnCircle
            // 
            btnCircle.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCircle.Image = (Image)resources.GetObject("btnCircle.Image");
            btnCircle.ImageTransparentColor = Color.Magenta;
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(29, 24);
            btnCircle.Tag = "Circle";
            btnCircle.Text = "toolStripButton1";
            btnCircle.Click += Tool_Click;
            // 
            // btnSquare
            // 
            btnSquare.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSquare.Image = (Image)resources.GetObject("btnSquare.Image");
            btnSquare.ImageTransparentColor = Color.Magenta;
            btnSquare.Name = "btnSquare";
            btnSquare.Size = new Size(29, 24);
            btnSquare.Tag = "Rectangle";
            btnSquare.Text = "toolStripButton2";
            btnSquare.Click += Tool_Click;
            // 
            // pbCanvas
            // 
            pbCanvas.BackColor = SystemColors.Window;
            pbCanvas.Dock = DockStyle.Fill;
            pbCanvas.Location = new Point(0, 55);
            pbCanvas.Name = "pbCanvas";
            pbCanvas.Size = new Size(800, 395);
            pbCanvas.TabIndex = 1;
            pbCanvas.TabStop = false;
            pbCanvas.Paint += pbCanvas_Paint;
            pbCanvas.MouseClick += pbCanvas_MouseClick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(59, 24);
            toolStripMenuItem1.Text = "Файл";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(74, 24);
            toolStripMenuItem2.Text = "Правка";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(56, 24);
            toolStripMenuItem3.Text = "Цвет";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pbCanvas);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbCanvas).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btnCircle;
        private ToolStripButton btnSquare;
        private PictureBox pbCanvas;
        private ColorDialog colorDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
    }
}
