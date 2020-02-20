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
    public partial class frmPersonelEkle : Form
    {
        public frmPersonelEkle()
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

        private void frmPersonelEkle_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            tbKullanicilar o = ent.tbKullanicilar.Where(x => x.kullanici_adi == textBox4.Text).FirstOrDefault();
            if (o != null)
            {
                label8.Text = "X";
                label8.ForeColor = Color.Red;
            }
            else if (o == null)
            {
                 label8.Text = "○";
                label8.ForeColor = Color.Green;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != ""&& textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && maskedTextBox1.Text != "" && richTextBox1.Text != "" && comboBox2.Text != "")
                {
                     if (label8.ForeColor==Color.Green)
                         {
                    tbKullanicilar kullanici = new tbKullanicilar();

                    kullanici.kullanici_adi = textBox4.Text.Trim();
                    kullanici.kullanici_sifresi = textBox3.Text.Trim();
                    kullanici.kullanici_ad_soyad = textBox1.Text.ToUpper();
                    kullanici.kullanici_mail = textBox2.Text.Trim();
                    kullanici.kullanici_tel = maskedTextBox1.Text;
                    kullanici.kullanici_adres = richTextBox1.Text;
                    if (comboBox2.Text == "YÖNETİCİ")
                    {
                        kullanici.kullanici_admin = true;
                    }
                    else if (comboBox2.Text == "KULLANICI")
                    {
                        kullanici.kullanici_admin = false;
                    }
                    else
                    {
                        MessageBox.Show("KULLANICI TÜRÜ OLARAK SADECE YÖNETİCİ VE KULLANICIYI SEÇEBİLİRSİNİZ!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ent.tbKullanicilar.Add(kullanici);
                    var k= ent.SaveChanges();
                    if (k!=0)
                    {
                        frmPersonel f1 = (frmPersonel)Application.OpenForms["frmPersonel"];
                        f1.doldur();
                        Hide();

                    }
                    
                }
                else
                  {
                    MessageBox.Show("AYNI KULLANICI ADIYLA BAŞKA KULLANICI EKLEYEMEZSİNİZ!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                 }




            }
             else
                {
                    MessageBox.Show("LÜTFEN BOŞ ALANLARI DOLDURUNUZ!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
           
        }
    }
}
