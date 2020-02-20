using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtobusBiletAPP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            panel1.Width = 285;
            panel1.Height = 299;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            panel1.Width = 300;
            panel1.Height = 314;
        }

        private void button1_Move(object sender, EventArgs e)
        {
            
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            panel2.Width = 285;
            panel2.Height = 299;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            panel2.Width = 300;
            panel2.Height = 314;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Width = 70;
            button2.Height =58;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            panel3.Width = 285;
            panel3.Height = 299;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            panel3.Width = 300;
            panel3.Height = 314;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            panel4.Width = 285;
            panel4.Height = 299;
        }

        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
            panel4.Width = 300;
            panel4.Height = 314;
        }

        private void button7_MouseMove(object sender, MouseEventArgs e)
        {
            panel5.Width = 300;
            panel5.Height = 314;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            panel5.Width = 285;
            panel5.Height = 299;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.Width = 80;
            button2.Height = 68;
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            button5.Width = 97;
            button5.Height = 83;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.Width = 87;
            button5.Height = 73;
        }

        private void button8_MouseMove(object sender, MouseEventArgs e)
        {
            button8.Width =75;
            button8.Height = 68;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.Width = 65;
            button8.Height = 58;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBilet frm = new frmBilet();
            frm.label1.Text = label1.Text;
            frm.Show();
            Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmOtobus frm = new frmOtobus();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSube frm = new frmSube();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmPersonel frm = new frmPersonel();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSeferler frm = new frmSeferler();
            frm.Show();
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
          
            panel6.Width = 285;
            panel6.Height = 299;
        }

        private void button9_MouseMove(object sender, MouseEventArgs e)
        {
            panel6.Width = 300;
            panel6.Height = 314;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmRapor frm = new frmRapor();
            frm.Show();
            Hide();
        }
    }
}
