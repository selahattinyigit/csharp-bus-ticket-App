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
    public partial class frmRapor : Form
    {
        public frmRapor()
        {
            InitializeComponent();
        }
        dbBiletEntities ent = new dbBiletEntities();
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            usrBilet frm = new usrBilet();
            panel1.Controls.Add(frm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            usrSefer frm = new usrSefer();
            panel1.Controls.Add(frm);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            usrYolcu frm = new usrYolcu();
            panel1.Controls.Add(frm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            usrOtobus frm = new usrOtobus();
            panel1.Controls.Add(frm);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            usrPersonel frm = new usrPersonel();
            panel1.Controls.Add(frm);
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.Width = 80;
            button2.Height = 68;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Width = 70;
            button2.Height = 58;
        }

        private void button51_MouseMove(object sender, MouseEventArgs e)
        {
            button51.Width = 75;
            button51.Height = 73;
        }

        private void button51_MouseLeave(object sender, EventArgs e)
        {
            button51.Width = 65;
            button51.Height = 63;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.Width = 174;
            button3.Height = 235;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Width = 164;
            button3.Height = 225;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Width = 174;
            button1.Height = 250;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Width = 164;
            button1.Height = 240;
        }

        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
            button6.Width = 174;
            button6.Height = 229;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.Width = 164;
            button6.Height = 219;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.Width = 174;
            button4.Height = 229;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.Width = 164;
            button4.Height = 219;
        }

        private void button7_MouseMove(object sender, MouseEventArgs e)
        {
            button7.Width = 174;
            button7.Height = 236;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.Width = 164;
            button7.Height = 226;
        }
    }
}
