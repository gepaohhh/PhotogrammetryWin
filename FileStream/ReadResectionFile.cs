using PhotogrammetryWin.Props;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotogrammetryWin.FileStream
{
    internal class ReadResectionFile
    {
        private string filePath;
        public List<GCP> gcpS;
        public Camera camera;
        /// <summary>
        /// 获取路径即可返回数据解析情况
        /// </summary>
        /// <param name="filePath"></param>
        public ReadResectionFile(string filePath)
        {
            this.filePath = filePath;
            readFile();
        }
        /// <summary>
        /// 读取文件
        /// </summary>
        private void readFile()
        {
            gcpS = new List<GCP>();
            camera = new Camera();
            StreamReader sr = new StreamReader(this.filePath, Encoding.UTF8);
            string line;
            int index = 0;
            

            while ((line = sr.ReadLine()) != null)
            {
                if (index != 0)
                {
                    String[] points = line.Split(',');
                    gcpS.Add(new GCP(Convert.ToDouble(points[0]), Convert.ToDouble(points[1]), Convert.ToDouble(points[2]),
                        Convert.ToDouble(points[3]), Convert.ToDouble(points[4])));
                }
                else
                {
                    camera.f = Convert.ToDouble(line);
                }
                index += 1;
            }

            sr.Close();
        }
    }
}
