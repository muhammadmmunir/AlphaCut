using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class GraphFuzzy : Form
    {

        public GraphFuzzy()
        {
            InitializeComponent();
            label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var series in chartGraph.Series)
            {
                series.Points.Clear();
            }

            chartGraph.ChartAreas[0].AxisX.CustomLabels.Clear();
            chartGraph.ChartAreas[0].AxisY.CustomLabels.Clear();

            int min = Convert.ToInt32(textBox1.Text);
            int middle = Convert.ToInt32(textBox2.Text);
            int max = Convert.ToInt32(textBox3.Text);

            chartGraph.ChartAreas[0].AxisX.Maximum = max + 10;
            chartGraph.ChartAreas[0].AxisX.Minimum = min - 10;

            chartGraph.Series[0].Points.AddXY(min, 0);
            chartGraph.Series[0].Points.AddXY(middle, 1);
            chartGraph.Series[0].Points.AddXY(max, 0);

            chartGraph.ChartAreas[0].AxisX.CustomLabels.Add(min-3, min+3, "" + min);
            chartGraph.ChartAreas[0].AxisX.CustomLabels.Add(middle - 3, middle + 3, "" + middle);
            chartGraph.ChartAreas[0].AxisX.CustomLabels.Add(max - 3, max + 3, "" + max);
            chartGraph.ChartAreas[0].AxisY.CustomLabels.Add(1 - 0.1, 1 + 0.1, "" + 1);

            if (textBox4.Text != "")
            {
                double x = Convert.ToDouble(textBox4.Text);
                chartGraph.ChartAreas[0].AxisY.CustomLabels.Add(x-0.1, x+0.1, "" + x);

                chartGraph.Series[1].Points.AddXY(min-10, x);
                chartGraph.Series[1].Points.AddXY(max+10, x);

                double posDot1 = x * (middle - min) + min;
                double posDot2 = -1 * (x * (max - middle) - (max - middle) - middle);

                chartGraph.Series[2].Points.AddXY(posDot1, 0);
                chartGraph.Series[2].Points.AddXY(posDot1, x);
                chartGraph.Series[3].Points.AddXY(posDot2, 0);
                chartGraph.Series[3].Points.AddXY(posDot2, x);
                chartGraph.ChartAreas[0].AxisX.CustomLabels.Add(posDot1 - 3, posDot1 + 3, "" + posDot1);
                chartGraph.ChartAreas[0].AxisX.CustomLabels.Add(posDot2 - 3, posDot2 + 3, "" + posDot2);

                label1.Text = "Interval [ " + posDot1 + ", " + posDot2 + " ]";
               
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
