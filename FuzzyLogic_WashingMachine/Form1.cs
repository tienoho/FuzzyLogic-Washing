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
        ItemWashing item = new ItemWashing();
        Cloudiness cloudiness;
        KindOfDirt kindOfDir;
        Washing washing;
        Weight weightClothes;
        public WashingMachine()
        {
            InitializeComponent();
        }

        private void WashingMachine_Load(object sender, EventArgs e)
        {
            UpdateChart();
            UpdateWeight();
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
            isGiatNgam();
            this.Invalidate();
        }

        private void WashingMachine_Paint(object sender, PaintEventArgs e)
        {
            DrawChartCloudiness(e.Graphics, cloudiness);
            DrawChartKindOfDirt(e.Graphics, kindOfDir);
            DrawChart3(e.Graphics);
            DrawChartWeight(e.Graphics, weightClothes);

        }

        private void trackBar_doban_Scroll(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void trackBar_loaichatban_Scroll(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void DrawChartCloudiness(Graphics graphics, Cloudiness cloudiness)
        {
            item.pen = new Pen(Brushes.Green);
            item.numberSmall = cloudiness.small;
            item.numberMedium = cloudiness.medium;
            item.numberLarger = cloudiness.large;
            item.trackBar_doban = trackBar_doban.Value;
            new WashingInput(item, graphics, item.pen, pictureBox1, trackBar_doban.Value);
        }
        private void DrawChartKindOfDirt(Graphics graphics, KindOfDirt kindOfDir)
        {
            item.pen = new Pen(Brushes.Green);
            item.numberSmall = kindOfDir.notGreasy;
            item.numberMedium = kindOfDir.Medium;
            item.numberLarger = kindOfDir.Greasy;
            item.trackBar_doban = trackBar_doban.Value;
            new WashingInput(item, graphics, item.pen, pictureBox2, trackBar_loaichatban.Value);
        }
        private void checkBox_Fill_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
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
                int ipoint = i * 25;
                g.DrawLine(pen, new Point(ipoint, 0), new Point(ipoint, img.Height));
                g.DrawLine(pen, new Point(0, ipoint), new Point(img.Width, ipoint));
            }
            //vẽ hình kết quả
            new WashingOutput(g, pen, img, pictureBox3, washing, checkBox_Fill);
        }
        private void isGiatNgam()
        {
            if (cb_giatNgam.Checked == true)
            {
                lb_sumTime.Text = (washing.ComputeTime(cloudiness, kindOfDir) + 60).ToString();
            }
            else
            {
                lb_sumTime.Text = washing.ComputeTime(cloudiness, kindOfDir).ToString();
            }
        }

        private void cb_giatNgam_CheckedChanged_1(object sender, EventArgs e)
        {
            isGiatNgam();
        }
        //Cân nặng
        private void UpdateWeight()
        {
            //trọng lượng tối đa là 10kg
            label_trongluong.Text = "Trọng lượng : " + ((float)trackBar_kg.Value/10).ToString()+" kg";
            weightClothes = new Weight(trackBar_kg.Value);
            //washing = new Washing();
            label_luongnuoc.Text = "Lượng nước : " + ((float)trackBar_kg.Value * 1.4 ).ToString()+" lít";

            this.Invalidate();
        }

        private void trackBar_kg_Scroll(object sender, EventArgs e)
        {
            UpdateWeight();
        }
        private void DrawChartWeight(Graphics graphics, Weight weightClothes)
        {
            item.pen = new Pen(Brushes.Green);
            item.numberSmall = weightClothes.small;
            item.numberMedium = weightClothes.medium;
            item.numberLarger = weightClothes.large;
            item.trackBar_doban = trackBar_kg.Value;
            new WashingInput(item, graphics, item.pen, pB_kgQuanAo, trackBar_kg.Value);
            item.pen = new Pen(Brushes.Green);
            new WashingInput(item, graphics, item.pen, pB_Water, trackBar_kg.Value);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
