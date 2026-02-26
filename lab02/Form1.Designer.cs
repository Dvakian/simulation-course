namespace lab02
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.inputH = new System.Windows.Forms.NumericUpDown();
            this.inputTau = new System.Windows.Forms.NumericUpDown();
            this.inputStartT = new System.Windows.Forms.NumericUpDown();
            this.inputTLeft = new System.Windows.Forms.NumericUpDown();
            this.inputTRight = new System.Windows.Forms.NumericUpDown();
            this.inputL = new System.Windows.Forms.NumericUpDown();
            this.inputTime = new System.Windows.Forms.NumericUpDown();
            this.inputRho = new System.Windows.Forms.NumericUpDown();
            this.inputC = new System.Windows.Forms.NumericUpDown();
            this.inputLambda = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.inputH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputStartT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputRho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputLambda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // inputH
            // 
            this.inputH.DecimalPlaces = 4;
            this.inputH.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.inputH.Location = new System.Drawing.Point(63, 31);
            this.inputH.Name = "inputH";
            this.inputH.Size = new System.Drawing.Size(120, 20);
            this.inputH.TabIndex = 0;
            // 
            // inputTau
            // 
            this.inputTau.DecimalPlaces = 4;
            this.inputTau.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.inputTau.Location = new System.Drawing.Point(63, 57);
            this.inputTau.Name = "inputTau";
            this.inputTau.Size = new System.Drawing.Size(120, 20);
            this.inputTau.TabIndex = 1;
            // 
            // inputStartT
            // 
            this.inputStartT.Location = new System.Drawing.Point(325, 17);
            this.inputStartT.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.inputStartT.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.inputStartT.Name = "inputStartT";
            this.inputStartT.Size = new System.Drawing.Size(120, 20);
            this.inputStartT.TabIndex = 2;
            // 
            // inputTLeft
            // 
            this.inputTLeft.Location = new System.Drawing.Point(325, 43);
            this.inputTLeft.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.inputTLeft.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.inputTLeft.Name = "inputTLeft";
            this.inputTLeft.Size = new System.Drawing.Size(120, 20);
            this.inputTLeft.TabIndex = 3;
            // 
            // inputTRight
            // 
            this.inputTRight.Location = new System.Drawing.Point(325, 69);
            this.inputTRight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.inputTRight.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.inputTRight.Name = "inputTRight";
            this.inputTRight.Size = new System.Drawing.Size(120, 20);
            this.inputTRight.TabIndex = 4;
            this.inputTRight.Value = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            // 
            // inputL
            // 
            this.inputL.DecimalPlaces = 3;
            this.inputL.Increment = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.inputL.Location = new System.Drawing.Point(112, 97);
            this.inputL.Name = "inputL";
            this.inputL.Size = new System.Drawing.Size(120, 20);
            this.inputL.TabIndex = 5;
            // 
            // inputTime
            // 
            this.inputTime.Location = new System.Drawing.Point(325, 95);
            this.inputTime.Name = "inputTime";
            this.inputTime.Size = new System.Drawing.Size(120, 20);
            this.inputTime.TabIndex = 6;
            // 
            // inputRho
            // 
            this.inputRho.Location = new System.Drawing.Point(112, 19);
            this.inputRho.Name = "inputRho";
            this.inputRho.Size = new System.Drawing.Size(120, 20);
            this.inputRho.TabIndex = 7;
            // 
            // inputC
            // 
            this.inputC.Location = new System.Drawing.Point(112, 45);
            this.inputC.Name = "inputC";
            this.inputC.Size = new System.Drawing.Size(120, 20);
            this.inputC.TabIndex = 8;
            // 
            // inputLambda
            // 
            this.inputLambda.Location = new System.Drawing.Point(112, 71);
            this.inputLambda.Name = "inputLambda";
            this.inputLambda.Size = new System.Drawing.Size(120, 20);
            this.inputLambda.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Launch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "шаг h";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "шаг tau";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Плотность тела";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Теплоемкость";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Теплопроводность";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Длина пластины";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Начальная";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(256, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Темп слева";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(256, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Темп справа";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(272, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Время";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(108, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(6, 161);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(461, 249);
            this.chart1.TabIndex = 23;
            this.chart1.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inputTime);
            this.groupBox1.Controls.Add(this.inputStartT);
            this.groupBox1.Controls.Add(this.inputTLeft);
            this.groupBox1.Controls.Add(this.inputTRight);
            this.groupBox1.Controls.Add(this.inputL);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.inputRho);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.inputC);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.inputLambda);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 130);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Чето вводим";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.inputTau);
            this.groupBox2.Controls.Add(this.inputH);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(499, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 130);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Чето тыкаем";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(499, 161);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(448, 249);
            this.dataGridView1.TabIndex = 26;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "h";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "tau";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "temp";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "sec";
            this.Column4.Name = "Column4";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(711, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 122);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(968, 428);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.inputH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputStartT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputRho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputLambda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown inputH;
        private System.Windows.Forms.NumericUpDown inputTau;
        private System.Windows.Forms.NumericUpDown inputStartT;
        private System.Windows.Forms.NumericUpDown inputTLeft;
        private System.Windows.Forms.NumericUpDown inputTRight;
        private System.Windows.Forms.NumericUpDown inputL;
        private System.Windows.Forms.NumericUpDown inputTime;
        private System.Windows.Forms.NumericUpDown inputRho;
        private System.Windows.Forms.NumericUpDown inputC;
        private System.Windows.Forms.NumericUpDown inputLambda;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

