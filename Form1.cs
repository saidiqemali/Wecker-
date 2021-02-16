using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wecker
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        delegate void UpdateLable(Label lbl, string value);
        void UpdateDataLable(Label lbl,string value)
        {
            lbl.Text = value;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime userTime = dateTimePicker.Value;
            if(currentTime.Hour == userTime.Hour && userTime.Minute == currentTime.Minute && userTime.Second == currentTime.Second)
            {
                timer.Stop();
                try
                {
                    UpdateLable upd = UpdateDataLable;
                    if(lblstatus.InvokeRequired)
                    
                        Invoke(upd, lblstatus, "Stop");
                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocationm = @"Dieser PC\Downloads\13767_morning_alarm";
                    player.PlayLooping();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            timer.Start();
        lblstatus.Text = "Running";
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            lblstatus.Text = "Stop";
        }
    
    }
}
