using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzyLogic_WashingMachine
{
    class WashingInput
    {
        public WashingInput(ItemWashing item, Graphics graphics, Pen pen, PictureBox pictureBox, int trackBar)
        {
            DrawChart(item,graphics, pen, pictureBox,trackBar);
        }
        private void DrawChart(ItemWashing item,Graphics graphics, Pen pen, PictureBox pictureBox, int trackBar)
        {
            //get Bitmap theo độ cao và rộng của PuctureBox
            Bitmap img = new Bitmap(pictureBox.Width, pictureBox.Height, graphics);
            //gán Graphics = img
            Graphics g = Graphics.FromImage(img);
            //giảm độ bớt răng cưa
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            for (int i = 0; i <= 10; i++)
            {
                int iPoint = i * 15;
                g.DrawLine(pen, new Point(iPoint, 0), new Point(iPoint, img.Height));
                g.DrawLine(pen, new Point(0, iPoint), new Point(img.Width, iPoint));
            }
            //Vẻ các đường chéo tạo thành các hình tam giác
            //=
            pen.Brush = Brushes.HotPink;
            g.DrawLine(pen, new Point(0, 0), new Point(15 * 5, 150));
            //=
            pen.Brush = Brushes.LightBlue;
            g.DrawLines(pen, new Point[] { new Point(0, 150), new Point(75, 0), new Point(150, 150) });
            //=
            pen.Brush = Brushes.Khaki;
            g.DrawLine(pen, new Point(150, 0), new Point(15 * 5, 150));
            //=            
            //int y;
            if (item.numberSmall != 0)
            {
                //màu của bút
                pen.Brush = Brushes.Bisque;
                DrawLine(pen, g, item.numberSmall, trackBar);
            }
            if (item.numberMedium != 0)
            {
                //màu của bút
                pen.Brush = Brushes.Brown;
                DrawLine(pen, g, item.numberMedium, trackBar);
            }
            if (item.numberLarger != 0)
            {
                pen.Brush = Brushes.DarkOrange;
                DrawLine(pen, g, item.numberLarger, trackBar);
            }
            pictureBox.Image = img;
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
