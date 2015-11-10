using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_substitution_Principle
{
    class WrongExProgram
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle();
            rect.setHeight(10);
            rect.setWidth(12);
            Console.WriteLine(rect.CalculateArea());

            // Below instantiation can be returned by some factory method
            Rectangle rect1 = new Square();
            rect1.setHeight(10);
            rect1.setWidth(12);
            Console.WriteLine(rect1.CalculateArea());

            Console.Read();
        }

        public class Rectangle
        {
            protected int _width;
            protected int _height;

            public int Width
            {
                get { return _width; }
            }

            public int Height
            {
                get { return _height; }
            }

            public virtual void setWidth(int width)
            {
                _width = width;
            }

            public virtual void setHeight(int height)
            {
                _height = height;
            }

            public int CalculateArea()
            {
                return _width * _height;
            }
        }

        public class Square : Rectangle
        {
            public override void setWidth(int width)
            {
                _width = width;
                _height = width;
            }

            public override void setHeight(int height)
            {
                _width = height;
                _height = height;
            }
        }
    }
}
