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
    public partial class frmBiletGöster : Form
    {
        public frmBiletGöster()
        {
            InitializeComponent();
        }
      
        dbBiletEntities ent = new dbBiletEntities();
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
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

        private void frmBiletGöster_Load(object sender, EventArgs e)
        {
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var soru = MessageBox.Show("BİLETİ İPTAL ETMEK İSTEDİĞİNİZE EMİN MİSİNİZ", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (soru == DialogResult.Yes)
            {
                if (frmBilet.idBilet.id!=0)
                {
                    int sil = frmBilet.idBilet.id;
                    
                    ent.tbBiletler.Remove(ent.tbBiletler.Find(sil));
                    ent.SaveChanges();
                    
                    frmBilet frm = new frmBilet();
                    frmBilet f1 = (frmBilet)Application.OpenForms["frmBilet"];
                    f1.koltuk();
                    Close();
                }
                else
                {
                    MessageBox.Show("BİLİNMEYEN BİR HATA OLUŞTU");
                }

            }
            else
            {
                return;
            }
        }
    }
}
