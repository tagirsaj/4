using System;
using System.Drawing;
namespace OOP_lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


public abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public Color ShapeColor { get; set; }
        public bool IsSelected { get; set; }

        public Shape(int x, int y, int size)
        {
            X = x; Y = y; Size = size;
            ShapeColor = Color.Blue;
            IsSelected = false;
        }

        public abstract void Draw(Graphics g);
        public abstract bool Contains(Point p);

        public virtual void Move(int dx, int dy, int boundsWidth, int boundsHeight)
        {
            int newX = X + dx;
            int newY = Y + dy;

            if (newX - Size / 2 >= 0 && newX + Size / 2 <= boundsWidth) X = newX;
            if (newY - Size / 2 >= 0 && newY + Size / 2 <= boundsHeight) Y = newY;
        }

        public void Resize(int dSize)
        {
            if (Size + dSize > 5) Size += dSize;
        }
    }

    public class Circle : Shape
    {
        public Circle(int x, int y, int size) : base(x, y, size) { }

        public override void Draw(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(ShapeColor))
            {
                g.FillEllipse(brush, X - Size / 2, Y - Size / 2, Size, Size);
            }
            if (IsSelected)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    g.DrawRectangle(pen, X - Size / 2, Y - Size / 2, Size, Size);
                }
            }
        }

        public override bool Contains(Point p)
        {
            int dx = p.X - X;
            int dy = p.Y - Y;
            return (dx * dx + dy * dy) <= (Size / 2 * Size / 2);
        }
    }

    public class RectangleShape : Shape
    {
        public RectangleShape(int x, int y, int size) : base(x, y, size) { }

        public override void Draw(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(ShapeColor))
            {
                g.FillRectangle(brush, X - Size / 2, Y - Size / 2, Size, Size);
            }
            if (IsSelected)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    g.DrawRectangle(pen, X - Size / 2 - 2, Y - Size / 2 - 2, Size + 4, Size + 4);
                }
            }
        }

        public override bool Contains(Point p)
        {
            return p.X >= X - Size / 2 && p.X <= X + Size / 2 &&
                   p.Y >= Y - Size / 2 && p.Y <= Y + Size / 2;
        }
    }

    public class MyStorage
    {
        private Shape[] items;
        private int count;

        public MyStorage(int capacity = 100)
        {
            items = new Shape[capacity];
            count = 0;
        }

        public int GetCount() => count;
        public Shape GetObject(int index) => items[index];

        public void Add(Shape shape)
        {
            if (count < items.Length)
            {
                items[count] = shape;
                count++;
            }
        }

        public void RemoveSelected()
        {
            int newCount = 0;
            for (int i = 0; i < count; i++)
            {
                if (!items[i].IsSelected)
                {
                    items[newCount] = items[i];
                    newCount++;
                }
            }
            count = newCount;
        }
    }
}
}
