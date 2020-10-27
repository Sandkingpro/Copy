using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Serialization;
using Lab3;

namespace Lab3
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Square))]
    [XmlInclude(typeof(Ellipse))]
    public abstract class Figure
    {
        public int x;
        public int y;
        public double thickness;
        public int Center_x = Console.WindowWidth / 2;
        public int Center_y = Console.WindowHeight / 2;
        public abstract double Area();
        public abstract string Type();
        public Figure() { }
    }
    public class Circle : Figure
    {
        public int radius;
        public Circle CreateCircle()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите радиус круга:");
                    radius = Convert.ToInt32(Console.ReadLine());
                    while (radius > Console.WindowHeight / 2 || radius > Console.WindowWidth / 2 || radius <= 1)
                    {
                        Console.WriteLine("Радиус больше размеров консоли или меньше либо равен нулю.Введите другой радиус.");
                        radius = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Введите толщину рамки:");
                    thickness = Convert.ToInt32(Console.ReadLine());
                    while (thickness <= 0)
                    {
                        Console.WriteLine("Невозможно иметь отрицательную толщину.Введите корректную толщину");
                        thickness = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод данных.");
                }
            }
            return this;

        }
        public override double Area()
        {
            return Math.PI * radius * radius;
        }
        public override string Type()
        {
            return "Круг";
        }
        public void CircletoConsole(Circle circle)
        {
            base.ToConsole();
            circle.x = 0;
            for (circle.y = 0; circle.y <= circle.radius; ++y)
            {
                circle.x = (int)Math.Sqrt(Math.Pow(circle.radius, 2) - Math.Pow(circle.y, 2));
                Console.SetCursorPosition(Center_x + circle.x, Center_y + circle.y);
                Console.WriteLine("*");
                Console.SetCursorPosition(Center_x + circle.x, Center_y - circle.y);
                Console.WriteLine("*");
                Console.SetCursorPosition(Center_x - circle.x, Center_y - circle.y);
                Console.WriteLine("*");
                Console.SetCursorPosition(Center_x - circle.x, Center_y + circle.y);
                Console.WriteLine("*");
            }
            Console.ReadKey();
            Console.WriteLine("Нажмите чтобы стереть круг.");
            Console.Clear();

        }

    }
    public class Square : Figure
    {
        public int a;
        public Square CreateSquare()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите длину стороны квадрата:");
                    a = Convert.ToInt32(Console.ReadLine());
                    while (a > Console.WindowHeight / 2 || a > Console.WindowWidth / 2 || a <= 1)
                    {
                        Console.WriteLine("Сторона квадрата больше размеров консоли или меньше либо равен единице.Введите правильные данные.");
                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Введите толщину рамки:");
                    thickness = Convert.ToInt32(Console.ReadLine());
                    while (thickness <= 0)
                    {
                        Console.WriteLine("Невозможно иметь отрицательную толщину.Введите корректную толщину");
                        thickness = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод данных.");
                }
            }
            return this;
        }
        public override double Area()
        {
            return a * a;
        }
        public override string Type()
        {
            return "Квадрат";
        }
        public void SquaretoConsole(Square square)
        {
            string s1 = new string('*', square.a);
            var s = String.Join(" ", s1.ToCharArray());
            string s2 = new string(' ', square.a * 2 - 3);
            Console.SetCursorPosition(Center_x - square.a, Center_y + square.a / 2);
            Console.Write(s);
            for (int i = 0; i < square.a - 2; i++)
            {
                Console.SetCursorPosition(Center_x - square.a, Center_y + (square.a / 2) - i - 1);
                Console.Write("*" + s2 + "*");
            }
            Console.WriteLine();
            Console.SetCursorPosition(Center_x - square.a, Center_y + 1 - square.a / 2);
            Console.Write(s);
            Console.ReadKey();
            Console.Clear();
        }
    }
    public class Rectangle : Figure
    {
        public int a;
        public int b;
        public Rectangle CreateRectangle()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите ширину прямоугольника:");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите высоту прямоугольнмка:");
                    b = Convert.ToInt32(Console.ReadLine());
                    while (b > Console.WindowHeight / 2 || a > Console.WindowWidth / 2 || a <= 1 || b <= 1)
                    {
                        Console.WriteLine("Стороны прямоугольника больше размеров консоли или меньше либо равен единице.Введите правильные данные.");
                        return CreateRectangle();
                    }

                    Console.WriteLine("Введите толщину рамки:");
                    thickness = Convert.ToInt32(Console.ReadLine());
                    while (thickness <= 0)
                    {
                        Console.WriteLine("Невозможно иметь отрицательную толщину.Введите корректную толщину");
                        thickness = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод данных.");
                }
            }
            return this;
        }
        public override double Area()
        {
            return a * b;
        }
        public override string Type()
        {
            return "Прямоугольник";
        }
        public void RectangletoConsole(Rectangle rectangle)
        {
            string s1 = new string('*', rectangle.a);
            var s = String.Join(" ", s1.ToCharArray());
            string s2 = new string(' ', 2 * rectangle.a - 3);
            Console.SetCursorPosition(Center_x - rectangle.a, Center_y + rectangle.b / 2);
            Console.Write(s);
            for (int i = 0; i < rectangle.b - 2; i++)
            {
                Console.SetCursorPosition(Center_x - rectangle.a, Center_y + rectangle.b / 2 - i - 1);
                Console.Write("*" + s2 + "*");
            }
            Console.SetCursorPosition(Center_x - rectangle.a, Center_y + 1 - rectangle.b / 2);
            Console.Write(s);
            Console.ReadKey();
            Console.Clear();
        }
    }
    public class Ellipse : Figure
    {
        public int a;
        public int b;
        public Ellipse CreateEllipse()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите большую полуось:");
                    a = Convert.ToInt32(Console.ReadLine());
                    x = a;
                    Console.WriteLine("Введите малую полуось(:");
                    b = Convert.ToInt32(Console.ReadLine());
                    y = b;
                    while (b >= Console.WindowHeight / 2 || a >= Console.WindowWidth / 2 || a <= 1 || b <= 1)
                    {
                        Console.WriteLine("Полуоси больше размеров консоли или меньше либо равен единице.Введите правильные данные.");
                        return CreateEllipse();
                    }

                    Console.WriteLine("Введите толщину рамки:");
                    thickness = Convert.ToInt32(Console.ReadLine());
                    while (thickness <= 0)
                    {
                        Console.WriteLine("Невозможно иметь отрицательную толщину.Введите корректную толщину");
                        thickness = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод данных.");
                }
            }
            return this;
        }
        public override double Area()
        {
            return Math.PI * a * b;
        }
        public override string Type()
        {
            return "Эллипс";
        }
        public void EllipsetoConsole(Ellipse ellipse)
        {
            if (ellipse.a > ellipse.b)
            {
                ellipse.x = 0;
                ellipse.y = 0;
                for (int i = 0; i < ellipse.a; i++)
                {
                    ellipse.x = (int)Math.Sqrt((Math.Pow(ellipse.a, 2) * Math.Pow(ellipse.b, 2) - Math.Pow(ellipse.a, 2) * Math.Pow(ellipse.y, 2)) / Math.Pow(ellipse.b, 2));
                    if (ellipse.x < 0)
                    {
                        break;
                    }
                    Console.SetCursorPosition(Center_x + ellipse.x, Center_y + i);
                    Console.WriteLine("*");
                    Console.SetCursorPosition(Center_x + ellipse.x, Center_y - i);
                    Console.WriteLine("*");
                    Console.SetCursorPosition(Center_x - ellipse.x, Center_y - i);
                    Console.WriteLine("*");
                    Console.SetCursorPosition(Center_x - ellipse.x, Center_y + i);
                    Console.WriteLine("*");
                    ellipse.y += 1;
                }
            }
            else
            {
                ellipse.x = 0;
                ellipse.y = 0;
                for (int i = 0; i < ellipse.b; i++)
                {
                    ellipse.x = (int)Math.Sqrt((Math.Pow(ellipse.a, 2) * Math.Pow(ellipse.b, 2) - Math.Pow(ellipse.a, 2) * Math.Pow(ellipse.y, 2)) / Math.Pow(ellipse.b, 2));
                    if (ellipse.x < 0)
                    {
                        break;
                    }
                    Console.SetCursorPosition(Center_x + ellipse.x, Center_y + i);
                    Console.WriteLine("*");
                    Console.SetCursorPosition(Center_x + ellipse.x, Center_y - i);
                    Console.WriteLine("*");
                    Console.SetCursorPosition(Center_x - ellipse.x, Center_y - i);
                    Console.WriteLine("*");
                    Console.SetCursorPosition(Center_x - ellipse.x, Center_y + i);
                    Console.WriteLine("*");
                    ellipse.y += 1;
                }
            }

            Console.ReadKey();
            Console.WriteLine("Нажмите чтобы стереть эллипс.");
            Console.Clear();
        }

    }
    class SquareComparer : IComparer<Figure>
    {
        public int Compare(Figure x, Figure y)
        {
            if (x.Area() > y.Area())
            {
                return 1;
            }
            else if (x.Area() < y.Area())
            {
                return -1;
            }
            else
            {
                if (x.thickness > y.thickness)
                {
                    return 1;
                }
                else if (x.thickness < y.thickness)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
    public class Figures
    {
        public List<Figure> Item = new List<Figure>();
    }
    class GraphicsEditor
    {
        static double AverageArea;
        static void Calculation(Figures figures)
        {
            double sum = 0;
            foreach (Figure s in figures.Item)
            {
                sum += s.Area();
            }
            AverageArea = sum / figures.Item.Count;
        }
        static void Main()
        {
            string a;
            Figures figures = new Figures();
            while (true)
            {
                Console.WriteLine("Введите данные с экрана:");
                Console.WriteLine("1-Создать фигуру круг.");
                Console.WriteLine("2-Создать фигуру квадрат.");
                Console.WriteLine("3-Создать фигуру прямоугольник.");
                Console.WriteLine("4-Создать фигуру эллипс.");
                Console.WriteLine("5-Exit");
                a = Console.ReadLine();
                if (a == "1")
                {
                    Circle circle1 = new Circle();
                    circle1.CreateCircle();
                    figures.Item.Add(circle1);
                    Calculation(figures);
                    Console.WriteLine("Средняя площадь:{0}", AverageArea);
                }
                if (a == "2")
                {
                    Square square1 = new Square();
                    square1.CreateSquare();
                    figures.Item.Add(square1);
                    Calculation(figures);
                    Console.WriteLine("Средняя площадь:{0}",AverageArea);
                }
                if (a == "3")
                {
                    Rectangle rectangle1 = new Rectangle();
                    rectangle1.CreateRectangle();
                    figures.Item.Add(rectangle1);
                    Calculation(figures);
                    Console.WriteLine("Средняя площадь:{0}", AverageArea);
                }
                if (a == "4")
                {
                    Ellipse ellipse1 = new Ellipse();
                    ellipse1.CreateEllipse();
                    figures.Item.Add(ellipse1);
                    Calculation(figures);
                    Console.WriteLine("Средняя площадь:{0}", AverageArea);
                }
                if (a == "5")
                {
                    if (figures.Item.Count >= 5)
                    {
                        SquareComparer sc = new SquareComparer();
                        figures.Item.Sort(sc);
                        for (int i = 0; i < figures.Item.Count; i++)
                        {
                            Console.WriteLine("Type:{0},Area:{1},Thickness:{2}", figures.Item[i].Type(), figures.Item[i].Area(), figures.Item[i].thickness);
                        }
                        Console.ReadKey();
                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine("Type:{0}", figures.Item[i].Type());
                        }
                        Console.ReadKey();
                        Xml_file(figures);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Создайте 5 фигур или больше");
                    }
                }
                static void Xml_file(Figures figures)
                {
                    var serializer = new XmlSerializer(typeof(List<Figure>));
                    using (FileStream fs = new FileStream(@"D://data.xml", FileMode.OpenOrCreate))
                    {
                        serializer.Serialize(fs, figures.Item);
                    }
                    using (FileStream fs = new FileStream(@"D://data.xml", FileMode.Open))
                    {
                        using var sr = new StreamReader(fs);
                        Console.WriteLine(sr.ReadToEnd());   
                    }
                }
            }
        }
    }
}


