using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogic_WashingMachine
{
    class Cloudiness
    {
        public float small { get; set; }
        public float medium { get; set; }
        public float large { get; set; }
        public Cloudiness()
        {
            small = 0;
            medium = 0;
            large = 0;
        }
        public Cloudiness(int value)
        {
            if (value <= 50)
            {
                small = 1 - value / 50.0f;
                medium = value / 50.0f;
                large = 0;
            }
            else
            {
                small = 0;
                medium = 2 - value / 50.0f;
                large = value / 50.0f;
            }
        }
    }
}
