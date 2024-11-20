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

        private void �򿪺󷽽����ļ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "txt�ļ�(*.txt)|*.txt";
            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String filePath = of.FileName;
                    ReadResectionFile readResectionFile = new ReadResectionFile(filePath);
                    camera = readResectionFile.camera;
                    gcpS = readResectionFile.gcpS;
                    textBoxRead.Text = "�󷽽����������\r\n";
                    textBoxRead.Text += "�����ࣺ" + camera.f + " (mm)\r\n";
                    textBoxRead.Text += "������Ƶ�Ͷ�Ӧ�������(mm)��";
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
                    MessageBox.Show("�ļ���ʽ����(����ѡ����ļ���ʽ������)", "ʧ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("ȡ�������ļ�", "ȡ��", MessageBoxButtons.OKCancel);
            }
        }

        private void ����Զ����ļ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "txt�ļ�(*.txt)|*.txt";
            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String filePath = of.FileName;
                    ReadRelativeOrientation readRelativeOrientation = new ReadRelativeOrientation(filePath);
                    camera = readRelativeOrientation.camera;
                    homonymyPoints = readRelativeOrientation.homonymyPoints;
                    Bx = readRelativeOrientation.Bx;

                    textBoxRead.Text = "��Զ����������\r\n";
                    textBoxRead.Text += "�����ࣺ" + camera.f + " (mm)\r\n";
                    textBoxRead.Text += "��Ӱ���߳���" + Bx + " (mm)\r\n";
                    textBoxRead.Text += "ͬ���������(mm)��";
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
                    MessageBox.Show("�ļ���ʽ����(����ѡ����ļ���ʽ������)", "ʧ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("ȡ�������ļ�", "ȡ��", MessageBoxButtons.OKCancel);
            }
        }

        private void �󷽽���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CalRescetion calRescetion = new CalRescetion(gcpS, camera);
                Camera resultCamera = calRescetion.camera;
                textBoxResult.Text = "�󷽽��������\r\n";
                textBoxResult.Text += "����" + calRescetion.num + "�������Ƭ�ⷽλԪ��Ϊ��\r\n";
                textBoxResult.Text += "Xs=" + resultCamera.Xs / 1000 + " m " + "\r\n";
                textBoxResult.Text += "Ys=" + resultCamera.Ys / 1000 + " m " + "\r\n";
                textBoxResult.Text += "Zs=" + resultCamera.Zs / 1000 + " m " + "\r\n";
                textBoxResult.Text += "phi=" + resultCamera.phi + " ��" + "\r\n";
                textBoxResult.Text += "omega=" + resultCamera.omega + " ��" + "\r\n";
                textBoxResult.Text += "kappa=" + resultCamera.kappa + " ��" + "\r\n";
            }
            catch
            {
                MessageBox.Show("����ʧ��", "ʧ��", MessageBoxButtons.OK);
            }
        }

        private void ��Զ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CalRescetion calRescetion = new CalRescetion(gcpS, camera);
                CalRelativeOrientation calRelativeOrientation = new CalRelativeOrientation(homonymyPoints, camera, Bx);
                Camera resultCamera = calRelativeOrientation.camera;
                textBoxResult.Text = "�󷽽��������\r\n";
                textBoxResult.Text += "����" + calRelativeOrientation.num + "�������Ƭ�ⷽλԪ��Ϊ��\r\n";
                textBoxResult.Text += "By=" + calRelativeOrientation.U * Bx / 1000 + " m " + "\r\n";
                textBoxResult.Text += "Bz=" + calRelativeOrientation.V * Bx / 1000 + " m " + "\r\n";
                textBoxResult.Text += "phi=" + resultCamera.phi + "��" + "\r\n";
                textBoxResult.Text += "omega=" + resultCamera.omega + "��" + "\r\n";
                textBoxResult.Text += "kappa=" + resultCamera.kappa + "��" + "\r\n";
            }
            catch
            {
                MessageBox.Show("����ʧ��", "ʧ��", MessageBoxButtons.OK);
            }
}

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "�ı��ļ�(*.txt)|*.txt";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String filePath = sf.FileName;
                    File.WriteAllText(filePath, textBoxResult.Text);
                }
                catch {
                    MessageBox.Show("����ʧ��", "ʧ��", MessageBoxButtons.OK);
                }
            }
            else {
                MessageBox.Show("ȡ�������ļ�", "ȡ��", MessageBoxButtons.OK);
            }
        }
    }
}
