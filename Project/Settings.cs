using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Project
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            button2.Hide();
        }
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        private void button1_Click(object sender, EventArgs e)
        {
            string a = comboBox1.Text.ToString();
            player.SoundLocation = a;
            player.Play();
            button2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //save
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            string a = comboBox1.Text.ToString();
            f.SetTone(a);
            this.Close();
        }
        //cancel
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
