using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using Yolov5Net.Scorer;
using Yolov5Net.Scorer.Models;

namespace Yolov5Net.App
{
    public class YoloImage
    {
        public Bitmap img;
        public Bitmap bitmap;
        public string[] results;
        YoloScorer<YoloCocoModel> scorer;

        public YoloImage(Mat image)
        {
            scorer = new YoloScorer<YoloCocoModel>();
        }

        public void Predict(Mat image)
        {
            bitmap = MatToBitmap(image);
            List<YoloPrediction> predictions = scorer.Predict(bitmap);
            img = bitmap;
            using Graphics graphics = Graphics.FromImage(img);
            results = new string[predictions.Count];
            int i = 0;
            foreach (var prediction in predictions) // iterate each prediction to draw results
            {
                double score = Math.Round(prediction.Score, 2);

                graphics.DrawRectangles(new Pen(prediction.Label.Color, 2),
                    new[] { prediction.Rectangle });

                var (x, y) = (prediction.Rectangle.X - 3, prediction.Rectangle.Y - 23);

                graphics.DrawString($"{prediction.Label.Name} ({score})",
                    new Font("Consolas", 32, GraphicsUnit.Pixel), new SolidBrush(prediction.Label.Color),
                    new PointF(x, y));
                results[i] = $"{i+1},{prediction.Label.Name},{score},{prediction.Rectangle.X},{prediction.Rectangle.Y},{prediction.Rectangle.Width},{prediction.Rectangle.Height}";
                i += 1;
            }
        }
        public static Bitmap MatToBitmap(Mat image)
        {
            try
            {
                return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
            }
            catch
            {
                image = new Mat();
                return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
            }
        } // end of MatToBitmap function
    }
}
