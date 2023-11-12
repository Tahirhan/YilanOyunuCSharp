using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YılanOyunu
{
    internal class Girdi
    {
        // Girilebilir tusların listesi
        private static Hashtable tusTablosu = new Hashtable();

        // basilan tus icin kontrol metodu
        public static bool TusaBasildi(Keys tus)
        {
            if (tusTablosu[tus] == null)
            {
                return false;
            }

            return (bool)tusTablosu[tus];
        }

        // klavye ye basılma durumunu kontrol eden metod
        public static void DurumDegistir(Keys tus, bool durum)
        {
            tusTablosu[tus] = durum;
        }
    }
}
