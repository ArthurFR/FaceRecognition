using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Control;

namespace View
{
    public partial class Home : Form
    {
        FaceRecog recog;
        Image<Bgr, Byte> imagem;
        private const string diretorio = "C:\\Database\\";
        private const string men = "M-0";
        private const string women = "W-0";
        public Home()
        {
            InitializeComponent();
            recog = new FaceRecog();
            recog.TrainRecognizer();
        }

        private void btProcurar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Openfile = new OpenFileDialog();
            if (Openfile.ShowDialog() == DialogResult.OK)
            {
                imagem = new Image<Bgr, byte>(Openfile.FileName);
                pictureBox1.Image = imagem.ToBitmap();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            if (imagem != null)
            {
                i = recog.RecognizeUser(new Image<Gray, byte>(imagem.ToBitmap()));
                if (i > 0)
                {
                    Image<Bgr, Byte> encontrado = new Image<Bgr, byte>(diretorio + men + (i < 9 ? "0" : "") + (i).ToString() + "-01" + ".bmp");
                    pictureBox2.Image = encontrado.ToBitmap();
                }
                
            }
                
        }

    }
}
