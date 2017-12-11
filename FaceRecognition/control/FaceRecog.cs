using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;
using Emgu.CV.ML;
using Emgu.CV.ML.MlEnum;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;

namespace Control
{
    class FaceRecog
    {
        private const string diretorio = "C:\\Database\\";
        private const string men = "M-0";
        private const string women = "W-0";
        private const string zero = "0";
        EigenFaceRecognizer _faceRecognizer;
        public bool TrainRecognizer()
        {
            var faceImages = new Image<Gray, byte>[750];
            var faceLabels = new int[750];
            int count = 0;
            for (int i = 0; i < 50; i++)
            {
                for(int j = 0; j < 15; j++)
                {
                    string abrir = diretorio + men + (i < 9 ? "0" : "") + (i + 1).ToString() + "-" + (j < 9 ? "0" : "") + (j + 1).ToString() + ".bmp";
                    var faceImage = new Image<Gray, byte>(abrir);
                    faceImages[count] = faceImage.Resize(100, 100, Inter.Cubic);
                    faceLabels[count] = (i + 1);
                    count++;
                }
                    
            }

            _faceRecognizer = new EigenFaceRecognizer(750,2000);
            _faceRecognizer.Train(faceImages, faceLabels);
            //_faceRecognizer.Save()

            return true;

        }

        public int RecognizeUser(Image<Gray, byte> userImage)
        {
            var result = _faceRecognizer.Predict(userImage.Resize(100, 100, Inter.Cubic));
            return result.Label;
        }
    }
}
