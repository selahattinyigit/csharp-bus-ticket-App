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
    public partial class frmSube : Form
    {
        public frmSube()
        {
            InitializeComponent();
        }
        dbBiletEntities ent = new dbBiletEntities();
        void doldur()
        {
            dataGridView1.DataSource = ent.tbSubeler.ToList();
            dataGridView1.Columns[0].HeaderText = "ŞUBE KODU";
            dataGridView1.Columns[0].Width =50;
            dataGridView1.Columns[1].Width = 150;
           
            dataGridView1.Columns[1].HeaderText = "ŞUBE ADI";
            

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

        private void frmSube_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "EKLE")
            {
                tbSubeler o = ent.tbSubeler.Where(x => x.sube_ad == textBox1.Text).FirstOrDefault();
                if (o != null)
                {
                    MessageBox.Show("AYNI ŞUBE İSMİNDEN İKİ TANE KAYDEDEMEZSİNİZ!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (o == null)
                {
                    if (textBox1.Text != "" )
                    {
                        tbSubeler sube = new tbSubeler();
                        tbSubeler2 sube2 = new tbSubeler2();
                        sube.sube_ad = textBox1.Text.ToUpper().Trim();
                        sube2.sube_ad_bitis = textBox1.Text.ToUpper().Trim();
                        ent.tbSubeler.Add(sube);
                        ent.tbSubeler2.Add(sube2);
                        ent.SaveChanges();
                        textBox1.Clear();
                      
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
            else if (button1.Text == "GÜNCELLE")
            {
                if (textBox1.Text != "")
                {
                    tbSubeler güncelle = ent.tbSubeler.Where(x => x.sube_ad == g).FirstOrDefault();
                    if (güncelle != null)
                    {
                        güncelle.sube_ad = textBox1.Text.ToUpper();
                          ent.SaveChanges();
                    textBox1.Clear();
                    
                    button1.Text = "EKLE";
                    button1.BackColor = Color.Lime;
                    textBox1.ReadOnly = false;
                    doldur();

                    }
                    else
                    {
                        return;
                    }
                    //////////////////////////////////
                    tbSubeler2 güncelle2 = ent.tbSubeler2.Where(x => x.sube_ad_bitis == g).FirstOrDefault();
                    if (güncelle2 != null)
                    {
                        güncelle2.sube_ad_bitis = textBox1.Text.ToUpper();
                        ent.SaveChanges();
                        textBox1.Clear();

                        button1.Text = "EKLE";
                        button1.BackColor = Color.Lime;
                        textBox1.ReadOnly = false;
                        doldur();

                    }
                    else
                    {
                        return;
                    }

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
        string g;
        private void button3_Click(object sender, EventArgs e)
        {
            var soru = MessageBox.Show("ŞUBEYİ GÜNCELLEMEK İSTEDİĞİNİZE EMİN MİSİNİZ", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (soru == DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow.Cells[0].ToString() != null)
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                   
                    button1.Text = "GÜNCELLE";
                    button1.BackColor = Color.Orange;
                    g = dataGridView1.CurrentRow.Cells[1].Value.ToString(); ;
                }


            }
            else
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var soru = MessageBox.Show("ŞUBEYİ SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (soru == DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow.Cells[0].ToString() != null)
                {
                    int sil = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) ;

                    ent.tbSubeler.Remove(ent.tbSubeler.Find(sil));
                    ent.tbSubeler2.Remove(ent.tbSubeler2.Find(sil));
                    ent.SaveChanges();
                    doldur();
                }


            }
            else
            {
                return;
            }
        }
    }
}
