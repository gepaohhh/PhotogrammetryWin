using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotogrammetryWin.Utils
{
    internal class Tools
    {
        public double[,] calR(double phi, double omega, double kappa)
        {
            double[,] R = new double[3, 3];
            R[0, 0] = Math.Cos(phi) * Math.Cos(kappa) - Math.Sin(phi) * Math.Sin(omega) * Math.Sin(kappa);//a1
            R[0, 1] = -Math.Cos(phi) * Math.Sin(kappa) - Math.Sin(phi) * Math.Sin(omega) * Math.Cos(kappa);//a2
            R[0, 2] = -Math.Sin(phi) * Math.Cos(omega);//a3
            R[1, 0] = Math.Cos(omega) * Math.Sin(kappa);//b1
            R[1, 1] = Math.Cos(omega) * Math.Cos(kappa);//b2
            R[1, 2] = -Math.Sin(omega);//b3
            R[2, 0] = Math.Sin(phi) * Math.Cos(kappa) + Math.Cos(phi) * Math.Sin(omega) * Math.Sin(kappa);//c1
            R[2, 1] = -Math.Sin(phi) * Math.Sin(kappa) + Math.Cos(phi) * Math.Sin(omega) * Math.Cos(kappa);//c2
            R[2, 2] = Math.Cos(phi) * Math.Cos(omega);//c3
            return R;
        }

        //度转度分秒
        public string degree2DMS(double deg) {
            deg = deg * 3600;//转为秒
            int angle = (int)deg;
            int d = angle / 3600;//提取度
            angle -= d * 3600;
            int m = angle / 60;//提取分
            double s = deg - d * 3600.0 - m * 60.0;//提取秒

            return d + "度" + m + "分" + s + "秒";
        }
    }
}
