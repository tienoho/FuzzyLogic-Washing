using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogic_WashingMachine
{
    class KindOfDirt
    {
        public float notGreasy { get; set; }
        public float Medium { get; set; }
        public float Greasy { get; set; }
        public KindOfDirt()
        {
            notGreasy = 0;
            Medium = 0;
            Greasy = 0;
        }
        public KindOfDirt(int value)
        {
            if (value <= 50)
            {
                notGreasy = 1 - value / 50.0f;
                Medium = value / 50.0f;
                Greasy = 0;
            }
            else if (value <= 100)
            {
                notGreasy = 0;
                Medium = 2 - value / 50.0f;
                Greasy = value / 50.0f-1;
            }
        }
    }
}
