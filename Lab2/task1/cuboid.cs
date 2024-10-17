using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_1_C__
{
    public class Cuboid : defaultClass
    {
        public Cuboid() : base() { }
    
        public Cuboid(int length, int width, int height) : base(length, width, height)
        {
            if (length < 0 || width < 0 || height < 0)
            {
                throw new ArgumentException("Длинна, ширина и высота должны быть положительными числами");
            }
        }

        public Cuboid (Cuboid other) : base(other)
        {
            if (X < 0 || Y < 0 || Z < 0)
            {
                throw new ArgumentException();
            }
        }

        public int GetVolume() { if (base.GetProduct() > 0) return base.GetProduct(); else throw new OverflowException(); }
        public int GetSurfaceArea()
        {
            return 2 * (X * Y + Y * Z + X * Z);
        }

        public double GetSimCub()
        {
            return Math.Cbrt(Convert.ToDouble(GetVolume()));
        }
        public override string ToString()
        {
            return $"Это прямоугольный параллелепипед со сторонами ({X}, {Y}, {Z})";
        }
    }
}
