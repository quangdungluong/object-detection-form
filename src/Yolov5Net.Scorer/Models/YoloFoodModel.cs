using System.Collections.Generic;
using Yolov5Net.Scorer.Models.Abstract;

namespace Yolov5Net.Scorer.Models
{
    public class YoloFoodModel : YoloModel
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
        public override int Dimensions { get; } = 26;


        public override string Weights { get; } = "E:/test yolov5 net/yolov5-net-master/src/Yolov5Net.App/Assets/Weights/FoodDetection.onnx";
        public override string[] OutputNames { get; } = new[] { "output" };

        public override bool UseDetect { get; } = true;

        public YoloFoodModel()
        {

            Labels = new List<YoloLabel>()
            {
                new YoloLabel { Id = 1, Name = "Milk" },
                new YoloLabel { Id = 2, Name = "Drinkable yogurt" },
                new YoloLabel { Id = 3, Name = "Rice" },
                new YoloLabel { Id = 4, Name = "Mixed rice" },
                new YoloLabel { Id = 5, Name = "Bread" },
                new YoloLabel { Id = 6, Name = "White bread" },
                new YoloLabel { Id = 7, Name = "Udon" },
                new YoloLabel { Id = 8, Name = "Fish" },
                new YoloLabel { Id = 9, Name = "Meat" },
                new YoloLabel { Id = 10, Name = "Salad" },
                new YoloLabel { Id = 11, Name = "Cherry tomatoes" },
                new YoloLabel { Id = 12, Name = "Soups" },
                new YoloLabel { Id = 13, Name = "Curry" },
                new YoloLabel { Id = 14, Name = "Spicy chili-flavored tofu" },
                new YoloLabel { Id = 15, Name = "Bibimbap" },
                new YoloLabel { Id = 16, Name = "Fried noodles" },
                new YoloLabel { Id = 17, Name = "Spaghetti" },
                new YoloLabel { Id = 18, Name = "Citrus" },
                new YoloLabel { Id = 19, Name = "Apple" },
                new YoloLabel { Id = 20, Name = "Cup desserts" },
                new YoloLabel { Id = 21, Name = "Other foods" }
               };

        }
    }
}
