using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotogrammetryWin.Props
{
    /// <summary>
    /// 全局控制点 Global Control Point
    /// </summary>
    internal class GCP
    {
        public double Xa = 0, Ya = 0, Za = 0;
        public double x = 0, y = 0;
        public GCP(double Xa, double Ya, double Za, double x, double y)
        {
            this.Xa = Xa * 1000;
            this.Ya = Ya * 1000;
            this.Za = Za * 1000;
            this.x = x;
            this.y = y;
        }
    }
}
