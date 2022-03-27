using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AggregateMetotları_CountSumAvg
{
    public partial class Form1 : Form
    {
        Db_UrunlerEntities db = new Db_UrunlerEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //toplam ürün miktarı
            LblToplamUrun.Text = db.Tbl_Urunler.Count().ToString();

            //Toplam Stok Adedi
            label2.Text = db.Tbl_Urunler.Sum(q1 => q1.UrunStok).ToString();

            //BUZDOLABI STOK ADEDİ
            label4.Text = db.Tbl_Urunler.Where(q1 => q1.UrunAd == "Buzdolabı").
                Sum(q1 => q1.UrunStok).ToString();

            //TEXTBOXA GİRİLEN ÜRÜNÜN STOK ADEDİ
            if (String.IsNullOrEmpty(txtStokAdedi.Text))
            {
                txtStokAdedi.Text = "BUZDOLABI";//EXCEPTION ICIN


            }
            else
            {
                var ad = txtStokAdedi.Text.ToUpper();
                lblStokAded.Text = db.Tbl_Urunler.Where(q1 => q1.UrunAd == ad).Sum(q1 => q1.UrunStok).ToString();
            }
            

            // ÜRÜNLERIN FİYAT ORTALAMASI
        
            lblFiyat.Text = db.Tbl_Urunler.Average(q2=>q2.UrunFiyat).ToString();














        }
    }
}
