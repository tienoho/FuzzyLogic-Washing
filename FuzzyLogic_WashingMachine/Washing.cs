using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogic_WashingMachine
{
    public enum WashingTime
    {
        VeryShort = 8,
        Short = 12,
        Medium = 20,
        Long = 40,
        VeryLong = 60
    }
    class Washing
    {
        float time;
        float[] washing_Y;
        float y1, y2;
        //const int VS = 8, S = 12, M = 20, L = 40, VL = 60;
        public float _VeryShort { get; set; }
        public float _Short { get; set; }
        public float _Medium { get; set; }
        public float _Long { get; set; }
        public float _VeryLong { get; set; }
        public Washing()
        {
            time = 0;
            washing_Y = new float[61];
            _VeryShort = _Short = _Medium = _Long = _VeryLong = 0;
        }
        public float ComputeTime(Cloudiness cloudiness, KindOfDirt kindOfDirt)
        {
            _VeryShort = Math.Min(cloudiness.small, kindOfDirt.notGreasy);
            _Short = Math.Min(cloudiness.medium, kindOfDirt.notGreasy);
            _Medium = Math.Min(cloudiness.large, kindOfDirt.notGreasy)
                + Math.Min(cloudiness.small, kindOfDirt.Medium)
                + Math.Min(cloudiness.medium, kindOfDirt.Medium);
            _Long = Math.Min(cloudiness.large, kindOfDirt.Medium)
                + Math.Min(cloudiness.small, kindOfDirt.Greasy)
                + Math.Min(cloudiness.medium, kindOfDirt.Greasy);
            _VeryLong = Math.Min(cloudiness.large, kindOfDirt.Greasy);

            BuildChart();
            Defuzzification2();
            return time;
        }

        private void Defuzzification2()
        {
            float sum = 0, sum_y = 0;
            for (int i = 0; i <= 60; i++)
            {
                sum += i * washing_Y[i];
                sum_y += washing_Y[i];
            }
            time = sum / sum_y;
        }

        private void isBuildChart(int i, float a, float b, WashingTime x, WashingTime y)
        {
            float xy = (float)(x - y);
            y1 = Math.Min(a, ((int)x - i) / xy);
            y2 = Math.Min(b, (i - (int)y) / xy);
            washing_Y[i] = Math.Max(y1, y2);
        }
        private void BuildChart()
        {
            for (int i = 0; i <= (int)WashingTime.VeryShort; i++)
            {
                washing_Y[i] = _VeryShort;
            }
            for (int i = (int)WashingTime.VeryShort + 1; i < (int)WashingTime.Short; i++)
            {
                isBuildChart(i, _VeryShort, _Short, WashingTime.Short, WashingTime.VeryShort);
            }
            for (int i = (int)WashingTime.Short + 1; i < (int)WashingTime.Medium; i++)
            {
                isBuildChart(i, _Short, _Medium, WashingTime.Medium, WashingTime.Short);
            }
            for (int i = (int)WashingTime.Medium + 1; i < (int)WashingTime.Long; i++)
            {
                isBuildChart(i, _Medium, _Long, WashingTime.Long, WashingTime.Medium);
            }
            for (int i = (int)WashingTime.Long + 1; i < (int)WashingTime.VeryLong; i++)
            {
                isBuildChart(i, _Long, _VeryLong, WashingTime.VeryLong, WashingTime.Long);
            }
        }
    }
}
