using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAHamburgerTakip_02.Models;

namespace WFAHamburgerTakip_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Hamburger> menuler = new List<Hamburger>() 
        {
            new Hamburger () {Adi="Steak House" , Fiyati=21},
            new Hamburger () {Adi="Texas Smoke House",Fiyati=23},
            new Hamburger () {Adi="Whooper",Fiyati=19},
            new Hamburger () {Adi="Big King",Fiyati=18},
            new Hamburger () {Adi="King Chicken", Fiyati=11},
            new Hamburger () {Adi="Mc Fish",Fiyati=10.25m}
        };

        List<Icecek> icecekler = new List<Icecek>()
        {
            new Icecek () {Adi="Coca Cola",Fiyati=1.10m},
            new Icecek () {Adi="Coca Cola Zero",Fiyati=1.20m},
            new Icecek () {Adi="Fanta",Fiyati=1},
            new Icecek () {Adi="İce Tea",Fiyati=1.25m},
            new Icecek () {Adi="Fruko",Fiyati=0.60m},
            new Icecek () {Adi="Ayran",Fiyati=0.50m}
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            cbMenuSec.Items.AddRange(menuler.ToArray());
            cbMenuSec.SelectedIndex = 0;
            cbIcecekSec.Items.AddRange(icecekler.ToArray());
            cbIcecekSec.SelectedIndex =0;   
        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            Siparis siparis = new Siparis();
            siparis.SeciliHamburger = (Hamburger)cbMenuSec.SelectedItem;
            siparis.SeciliIcecek = (Icecek)cbIcecekSec.SelectedItem;

            if (rbKucuk.Checked) siparis.SeciliBoyut = Boyut.Kucuk;
            else if (rbOrta.Checked) siparis.SeciliBoyut = Boyut.Orta;
            else if (rbBuyuk.Checked) siparis.SeciliBoyut = Boyut.Buyuk;
            else
            { MessageBox.Show("Lütfen Boyut Seçimi Yapınız."); return; }

            foreach (CheckBox item in grpEkstraMalzemeler.Controls)
            {
                if (item.Checked)
                {
                    EkstraMalzeme ekstra = new EkstraMalzeme();
                    ekstra.Adi = item.Text;
                    ekstra.Fiyati =Convert.ToDecimal (item.Tag);
                    siparis.Extramelzemeleri.Add(ekstra);
                }
            }

            siparis.Adet = Convert.ToInt32(nmrAdet.Value);
            siparis.TutarHesapla();
            lstSiparis.Items.Add(siparis);
            decimal tutar = 0;
            foreach (Siparis item in lstSiparis.Items)
            {
                tutar += item.ToplamTutar;
            }
            
            
            lblTutar.Text = tutar.ToString("C2");
        }

        private void btnTutarHesapla_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            foreach (Siparis item in lstSiparis.Items)
            {
                total += item.ToplamTutar;
            }

            MessageBox.Show($"Siparişiniz başarıyl alınmıştır. Toplam Tutarınız: {total.ToString("C2")}" );
            lstSiparis.Items.Clear();
        }
    }
}
