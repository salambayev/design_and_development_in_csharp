using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndTerm
{
    public partial class Form1 : Form
    {
        public static Color c1, c2, c3;

        public Form1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button2.BackColor = colorDialog1.Color;
                c2 = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button3.BackColor = colorDialog1.Color;
                c3 = colorDialog1.Color;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
                c1 = colorDialog1.Color;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            int fpl = 45;
            int spl = 20;
            int n = 25, m=25;

            int delta1, delta2, delta3;

            delta1 = (c2.R - c1.R) / (n - 1);
            delta2 = (c2.G - c1.G) / (n - 1);
            delta3 = (c3.B - c1.B) / (m - 1);

            int delta_b = (c3.R - c1.R) / (m - 1);

            int first = c1.R, second = c1.G, third = c1.B;
            int forC = c1.R;
            int lastR;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    circlec(Shape.ShapeType.Circle, first, second, third, fpl, spl);
                    fpl += 20;
                    if (c2.R < c1.R)
                    {
                        first = forC + ((j)*delta1);
                    }
                    else
                    {
                        first = forC - ((j) * delta1);
                    }
                    if (c2.G > c1.G)
                    {
                        second = c1.G + ((j)*delta2);
                    }
                    else
                    {
                        second = c1.G - ((j) * delta2);
                    }
                }
                if (c2.R > c1.R)
                {
                    lastR = first - delta1;
                }
                else
                {
                    lastR = first + delta1;
                }
                
                n--;
                spl += 20;
                fpl = 45;
                if (c1.R > c3.R)
                {
                    forC = c1.R + ((i) * delta_b);
                    first = forC;
                }
                else
                {
                    forC = c1.R - ((i) * delta_b);
                    first = forC;
                }
                delta1 = (lastR - forC) / (n+1);
                second = c1.G;
                if (c3.B > c1.B)
                {
                    third = c1.B + ((i)*delta3);
                }
                else
                {
                    third = c1.B - ((i)*delta3);
                }
                
            }
        }

        

        void circlec(Shape.ShapeType st, int sol,  int gol, int bol, int loc1, int loc2)
        {
            Shape newShape = new Shape();
            newShape.Size = new Size(20, 20);
            newShape.Type = st;
            newShape.Location = new Point(loc1, loc2);
            newShape.BackColor = Color.FromArgb(sol, gol, bol);
            newShape.ForeColor = Color.FromArgb(sol, gol, bol);
            newShape.ShapeName = "R: " + sol + "G: " + gol + "B: " + bol;
            this.Controls.Add(newShape);
        }

        
    }
}
