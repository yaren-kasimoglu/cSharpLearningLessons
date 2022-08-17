using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Static
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
             * STATIC CLASS
             * Eger nesneye bagimli islemler gerceklestirmiyorsaniz - yani amac sadece belirli bir duruma hizmet eden birden fazla ogeyi bir araya toplamak ise - ilgili sınıfı static olarak isaretleyebilir ve icerisindeki tum ogelere instance'dan bagimsiz olarak ulasabilirsiniz...
             *
             * Static sınıflar icerisinde yalnizca static ogeler barinabilir (field, property, method...)
             *
             * Static bir class baska bir classtan kalitim alamaz! Ancak .NET Framework mantigi geregi, tum sınıflar System.Object sınıfından kalitim alirlar. Static sınıflar da bu kalitim islemine dahildir...
             *
             * Static sınıflara en guzel iki ornek Math ve File sınıflaridir. Ayni amaca (Math => Matematiksel islemlerin bir arada tutulmasi; File => Dosya bazli islemler gerceklestiren birden fazla islemin bir arada tutulmasi) hizmet eden ogeleri icerisinde barindiran ve hizlica ulasmamizi saglayan siniflardir.
             *
             * Ancak her sinif static olarak isaretlenmemelidir. Cunku tanimlamis oldugunuz her static sinif size ufak da olsa performans kaybi olarak donecektir...
             */

        /*
        * non static class ın içinde static öge olabilir.
        * Ama static nesnenin içinde non static öge bulunamaz
        */

        private void Form1_Load(object sender, EventArgs e)
        {
         //FizikKutuphanesi classının adını yazdığımda içindeki static olan nesneleri çekebiliryorum new leme yapmadan  
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Ziyaretci ziyaretci = new Ziyaretci();
        //    ziyaretci.AdiSoyadi="Yaren Kasımoğlu";
        //    ziyaretci.ZiyaretciSayisi += 1;
            
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Ziyaretci ziyaretci2 = new Ziyaretci();
        //    ziyaretci2.AdiSoyadi = "Yaren Kasımoğlu";
        //    ziyaretci2.ZiyaretciSayisi -= 1;
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    Ziyaretci ziyaretci3 = new Ziyaretci();
        //    MessageBox.Show(ziyaretci3.ZiyaretciSayisi.ToString());
        //}

        /*
         static dediğimiz nesne uygulama başladığı andan itibaren ram in üzerinde yer tutar ve  uygulama bitene kadar orda kalır .
        Bu sayede hep aynı nesneye hizmet eder.
        aşağıdaki örnekte gördüğümüz ziyaretçi sayısı her seferinde yeniden oluşmasını istemiyoruz tüm uygulama boyunca new lenmeden yani yeniden oluşmadan  çalışsın.

        *****************
        
         
        benden bir tane var ve hizmet verdiğim 10 tane yazılım şirketine ben bakıyorum hepsi bir şey ihtiyacı olduğunda direkt bana ulaşabilecek. her an ulaşabilecek. Görevlerim sıfırlanmadan yola devam edebiliyorum 
         
         
         */

        private void button1_Click(object sender, EventArgs e)
        {
            Ziyaretci ziyaretci = new Ziyaretci();
            ziyaretci.AdiSoyadi = "Yaren Kasımoğlu";
            Ziyaretci.ZiyaretciSayisi += 1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ziyaretci ziyaretci2 = new Ziyaretci();
            ziyaretci2.AdiSoyadi = "Yaren Kasımoğlu";
            Ziyaretci.ZiyaretciSayisi -= 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ziyaretci ziyaretci3 = new Ziyaretci();
            MessageBox.Show(Ziyaretci.ZiyaretciSayisi.ToString());
        }
    }
}
