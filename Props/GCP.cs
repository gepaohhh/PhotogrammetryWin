using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotogrammetryWin.Props
{
    internal class GCP
    {
        public double Xa = 0, Ya = 0, Za = 0;
        public double x = 0, y = 0;
        /// <summary>
        /// 地面控制点和像控点
        /// </summary>
        /// <param name="Xa"></param>
        /// <param name="Ya"></param>
        /// <param name="Za"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
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
