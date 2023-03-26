using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionWorking
{
    public class Program
    {
        static void Main(string[] args)
        {
            //KullaniciyiBilgiendir();
            
            //Console.WriteLine(Topla(5,6));
            Console.ReadKey();
        }
        #region Çalışlma1
        public static void KullaniciyiBilgiendir()
        {
            Console.WriteLine("Kullanıcı Bilgilendirme Yapılır");
        }

        public static int Topla(int s1, int s2)
        {
            int toplam=0;
            toplam = s1 + s2;

            return toplam;
        }
        #endregion
    }
}
