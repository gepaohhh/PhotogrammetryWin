using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotogrammetryWin.Props
{
    internal class Camera
    {
        public double Xs = 0, Ys = 0, Zs = 0;
        public double phi = 0, omega = 0, kappa = 0;
        public double f = 0;
        /// <summary>
        /// 相机内外方位元素
        /// </summary>
        /// <param name="Xs"></param>
        /// <param name="Ys"></param>
        /// <param name="Zs"></param>
        /// <param name="phi"></param>
        /// <param name="omega"></param>
        /// <param name="kappa"></param>
        /// <param name="f"></param>
        public Camera(double Xs, double Ys, double Zs, double phi, double omega, double kappa, double f)
        {
            this.Xs = Xs;
            this.Ys = Ys;
            this.Zs = Zs;
            this.phi = phi;
            this.omega = omega;
            this.kappa = kappa;
            this.f = f;
        }
        public Camera() { }
    }
}
