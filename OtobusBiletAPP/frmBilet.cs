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
    public partial class frmBilet : Form
    {
        public frmBilet()
        {
            InitializeComponent();
        }
        public class idBilet
        {
            public static int id;
        }
        public class kolt
        {
            public static int kol;
        }
        dbBiletEntities ent = new dbBiletEntities();
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public bool kullanici_admin;
        private void button5_Click(object sender, EventArgs e)
        {
            
                Form1 frm2 = new Form1();
                frm2.Show();
                Hide();
            
            
        }
       
        void subeYukle()
        {
            comboBox1.DataSource = ent.tbSubeler.Where(z => z.sube_ad == z.sube_ad).ToList();
            comboBox1.ValueMember = "sube_id";
            comboBox1.DisplayMember = "sube_ad";
            comboBox2.DataSource = ent.tbSubeler.Where(z => z.sube_ad == z.sube_ad).ToList();
            comboBox2.ValueMember = "sube_id";
            comboBox2.DisplayMember = "sube_ad";
        }

       
       
        public void koltukKaldır()
        {
            int x = panel1.Controls.Count;
            for (int i = 0; i < x; i++)
            {
                panel1.Controls[i].Enabled = false;
            }
        }
        public void koltukAc()
        {
            int x = panel1.Controls.Count;
            for (int i = 0; i < x; i++)
            {
                panel1.Controls[i].Enabled = true;
                panel1.Controls[i].BackColor = Color.Lime;
            }
        }

        private void frmBilet_Load(object sender, EventArgs e)
        {
            koltukKaldır();
            subeYukle();
        }

        private void button2_MouseLeave_1(object sender, EventArgs e)
        {
            button2.Width = 70;
            button2.Height = 58;
        }

        private void button2_MouseMove_1(object sender, MouseEventArgs e)
        {
            button2.Width = 80;
            button2.Height = 68;
        }

        private void button5_MouseLeave_1(object sender, EventArgs e)
        {
            button5.Width = 87;
            button5.Height = 73;
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            button5.Width = 97;
            button5.Height = 83;
        }

        private void button8_MouseLeave_1(object sender, EventArgs e)
        {
            button8.Width = 65;
            button8.Height = 58;
        }
        void doldurBilet()
        {
            frmBiletGöster frm = new frmBiletGöster();
            tbBiletler bilet = ent.tbBiletler.Where(x => x.sefer_id.ToString() ==id && x.koltuk_no.ToString() == ActiveControl.Text).FirstOrDefault();
            if (bilet != null)
            {
                frm.label6.Text = ActiveControl.Text;
                frm.label5.Text = id;
                frm.label9.Text = bilet.ucret.ToString();
                frm.label12.Text = bilet.ad;
                frm.label7.Text = bilet.soyad;
                frm.label2.Text = bilet.tc;
                frm.label18.Text = bilet.telefon;
                frm.label12.Text = bilet.ad;
                idBilet.id = bilet.bilet_id;
                if (bilet.cinsiyet == true)
                {
                    frm.label16.Text = "ERKEK";
                }
                else if (bilet.cinsiyet == false)
                {
                    frm.label16.Text = "KADIN";
                }
            }
            else
            {
                MessageBox.Show("BİLİNMEYEN BİR HATA OLUŞTU");
            }
            frm.Show();
        }
        private void button8_MouseMove_1(object sender, MouseEventArgs e)
        {
            button8.Width = 75;
            button8.Height = 68;
        }

      
       
        Button btn = new Button();
        int i = 0;
        private void button50_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            int xz = panel1.Controls.Count;
            for (int j = 0; j < xz; j++)
            {
                panel1.Controls[j].BackColor = Color.Lime;


            }
            i = 0;

            frmBilet frm = new frmBilet();
            tbSubeler sube = ent.tbSubeler.Where(z => z.sube_ad ==comboBox1.Text).FirstOrDefault();
            tbSubeler sube2 = ent.tbSubeler.Where(z => z.sube_ad == comboBox2.Text).FirstOrDefault();

            var sefer =ent.tbSeferler.Where(x => x.sefer_baslangic_sube == sube.sube_id && x.sefer_bitis_sube == sube2.sube_id && x.sefer_tarih ==dateTimePicker1.Value).ToList();
            if (sefer!=null)
            {
                foreach (var item in sefer)
                {
                    i++;
                    btn = new Button();
                    btn.Name = item.sefer_id.ToString();
                    Point btnyer = new Point(50, 100);
                    btn.Dock = System.Windows.Forms.DockStyle.Top;
                    btn.BackColor = Color.Red;
                    btn.Font = new Font(btn.Font.FontFamily, 20);
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Height = 50;
                    btn.Text = "" + item.sefer_id + " " + sube.sube_ad + " - " + sube2.sube_ad + "  " + item.sefer_tarih.ToString().Remove(10) + "  " + item.sefer_saat + "  " + item.fiyat + "TL";
                    btn.Location = btnyer;
                    panel3.Controls.Add(btn);
                    id = ActiveControl.Name;
                    btn.Click += Btn_Click1;
                }
                if (i == 0)
                {
                    MessageBox.Show("ARADIĞINIZ KRİTERLERE UYGUN SEFER BULUNAMADI", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
           
            
            
        }
       public string id ;
       
        
        public void koltukDoldur()
        {/*
            int k = 1;
            var koltuk = ent.tbBiletler.Where(x => x.sefer_id == kol);
            foreach (var item in koltuk)
            {
                var bul = panel1.Controls.Find(item.koltuk_no, true).FirstOrDefault();
                
                if (bul != null)
                {
                   
                }
                else
                {
                    if (item.cinsiyet == true)
                    {
                        bul.BackColor = Color.Blue;
                        bul.Enabled = true;
                    }
                    else if (item.cinsiyet == false)
                    {
                        bul.BackColor = Color.Pink;
                        bul.Enabled = true;
                    }

                }
            }*/
        }
        public void koltuk()
        {
            int s = 0;
            int x = panel1.Controls.Count;
            koltukAc();
            var koltuk = ent.tbBiletler.Where(db => db.sefer_id == kolt.kol);
            foreach (var item in koltuk)
            {
                s++;
                string i =item.koltuk_no.ToString();
                for (int j= 0; j < x; j++)
                {
                    if (int.Parse(panel1.Controls[j].Text)==item.koltuk_no)
                    {
                        if (item.cinsiyet == true)
                        {
                            panel1.Controls[j].BackColor = Color.Blue;
                            

                        }
                        else if (item.cinsiyet == false)
                        {
                            panel1.Controls[j].BackColor = Color.Pink;
                           
                        }
                    }
                }
                        
                
                    
                
            }
            
        }
        private void Btn_Click1(object sender, EventArgs e)
        {
           

            if (id==ActiveControl.Name)
            {
                return;
               
                
            }
            else
            {
                var bul = panel3.Controls.Find(id, true).FirstOrDefault();
                if (bul == null)
                {
                    ActiveControl.BackColor = Color.Lime;
                    id = ActiveControl.Name;
                    kolt.kol = int.Parse(id);
                    int x = panel1.Controls.Count;
                    for (int j = 0; j < x; j++)
                    {
                        panel1.Controls[j].BackColor = Color.Lime;
                        

                    }
                    koltuk();
                }
                else
                {
                    bul.BackColor = Color.Red;
                    ActiveControl.BackColor = Color.Lime;
                    id = ActiveControl.Name;
                    int x = panel1.Controls.Count;
                    for (int j = 0; j < x; j++)
                    {
                        panel1.Controls[j].BackColor = Color.Lime;
                        

                    }
                    kolt.kol = int.Parse(id);
                    koltuk();
                }



            }



        }

       
     void biletal()
        {
            if (id!=null)
            {
                if (ActiveControl.BackColor == Color.Lime)
                {
                    var fiyat = ent.tbSeferler.Where(x => x.sefer_id.ToString() == id).FirstOrDefault();
                    frmBiletAl frm = new frmBiletAl();
                    frm.label6.Text = ActiveControl.Text;
                    frm.label5.Text = id;
                    frm.label9.Text = fiyat.fiyat.ToString();
                    frm.Show();
                }
                else
                {
                    doldurBilet();
   
                }
            }
          
        }
        
      

        private void button51_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.label1.Text = label1.Text;
            frm.Show();
            Hide();
        }

        private void button51_MouseMove(object sender, MouseEventArgs e)
        {
            button51.Width = 57;
            button51.Height = 61;
        }

        private void button51_MouseLeave(object sender, EventArgs e)
        {
            button51.Width = 47;
            button51.Height = 51;
        }

        private void panel3_CursorChanged(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            biletal();
        }
        private void button45_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button46_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            biletal();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            biletal();
        }
    }
}
