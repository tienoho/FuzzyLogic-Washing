using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogic_WashingMachine
{
    public enum WashingWater
    {
        small = 14,
        Medium = 70,
        heavy = 140,
    }
    class WaterL
    {

        //float time;
        //float[] washing_Y;
        //float y1, y2;
        //const int VS = 8, S = 12, M = 20, L = 40, VL = 60;
        public float _small { get; set; }
        public float _Medium { get; set; }
        public float _heavy { get; set; }
        public WaterL()
        {
            //time = 0;
            //washing_Y = new float[141];
            _small = _Medium = _heavy = 0;
        }
        public WaterL(int value)
        {
            if (value <= 50)
            {
                _small = 1 - value / 50.0f;
                _Medium = value / 50.0f;
                _heavy = 0;
            }
            else if (value <= 100)
            {
                _small = 0;
                _Medium = 2 - value / 50.0f;
                _heavy = value / 50.0f - 1;
            }
        }


        //public float ComputeTime4(Weight weight)
        //{
        //    //lỗi
        //    _small =Math.Min(weight.small,weight.medium);
        //    _Medium = weight.medium;
        //    _heavy = Math.Min(weight.medium, weight.large);

        //    BuildChart();
        //    Defuzzification2();
        //    return time;
        //}

        //private void Defuzzification2()
        //{
        //    float sum = 0, sum_y = 0;
        //    for (int i = 0; i <= 140; i++)
        //    {
        //        sum += i * washing_Y[i];
        //        sum_y += washing_Y[i];
        //    }
        //    time = sum / sum_y;
        //}

        //private void isBuildChart(int i, float a, float b, WashingWater x, WashingWater y)
        //{
        //    float xy = (x - y);
        //    y1 = Math.Min(a, ((float)x - i) / xy);
        //    y2 = Math.Min(b, (i - (float)y) / xy);
        //    washing_Y[i] = Math.Max(y1, y2);
        //}
        //private void BuildChart()
        //{
        //    for (int i = 0; i <= (int)WashingWater.small; i++)
        //    {
        //        washing_Y[i] = _small;
        //    }
        //    for (int i = (int)WashingWater.small + 1; i < (int)WashingWater.Medium; i++)
        //    {
        //        isBuildChart(i, _small, _Medium, WashingWater.Medium, WashingWater.small);
        //    }
        //    for (int i = (int)WashingWater.Medium + 1; i < (int)WashingWater.heavy; i++)
        //    {
        //        isBuildChart(i, _Medium, _heavy, WashingWater.Medium, WashingWater.heavy);
        //    }
        //}
    }
}

