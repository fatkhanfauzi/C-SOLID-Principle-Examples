using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_substitution_Principle
{
    class Program
    {
        //http://www.codecompiled.com/liskov-substitution-principle-in-c/
        static void Main(string[] args)
        {
            Quadrilaterals rect = new Rectangle();
            rect.Height = 10;
            rect.Width = 2;
            Console.WriteLine(rect.CalculateArea());

            // Below instantiation can be returned by some factory method
            Quadrilaterals rect1 = new Square();
            rect1.Height = 10;
            rect1.Width = 5;
            Console.WriteLine(rect1.CalculateArea());

            Console.Read();
        }

        public class Quadrilaterals
        {
            public virtual int Height { get; set; }
            public virtual int Width { get; set; }

            public virtual int CalculateArea()
            {
                return this.Height * this.Width;
            }
        }

        public class Rectangle : Quadrilaterals
        {
            public override int Width
            {
                get { return base.Width; }
                set { base.Width = value; }
            }
            public override int Height
            {
                get { return base.Height; }
                set { base.Height = value; }
            }
        }

        public class Square : Quadrilaterals
        {
            public override int Height
            {
                get { return base.Height; }
                set
                {
                    base.Height = value;
                    base.Width = value;
                }
            }

            public override int Width
            {
                get { return base.Width; }
                set
                {
                    base.Height = value;
                    base.Width = value;
                }
            }
        }
    }
}
