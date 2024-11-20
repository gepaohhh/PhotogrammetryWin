using PhotogrammetryWin.FileStream;
using PhotogrammetryWin.Props;
using PhotogrammetryWin.Utils;
using System.ComponentModel;

namespace PhotogrammetryWin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Camera camera = new Camera();
        List<GCP> gcpS = new List<GCP>();
        List<HomonymyPoint> homonymyPoints = new List<HomonymyPoint>();
        double Bx = 0;
        Tools tools = new Tools();

        private void 打开后方交会文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "txt文件(*.txt)|*.txt";
            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String filePath = of.FileName;
                    ReadResectionFile readResectionFile = new ReadResectionFile(filePath);
                    camera = readResectionFile.camera;
                    gcpS = readResectionFile.gcpS;
                    textBoxRead.Text = "后方交会计算数据\r\n";
                    textBoxRead.Text += "像主距：" + camera.f + " (mm)\r\n";
                    textBoxRead.Text += "地面控制点和对应像点坐标(mm)：";
                    textBoxRead.Text += "( Xa , Ya , Za ) -> ( x , y )\r\n";
                    for (int index = 0; index < gcpS.Count; index++)
                    {
                        textBoxRead.Text += "(" + gcpS[index].Xa + "," + gcpS[index].Ya + "," + gcpS[index].Za + ")" + " -> " +
                            "(" + gcpS[index].x + gcpS[index].y + ")";
                        if (index != gcpS.Count - 1)
                        {
                            textBoxRead.Text += "\r\n";
                        }
                    }

                }
                catch
                {
                    MessageBox.Show("文件格式有误(可能选择的文件格式不符合)", "失败", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("取消导入文件", "取消", MessageBoxButtons.OKCancel);
            }
        }

        private void 打开相对定向文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "txt文件(*.txt)|*.txt";
            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String filePath = of.FileName;
                    ReadRelativeOrientation readRelativeOrientation = new ReadRelativeOrientation(filePath);
                    camera = readRelativeOrientation.camera;
                    homonymyPoints = readRelativeOrientation.homonymyPoints;
                    Bx = readRelativeOrientation.Bx;

                    textBoxRead.Text = "相对定向计算数据\r\n";
                    textBoxRead.Text += "像主距：" + camera.f + " (mm)\r\n";
                    textBoxRead.Text += "摄影基线长：" + Bx + " (mm)\r\n";
                    textBoxRead.Text += "同名像点坐标(mm)：";
                    textBoxRead.Text += "( Lx , Ly ) <-> ( Rx , Ry )\r\n";
                    for (int index = 0; index < homonymyPoints.Count; index++)
                    {
                        textBoxRead.Text += "(" + homonymyPoints[index].Lx + "," + homonymyPoints[index].Ly + ")" + " <-> " +
                            "(" + homonymyPoints[index].Rx + homonymyPoints[index].Ry + ")";
                        if (index != gcpS.Count - 1)
                        {
                            textBoxRead.Text += "\r\n";
                        }
                    }

                }
                catch
                {
                    MessageBox.Show("文件格式有误(可能选择的文件格式不符合)", "失败", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("取消导入文件", "取消", MessageBoxButtons.OKCancel);
            }
        }

        private void 后方交会ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CalRescetion calRescetion = new CalRescetion(gcpS, camera);
                Camera resultCamera = calRescetion.camera;
                textBoxResult.Text = "后方交会计算结果\r\n";
                textBoxResult.Text += "迭代" + calRescetion.num + "结算后相片外方位元素为：\r\n";
                textBoxResult.Text += "Xs=" + resultCamera.Xs / 1000 + " m " + "\r\n";
                textBoxResult.Text += "Ys=" + resultCamera.Ys / 1000 + " m " + "\r\n";
                textBoxResult.Text += "Zs=" + resultCamera.Zs / 1000 + " m " + "\r\n";
                textBoxResult.Text += "phi=" + resultCamera.phi + " 度" + "\r\n";
                textBoxResult.Text += "omega=" + resultCamera.omega + " 度" + "\r\n";
                textBoxResult.Text += "kappa=" + resultCamera.kappa + " 度" + "\r\n";
            }
            catch
            {
                MessageBox.Show("计算失败", "失败", MessageBoxButtons.OK);
            }
        }

        private void 相对定向ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CalRescetion calRescetion = new CalRescetion(gcpS, camera);
                CalRelativeOrientation calRelativeOrientation = new CalRelativeOrientation(homonymyPoints, camera, Bx);
                Camera resultCamera = calRelativeOrientation.camera;
                textBoxResult.Text = "后方交会计算结果\r\n";
                textBoxResult.Text += "迭代" + calRelativeOrientation.num + "结算后相片外方位元素为：\r\n";
                textBoxResult.Text += "By=" + calRelativeOrientation.U * Bx / 1000 + " m " + "\r\n";
                textBoxResult.Text += "Bz=" + calRelativeOrientation.V * Bx / 1000 + " m " + "\r\n";
                textBoxResult.Text += "phi=" + resultCamera.phi + "度" + "\r\n";
                textBoxResult.Text += "omega=" + resultCamera.omega + "度" + "\r\n";
                textBoxResult.Text += "kappa=" + resultCamera.kappa + "度" + "\r\n";
            }
            catch
            {
                MessageBox.Show("计算失败", "失败", MessageBoxButtons.OK);
            }
}

        private void 保存运算结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "文本文件(*.txt)|*.txt";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String filePath = sf.FileName;
                    File.WriteAllText(filePath, textBoxResult.Text);
                }
                catch {
                    MessageBox.Show("保存失败", "失败", MessageBoxButtons.OK);
                }
            }
            else {
                MessageBox.Show("取消保存文件", "取消", MessageBoxButtons.OK);
            }
        }
    }
}
