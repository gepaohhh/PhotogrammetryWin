﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotogrammetryWin.Props
{
    internal class HomonymyPoint
    {
        public double Lx = 0, Ly = 0;
        public double Rx = 0, Ry = 0;
        //private double Bx = 0;
        public HomonymyPoint(double Lx,double Ly,double Rx,double Ry) {
            this.Lx = Lx;
            this.Ly = Ly;
            this.Rx = Rx;
            this.Ry = Ry;
            //this.Bx = Bx*1000;
        }
    }
}