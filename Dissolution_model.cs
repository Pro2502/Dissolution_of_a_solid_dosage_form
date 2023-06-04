using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office;
using Microsoft.Office.Interop.Excel;
using Point = System.Drawing.Point;

namespace Dissolution_of_a_solid_dosage_form
{
    public partial class Dissolution_model : Form
    {
        List<TimeSpan> Times = new List<TimeSpan>(15000);
        public List<int> QuantityCurve = new List<int>(15000);

        private Graphics graphics;
        private int resolution;
        private int maxConc;
        private int sat_solution;
        private double Dt,k;
        private bool no_end = true;
        private CellularAutomata cellularAutomata;
        private int R;
        private int attitude = 15000;//если для лоратадина, 18883 - для кетопрофена,  45032 - для нимесулида
        public Dissolution_model()
        {
            TopMost = false;
            InitializeComponent();

            backgroundWorker1 = new BackgroundWorker()
            {
                WorkerReportsProgress = true,//поток поодерживает сообщения о прогрессе
                WorkerSupportsCancellation = true,//поток может быть прерван              
            };
            //подписываемся на события описанные ниже
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;//что будет выполняться в потоке
            backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;//эта функция будет вызываться и сообщать о прогрессе
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;//событие завершения работы потока            
        }

        private void StartProcess()
        {
            TimeSpan time = DateTime.Now.TimeOfDay;//отсчет времени
            bool can_update = true;
            while (no_end)
            {
                for (int i = 0; can_update; i++)
                {
                    if (no_end)
                    {
                        cellularAutomata.Transition_Rule_dissolution(k, sat_solution);
                        cellularAutomata.Transition_Rule_diffusion(Dt, sat_solution);
                        cellularAutomata.Transformation(pictProcess.Width / resolution, pictProcess.Height / resolution);

                        QuantityCurve.Add((int)cellularAutomata.quantity);
                        cellularAutomata.Iteration_Count(ref no_end, pictProcess.Width / (2 * resolution), pictProcess.Height / (2 * resolution));
                        DrawNewGeneration();

                        Times.Add(DateTime.Now.TimeOfDay - time);
                        if (i % 15 == 0)//каждую 20 итерацию сообщаем о прогрессе
                        {
                            backgroundWorker1.ReportProgress(0, Times);
                            if (backgroundWorker1.CancellationPending)
                            {
                                no_end = false;
                                break;
                            }//если был запрос на отмену - прерываем выполнение
                        }
                        //pictProcess.Refresh();//обновляем элементы управления ТОЛЬКО в основном потоке
                        //и если делать это слишком часто то всё снова зависнет
                        //конец времени
                    }
                    else
                    {
                        break;
                    }
                }
            

                timerDisplay.Start();
            }
        }

        private void DrawNewGeneration()
        {
            graphics.Clear(Color.Black);
            
            {

                for (int x = 0; x < cellularAutomata.Field.GetLength(0); x++)
                {
                    for (int y = 0; y < cellularAutomata.Field.GetLength(1); y++)
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
                        else
                        {
                            int weight = (int)(255 * cellularAutomata.Field[x, y].concentration / sat_solution);
                            int r = weight;
                            int g = 0;
                            int b = 255 - weight;
                            Brush brush = new SolidBrush(Color.FromArgb(r, g, b));
                            graphics.FillEllipse(brush, x * resolution, y * resolution, resolution, resolution);
                        }
                        //else if (cellularAutomata.Field[x, y].concentration < sat_solution && cellularAutomata.Field[x, y].concentration > 0)//(int)(Field[x, y].saturated_solution * 0.1))
                        //{
                        //    int MinC = (int)(sat_solution * 0.4);
                        //    if (cellularAutomata.Field[x, y].concentration < MinC)
                        //    {
                        //        graphics.FillEllipse(Brushes.Green, x * resolution, y * resolution, resolution, resolution);
                        //    }
                        //    else
                        //    {
                        //        graphics.FillEllipse(Brushes.White, x * resolution, y * resolution, resolution, resolution);
                        //    }
                        //}
                        //else
                        //{
                        //    graphics.FillEllipse(Brushes.Blue, x * resolution, y * resolution, resolution, resolution);
                        //}
                    }
                    Console.WriteLine();
                }
            }
            //pictProcess.Refresh();
        }

        private void StopProcess()
        {
            if (!timerDisplay.Enabled)
            {
                return;
            }
            timerDisplay.Stop();
            //Graphics graphic = pictGraphic.CreateGraphics();
            //Pen pen = new Pen(Color.DarkBlue, 3f);

            //Point[] points = new Point[QuantityCurve.Count];
            //for (int i = 0; i < QuantityCurve.Count; i++)
            //{
            //    points[i] = new Point(i, cellularAutomata.CurrentGeneration);
            //}
            //graphic.DrawLines(pen, points);
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
            if (backgroundWorker1.IsBusy)//если работа уже выполняется - выходим
                return;
            nud_Dt.Enabled = false;
            nud_k.Enabled = false;
            resolution = (int)nudResol.Value;
            maxConc = (int)nudConc.Value;
            sat_solution = maxConc / 2;
            R= (int)(((int)Math.Sqrt(pictProcess.Height* pictProcess.Width/attitude / Math.PI)));
            Dt = (double)nud_Dt.Value;
            k = (double)nud_k.Value;
            cellularAutomata = new CellularAutomata();
            cellularAutomata.Initialisation(pictProcess.Width / resolution, pictProcess.Height / resolution, pictProcess.Width / (2 * resolution), pictProcess.Height / (2 * resolution), maxConc, sat_solution,R);
            // Инициализируем канву сразу
            pictProcess.Image = new Bitmap(pictProcess.Width, pictProcess.Height);
            graphics = Graphics.FromImage(pictProcess.Image);
            backgroundWorker1.RunWorkerAsync();
            //StartProcess();
        }


        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            StartProcess();
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //listBox1.Items.Clear();
            List<TimeSpan> times = (List<TimeSpan>)e.UserState;
            Time_record.DataSource = times.ToArray();
            pictProcess.Refresh();
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            nud_Dt.Enabled = true;
            nud_k.Enabled = true;
            //MessageBox.Show("End!");
        }



        private void butStop_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            StopProcess();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog()
            {
                InitialDirectory = @"D:\Дипломная работа\Для диплома\Dissolution_of_a_solid_dosage_form-master",
                AddExtension = true,
                DefaultExt = ".xlsx",
                ValidateNames = true,
                OverwritePrompt = false,
                Filter = "Excel files (*.xlsx)|*.xlsx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(sfd.FileName))
                    {
                        Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
                        exApp.DisplayAlerts = false;
                        Workbook wb = exApp.Workbooks.Open(sfd.FileName);
                        Worksheet sh = wb.Worksheets[1];
                        int lRow = sh.UsedRange.Rows.Count + 2;
                        for (int i = 0; i < Times.Count; i++)
                        {
                            sh.Cells[i + lRow, 1] = Times[i].ToString();
                            sh.Cells[i + lRow, 2] = QuantityCurve[i].ToString();
                        }

                        wb.SaveAs(sfd.FileName);
                        //wb.Close(true);
                        exApp.Quit();
                    }
                    else
                    {
                        Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
                        exApp.DisplayAlerts = false;
                        Workbook wb = exApp.Workbooks.Add();
                        Worksheet sh = wb.ActiveSheet;

                        for (int i = 0; i < Times.Count; i++)
                        {
                            sh.Cells[i + 1, 1] = Times[i].ToString();
                            sh.Cells[i + 1, 2] = QuantityCurve[i].ToString();
                        }

                        wb.SaveAs(sfd.FileName);
                        //wb.Close();
                        exApp.Quit();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void timerDisplay_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
