using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzyLogic_WashingMachine
{
    class ItemWashing
    {
        public const int endTop = 150;
        public const int endBot = 0;
        public const int endLeft = 0;
        public const int endRight = 150;
        public Graphics graphics { get; set; }
        public Pen pen { get; set; }
        public PictureBox pictureBox1 { get; set; }
        public PictureBox pictureBox2 { get; set; }
        public PictureBox pictureBox3 { get; set; }
        public int trackBar_doban { get; set; }
        public int trackBar_loaiban { get; set; }
        //s
        public float numberSmall { get; set; }
        //m
        public float numberMedium { get; set; }
        //l
        public float numberLarger { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public float y1 { get; set; }
        public float y2 { get; set; }

        public float cloudiness { get; set; }

    }
}
