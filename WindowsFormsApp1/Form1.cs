using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Timer and lenght variables
        private System.Windows.Forms.Timer timer1;
        private int counter = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            // Creates timer
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(TimerEventProcessor);

            // Configure timer & starts
            if (counter > 0)
            {
                timer1.Interval = 60000;
                timer1.Start();
                label1.Text = counter.ToString() + " min";
            } else
            {
                MessageBox.Show("Please insert a time amount in the text box", "Error");
            }

        }
        private void TimerEventProcessor(object sender, EventArgs e)
        {
            // Alarm code
            counter--;
            if (counter == 0)
            {
                timer1.Stop();

                SoundPlayer splayer = new SoundPlayer(WindowsFormsApp1.Properties.Resources.sound_astolfo);
                splayer.Play();

                // Checks if loop is enabled
                if (OptionSelected == true)
                {
                    Int32.TryParse(textBox1.Text, out counter);
                    timer1.Start();
                }
            }
            label1.Text = counter.ToString() + " min";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Parses textbox data to counter
            Int32.TryParse(textBox1.Text, out counter);
        }

        public bool OptionSelected
        {
            get { return checkBox1.Checked; }
        }
    }
}
