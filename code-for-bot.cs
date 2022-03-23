using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpamBot
{
    public partial class Form1 : Form
    {

        public int number;
        public int maxProgress = 80000;
        public int ammountOfMessages;
        public bool isInfinit = true;
        public bool ammountIsAll;
        public int i = -1;
        public Form1()
        {
            InitializeComponent();
            label2.Text = "";
            if(delayTextBox.Text == "")
            {
                maxProgress = 1000;
            }
            else
            {
                try
                {
                    maxProgress = int.Parse(delayTextBox.Text);
                    delayTextBox.Text = maxProgress.ToString();
                    progressBar1.Maximum = maxProgress;
                }
                catch (Exception)
                {
                    maxProgress = 1000;
                    progressBar1.Maximum = maxProgress;

                }
                
            }
            trackBar1.Maximum = 10000;
            trackBar1.Minimum = 10;
            trackBar1.Value = 5000;
            number = trackBar1.Value;
            delayNubmerLabel.Text = trackBar1.Value.ToString();
            progressBar1.Maximum = maxProgress;
            progressBar1.Minimum = 0;
            loadingSpamLabel.Visible = false;
            progressBar1.Visible = false;
            infinitRadioButton.Checked = true;
            ammountRadioButton.Checked = false;
            stopButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            loadingSpamLabel.Visible = false;
            stopButton.Enabled = true;
            if (isInfinit == true)
            {
                timer1.Interval = trackBar1.Value;

                SendKeys.Send(textBox1.Text);
                SendKeys.Send("{ENTER}");
            }
            else if(isInfinit == false) 
            {
                if(i != ammountOfMessages)
                {
                    timer1.Interval = trackBar1.Value;

                    SendKeys.Send(textBox1.Text);
                    SendKeys.Send("{ENTER}");
                    i++;
                    int all = ammountOfMessages - i;
                    label2.Text = all.ToString();
                }
                else
                {
                    timer1.Stop();
                    textBox1.Enabled = true;
                    numberOfMessagesTextBox.Enabled = true;
                    i = -1;
                    startButton.Enabled = true;
                    stopButton.Enabled = false;
                    delayTextBox.Enabled = true;
                    delayInMsTextBox.Enabled = true;
                    MessageBox.Show("Bot Stopped", "Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                

            }
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            try
            {
                maxProgress = int.Parse(delayTextBox.Text);
                delayTextBox.Text = maxProgress.ToString();
                progressBar1.Maximum = maxProgress;
            }
            catch (Exception)
            {
                maxProgress = 1000;

            }
            textBox1.Enabled = false;
            numberOfMessagesTextBox.Enabled = false;
            delayTextBox.Enabled = false;
            delayInMsTextBox.Enabled = false;
            MessageBox.Show("Bot Started", "Started", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (infinitRadioButton.Checked)
            {
                isInfinit = true;
                progressBar1.Visible = true;
                loadingSpamLabel.Visible = true;
                for (int i = 0; i <= maxProgress; i++)
                {
                    progressBar1.Value = i;
                }
                timer1.Start();
            }
            else if (!infinitRadioButton.Checked)
            {
                try
                {
                    ammountOfMessages = int.Parse(numberOfMessagesTextBox.Text);
                }
                catch (Exception)
                {

                    MessageBox.Show("An Error Accured Make Sure to only Put numbers in the Ammount Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                isInfinit = false;
                progressBar1.Visible = true;
                loadingSpamLabel.Visible = true;
                for (int i = 0; i <= maxProgress; i++)
                {
                    progressBar1.Value = i;
                }
                timer1.Start();
                
            }
            
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            startButton.Enabled = true;
            numberOfMessagesTextBox.Enabled = true;
            timer1.Stop();
            i = -1;
            stopButton.Enabled = false;
            delayTextBox.Enabled = true;
            delayInMsTextBox.Enabled = true;
            MessageBox.Show("Bot Stopped", "Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            delayNubmerLabel.Text = trackBar1.Value.ToString();
        }

        private void infinitRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isInfinit = true;
            numberOfMessagesTextBox.Enabled = false;
            label2.Text = "";
        }

        private void ammountRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isInfinit = false;
            numberOfMessagesTextBox.Enabled = true;
            label2.Text = "0";
        }

        private void delayInMsButton_Click(object sender, EventArgs e)
        {
            if (delayInMsTextBox.Text != "")
            {
                try
                {
                    timer1.Interval = int.Parse(delayInMsTextBox.Text);
                    trackBar1.Value = int.Parse(delayInMsTextBox.Text);
                    delayNubmerLabel.Text = delayInMsTextBox.Text;
                }
                catch (Exception)
                {


                }
            }
            else 
            { 
            
            }
        }

        private void fileSpammButton_Click(object sender, EventArgs e)
        {
            Form2 fileSpammerForm = new Form2();
            this.Hide();
            fileSpammerForm.Show();
        }
    }
}
