using System.Collections.Generic;
using Yolov5Net.Scorer.Models.Abstract;
using System.Drawing;

namespace Yolov5Net.Scorer.Models
{
    public class YoloInternModel: YoloModel
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

        public override float Confidence { get; } = 0.20f;
        public override float MulConfidence { get; } = 0.25f;
        public override float Overlap { get; } = 0.45f;
        public override int Dimensions { get; } = 9;


        public override string Weights { get; } = "Assets/Weights/best.onnx";
        public override string[] OutputNames { get; } = new[] { "output" };

        public override bool UseDetect { get; } = true;

        public YoloInternModel()
        {

            Labels = new List<YoloLabel>()
            {
                new YoloLabel { Id = 1, Name = "calculator" , Color=Color.Red},
                new YoloLabel { Id = 2, Name = "Orion_cake" , Color=Color.Yellow},
                new YoloLabel { Id = 3, Name = "Karo_cake" , Color=Color.Green},
                new YoloLabel { Id = 4, Name = "ATM_card" , Color=Color.Bisque}
               };
        }
    }
}
