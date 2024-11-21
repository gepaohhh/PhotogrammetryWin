using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotogrammetryWin.Utils
{
    internal class MatrixCal
    {
        /// <summary>
        /// 矩阵转置
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public double[,] matrixT(double[,] a)
        {
            int row = a.GetLength(0);
            int col = a.GetLength(1);
            //存入临时矩阵
            double[,] tempMatrix = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    tempMatrix[i, j] = a[i, j];
                }
            }
            //转置矩阵
            double[,] tMatrix = new double[col, row];
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    tMatrix[i, j] = tempMatrix[j, i];
                }
            }
            return tMatrix;
        }
        /// <summary>
        /// 矩阵相乘
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public double[,] matrixMulti(double[,] left, double[,] right)
        {
            int row = left.GetLength(0);
            int col = right.GetLength(1);

            int leftCol = left.GetLength(1);
            int rightCol = right.GetLength(0);
            if (leftCol != rightCol)
            {
                Console.WriteLine("无法相乘");
                return null;
            }
            else
            {
                double[,] multiMatrix = new double[row, col];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        for (int k = 0; k < leftCol; k++)
                        {
                            multiMatrix[i, j] += left[i, k] * right[k, j];
                        }
                    }
                }
                return multiMatrix;
            }
        }
        /// <summary>
        /// 矩阵求逆
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public double[,] matrixInverse(double[,] a)
        {
            int i = 0;
            int row = a.GetLength(0);
            double[,] MatrixZwei = new double[row, row * 2];
            double[,] iMatrixInv = new double[row, row];
            //生成扩展数组
            for (i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    MatrixZwei[i, j] = a[i, j];
                }
            }
            for (i = 0; i < row; i++)
            {
                for (int j = row; j < row * 2; j++)
                {
                    MatrixZwei[i, j] = 0;
                    if (i + row == j)
                        MatrixZwei[i, j] = 1;
                }
            }
            //求逆
            for (i = 0; i < row; i++)
            {
                if (MatrixZwei[i, i] != 0)
                {
                    double intTemp = MatrixZwei[i, i];
                    for (int j = 0; j < row * 2; j++)
                    {
                        MatrixZwei[i, j] = MatrixZwei[i, j] / intTemp;
                    }
                }
                for (int j = 0; j < row; j++)
                {
                    if (j == i)
                        continue;
                    double intTemp = MatrixZwei[j, i];
                    for (int k = 0; k < row * 2; k++)
                    {
                        MatrixZwei[j, k] = MatrixZwei[j, k] - MatrixZwei[i, k] * intTemp;
                    }
                }
            }
            //提取逆矩阵
            for (i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    iMatrixInv[i, j] = MatrixZwei[i, j + row];
                }
            }
            return iMatrixInv;
        }
    }
}
