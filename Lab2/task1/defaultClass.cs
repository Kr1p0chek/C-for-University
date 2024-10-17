using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_1_C__
{
    public class defaultClass
    {
        private int x, y, z;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int Z { get { return z; } set { z = value; } }

        public defaultClass()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
        
        public defaultClass(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public defaultClass(defaultClass prevObj)
        {
            this.x = prevObj.x;
            this.y = prevObj.y;
            this.z = prevObj.z;
        }

        public override string ToString() //перегрузка оператора
        {
            return "x = " + this.x + ", y = " + this.y + ", z = " + this.z;
        }

        public int GetProduct()
        {
            return this.x * this.y * this.z;
        }
    }
}
