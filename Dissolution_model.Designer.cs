
namespace Dissolution_of_a_solid_dosage_form
{
    partial class Dissolution_model
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudConc = new System.Windows.Forms.NumericUpDown();
            this.butStart = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.pictProcess = new System.Windows.Forms.PictureBox();
            this.pictGraphic = new System.Windows.Forms.PictureBox();
            this.butStop = new System.Windows.Forms.Button();
            this.timerDisplay = new System.Windows.Forms.Timer(this.components);
            this.nudResol = new System.Windows.Forms.NumericUpDown();
            this.nudResolution = new System.Windows.Forms.Label();
            this.nud_Dt = new System.Windows.Forms.NumericUpDown();
            this.nud_k = new System.Windows.Forms.NumericUpDown();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Time_record = new System.Windows.Forms.ListBox();
            this.butSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudConc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Dt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_k)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(327, 710);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dissolution of a solid drug substance ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Exercise:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(115, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sat. sol. concentration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(142, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Diffusion coefficient";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(142, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Dissolution factor";
            // 
            // nudConc
            // 
            this.nudConc.AllowDrop = true;
            this.nudConc.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudConc.Location = new System.Drawing.Point(44, 116);
            this.nudConc.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudConc.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudConc.Name = "nudConc";
            this.nudConc.Size = new System.Drawing.Size(54, 27);
            this.nudConc.TabIndex = 8;
            this.nudConc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudConc.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // butStart
            // 
            this.butStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.butStart.AutoSize = true;
            this.butStart.BackColor = System.Drawing.Color.Pink;
            this.butStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butStart.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.butStart.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butStart.Location = new System.Drawing.Point(30, 479);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(277, 78);
            this.butStart.TabIndex = 11;
            this.butStart.Text = "START";
            this.butStart.UseVisualStyleBackColor = false;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            this.butStart.MouseEnter += new System.EventHandler(this.butStart_MouseEnter);
            this.butStart.MouseLeave += new System.EventHandler(this.butStart_MouseLeave);
            // 
            // butClose
            // 
            this.butClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.butClose.AutoSize = true;
            this.butClose.BackColor = System.Drawing.Color.LawnGreen;
            this.butClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butClose.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butClose.Location = new System.Drawing.Point(74, 656);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(188, 42);
            this.butClose.TabIndex = 12;
            this.butClose.Text = "CLOSE";
            this.butClose.UseVisualStyleBackColor = false;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            this.butClose.MouseEnter += new System.EventHandler(this.butClose_MouseEnter);
            this.butClose.MouseLeave += new System.EventHandler(this.butClose_MouseLeave);
            // 
            // pictProcess
            // 
            this.pictProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictProcess.Location = new System.Drawing.Point(327, 0);
            this.pictProcess.Name = "pictProcess";
            this.pictProcess.Size = new System.Drawing.Size(758, 710);
            this.pictProcess.TabIndex = 13;
            this.pictProcess.TabStop = false;
            // 
            // pictGraphic
            // 
            this.pictGraphic.Location = new System.Drawing.Point(333, 634);
            this.pictGraphic.Name = "pictGraphic";
            this.pictGraphic.Size = new System.Drawing.Size(751, 76);
            this.pictGraphic.TabIndex = 14;
            this.pictGraphic.TabStop = false;
            this.pictGraphic.Visible = false;
            // 
            // butStop
            // 
            this.butStop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.butStop.AutoSize = true;
            this.butStop.BackColor = System.Drawing.Color.LightBlue;
            this.butStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butStop.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butStop.Location = new System.Drawing.Point(30, 554);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(277, 78);
            this.butStop.TabIndex = 15;
            this.butStop.Text = "STOP";
            this.butStop.UseVisualStyleBackColor = false;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            this.butStop.MouseEnter += new System.EventHandler(this.butStop_MouseEnter);
            this.butStop.MouseLeave += new System.EventHandler(this.butStop_MouseLeave);
            // 
            // timerDisplay
            // 
            this.timerDisplay.Interval = 50;
            this.timerDisplay.Tick += new System.EventHandler(this.timerDisplay_Tick);
            // 
            // nudResol
            // 
            this.nudResol.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudResol.Hexadecimal = true;
            this.nudResol.InterceptArrowKeys = false;
            this.nudResol.Location = new System.Drawing.Point(44, 149);
            this.nudResol.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudResol.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudResol.Name = "nudResol";
            this.nudResol.Size = new System.Drawing.Size(54, 27);
            this.nudResol.TabIndex = 18;
            this.nudResol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudResol.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nudResolution
            // 
            this.nudResolution.AutoSize = true;
            this.nudResolution.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudResolution.Location = new System.Drawing.Point(115, 151);
            this.nudResolution.Name = "nudResolution";
            this.nudResolution.Size = new System.Drawing.Size(85, 19);
            this.nudResolution.TabIndex = 19;
            this.nudResolution.Text = "Resolution";
            // 
            // nud_Dt
            // 
            this.nud_Dt.DecimalPlaces = 3;
            this.nud_Dt.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nud_Dt.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_Dt.Location = new System.Drawing.Point(44, 198);
            this.nud_Dt.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            131072});
            this.nud_Dt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nud_Dt.Name = "nud_Dt";
            this.nud_Dt.Size = new System.Drawing.Size(77, 27);
            this.nud_Dt.TabIndex = 20;
            this.nud_Dt.ThousandsSeparator = true;
            this.nud_Dt.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // nud_k
            // 
            this.nud_k.DecimalPlaces = 3;
            this.nud_k.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nud_k.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nud_k.Location = new System.Drawing.Point(44, 234);
            this.nud_k.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.nud_k.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_k.Name = "nud_k";
            this.nud_k.Size = new System.Drawing.Size(77, 27);
            this.nud_k.TabIndex = 21;
            this.nud_k.ThousandsSeparator = true;
            this.nud_k.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // Time_record
            // 
            this.Time_record.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Time_record.FormattingEnabled = true;
            this.Time_record.ItemHeight = 17;
            this.Time_record.Location = new System.Drawing.Point(30, 287);
            this.Time_record.Name = "Time_record";
            this.Time_record.Size = new System.Drawing.Size(267, 123);
            this.Time_record.TabIndex = 22;
            // 
            // butSave
            // 
            this.butSave.AutoSize = true;
            this.butSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSave.Location = new System.Drawing.Point(119, 416);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(107, 32);
            this.butSave.TabIndex = 23;
            this.butSave.Text = "сохранить";
            this.butSave.UseVisualStyleBackColor = false;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // Dissolution_model
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 710);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.Time_record);
            this.Controls.Add(this.nud_k);
            this.Controls.Add(this.nud_Dt);
            this.Controls.Add(this.nudResolution);
            this.Controls.Add(this.nudResol);
            this.Controls.Add(this.butStop);
            this.Controls.Add(this.pictGraphic);
            this.Controls.Add(this.pictProcess);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butStart);
            this.Controls.Add(this.nudConc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dissolution_model";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dissolution model";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.nudConc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Dt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_k)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudConc;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.PictureBox pictProcess;
        private System.Windows.Forms.PictureBox pictGraphic;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.Timer timerDisplay;
        private System.Windows.Forms.NumericUpDown nudResol;
        private System.Windows.Forms.Label nudResolution;
        private System.Windows.Forms.NumericUpDown nud_Dt;
        private System.Windows.Forms.NumericUpDown nud_k;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox Time_record;
        private System.Windows.Forms.Button butSave;
    }
}

