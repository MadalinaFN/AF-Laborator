using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ex_3
{
    public partial class Form1 : Form
    {
        private List<point> points = new List<point>();
        private List<point> red = new List<point>();
        private List<point> green = new List<point>();
        private List<point> blue = new List<point>();

        private static Graphics grp;
        public class point
        {
            public int x, y;

            public point()
            {

            }

            public void Draw(Graphics grp)
            {
                grp.DrawEllipse(new Pen(Color.Black, 4), x, y, 4, 4);
            }

            public override string ToString()
            {
                return "(" + x + "," + y + ")";
            }
        }

        void load(string fileName)
        {
            int n;
            TextReader Load = new StreamReader(fileName);
            string[] buffer;
            buffer = (Load.ReadLine()).Split(' ');
            n = int.Parse(buffer[0]);
            for (int i = 0; i < n; i++)
            {
                point newPoint = new point();
                string[] text = (Load.ReadLine()).Split(' ');
                newPoint.x = Int32.Parse(text[0]);
                newPoint.y = Int32.Parse(text[1]);
                points.Add(newPoint);
            }
            foreach (point p in points)
            {
                if ((isPrim(p.x)) == true && (isPrim(p.y) == true))
                {
                    grp.FillEllipse(new SolidBrush(Color.Red), p.x, p.y, 6, 6);
                    red.Add(p);
                }
                else
                {
                    if (isPrim(p.x) == true || isPrim(p.y) == true)
                    {
                        grp.FillEllipse(new SolidBrush(Color.Green), p.x, p.y, 6, 6);
                        green.Add(p);
                    }
                    else
                    {
                        grp.FillEllipse(new SolidBrush(Color.Blue), p.x, p.y, 6, 6);
                        blue.Add(p);
                    }
                }
            }
        }

        static bool isPrim(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if ((n % 2) == 0) return false;
            for (int i = 3; i * i <= n; i++)
                if ((n % i) == 0)
                    return false;
            return true;
        }

        public Form1()
        {
            InitializeComponent();

        }

        Bitmap bmp;

        public float area(point p1, point p2, point p3)
        {
            float s = 0, a = 0, h = 0;
            a = Math.Abs(p2.x - p3.x);
            h = Math.Abs(p2.y - p1.y);
            s = (a * h) / 2;
            return s;
        }

        int pozred = 0, pozgreen = 0, pozblue = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            load(@"..\..\ex03.in");
            if (red.Count != 0 && green.Count != 0 && blue.Count != 0)
            {
                float ariamin = area(red[0], green[0], blue[0]);

                for (int i = 0; i < red.Count; i++)
                    for (int j = 0; j < green.Count; j++)
                        for (int k = 0; k < blue.Count; k++)
                        {
                            float t = area(red[i], green[i], blue[i]);
                            if (t < ariamin)
                            {
                                t = ariamin;
                                pozred = i;
                                pozgreen = j;
                                pozblue = k;
                            }
                        }
            }
            int crx = red[pozred].x;
            int cry = red[pozred].y;
            int cgx = green[pozgreen].x;
            int cgy = green[pozgreen].y;
            int cbx = blue[pozblue].x;
            int cby = blue[pozblue].y;

            grp.DrawLine(new Pen(Color.Black, 1), crx, cry, cgx, cgy);
            grp.DrawLine(new Pen(Color.Black, 1), cgx, cgy, cbx, cby);
            grp.DrawLine(new Pen(Color.Black, 1), crx, cry, cbx, cby);

            using (Font myFont = new Font("Arial", 8))
            {
                grp.DrawString($"P({crx}, {cry}", myFont, Brushes.Red, crx - 4, cry + 7);
            }
            using (Font myFont = new Font("Arial", 8))
            {
                grp.DrawString($"P({cgx}, {cgy}", myFont, Brushes.Green, cgx + 6, cgy - 4);
            }
            using (Font myFont = new Font("Arial", 8))
            {
                grp.DrawString($"P({cbx}, {cby}", myFont, Brushes.Blue, cbx + 6, cby - 4);
            }
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grp.Clear(Color.White);
            load(@"..\..\ex03.in");
            pictureBox1.Image = bmp;
        }
    }
}