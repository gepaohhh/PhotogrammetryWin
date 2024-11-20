using PhotogrammetryWin.Props;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotogrammetryWin.FileStream
{
    internal class ReadRelativeOrientation
    {
        private string filePath;
        public List<HomonymyPoint> homonymyPoints;
        public Camera camera;
        public double Bx;
        public ReadRelativeOrientation(string filePath) {
            this.filePath = filePath;
            readFile();
        }

        public void readFile() {
            homonymyPoints = new List<HomonymyPoint>();
            camera = new Camera();
            StreamReader sr = new StreamReader(filePath,Encoding.UTF8);
            string line;
            int index = 0;

            while ((line = sr.ReadLine()) != null)
            {
                if (index == 0)
                {
                    camera.f = Convert.ToDouble(line);
                }
                else if (index == 1) {
                    Bx = Convert.ToDouble(line)*1000;
                }
                else
                {
                    string[] points = line.Split(',');
                    homonymyPoints.Add(new HomonymyPoint(Convert.ToDouble(points[0]),Convert.ToDouble(points[1]),
                        Convert.ToDouble(points[2]), Convert.ToDouble(points[3])));
                }
                index += 1;
            }

            sr.Close();
        }
    }
}
