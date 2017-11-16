using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzyLogic_WashingMachine
{
    public partial class WashingMachine : Form
    {
        Cloudiness cloudiness;
        KindOfDirt kindOfDir;
        Washing washing;
        float s, m, l;
        float y, x1, x2;
        public WashingMachine()
        {
            InitializeComponent();
        }

        private void WashingMachine_Load(object sender, EventArgs e)
        {
            UpdateChart();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void UpdateChart()
        {
            label_doban.Text = "Độ bẩn : " + trackBar_doban.Value.ToString();
            label_loaichatban.Text = "Loại chất bẩn : " + trackBar_loaichatban.Value.ToString();
            cloudiness = new Cloudiness(trackBar_doban.Value);
            kindOfDir = new KindOfDirt(trackBar_loaichatban.Value);
            washing = new Washing();
            label_washingtime.Text = "Thời gian giặt : " + washing.ComputeTime(cloudiness, kindOfDir).ToString();
            this.Invalidate();
        }

        private void WashingMachine_Paint(object sender, PaintEventArgs e)
        {
            DrawChartCloudiness(e.Graphics, cloudiness);
            DrawChartKindOfDirt(e.Graphics, kindOfDir);
            DrawChart3(e.Graphics);
        }

        private void trackBar_doban_Scroll(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void trackBar_loaichatban_Scroll(object sender, EventArgs e)
        {
            UpdateChart();
        }
        private void DrawLineCloudiness(Pen pen, Graphics g, int x, float cloudiness)
        {
            int y = (int)(150 - cloudiness * 150);
            g.DrawLine(pen, new Point(x, 150), new Point(x, y));
            g.DrawLine(pen, new Point(x, y), new Point(0, y));
        }
        private void DrawChartCloudiness(Graphics graphics, Cloudiness cloudiness)
        {
            Pen pen = new Pen(Brushes.Green);
            s = cloudiness.small;
            m = cloudiness.medium;
            l = cloudiness.large;
            DrawChart(graphics, pen, pictureBox1);
        }
        private void DrawChartKindOfDirt(Graphics graphics, KindOfDirt kindOfDir)
        {
            Pen pen = new Pen(Brushes.Green);
            s = kindOfDir.notGreasy;
            m = kindOfDir.Medium;
            l = kindOfDir.Greasy;
            DrawChart(graphics, pen, pictureBox2);
        }

        private void checkBox_Fill_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void DrawChart(Graphics graphics, Pen pen, PictureBox pictureBox)
        {
            Bitmap img = new Bitmap(pictureBox.Width, pictureBox.Height, graphics);
            Graphics g = Graphics.FromImage(img);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            for (int i = 0; i <= 10; i++)
            {
                g.DrawLine(pen, new Point(i * 15, 0), new Point(i * 15, img.Height));
                g.DrawLine(pen, new Point(0, i * 15), new Point(img.Width, i * 15));
            }
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
            int x = (int)(trackBar_doban.Value * 1.5);
            //int y;
            if (s != 0)
            {
                //màu của bút
                pen.Brush = Brushes.Bisque;
                DrawLineCloudiness(pen, g, x, s);
            }
            if (m != 0)
            {
                //màu của bút
                pen.Brush = Brushes.Brown;
                DrawLineCloudiness(pen, g, x, m);
            }
            if (l != 0)
            {
                pen.Brush = Brushes.DarkOrange;
                DrawLineCloudiness(pen, g, x, l);
            }
            pictureBox.Image = img;
            g.Dispose();
        }
        private void DrawChart3(Graphics graphics)
        {
            Pen pen = new Pen(Brushes.Green);
            Bitmap img = new Bitmap(pictureBox3.Width, pictureBox3.Height, graphics);
            Graphics g = Graphics.FromImage(img);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //gạch dọc
            for (int i = 0; i <= 20; i++)
            {
                g.DrawLine(pen, new Point(i * 25, 0), new Point(i * 25, img.Height));
                g.DrawLine(pen, new Point(0, i * 25), new Point(img.Width, i * 25));
            }
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
            pictureBox3.Image = img;

            //Graph
            pen.Brush = Brushes.PowderBlue;
            if (washing._VeryShort != 0.0f)
            {
                //y = 150 - washing._VeryShort * 150;
                //x1 = 0;
                //x2 = (3 - washing._VeryShort) * 10;
                //WashingDraw(g, pen, washing._VeryShort);

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
                //y = 150 - washing._Short * 150;
                //x1 = (4 * washing._Short + (int)WashingTime.VeryShort) * 2.5f;
                //x2 = ((int)WashingTime.Medium - (int)WashingTime.VeryShort * washing._Short) * 2.5f;
                //WashingDraw(g, pen, washing._Short);

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
                //y = 150 - washing._Medium * 150;
                //x1 = ((int)WashingTime.VeryShort * washing._Medium + (int)WashingTime.Short) * 2.5f;
                //x2 = ((int)WashingTime.Long - (int)WashingTime.Medium * washing._Medium) * 2.5f;
                //WashingDraw(g, pen, washing._Medium);

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
                //y = 150 - washing._Long * 150;
                //x1 = ((int)WashingTime.Medium * washing._Long + (int)WashingTime.Medium) * 2.5f;
                //x2 = ((int)WashingTime.VeryLong - (int)WashingTime.Medium * washing._Long) * 2.5f;
                //WashingDraw(g, pen, washing._Long);

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
                //y = 150 - washing._VeryLong * 150;
                //x1 = ((int)WashingTime.Medium * washing._VeryLong + (int)WashingTime.VeryLong) * 2.5f;
                //x2 = 150;
                //WashingDraw(g, pen, washing._VeryLong);

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
        private void WashingDraw(Graphics g, Pen pen, float type)
        {
            //float y = 150 - type * 150;
            //float x1 = (20 * type + 20) * 2.5f;
            //float x2 = (60 - 20 * type) * 2.5f;
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
    }
}
