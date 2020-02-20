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
    public partial class frmOtobus : Form
    {
        public frmOtobus()
        {
            InitializeComponent();
        }
        dbBiletEntities ent = new dbBiletEntities();
        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }
        void doldur()
        {
            dataGridView1.DataSource = ent.tbOtobusler.Where(x => x.plaka == x.plaka && x.otobus_marka == x.otobus_marka && x.otobus_model == x.otobus_model).ToList();
            dataGridView1.Columns[0].HeaderText = "PLAKA";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 146;
            dataGridView1.Columns[2].Width = 118;
            dataGridView1.Columns[1].HeaderText = "MARKA";
            dataGridView1.Columns[2].HeaderText = "MODEL";

        }
        private void frmOtobus_Load(object sender, EventArgs e)
        {

            doldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text=="EKLE")
            {
                tbOtobusler o = ent.tbOtobusler.Where(x => x.plaka == textBox1.Text).FirstOrDefault();
                if (o != null)
                {
                    MessageBox.Show("AYNI PLAKALI ARAÇDAN İKİ TANE KAYDEDEMEZSİNİZ!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (o == null)
                {
                    if (textBox1.Text!=""&&textBox2.Text !="" && textBox3.Text !="")
                    {
                        tbOtobusler otobus = new tbOtobusler();
                        otobus.plaka = textBox1.Text.ToUpper().Trim();
                        otobus.otobus_marka = textBox2.Text.ToUpper().Trim();
                        otobus.otobus_model = textBox3.Text.ToUpper().Trim();
                        ent.tbOtobusler.Add(otobus);
                        ent.SaveChanges();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        doldur();

                    }
                    else
                    {
                        MessageBox.Show("LÜTFEN BOŞ ALANLARI DOLDURUNUZ!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    MessageBox.Show("BİLİNMEYEN BİR HATA OLUŞTU!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else if (button1.Text=="GÜNCELLE")
            {
                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    tbOtobusler güncelle = ent.tbOtobusler.Where(x => x.plaka == textBox1.Text).FirstOrDefault();
                    if (güncelle != null)
                    {
                        güncelle.otobus_model = textBox3.Text.ToUpper();
                        güncelle.otobus_marka = textBox2.Text.ToUpper();
                        güncelle.plaka = textBox1.Text.ToUpper().Trim(); ;

                    }
                    ent.SaveChanges();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    button1.Text = "EKLE";
                    button1.BackColor = Color.Lime;
                    textBox1.ReadOnly = false;
                    doldur();
                }
                else
                {
                    MessageBox.Show("LÜTFEN BOŞ ALANLARI DOLDURUNUZ!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            else
            {
                MessageBox.Show("BİLİNMYEN BİR HATA OLUŞTU");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
          var soru=  MessageBox.Show("OTOBÜSÜ SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ","UYARI",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if(soru==DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow.Cells[0].ToString()!=null)
                {
                    string sil= dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    
                    ent.tbOtobusler.Remove(ent.tbOtobusler.Find(sil));
                    ent.SaveChanges();
                    doldur();
                }
               

            }
            else
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var soru = MessageBox.Show("OTOBÜSÜ GÜNCELLEMEK İSTEDİĞİNİZE EMİN MİSİNİZ", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (soru == DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow.Cells[0].ToString() != null)
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    button1.Text = "GÜNCELLE";
                    button1.BackColor = Color.Orange;
                    textBox1.ReadOnly = true;
                }


            }
            else
            {
                return;
            }
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.Width = 54;
            button2.Height = 49;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Width = 44;
            button2.Height = 39;
        }
    }
}
