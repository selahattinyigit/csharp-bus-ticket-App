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
    public partial class frmBiletAl : Form
    {
        public frmBiletAl()
        {
            InitializeComponent();
        }
        dbBiletEntities ent = new dbBiletEntities();
        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.Width = 48;
            button2.Height = 51;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Width = 38;
            button2.Height = 41;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            tbBiletler dene = ent.tbBiletler.Where(x => x.sefer_id.ToString() == label5.Text && x.koltuk_no.ToString() == label6.Text).FirstOrDefault();
            if (dene == null)
            {
                if (textBox1.Text != null && textBox4.Text != null && maskedTextBox1 != null && maskedTextBox2.Text != null)
                {
                    bool cinsiyet = false;
                    if (comboBox1.Text == "ERKEK")
                    {
                        cinsiyet = true;
                    }
                    else if (comboBox1.Text == "KADIN")
                    {
                        cinsiyet = false;
                    }
                    else
                    {
                        MessageBox.Show("CİNSİYETİ ERKEK VAYA KADIN OLARAK SEÇİNİZ");
                    }
                    tbBiletler bilet = new tbBiletler();
                    bilet.sefer_id = Convert.ToInt32(label5.Text);
                    bilet.koltuk_no = Convert.ToInt32(label6.Text);
                    bilet.ucret = Convert.ToInt32(label9.Text);
                    bilet.ad = textBox1.Text;
                    bilet.soyad = textBox4.Text;
                    bilet.tc = maskedTextBox1.Text;
                    bilet.cinsiyet = cinsiyet;
                    bilet.telefon = maskedTextBox2.Text;
                    Form1 frm = new Form1();
                    bilet.kullanici_adi =Form1.adi.ad;
                    ent.tbBiletler.Add(bilet);
                    int kayıt = ent.SaveChanges();
                    if (kayıt > 0)
                    {
                        MessageBox.Show("BİLET SATIŞ İŞLEMİ TAMAMLANDI!");
                        frmBilet f1 = (frmBilet)Application.OpenForms["frmBilet"];
                        f1.koltuk();
                        Hide();

                    }
                    else
                    {
                        MessageBox.Show("BİLİNMEYEN BİR HATAYLA KARŞILAŞILDI!");
                    }
                }
            }
            else
            {
                MessageBox.Show("AYNI KOLTUĞU İKİ KİŞİYE SATAMAZSINIZ");
            }
        }
    }
}
