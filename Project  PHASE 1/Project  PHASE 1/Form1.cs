﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project__PHASE_1
{
    public partial class ThemeForm : Form
    {
        public ThemeForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ForeColor = Color.FromArgb(28, 28, 33);
            BackColor = Color.FromArgb(240, 240, 240);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ThemeDark_CheckedChanged(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(28, 28, 33);
            ForeColor = Color.FromArgb(240, 240, 240);
        }
        private void themeLight_CheckedChanged(object sender, EventArgs e)
        {
            ForeColor = Color.FromArgb(28, 28, 33);
            BackColor = Color.FromArgb(240, 240, 240);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (ThemeDark.Checked == true)
            {
                panel2.BackColor = Color.FromArgb(50, 50, 66);
            }
            else
            {
                panel2.BackColor = Color.FromArgb(220, 220, 220);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void StartedButton_Click(object sender, EventArgs e)
        {
            login Form4Loign=new login(this.BackColor, 
                this.ForeColor,panel2.BackColor,panel2.ForeColor);
            this.Hide();
            Form4Loign.ShowDialog();
         
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
