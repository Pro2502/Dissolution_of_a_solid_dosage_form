using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dissolution_of_a_solid_dosage_form
{
    public partial class Dissolution_model : Form
    {
        private Graphics graphics;
        private int resolution;
        private int maxConc;
        private int sat_solution;
        private double Dt,k;
        private bool no_end = true;
        private CellularAutomata cellularAutomata;
        public Dissolution_model()
        {
            InitializeComponent();
        }
        private void StartProcess()
        {
            if (timerDisplay.Enabled)
                return;
            nud_Dt.Enabled = false;
            nud_k.Enabled = false;
            resolution = (int)nudResol.Value;
            maxConc = (int)nudConc.Value;
            sat_solution = maxConc / 2;
            Dt = (double)nud_Dt.Value; 
            k= (double)nud_k.Value;
            cellularAutomata = new CellularAutomata();
            cellularAutomata.Initialisation(pictProcess.Height / resolution, pictProcess.Width / resolution, pictProcess.Height / (2*resolution) , pictProcess.Width / (2 * resolution), maxConc, sat_solution);

            
            bool can_update = true;
            while (no_end)
            {
                while (can_update)
                {
                    if (no_end)
                    {
                        cellularAutomata.Transition_Rule_dissolution(k,sat_solution);
                        cellularAutomata.Transition_Rule_diffusion(Dt, sat_solution);
                        cellularAutomata.Transformation(pictProcess.Height / resolution, pictProcess.Width / resolution);

                        cellularAutomata.quantityCurve.Add((int)cellularAutomata.quantity);
                        cellularAutomata.Iteration_Count(ref no_end, pictProcess.Height / (2 * resolution), pictProcess.Width / (2 * resolution));
              
                    }
                    else
                    {
                        break;
                    }
                }
            }
            pictProcess.Image = new Bitmap(pictProcess.Width, pictProcess.Height);
            graphics = Graphics.FromImage(pictProcess.Image);

            timerDisplay.Start();
        }
        private void DrawNewGeneration()
        {
            graphics.Clear(Color.Black);
            if (!no_end)
            {
                
                for (int x = 0; x < pictProcess.Width; x++)
                {
                    for (int y = 0; y < pictProcess.Height; y++)
                    {
                        if (cellularAutomata.Field[x, y].concentration >= sat_solution)
                        {
                            int MaxC = (int)(maxConc * 0.9);
                            if (cellularAutomata.Field[x, y].concentration > MaxC)
                            {
                                graphics.FillEllipse(Brushes.Yellow, x * resolution, y * resolution, resolution, resolution);
                            }
                            else
                            {
                                graphics.FillEllipse(Brushes.Gray, x * resolution, y * resolution, resolution, resolution);
                            }
                        }

                        else if (cellularAutomata.Field[x, y].concentration < sat_solution && cellularAutomata.Field[x, y].concentration > 0)//(int)(Field[x, y].saturated_solution * 0.1))
                        {
                            int MinC = (int)(sat_solution * 0.4);
                            if (cellularAutomata.Field[x, y].concentration < MinC)
                            {
                                graphics.FillEllipse(Brushes.Green, x * resolution, y * resolution, resolution, resolution);
                            }
                            else
                            {
                                graphics.FillEllipse(Brushes.White, x * resolution, y * resolution, resolution, resolution);
                            }
                        }
                        else
                        {
                            graphics.FillEllipse(Brushes.Blue, x * resolution, y * resolution, resolution, resolution);
                        }
                    }
                    Console.WriteLine();
                }
            }
            pictProcess.Refresh();
        }
            private void StopProcess()
        {
            if (!timerDisplay.Enabled)
            {
                return;
            }
            timerDisplay.Stop();
            Graphics graphic = pictGraphic.CreateGraphics();
            Pen pen = new Pen(Color.DarkBlue, 3f);

            Point[] points = new Point[cellularAutomata.quantityCurve.Count];
            for (int i = 0; i < cellularAutomata.quantityCurve.Count; i++)
            {
                points[i] = new Point(i, cellularAutomata.CurrentGeneration);
            }
            graphic.DrawLines(pen, points);
        }
            private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void butClose_MouseEnter(object sender, EventArgs e)
        {
            butClose.ForeColor = Color.DarkGreen;
        }
        private void butClose_MouseLeave(object sender, EventArgs e)
        {
            butClose.ForeColor = Color.Black;
        }

        private void butStart_MouseEnter(object sender, EventArgs e)
        {
            butStart.ForeColor = Color.Red;
        }

        private void butStart_MouseLeave(object sender, EventArgs e)
        {
            butStart.ForeColor = Color.Black;
        }
        private void butStop_MouseEnter(object sender, EventArgs e)
        {
            butStop.ForeColor = Color.Blue;
        }

        private void butStop_MouseLeave(object sender, EventArgs e)
        {
            butStop.ForeColor = Color.Black;
        }
        private void butStart_Click(object sender, EventArgs e)
        {
            StartProcess();
        }

        private void butStop_Click(object sender, EventArgs e)
        {
            StopProcess();
        }

        private void timerDisplay_Tick(object sender, EventArgs e)
        {

        }
    }
}
