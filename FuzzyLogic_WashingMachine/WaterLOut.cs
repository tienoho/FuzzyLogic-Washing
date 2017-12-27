using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzyLogic_WashingMachine
{
    class WaterLOut
    {
        public WaterLOut(Graphics g, Pen pen, Bitmap img, PictureBox pic, WaterL waterL,int trackBar)
        {
            DrawPictureBox(g, pen, img, pic, waterL, trackBar);
            //GraphicChar(g, pen, waterL, checkBox_Fill);
        }
        private void DrawPictureBox(Graphics g, Pen pen, Bitmap img, PictureBox pic, WaterL waterL,int trackBar)
        {   
            pen.Brush = Brushes.HotPink;
            g.DrawLine(pen, new Point(0, 0), new Point(15 * 5, 150));
            //=
            pen.Brush = Brushes.LightBlue;
            g.DrawLines(pen, new Point[] { new Point(0, 150), new Point(75, 0), new Point(150, 150) });
            //=
            pen.Brush = Brushes.Khaki;
            g.DrawLine(pen, new Point(150, 0), new Point(15 * 5, 150));
            //int y;
            if (waterL._small != 0)
            {
                //màu của bút
                pen.Brush = Brushes.Bisque;
                DrawLine(pen, g, waterL._small, trackBar);
            }
            if (waterL._Medium != 0)
            {
                //màu của bút
                pen.Brush = Brushes.Brown;
                DrawLine(pen, g, waterL._Medium, trackBar);
            }
            if (waterL._heavy != 0)
            {
                pen.Brush = Brushes.DarkOrange;
                DrawLine(pen, g, waterL._heavy, trackBar);
            }
            pic.Image = img;
            g.Dispose();
        }
        private void DrawLine(Pen pen, Graphics g, float cloudiness, int trackBar_doban_chatban)
        {
            //tính tọa độ của x và x theo trackbar độ bẩn và chất bẩn
            int x = (int)(trackBar_doban_chatban * 1.5);
            int y = (int)(150 - cloudiness * 150);
            g.DrawLine(pen, new Point(x, 150), new Point(x, y));
            g.DrawLine(pen, new Point(x, y), new Point(0, y));
        }        
    }
}
