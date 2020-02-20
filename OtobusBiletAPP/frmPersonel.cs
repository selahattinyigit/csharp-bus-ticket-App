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
    public partial class frmPersonel : Form
    {
        public frmPersonel()
        {
            InitializeComponent();
        }
        dbBiletEntities ent = new dbBiletEntities();
       public void doldur()
        {


            var liste = from k in ent.tbKullanicilar
                        where k.kullanici_admin==false
                        select new { k.kullanici_ad_soyad, k.kullanici_tel, k.kullanici_mail, k.kullanici_adres,k.kullanici_adi};
                        
                                      
                                    
            dataGridView1.DataSource = liste.ToList();
            dataGridView1.Columns[0].HeaderText = "AD SOYAD";
            dataGridView1.Columns[0].Width = 118;
            dataGridView1.Columns[1].Width = 90;
            dataGridView1.Columns[2].Width = 118;
            dataGridView1.Columns[1].HeaderText = "TELEFON";
            dataGridView1.Columns[2].HeaderText = "MAİL";
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[3].HeaderText = "ADRES";
            dataGridView1.Columns[4].HeaderText = "id";
            dataGridView1.Columns[4].Visible = false;



        }
        private void frmPersonel_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
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

        private void button4_Click(object sender, EventArgs e)
        {
            var soru = MessageBox.Show("KULLANICIYI SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (soru == DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow.Cells[4].ToString() != null)
                {
                    string sil = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                    ent.tbKullanicilar.Remove(ent.tbKullanicilar.Find(sil));
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
            frmPersonelEkle frm = new frmPersonelEkle();
            frm.Show();

        }
    }
}
