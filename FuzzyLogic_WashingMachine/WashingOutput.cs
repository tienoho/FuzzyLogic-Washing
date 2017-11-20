using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzyLogic_WashingMachine
{
    class WashingOutput
    {
        public WashingOutput(Graphics g,Pen pen,Bitmap img,PictureBox pic, Washing washing,CheckBox checkBox_Fill)
        {
            DrawPictureBox(g, pen, img, pic);
            GraphicChar(g,pen,washing,checkBox_Fill);
        }
        private void DrawPictureBox(Graphics g,Pen pen, Bitmap img,PictureBox pic)
        {    //vẽ các đường chéo biểu thị
            //8 -12 -20 - 40 - 60
            //Very Short
            pen.Brush = Brushes.Coral;
            g.DrawLine(pen, 0, 0, 20, 0);
            g.DrawLine(pen, 20, 0, 30, 150);
            //Short
            pen.Brush = Brushes.Fuchsia;
            g.DrawLine(pen, 20, 150, 30, 0);
            g.DrawLine(pen, 30, 0, 50, 150);
            //Medium
            pen.Brush = Brushes.GhostWhite;
            g.DrawLine(pen, 30, 150, 50, 0);
            g.DrawLine(pen, 50, 0, 100, 150);
            //Long
            pen.Brush = Brushes.Khaki;
            g.DrawLine(pen, 50, 150, 100, 0);
            g.DrawLine(pen, 100, 0, 150, 150);
            //VeryLong
            pen.Brush = Brushes.MediumVioletRed;
            g.DrawLine(pen, 100, 150, 150, 0);
            pic.Image = img;
        }
        private void GraphicChar(Graphics g, Pen pen, Washing washing, CheckBox checkBox_Fill)
        {
            //Graph
            pen.Brush = Brushes.PowderBlue;
            if (washing._VeryShort != 0.0f)
            {
                float y = 150 - washing._VeryShort * 150;
                float x1 = 0;
                float x2 = (3 - washing._VeryShort) * 10;
                if (checkBox_Fill.Checked == true)
                {
                    PointF[] p = {
                            new PointF(x1,y),
                            new PointF(x2,y),
                            new PointF(30,150),
                            new PointF(0,150)
                                };
                    g.FillPolygon(Brushes.White, p);
                }
                else
                    g.DrawLine(pen, x1, y, x2, y);

            }
            if (washing._Short != 0.0f)
            {
                float y = 150 - washing._Short * 150;
                float x1 = (4 * washing._Short + 8) * 2.5f;
                float x2 = (20 - 8 * washing._Short) * 2.5f;
                if (checkBox_Fill.Checked == true)
                {
                    PointF[] p = {
                            new PointF(x1,y),
                            new PointF(x2,y),
                            new PointF(50,150),
                            new PointF(20,150)
                                };
                    g.FillPolygon(Brushes.White, p);
                }
                else
                    g.DrawLine(pen, x1, y, x2, y);
            }
            if (washing._Medium != 0.0f)
            {
                float y = 150 - washing._Medium * 150;
                float x1 = (8 * washing._Medium + 12) * 2.5f;
                float x2 = (40 - 20 * washing._Medium) * 2.5f;
                if (checkBox_Fill.Checked == true)
                {
                    PointF[] p = {
                            new PointF(x1,y),
                            new PointF(x2,y),
                            new PointF(100,150),
                            new PointF(30,150)
                                };
                    g.FillPolygon(Brushes.White, p);
                }
                else
                    g.DrawLine(pen, x1, y, x2, y);
            }
            if (washing._Long != 0.0f)
            {
                float y = 150 - washing._Long * 150;
                float x1 = (20 * washing._Long + 20) * 2.5f;
                float x2 = (60 - 20 * washing._Long) * 2.5f;
                if (checkBox_Fill.Checked == true)
                {
                    PointF[] p = {
                            new PointF(x1,y),
                            new PointF(x2,y),
                            new PointF(150,150),
                            new PointF(50,150)
                                };
                    g.FillPolygon(Brushes.White, p);
                }
                else
                    g.DrawLine(pen, x1, y, x2, y);
            }
            if (washing._VeryLong != 0.0f)
            {
                float y = 150 - washing._VeryLong * 150;
                float x1 = (20 * washing._VeryLong + 40) * 2.5f;
                float x2 = 150;
                if (checkBox_Fill.Checked == true)
                {
                    PointF[] p = {
                            new PointF(x1,y),
                            new PointF(x2,y),
                            new PointF(150,150),
                            new PointF(100,150)
                                };
                    g.FillPolygon(Brushes.White, p);
                }
                else
                    g.DrawLine(pen, x1, y, x2, y);
            }
            g.Dispose();
        }
    }
}
