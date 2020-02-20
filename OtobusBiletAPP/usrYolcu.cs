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
    public partial class usrYolcu : UserControl
    {
        public usrYolcu()
        {
            InitializeComponent();
        }
        dbBiletEntities ent = new dbBiletEntities();
        void grafik1()
        {
            var sorgu = from b in ent.tbBiletler

                        group b by new
                        {
                           b.tc,
                           b.ad,
                           b.soyad
                        } into plk
                        orderby plk.Count() descending
                        select new { sefer = plk.Key.ad,sefer2=plk.Key.soyad, seferSayisi = plk.Count() };

            int sayac = 0;
            foreach (var item in sorgu)
            {
                if (sayac != 5)
                {
                    chart1.Series["YOLCU"].Points.Add(double.Parse(item.seferSayisi.ToString()));
                    chart1.Series["YOLCU"].Points[sayac].AxisLabel = item.sefer.ToString()+"\n"+item.sefer2.ToString();

                    sayac++;
                }

            }
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -70;



        }
        void grafik2()
        {
            var sorgu = from b in ent.tbBiletler

                        group b by b.cinsiyet into plk
                        orderby plk.Count() descending
                        select new { sefer = plk.Key, seferSayisi = plk.Count() };

            int sayac = 0;
            foreach (var item in sorgu)
            {
                if (item.sefer==false)
                {
                    
                    chart2.Series["YOLCU"].Points.Add(double.Parse(item.seferSayisi.ToString()));
                    chart2.Series["YOLCU"].Points[sayac].AxisLabel = "KADIN";
                    chart2.Series["YOLCU"].Points[sayac].Color = Color.LightPink;
                    

                    
                }
                else if(item.sefer==true)
                {
                    
                    chart2.Series["YOLCU"].Points.Add(double.Parse(item.seferSayisi.ToString()));
                    chart2.Series["YOLCU"].Points[sayac].AxisLabel = "ERKEK";
                    chart2.Series["YOLCU"].Points[sayac].Color = Color.CornflowerBlue;
                    
                }
                sayac++;

            }
            
           
            chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -70;



        }
        private void usrYolcu_Load(object sender, EventArgs e)
        {
            grafik1();
            grafik2();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Yazı fontumu ve çizgi çizmek için fırçamı ve kalem nesnemi oluşturdum
            Font myFont = new Font("Calibri", 28);
            SolidBrush sbrush = new SolidBrush(Color.Red);
            Font myFont2 = new Font("Calibri", 18);
            SolidBrush sbrush2 = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black);
            e.Graphics.DrawString("Tarih:"+DateTime.Now.ToString(), myFont2, sbrush2, 10, 10);
            //çizgileri yazdırıyorum
            e.Graphics.DrawLine(myPen, 120, 120, 750, 120);
            e.Graphics.DrawLine(myPen, 120, 180, 750, 180);
            e.Graphics.DrawString("YOLCU RAPORLARI", myFont, sbrush, 230, 120);
            ////////////////////////
            e.Graphics.DrawString("En Fazla Yolculuk Yapan Yolcular", myFont2, sbrush2, 200, 220);
            StringFormat myStringFormat = new StringFormat();
            myStringFormat.Alignment = StringAlignment.Far;
            Bitmap bmap = new Bitmap(chart1.Width,chart1.Height);
            System.Drawing.Rectangle myRec = new System.Drawing.Rectangle(50, 250, 750, 400);
            chart1.Printing.PrintPaint(e.Graphics, myRec);

            e.Graphics.DrawString("Yolcuların Cinsiyet Dağılımı", myFont2, sbrush2, 200, 650);

            System.Drawing.Rectangle myRec2 = new System.Drawing.Rectangle(50, 678, 750, 400);
            chart2.Printing.PrintPaint(e.Graphics, myRec2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
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
    }
}
