using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YılanOyunu
{
    public enum Yon
    {
        Yukari,
        Asagi,
        Sol,
        Sag
    }

    internal class Ayarlar
    {
        public static int Genislik {  get; set; }
        public static int Yukseklik {  get; set; }
        public static int Hiz { get; set; }
        public static int Puan { get; set; }
        public static int YemekPuani { get; set; }
        public static bool OyunBitti {  get; set; }
        public static Yon yon { get; set; }

        public Ayarlar() 
        {
            Genislik = 16;
            Yukseklik = 16;
            Hiz = 12;
            Puan = 0;
            YemekPuani = 100;
            OyunBitti = false;
            yon = Yon.Asagi;
        }
    }
}
