using System.Collections.Generic;
using Yolov5Net.Scorer.Models.Abstract;

namespace Yolov5Net.Scorer.Models
{
    public class YoloVehicleModel : YoloModel
    {
        public override int Width { get; } = 640;
        public override int Height { get; } = 640;
        public override int Depth { get; } = 3;


        public override float[] Strides { get; } = new float[] { 8, 16, 32 };

        public override float[][][] Anchors { get; } = new float[][][]
        {
            new float[][] { new float[] { 010, 13 }, new float[] { 016, 030 }, new float[] { 033, 023 } },
            new float[][] { new float[] { 030, 61 }, new float[] { 062, 045 }, new float[] { 059, 119 } },
            new float[][] { new float[] { 116, 90 }, new float[] { 156, 198 }, new float[] { 373, 326 } }
        };

        public override int[] Shapes { get; } = new int[] { 80, 40, 20 };

        public override float Confidence { get; } = 0.20f; //old 0.20f
        public override float MulConfidence { get; } = 0.25f;
        public override float Overlap { get; } = 0.45f;
        public override int Dimensions { get; } = 9;


        public override string Weights { get; } = "E:/test yolov5 net/yolov5-net-master/src/Yolov5Net.App/Assets/Weights/VehicleDetection.onnx";
        public override string[] OutputNames { get; } = new[] { "output" };


        public override bool UseDetect { get; } = true;

        public YoloVehicleModel()
        {

            Labels = new List<YoloLabel>()
            {
                new YoloLabel { Id = 1, Name = "two-wheels" },
                new YoloLabel { Id = 2, Name = "four-wheels" },
                new YoloLabel { Id = 3, Name = "bus" },
                new YoloLabel { Id = 4, Name = "truck" }
               };

        }
    }
}
