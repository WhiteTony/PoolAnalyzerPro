namespace PoolAnalyserProGui
{
    partial class papForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.phLabel = new System.Windows.Forms.Label();
            this.TdsLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TempLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PhMinTextBox = new System.Windows.Forms.TextBox();
            this.TdsMinTextBox = new System.Windows.Forms.TextBox();
            this.TempMinTextBox = new System.Windows.Forms.TextBox();
            this.PhMaxTextBox = new System.Windows.Forms.TextBox();
            this.TdsMaxTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tempMaxTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.TestConnection = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPortSelector = new System.Windows.Forms.ComboBox();
            this.baudRateSelection = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.DeleteEvents = new System.Windows.Forms.Button();
            this.unwantedEventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unwantedEventBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.Controls.Add(this.phLabel, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.TdsLabel, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.TempLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(193, 386);
            this.tableLayoutPanel3.TabIndex = 7;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // phLabel
            // 
            this.phLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.phLabel.AutoSize = true;
            this.phLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phLabel.Location = new System.Drawing.Point(46, 256);
            this.phLabel.Name = "phLabel";
            this.phLabel.Size = new System.Drawing.Size(144, 130);
            this.phLabel.TabIndex = 5;
            this.phLabel.Text = "phLabel";
            this.phLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.phLabel.Click += new System.EventHandler(this.label13_Click);
            // 
            // TdsLabel
            // 
            this.TdsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TdsLabel.AutoSize = true;
            this.TdsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TdsLabel.Location = new System.Drawing.Point(46, 128);
            this.TdsLabel.Name = "TdsLabel";
            this.TdsLabel.Size = new System.Drawing.Size(144, 128);
            this.TdsLabel.TabIndex = 4;
            this.TdsLabel.Text = "TdsLabel";
            this.TdsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TdsLabel.Click += new System.EventHandler(this.label12_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 130);
            this.label9.TabIndex = 2;
            this.label9.Text = "pH:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 128);
            this.label3.TabIndex = 0;
            this.label3.Text = "Temp:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // TempLabel
            // 
            this.TempLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TempLabel.AutoSize = true;
            this.TempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TempLabel.Location = new System.Drawing.Point(46, 0);
            this.TempLabel.Name = "TempLabel";
            this.TempLabel.Size = new System.Drawing.Size(144, 128);
            this.TempLabel.TabIndex = 3;
            this.TempLabel.Text = "TempLabel";
            this.TempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TempLabel.Click += new System.EventHandler(this.label10_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 128);
            this.label8.TabIndex = 1;
            this.label8.Text = "TDS:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.Controls.Add(this.PhMinTextBox, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.TdsMinTextBox, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.TempMinTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.PhMaxTextBox, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.TdsMaxTextBox, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tempMaxTextBox, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 393);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(197, 63);
            this.tableLayoutPanel2.TabIndex = 6;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // PhMinTextBox
            // 
            this.PhMinTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PhMinTextBox.Location = new System.Drawing.Point(144, 41);
            this.PhMinTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.PhMinTextBox.Name = "PhMinTextBox";
            this.PhMinTextBox.Size = new System.Drawing.Size(52, 20);
            this.PhMinTextBox.TabIndex = 16;
            this.PhMinTextBox.Text = "7.6";
            // 
            // TdsMinTextBox
            // 
            this.TdsMinTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TdsMinTextBox.Location = new System.Drawing.Point(94, 41);
            this.TdsMinTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.TdsMinTextBox.Name = "TdsMinTextBox";
            this.TdsMinTextBox.Size = new System.Drawing.Size(48, 20);
            this.TdsMinTextBox.TabIndex = 15;
            this.TdsMinTextBox.Text = "10";
            // 
            // TempMinTextBox
            // 
            this.TempMinTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TempMinTextBox.Location = new System.Drawing.Point(42, 41);
            this.TempMinTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.TempMinTextBox.Name = "TempMinTextBox";
            this.TempMinTextBox.Size = new System.Drawing.Size(50, 20);
            this.TempMinTextBox.TabIndex = 14;
            this.TempMinTextBox.Text = "15";
            // 
            // PhMaxTextBox
            // 
            this.PhMaxTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PhMaxTextBox.Location = new System.Drawing.Point(144, 21);
            this.PhMaxTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.PhMaxTextBox.Name = "PhMaxTextBox";
            this.PhMaxTextBox.Size = new System.Drawing.Size(52, 20);
            this.PhMaxTextBox.TabIndex = 13;
            this.PhMaxTextBox.Text = "8.2";
            this.PhMaxTextBox.TextChanged += new System.EventHandler(this.PhMaxTextBox_TextChanged);
            // 
            // TdsMaxTextBox
            // 
            this.TdsMaxTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TdsMaxTextBox.Location = new System.Drawing.Point(94, 21);
            this.TdsMaxTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.TdsMaxTextBox.Name = "TdsMaxTextBox";
            this.TdsMaxTextBox.Size = new System.Drawing.Size(48, 20);
            this.TdsMaxTextBox.TabIndex = 12;
            this.TdsMaxTextBox.Text = "2000";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1, 45);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Min";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 23);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Max";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "ph";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "TDS";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Temp";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // tempMaxTextBox
            // 
            this.tempMaxTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tempMaxTextBox.Location = new System.Drawing.Point(42, 21);
            this.tempMaxTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.tempMaxTextBox.Name = "tempMaxTextBox";
            this.tempMaxTextBox.Size = new System.Drawing.Size(50, 20);
            this.tempMaxTextBox.TabIndex = 10;
            this.tempMaxTextBox.Text = "40";
            this.tempMaxTextBox.TextChanged += new System.EventHandler(this.tempMaxTextBox_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 420F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(791, 477);
            this.tableLayoutPanel1.TabIndex = 6;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.TestConnection);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.serialPortSelector);
            this.panel1.Controls.Add(this.baudRateSelection);
            this.panel1.Location = new System.Drawing.Point(200, 393);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 63);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Update min/max";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestConnection
            // 
            this.TestConnection.Location = new System.Drawing.Point(126, 29);
            this.TestConnection.Name = "TestConnection";
            this.TestConnection.Size = new System.Drawing.Size(105, 23);
            this.TestConnection.TabIndex = 0;
            this.TestConnection.Text = "Scan COM Ports";
            this.TestConnection.UseVisualStyleBackColor = true;
            this.TestConnection.Click += new System.EventHandler(this.TestConnection_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Baudrate";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "COM Port";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // serialPortSelector
            // 
            this.serialPortSelector.FormattingEnabled = true;
            this.serialPortSelector.Location = new System.Drawing.Point(292, 31);
            this.serialPortSelector.Name = "serialPortSelector";
            this.serialPortSelector.Size = new System.Drawing.Size(121, 21);
            this.serialPortSelector.TabIndex = 1;
            this.serialPortSelector.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // baudRateSelection
            // 
            this.baudRateSelection.FormattingEnabled = true;
            this.baudRateSelection.Location = new System.Drawing.Point(292, 4);
            this.baudRateSelection.Name = "baudRateSelection";
            this.baudRateSelection.Size = new System.Drawing.Size(121, 21);
            this.baudRateSelection.TabIndex = 2;
            this.baudRateSelection.SelectedIndexChanged += new System.EventHandler(this.baudRateSelection_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(202, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(414, 386);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.button5, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button4, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.button3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.DeleteEvents, 0, 3);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(622, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(110, 386);
            this.tableLayoutPanel4.TabIndex = 11;
            this.tableLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 131);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "Delete local";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Synchronise time";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 163);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Synchronise time";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Request events";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // DeleteEvents
            // 
            this.DeleteEvents.Location = new System.Drawing.Point(3, 93);
            this.DeleteEvents.Name = "DeleteEvents";
            this.DeleteEvents.Size = new System.Drawing.Size(100, 23);
            this.DeleteEvents.TabIndex = 11;
            this.DeleteEvents.Text = "Delete events";
            this.DeleteEvents.UseVisualStyleBackColor = true;
            this.DeleteEvents.Click += new System.EventHandler(this.DeleteEvents_Click);
            // 
            // unwantedEventBindingSource
            // 
            this.unwantedEventBindingSource.DataSource = typeof(PoolAnalyserProGui.UnwantedEvent);
            // 
            // papForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 477);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "papForm";
            this.Text = "PoolAnalyzerPro";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.unwantedEventBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label phLabel;
        private System.Windows.Forms.Label TdsLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TempLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox PhMinTextBox;
        private System.Windows.Forms.TextBox TdsMinTextBox;
        private System.Windows.Forms.TextBox TempMinTextBox;
        private System.Windows.Forms.TextBox PhMaxTextBox;
        private System.Windows.Forms.TextBox TdsMaxTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tempMaxTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource unwantedEventBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button TestConnection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox serialPortSelector;
        private System.Windows.Forms.ComboBox baudRateSelection;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn differenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button DeleteEvents;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
    }
}

