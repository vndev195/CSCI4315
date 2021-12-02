using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace P4_Winforms
{
    public partial class Form1 : Form
    {
        private CTime2 currentTime;
        private AlarmTime alarmTime;
        private List<AlarmTime> alarmTimes;
        private AlarmTime nextAlarm;
        private bool isAlarmedOff = true;

        public Form1()
        {
            InitializeComponent();
            alarmTimes = new List<AlarmTime>();
        }

        private void settimeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHour.Text) || string.IsNullOrEmpty(tbMinute.Text) || string.IsNullOrEmpty(tbSecond.Text))
            {
                MessageBox.Show("Incorrect input", "Error");
            }
            else
            {
                try
                {
                    int hours = int.Parse(tbHour.Text);
                    int minutes = int.Parse(tbMinute.Text);
                    int seconds = int.Parse(tbSecond.Text);
                    // MessageBox.Show(tbHour.Text);

                    //Ini current time type CTime2
                    currentTime = new CTime2(hours, minutes, seconds);
                    currentTimeLable.Text = currentTime.ToUniversalString();

                    //set the timmer
                    timer1.Enabled = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void alarmButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHour.Text) || string.IsNullOrEmpty(tbMinute.Text) || string.IsNullOrEmpty(tbSecond.Text))
            {
                MessageBox.Show("Incorrect input", "Error");
            }
            else
            {
                try
                {
                    int hours = int.Parse(tbHour.Text);
                    int minutes = int.Parse(tbMinute.Text);
                    int seconds = int.Parse(tbSecond.Text);

                    //
                    alarmTime = new AlarmTime(tbText.Text, hours, minutes, seconds);
                    alarmTime.SnoozeTime = new CTime2(hours, minutes, seconds);

                    alarmTimes.Add(alarmTime);
                    alarmTimes.Sort();

                    //listBox1.Items.Add(alarmTime.ToString());
                    this.listBox1.SelectedIndexChanged -= new System.EventHandler(this.listBox1_SelectedIndexChanged);
                    listBox1.DataSource = alarmTimes.ToArray();
                    listBox1.SelectedIndex = -1;
                    this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void listBox1_DataSourceChanged(object sender, EventArgs e)
        {
            //sort
            alarmTimes.Sort();

            //display to listbox
            listBox1.DataSource = alarmTimes.ToArray();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var hour = currentTime.Hour;
            var minute = currentTime.Minute;
            var second = currentTime.Second;

            if (second < 59)
            {
                second++;
            }
            else
            {
                second = 0;
                if (minute < 59)
                    minute++;
                else
                {
                    minute = 0;
                    hour++;
                    if (hour > 23)
                    {
                        hour = 0;
                    }
                }

            }

            //Update current time and show them in lable
            currentTime.SetTime(hour, minute, second);
            currentTimeLable.Text = currentTime.ToUniversalString();

            //check alarm
            foreach (var item in alarmTimes)
            {
                if (currentTime.CompareTo(item) == 0)
                {
                    MessageBox.Show(item.ToString());
                    nextAlarm = item;
                    snoozeButton.Enabled = true;
                    alarmedOffButton.Enabled = true;
                    isAlarmedOff = false;
                    label5.Text = currentTime.ToString();
                }
            }

            if (isAlarmedOff == false)
            {
                label5.Text = "ALARM!\n" + currentTime.ToString();

                if (currentTime.CompareTo(nextAlarm.SnoozeTime) == 0)
                {
                    MessageBox.Show(nextAlarm.SnoozeTime.ToString());
                }
            }

        }

        private void snoozeButton_Click(object sender, EventArgs e)
        {
            //Add by minute
            int period = (int)numericUpDown1.Value;
            nextAlarm.SnoozeTime.AddTime(period);
        }

        private void alarmedOfButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{nextAlarm.Message}", "Message From Alarm", MessageBoxButtons.OK);
            isAlarmedOff = true;
            label5.Text = "";
            nextAlarm.SnoozeTime = nextAlarm;
            nextAlarm = null;
            alarmedOffButton.Enabled = false;
            snoozeButton.Enabled = false;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown2.Value;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index != -1)
            {
                alarmTimes.RemoveAt(index);

                #region prevent auto select first object when using data source
                this.listBox1.SelectedIndexChanged -= new System.EventHandler(this.listBox1_SelectedIndexChanged);
                listBox1.DataSource = alarmTimes.ToArray();
                listBox1.SelectedIndex = -1;
                this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
                #endregion
            }
        }
    }
}
