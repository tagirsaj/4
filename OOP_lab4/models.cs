using System;
using System.Drawing;
using System.Collections.Generic;

namespace OOP_lab4
{
    // Базовый абстрактный класс фигуры 
    public abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; } = 60;
        public bool IsSelected { get; set; } = false;

        // Общий метод проверки выхода за границы [cite: 100]
        public bool CanMove(int dx, int dy, Size containerSize)
        {
            int nextX = X + dx;
            int nextY = Y + dy;
            return nextX >= 0 && nextY >= 0 &&
                   (nextX + Size) <= containerSize.Width &&
                   (nextY + Size) <= containerSize.Height;
        }

        public abstract void Draw(Graphics g);
        public abstract bool IsHit(Point p); // Проверка попадания мышки [cite: 73]
    }

    public class Circle : Shape
    {
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(IsSelected ? Color.Red : Color.Black, IsSelected ? 3 : 1))
            {
                g.DrawEllipse(pen, X, Y, Size, Size);
            }
        }
        public override bool IsHit(Point p)
        {
            double centerX = X + Size / 2.0;
            double centerY = Y + Size / 2.0;
            double dist = Math.Sqrt(Math.Pow(p.X - centerX, 2) + Math.Pow(p.Y - centerY, 2));
            return dist <= Size / 2.0;
        }
    }

    public class RectangleShape : Shape
    {
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(IsSelected ? Color.Red : Color.Black, IsSelected ? 3 : 1))
            {
                g.DrawRectangle(pen, X, Y, Size, Size);
            }
        }
        public override bool IsHit(Point p)
        {
            return p.X >= X && p.X <= X + Size && p.Y >= Y && p.Y <= Y + Size;
        }
    }

    // Собственный контейнер объектов из Л.Р.3 [cite: 59, 99]
    public class MyStorage
    {
        private List<Shape> shapes = new List<Shape>();
        public void Add(Shape s) => shapes.Add(s);
        public void RemoveSelected() => shapes.RemoveAll(s => s.IsSelected);
        public IEnumerable<Shape> All() => shapes;
        public void UnselectAll() { foreach (var s in shapes) s.IsSelected = false; }
    }
}