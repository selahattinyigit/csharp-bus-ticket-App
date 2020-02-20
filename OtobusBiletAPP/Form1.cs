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
  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        
        public class adi
        {
            public static string ad = "";
        }
        
        dbBiletEntities ent = new dbBiletEntities();
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textBox2.BorderStyle = BorderStyle.FixedSingle;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.BorderStyle = BorderStyle.FixedSingle;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
         
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Width = 85;
            button1.Height = 70;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Width = 70;
            button1.Height = 58;
        }
        
        private void btn_giris_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text!="")
            {
                label2.ForeColor = Color.Lime;
            }
            else
            {
                return;
            }
            tbKullanicilar k = ent.tbKullanicilar.Where(x => x.kullanici_adi == textBox1.Text && x.kullanici_sifresi == textBox2.Text).SingleOrDefault();
            if (k==null)
            {
                label2.ForeColor = Color.Red;
                label1.ForeColor = Color.Red;
                MessageBox.Show("KULLANICI BULUNAMADI\n LÜTFEN KULLANICI ADINIZI ŞİFRENİZİ DOĞRU YAZINIZ","HATA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (k !=null)
            {
                
                frmBilet frm = new frmBilet();
                Form2 frm2 = new Form2();

                adi.ad = k.kullanici_adi;
                if (k.kullanici_admin==true)
                {
                   
                    frm2.label1.Text = "HOŞ  GELDİNİZ  SAYIN " + k.kullanici_ad_soyad.ToUpper() + "  " + DateTime.Now;
                    
                    frm2.Show();
                    this.Hide();
                }
                else if (k.kullanici_admin == false)
                {
                    frm.button51.Visible = false;
                    frm.label1.Text = "HOŞ  GELDİNİZ  " + k.kullanici_ad_soyad.ToUpper() + "  " + DateTime.Now;
                    frm.Show();
                    this.Hide();
                }
            }
             
        }
       
        private void btn_giris_MouseMove(object sender, MouseEventArgs e)
        {
            panel2.Width = 248;
            panel2.Height = 105;
            float boyut = 25;
            btn_giris.Font = new Font(btn_giris.Font.FontFamily, boyut);
        }

        private void btn_giris_MouseLeave(object sender, EventArgs e)
        {
            panel2.Width = 238;
            panel2.Height = 95;
            float boyut = 17;
            btn_giris.Font = new Font(btn_giris.Font.FontFamily, boyut);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                label1.ForeColor = Color.Lime;
            }
            else
            {
                return;
            }
        }
    }
}
