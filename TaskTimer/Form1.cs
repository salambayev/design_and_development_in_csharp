using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            TaskTimer tt = new TaskTimer();

            Process[] processList = Process.GetProcesses();
            foreach(Process theprocess in processList)
            {
                
                panel1.Controls.Add(tt);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaskTimer tt = new TaskTimer();

            panel1.CreateControl(tt);

        }
    }
}
