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
    public partial class frmSeferEkle : Form
    {
        public frmSeferEkle()
        {
            InitializeComponent();
        }
        dbBiletEntities ent = new dbBiletEntities();
        void comboDoldur()
        {
            comboBox1.DataSource = ent.tbSubeler.Where(z => z.sube_ad == z.sube_ad).ToList();
            comboBox1.ValueMember = "sube_id";
            comboBox1.DisplayMember = "sube_ad";
            comboBox3.DataSource = ent.tbSubeler2.Where(z => z.sube_ad_bitis == z.sube_ad_bitis).ToList();
            comboBox3.ValueMember = "sube_id";
            comboBox3.DisplayMember = "sube_ad_bitis";

            comboBox2.DataSource = ent.tbOtobusler.Where(z => z.plaka == z.plaka).ToList();
            comboBox2.ValueMember = "plaka";
            comboBox2.DisplayMember = "plaka";
        }
        private void frmSeferEkle_Load(object sender, EventArgs e)
        {
            comboDoldur();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && comboBox1.Text != "" && comboBox3.Text != "" && comboBox2.Text != "" && textBox1.Text != "")
            {
                tbSeferler o = ent.tbSeferler.Where(x => x.sefer_id.ToString() == textBox4.Text).FirstOrDefault();
                if (o != null)
                {
                    MessageBox.Show("AYNI SEFER İSMİNDEN İKİ TANE KAYDEDEMEZSİNİZ!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (o == null)
                {
                   
                  tbSeferler sefer = new tbSeferler();
                    
                    sefer.sefer_id =int.Parse(textBox4.Text);
                    tbSubeler sf= (tbSubeler)comboBox1.SelectedItem;
                    tbSubeler2 sf2 = (tbSubeler2)comboBox3.SelectedItem;
                    tbOtobusler ot = (tbOtobusler)comboBox2.SelectedItem;
                    sefer.sefer_baslangic_sube = sf.sube_id;
                    sefer.sefer_bitis_sube = sf2.sube_id;
                    sefer.sefer_tarih = (dateTimePicker1.Value);
                    sefer.sefer_saat = dateTimePicker2.Value.TimeOfDay;
                    sefer.fiyat =double.Parse(textBox1.Text);
                    sefer.plaka = ot.plaka;
                    
                    ent.tbSeferler.Add(sefer);
                    var k = ent.SaveChanges();
                    if (k != 0)
                    {
                        frmSeferler f1 = (frmSeferler)Application.OpenForms["frmSeferler"];
                        f1.doldurGelecekler();
                        Hide();

                    }

                }
              




            }
            else
            {
                MessageBox.Show("LÜTFEN BOŞ ALANLARI DOLDURUNUZ!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
