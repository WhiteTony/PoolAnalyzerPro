using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Globalization;




namespace PoolAnalyserProGui
{
    
    public partial class papForm : Form
    {
        public string[] serialPortChoices;
        public string selectedPort;
        public string reveivedMessage;
        public SerialPort serialPort;
        public int[] baudRateChoices;
        static string inBuffer;
        public double maxTemp;
        public double minTemp;
        public double maxTds;
        public double minTds;
        public double maxPh;
        public double minPh;
        const string TEMP = "tp";
        const string TDS = "td";
        const string PH = "ph";
        const string TOOHIGH = "High";
        const string TOOLOW = "Low";
        public double temp;
        public BindingList<UnwantedEvent> UnwantedEventList { get; set; }

        public event System.IO.Ports.SerialDataReceivedEventHandler DataReceived;

        public papForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;



            this.maxTemp = 40.00;
            this.minTemp = 10.00;
            this.maxTds = 800;
            this.minTds = 100;
            this.maxPh = 8.5;
            this.minPh = 6.5;
            

            serialPort = new SerialPort("COM9");
            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.None;
            serialPort.RtsEnable = true;


            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            //serialPort.Open();

            baudRateChoices = new int[10];
            baudRateChoices[0] = 110;
            baudRateChoices[1] = 300;
            baudRateChoices[2] = 600;
            baudRateChoices[3] = 1200;
            baudRateChoices[4] = 2400;
            baudRateChoices[5] = 4800;
            baudRateChoices[6] = 9600;
            baudRateChoices[7] = 14400;
            baudRateChoices[8] = 19200;
            baudRateChoices[9] = 38400;


            for (int i = 0; i < 10; i++)
            {
                baudRateSelection.Items.Add(baudRateChoices[i]);
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoGenerateColumns = true;

            UnwantedEventList = new BindingList<UnwantedEvent>();


            var source = new BindingSource();

            source.DataSource = UnwantedEventList;

            dataGridView1.DataSource = source;

            UnwantedEvent unwantedEventTest = new UnwantedEvent(TEMP, TOOLOW, 4, DateTime.Now);
            UnwantedEventList.Add(unwantedEventTest);

        }

        public void addEvent(UnwantedEvent unwantedEvent)
        {
            UnwantedEventList.Add(unwantedEvent);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void TestConnection_Click(object sender, EventArgs e)
        {
            serialPortSelector.Items.Clear();
            serialPortChoices = SerialPort.GetPortNames();
            
            for (int i=0;i<serialPortChoices.Length;i++)
            {
                serialPortSelector.Items.Add(serialPortChoices[i]);
            }

        }

        
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPort = this.serialPortSelector.GetItemText(this.serialPortSelector.SelectedItem);
        }

        private void baudRateSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.serialPort.BaudRate = (int)this.baudRateSelection.SelectedItem;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
         void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
         {

            SerialPort sp = (SerialPort)sender;
            DateTime timeStamp = DateTime.Now;
            string indata = sp.ReadExisting();

            // Si message pas encore fini
            if (indata[indata.Length-1] != '\n')
            {
                inBuffer += indata;
            }
            // Si message fini mais il reste du contenu a mettre dans le buffer
            else if(indata[indata.Length-1] == '\n' && indata.Length > 1)
            {
                inBuffer += indata.Substring(0, indata.Length - 1);
                sortData(inBuffer);
                inBuffer = String.Empty;
            }
            // Si le message est fini
            else
            {
                sortData(inBuffer);
                inBuffer = String.Empty;
            }
         }

        void sortData(string buffer)
        {
            string prefix = inBuffer.Substring(0, 2);
            string valueString;
            double doubleOutData;

            int secondString;
            string minuteString;
            string hourString;
            string dayString;
            string monthString;
            DateTime eventTime = new DateTime();

            if (prefix == TEMP)
            {
                valueString = inBuffer.Substring(3, 4);
                doubleOutData = Convert.ToDouble(valueString) / 10;

                SetTempText(doubleOutData.ToString() + " °C");

            }

            if (prefix == TDS)
            {
                valueString = inBuffer.Substring(3, 4);
                doubleOutData = Convert.ToDouble(valueString);

                SetTdsText(doubleOutData.ToString() + " ppm");
            }

            if (prefix == PH)
            {
                valueString = inBuffer.Substring(3, 3);
                doubleOutData = Convert.ToDouble(valueString) / 10;

                SetpHText(doubleOutData.ToString());
            }

            if(prefix == "th")
            {
                valueString = inBuffer.Substring(3, 4);
                minuteString = inBuffer.Substring(9, 2);
                hourString = inBuffer.Substring(11, 2);
                dayString = inBuffer.Substring(13, 2);
                monthString = inBuffer.Substring(15, 2);
                doubleOutData = Convert.ToDouble(valueString) / 10;

                //th_ttttsshh
                
                 eventTime = new DateTime(2021, Convert.ToInt32(monthString), Convert.ToInt32(dayString), Convert.ToInt32(hourString), Convert.ToInt32(minuteString), 0);


                UnwantedEvent temp2HighEvent = new UnwantedEvent("Temp", "High", doubleOutData, eventTime);

                
                
                addEvent(temp2HighEvent);



            }
            if (prefix == "sh")
            {
                valueString = inBuffer.Substring(3, 4);
                minuteString = inBuffer.Substring(9, 2);
                hourString = inBuffer.Substring(11, 2);
                dayString = inBuffer.Substring(13, 2);
                monthString = inBuffer.Substring(15, 2);
                doubleOutData = Convert.ToDouble(valueString);

                //th_ttttsshh

                eventTime = new DateTime(2021, Convert.ToInt32(monthString), Convert.ToInt32(dayString), Convert.ToInt32(hourString), Convert.ToInt32(minuteString), 0);


                UnwantedEvent temp2HighEvent = new UnwantedEvent("Tds", "High", doubleOutData, eventTime);



                addEvent(temp2HighEvent);



            }
        }


        // Fonctions qui permettent de changer le texte des Labels sur le form
        delegate void SetTextCallback(string text);



        private void SetTempText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.TempLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTempText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.TempLabel.Text = text;
            }
        }

        private void SetTdsText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.TempLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTdsText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.TdsLabel.Text = text;
            }
        }
        private void SetpHText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.TempLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetpHText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.phLabel.Text = text;
            }
        }

        #region Buttons
        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void tempMaxTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string second;
            string minute;
            string hour;
            string month;
            string day;
            DateTime now = DateTime.Now;

            if (now.Second > 9)
            {
                second = now.Second.ToString();
            }
            else
            {
                second = "0" + now.Second.ToString();
            }

            if(now.Minute > 9)
            {
                minute = now.Minute.ToString();
            }
            else
            {
                minute = "0" + now.Minute.ToString();
            }

            if(now.Hour > 9)
            {
                hour = now.Hour.ToString();
            }
            else
            {
                hour = "0" + now.Hour.ToString();
            }

            if (now.Day > 9)
            {
                day = now.Day.ToString();
            }
            else
            {
                day = "0" + now.Day.ToString();
            }

            if (now.Month > 9)
            {
                month = now.Month.ToString();
            }
            else
            {
                month = "0" + now.Month.ToString();
            }

            serialPort.Write("tm_" + second + minute + hour + day + month + '\n');
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Send temperature
            double tempMaxDouble = Convert.ToDouble(tempMaxTextBox.Text) * 10;
            double tempMinDouble = Convert.ToDouble(TempMinTextBox.Text) * 10;
            string tempMaxToSend;
            string tempMinToSend;

            if (tempMaxDouble / 10 > 9)
            {
                tempMaxToSend = tempMaxDouble.ToString();
            }
            else if (tempMaxDouble / 10 > 0.9)
            {
                tempMaxToSend = "0" + tempMaxDouble.ToString();
            }
            else
            {
                tempMaxToSend = "00" + tempMaxDouble.ToString();
            }

            if (tempMinDouble/10 > 9)
            {
                tempMinToSend = tempMinDouble.ToString();
            }
            else if (tempMinDouble/10 > 0.9)
            {
                tempMinToSend = "0" + tempMinDouble.ToString();
            }
            else
            {
                tempMinToSend = "00" + tempMinDouble.ToString();
            }

            //Send TDS
            string tdsMaxToSend;
            string tdsMinToSend;

            double tdsMaxDouble = Convert.ToDouble(TdsMaxTextBox.Text);
            double tdsMinDouble = Convert.ToDouble(TdsMinTextBox.Text);

            if (tdsMaxDouble > 999)
            {
                tdsMaxToSend = TdsMaxTextBox.Text;
            }
            else if (tdsMaxDouble > 99)
            {
                tdsMaxToSend = "0" + TdsMaxTextBox.Text;
            }
            else if (tdsMaxDouble > 9)
            {
                tdsMaxToSend = "00" + TdsMaxTextBox.Text;
            }
            else
            {
                tdsMaxToSend = "000" + TdsMaxTextBox.Text;
            }

            if (tdsMinDouble > 999)
            {
                tdsMinToSend = TdsMinTextBox.Text;
            }
            else if (tdsMinDouble > 99)
            {
                tdsMinToSend = "0" + TdsMinTextBox.Text;
            }
            else if (tdsMinDouble > 9)
            {
                tdsMinToSend = "00" + TdsMinTextBox.Text;
            }
            else
            {
                tdsMinToSend = "000" + TdsMinTextBox.Text;
            }

            //Send pH
            double phMaxDouble = Convert.ToDouble(PhMaxTextBox.Text) * 10;
            double phMinDouble = Convert.ToDouble(PhMinTextBox.Text) * 10;
            string phMaxToSend;
            string phMinToSend;

            if (phMaxDouble/10 > 9)
            {
                phMaxToSend = phMaxDouble.ToString();
            }
            else
            {
                phMaxToSend = "0" + phMaxDouble.ToString();
            }

            if (phMinDouble / 10 > 9)
            {
                phMinToSend = phMinDouble.ToString();
            }
            else
            {
                phMinToSend = "0" + phMinDouble.ToString();
            }




            string minMaxMessage = "mm_" + tempMaxToSend + tempMinToSend + tdsMaxToSend + tdsMinToSend + phMaxToSend + phMinToSend;
            serialPort.Write(minMaxMessage + '\n');
            minMaxMessage = string.Empty;
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            string second;
            string minute;
            string hour;
            string month;
            string day;
            DateTime now = DateTime.Now;

            // Pour s'assurer que le format du message est toujours tm_ssmmhhjjMM
            // i.e si seconde = 1 on veut envoyer tm_01... et non tm_1... 
            if (now.Second > 9)
            {
                second = now.Second.ToString();
            }
            else
            {
                second = "0" + now.Second.ToString();
            }

            if (now.Minute > 9)
            {
                minute = now.Minute.ToString();
            }
            else
            {
                minute = "0" + now.Minute.ToString();
            }

            if (now.Hour > 9)
            {
                hour = now.Hour.ToString();
            }
            else
            {
                hour = "0" + now.Hour.ToString();
            }

            if (now.Day > 9)
            {
                day = now.Day.ToString();
            }
            else
            {
                day = "0" + now.Day.ToString();
            }

            if (now.Month > 9)
            {
                month = now.Month.ToString();
            }
            else
            {
                month = "0" + now.Month.ToString();
            }

            serialPort.Write("tm_" + second + minute + hour + day + month + '\n');
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void PhMaxTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeleteEvents_Click(object sender, EventArgs e)
        {
            UnwantedEventList.Clear();
            dataGridView1.Rows.Clear();
            serialPort.Write("dl" + '\n');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UnwantedEventList.Clear();
            dataGridView1.Rows.Clear();
            serialPort.Write("re" + '\n');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UnwantedEventList.Clear();
            dataGridView1.Rows.Clear();
        }
    }
        #endregion 

}




