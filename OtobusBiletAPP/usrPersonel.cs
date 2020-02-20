using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtobusBiletAPP
{
    public partial class usrPersonel : UserControl
    {
        public usrPersonel()
        {
            InitializeComponent();
        }
        dbBiletEntities ent = new dbBiletEntities();
        void grafik1()
        {
            var sorgu = from k in ent.tbKullanicilar
                        join b in ent.tbBiletler on k.kullanici_adi equals b.kullanici_adi
                        
                       
                        group k by new
                        {
                           k.kullanici_adi,
                           k.kullanici_ad_soyad
                        } into plk
                        orderby plk.Count() descending
                        select new { sefer = plk.Key.kullanici_ad_soyad, sayi = plk.Count() };

            int sayac = 0;
            foreach (var item in sorgu)
            {
                if (true)
                {
                    chart1.Series["BİLET"].Points.Add(double.Parse(item.sayi.ToString()));
                    chart1.Series["BİLET"].Points[sayac].AxisLabel = item.sefer.ToString();

                    sayac++;
                }

            }
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -70;



        }
        void grafik2()
        {
            var sorgu =( from k in ent.tbKullanicilar
                        join b in ent.tbBiletler on k.kullanici_adi equals b.kullanici_adi


                        group b by new
                        {
                            b.kullanici_adi,
                            k.kullanici_ad_soyad
                        } into plk
                        orderby plk.Count() descending
                        select new { sefer = plk.Key.kullanici_ad_soyad,sayi=plk.Sum(x=>x.ucret) }).Distinct();

            int sayac = 0;
            foreach (var item in sorgu)
            {
                if (true)
                {
                    chart2.Series["FİYAT"].Points.Add(double.Parse(item.sayi.ToString()));
                    chart2.Series["FİYAT"].Points[sayac].AxisLabel = item.sefer.ToString();

                    sayac++;
                }

            }
            chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -70;



        }
        private void usrPersonel_Load(object sender, EventArgs e)
        {
            grafik1();
            grafik2();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Width = 107;
            button1.Height = 90;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Width = 97;
            button1.Height = 80;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Yazı fontumu ve çizgi çizmek için fırçamı ve kalem nesnemi oluşturdum
            Font myFont = new Font("Calibri", 28);
            SolidBrush sbrush = new SolidBrush(Color.Red);
            Font myFont2 = new Font("Calibri", 18);
            SolidBrush sbrush2 = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black);
            e.Graphics.DrawString("Tarih:" + DateTime.Now.ToString(), myFont2, sbrush2, 10, 10);
            //çizgileri yazdırıyorum
            e.Graphics.DrawLine(myPen, 120, 120, 750, 120);
            e.Graphics.DrawLine(myPen, 120, 180, 750, 180);
            e.Graphics.DrawString("PERSONEL RAPORLARI", myFont, sbrush, 230, 120);
            ////////////////////////
            e.Graphics.DrawString("Personellerin Bilet Satışları", myFont2, sbrush2, 200, 220);
            StringFormat myStringFormat = new StringFormat();
            myStringFormat.Alignment = StringAlignment.Far;
            Bitmap bmap = new Bitmap(chart1.Width, chart1.Height);
            System.Drawing.Rectangle myRec = new System.Drawing.Rectangle(50, 250, 750, 400);
            chart1.Printing.PrintPaint(e.Graphics, myRec);

            e.Graphics.DrawString("Personellerin Toplam Bilet Satış Tutarları", myFont2, sbrush2, 200, 650);

            System.Drawing.Rectangle myRec2 = new System.Drawing.Rectangle(50, 678, 750, 400);
            chart2.Printing.PrintPaint(e.Graphics, myRec2);
        }
    }
}
