using PhotogrammetryWin.Props;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotogrammetryWin.Utils
{
    internal class CalRescetion
    {
        private List<GCP> gcps;
        public Camera camera;
        private double[,] ATAInverseATL = new double[6, 1];
        Tools tools = new Tools();
        public int num = 0;
        public CalRescetion(List<GCP> gcps, Camera camera)
        {
            this.gcps = gcps;
            this.camera = camera;

            
            while (true)
            {
                if (num == 0)
                {
                    ATAInverseATL = calResection();
                }
                else
                {
                    if (Math.Abs(ATAInverseATL[0, 0]) < 0.0000001 &&
                        Math.Abs(ATAInverseATL[1, 0]) < 0.0000001 &&
                        Math.Abs(ATAInverseATL[2, 0]) < 0.0000001 &&
                        Math.Abs(ATAInverseATL[3, 0]) < 0.0000001 &&
                        Math.Abs(ATAInverseATL[4, 0]) < 0.0000001 &&
                        Math.Abs(ATAInverseATL[5, 0]) < 0.0000001)
                    {
                        //Console.WriteLine("迭代：" + num + "次");
                        //Console.WriteLine("完成");
                        break;
                    }
                    else
                    {
                        ATAInverseATL = calResection();
                    }
                }
                num += 1;
            }
        }

        public double[,] calResection()
        {
            MatrixCal matrixCal = new MatrixCal();

            double[,] R = tools.calR(camera.phi, camera.omega, camera.kappa);
            double[,] A = new double[gcps.Count * 2, 6];
            double[,] l = new double[gcps.Count * 2, 1];
            for (int i = 0; i < gcps.Count; i++)
            {
                //地面控制点
                double XX = calXX(R, gcps[i], camera);
                double YY = calYY(R, gcps[i], camera);
                double ZZ = calZZ(R, gcps[i], camera);
                //系数矩阵
                //关于Vx
                A[2 * i, 0] = (R[0, 0] * camera.f + R[0, 2] * gcps[i].x) / ZZ;
                A[2 * i, 1] = (R[1, 0] * camera.f + R[1, 2] * gcps[i].x) / ZZ;
                A[2 * i, 2] = (R[2, 0] * camera.f + R[2, 2] * gcps[i].x) / ZZ;
                A[2 * i, 3] = gcps[i].y * Math.Sin(camera.omega) -
                    (
                        (
                            gcps[i].x * Math.Cos(camera.kappa) - gcps[i].y * Math.Sin(camera.kappa)
                        )
                        * gcps[i].x / camera.f + camera.f * Math.Cos(camera.kappa)
                    )
                    * Math.Cos(camera.omega);
                A[2 * i, 4] = -camera.f * Math.Sin(camera.kappa) -
                    (
                        gcps[i].x * Math.Sin(camera.kappa) + gcps[i].y * Math.Cos(camera.kappa)
                    )
                    * gcps[i].x / camera.f;
                A[2 * i, 5] = gcps[i].y;
                //关于Vy
                A[2 * i + 1, 0] = (R[0, 1] * camera.f + R[0, 2] * gcps[i].y) / ZZ;
                A[2 * i + 1, 1] = (R[1, 1] * camera.f + R[1, 2] * gcps[i].y) / ZZ;
                A[2 * i + 1, 2] = (R[2, 1] * camera.f + R[2, 2] * gcps[i].y) / ZZ;
                A[2 * i + 1, 3] = -gcps[i].x * Math.Sin(camera.omega) -
                    (
                        (
                            gcps[i].x * Math.Cos(camera.kappa) - gcps[i].y * Math.Sin(camera.kappa)
                        )
                        * gcps[i].y / camera.f - camera.f * Math.Sin(camera.kappa)
                    )
                    * Math.Cos(camera.omega);
                A[2 * i + 1, 4] = -camera.f * Math.Cos(camera.kappa) -
                    (
                        gcps[i].x * Math.Sin(camera.kappa) + gcps[i].y * Math.Cos(camera.kappa)
                    )
                    * gcps[i].y / camera.f;
                A[2 * i + 1, 5] = -gcps[i].x;
                //常数矩阵l
                l[2 * i, 0] = gcps[i].x + camera.f * XX / ZZ;
                l[2 * i + 1, 0] = gcps[i].y + camera.f * YY / ZZ;
            }
            //最小二乘求解
            ATAInverseATL =
                matrixCal.matrixMulti(
                        matrixCal.matrixMulti(
                                matrixCal.matrixInverse(
                                        matrixCal.matrixMulti(matrixCal.matrixT(A), A)
                                    ), matrixCal.matrixT(A)
                            ), l
                    );
            camera.Xs += ATAInverseATL[0, 0];
            camera.Ys += ATAInverseATL[1, 0];
            camera.Zs += ATAInverseATL[2, 0];
            camera.phi += ATAInverseATL[3, 0];
            camera.omega += ATAInverseATL[4, 0];
            camera.kappa += ATAInverseATL[5, 0];
            return ATAInverseATL;
        }

        //==============================================================================
        //public double[,] calR(double phi, double omega, double kappa)
        //{
        //    double[,] R = new double[3, 3];
        //    R[0, 0] = Math.Cos(phi) * Math.Cos(kappa) - Math.Sin(phi) * Math.Sin(omega) * Math.Sin(kappa);//a1
        //    R[0, 1] = -Math.Cos(phi) * Math.Sin(kappa) - Math.Sin(phi) * Math.Sin(omega) * Math.Cos(kappa);//a2
        //    R[0, 2] = -Math.Sin(phi) * Math.Cos(omega);//a3
        //    R[1, 0] = Math.Cos(omega) * Math.Sin(kappa);//b1
        //    R[1, 1] = Math.Cos(omega) * Math.Cos(kappa);//b2
        //    R[1, 2] = -Math.Sin(omega);//b3
        //    R[2, 0] = Math.Sin(phi) * Math.Cos(kappa) + Math.Cos(phi) * Math.Sin(omega) * Math.Sin(kappa);//c1
        //    R[2, 1] = -Math.Sin(phi) * Math.Sin(kappa) + Math.Cos(phi) * Math.Sin(omega) * Math.Cos(kappa);//c2
        //    R[2, 2] = Math.Cos(phi) * Math.Cos(omega);//c3
        //    return R;
        //}
        public double calXX(double[,] R, GCP gcp, Camera camera)
        {
            return R[0, 0] * (gcp.Xa - camera.Xs) + R[1, 0] * (gcp.Ya - camera.Ys) + R[2, 0] * (gcp.Za - camera.Zs);
        }
        public double calYY(double[,] R, GCP gcp, Camera camera)
        {
            return R[0, 1] * (gcp.Xa - camera.Xs) + R[1, 1] * (gcp.Ya - camera.Ys) + R[2, 1] * (gcp.Za - camera.Zs);
        }
        public double calZZ(double[,] R, GCP gcp, Camera camera)
        {
            return R[0, 2] * (gcp.Xa - camera.Xs) + R[1, 2] * (gcp.Ya - camera.Ys) + R[2, 2] * (gcp.Za - camera.Zs);
        }
    }
}
