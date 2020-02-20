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
    public partial class frmSeferler : Form
    {
        public frmSeferler()
        {
            InitializeComponent();
        }
        dbBiletEntities ent = new dbBiletEntities();
        void doldur()
        {
           /* var sube = ent.tbSubeler.Where(z => z.sube_ad == z.sube_ad).ToList();
            var sube2 = ent.tbSubeler.Where(z => z.sube_id == z.sube_id).ToList();
            var liste = ent.tbSubeler.SqlQuery("select  s.sefer_id,(select sube_ad from tbSubeler where s.sefer_baslangic_sube=sube_id),(select sube_ad from tbSubeler  where s.sefer_bitis_sube=sube_id),s.sefer_tarih, s.sefer_saat,s.fiyat,s.plaka from tbSeferler s");

             var ekle = from s in ent.tbSeferler
                          from t in ent.tbSubeler
                          where s.sefer_baslangic_sube == t.sube_id
                          from k in ent.tbSubeler2
                          where s.sefer_bitis_sube == k.sube_id

                          select new
                          {
                              s.sefer_id,
                              t.sube_ad,
                              k.sube_ad,
                              s.sefer_saat,
                              s.sefer_tarih,
                              s.fiyat,
                              s.plaka

                          };*/

            var ekle = from sf in ent.tbSeferler
                       join sb in ent.tbSubeler on sf.sefer_baslangic_sube equals sb.sube_id
                       join sb2 in ent.tbSubeler2 on sf.sefer_bitis_sube equals sb2.sube_id
                       select new
                       {
                           sf.sefer_id,
                           sb.sube_ad,
                           sb2.sube_ad_bitis,
                           sf.sefer_saat,
                           sf.sefer_tarih,
                           sf.fiyat,
                           sf.plaka
                       };
          
           // var sefer = ent.tbSeferler.Where(x=>).ToList();
           
            dataGridView1.DataSource = ekle.ToList();
            dataGridView1.Columns[0].HeaderText = "SEFER NO";
            dataGridView1.Columns[1].HeaderText = "BAŞLANGIÇ ŞUBE";
            dataGridView1.Columns[1].Width = 118;

            dataGridView1.Columns[2].HeaderText = "BİTİŞ ŞUBE";
            dataGridView1.Columns[3].HeaderText = "SAAT";
            dataGridView1.Columns[4].HeaderText = "TARİH";
            dataGridView1.Columns[5].HeaderText = "FİYAT";
            dataGridView1.Columns[5].Width = 80;

            dataGridView1.Columns[6].HeaderText = "PLAKA";


        }
        void doldurOncekiler()
        {
            var ekle = from sf in ent.tbSeferler
                       join sb in ent.tbSubeler on sf.sefer_baslangic_sube equals sb.sube_id
                       join sb2 in ent.tbSubeler2 on sf.sefer_bitis_sube equals sb2.sube_id
                       where sf.sefer_tarih<DateTime.Now
                       select new
                       {
                           sf.sefer_id,
                           sb.sube_ad,
                           sb2.sube_ad_bitis,
                           sf.sefer_saat,
                           sf.sefer_tarih,
                           sf.fiyat,
                           sf.plaka
                       };
            dataGridView1.DataSource = ekle.ToList();
        }
        public void doldurGelecekler()
        {
            var ekle = from sf in ent.tbSeferler
                       join sb in ent.tbSubeler on sf.sefer_baslangic_sube equals sb.sube_id
                       join sb2 in ent.tbSubeler2 on sf.sefer_bitis_sube equals sb2.sube_id
                       where sf.sefer_tarih > DateTime.Now
                       select new
                       {
                           sf.sefer_id,
                           sb.sube_ad,
                           sb2.sube_ad_bitis,
                           sf.sefer_saat,
                           sf.sefer_tarih,
                           sf.fiyat,
                           sf.plaka
                       };
            dataGridView1.DataSource = ekle.ToList();
        }
        private void frmSeferler_Load(object sender, EventArgs e)
        {
            doldur();
        }

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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            doldur();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            doldurOncekiler();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            doldurGelecekler();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var soru = MessageBox.Show("SEFERİ SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (soru == DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow.Cells[0].ToString() != null)
                {
                    int sil = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                    ent.tbSeferler.Remove(ent.tbSeferler.Find(sil));
                    ent.SaveChanges();
                    doldur();
                }


            }
            else
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSeferEkle FRM = new frmSeferEkle();
            FRM.Show();
        }
    }
}
