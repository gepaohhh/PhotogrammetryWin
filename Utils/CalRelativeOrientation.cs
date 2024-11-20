using PhotogrammetryWin.Props;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotogrammetryWin.Utils
{
    internal class CalRelativeOrientation
    {
        MatrixCal matrixCal = new MatrixCal();

        public double U = 0, V = 0;
        public Camera camera;

        private double[,] ATAInverseATL = new double[6, 1];
        private List<HomonymyPoint> homonymyPoints;
        private double Bx;
        Tools tools = new Tools();
        public int num = 0;

        public CalRelativeOrientation(List<HomonymyPoint> homonymyPoints, Camera camera, double Bx) {
            this.homonymyPoints = homonymyPoints;
            this.camera = camera;
            this.Bx = Bx;

            
            while (true)
            {
                if (num == 0)
                {
                    ATAInverseATL = calRelativeOrientation();
                }
                else
                {
                    if (Math.Abs(ATAInverseATL[0, 0]) < 0.0000001 &&
                        Math.Abs(ATAInverseATL[1, 0]) < 0.0000001 &&
                        Math.Abs(ATAInverseATL[2, 0]) < 0.0000001 &&
                        Math.Abs(ATAInverseATL[3, 0]) < 0.0000001 &&
                        Math.Abs(ATAInverseATL[4, 0]) < 0.0000001)
                    {
                        //Console.WriteLine("迭代：" + num + "次");
                        //Console.WriteLine("完成");
                        break;
                    }
                    else
                    {
                        ATAInverseATL = calRelativeOrientation();
                    }
                }
                num += 1;
            }
        }

        public double[,] calRelativeOrientation() {
            double[,] R = tools.calR(camera.phi, camera.omega, camera.kappa);
            double[,] A = new double[homonymyPoints.Count, 5];
            double[,] l = new double[homonymyPoints.Count, 1];

            for (int i = 0; i < homonymyPoints.Count; i++) {
                double X1 = homonymyPoints[i].Lx;
                double Y1 = homonymyPoints[i].Ly;
                double Z1 = -camera.f;
                double X2 = homonymyPoints[i].Rx*R[0,0] + homonymyPoints[i].Ry*R[0,1] - camera.f*R[0,2];
                double Y2 = homonymyPoints[i].Rx*R[1,0] + homonymyPoints[i].Ry*R[1,1] - camera.f*R[1,2];
                double Z2 = homonymyPoints[i].Rx*R[2,0] + homonymyPoints[i].Ry*R[2,1] - camera.f*R[2,2];

                A[i,0] = Z1 * X2 - X1 * Z2;
                A[i,1] = X1 * Y2 - X2 * Y1;
                A[i,2] = Y1 * X2;
                A[i,3] = Y1 * Y2 + Z1 * Z2;
                A[i,4] = -X2 * Z1;

                l[i,0] = -(Y1 * Z2 - Y2 * Z1) + U * (X1 * Z2 - X2 * Z1) - V * (X1 * Y2 - X2 * Y1);
            }
            ATAInverseATL =
                matrixCal.matrixMulti(
                        matrixCal.matrixMulti(
                                matrixCal.matrixInverse(
                                        matrixCal.matrixMulti(matrixCal.matrixT(A), A)
                                    ), matrixCal.matrixT(A)
                            ), l
                    );
            U += ATAInverseATL[0, 0];
            V += ATAInverseATL[1, 0];
            camera.phi += ATAInverseATL[2, 0];
            camera.omega += ATAInverseATL[3, 0];
            camera.kappa += ATAInverseATL[4, 0];
            return ATAInverseATL;
        }
    }
}
