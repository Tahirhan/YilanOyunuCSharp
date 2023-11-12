namespace YılanOyunu
{
    public partial class FormOyun : Form
    {
        private List<Cember> yilan = new List<Cember>(); // yılan cember objelerinden olusuyor
        private Cember besin = new Cember();

        public FormOyun()
        {
            InitializeComponent();

            // taslak ayarları atayalım
            new Ayarlar();

            // Oyun hızını ve zamanlayıcıyı ayarlayalım
            timerOyun.Interval = 1000 / Ayarlar.Hiz;
            timerOyun.Start();

            // Oyunu baslatabiliriz
            OyunuBaslat();
        }

        private void OyunuBaslat()
        {
            lblOyunSonuMetni.Visible = false; // Oyun sonu metnini gizliyoruz

            // Oyuna tekrar baslama durumu icin ayarları sıfırlıyoruz
            new Ayarlar();

            yilan.Clear(); // yılanı baslangıcta ekranın ortasında tek cemberden olusmus duruma getiriyoruz
            Cember bas = new Cember();
            bas.X = 10;
            bas.Y = 5;
            yilan.Add(bas);

            lblPuan.Text = Ayarlar.Puan.ToString(); // puan metnini guncelleyelim
            BesinUret();
        }

        private void BesinUret()
        {
            int maksimumX = pbCanvas.Size.Width / Ayarlar.Genislik;
            int maksimumY = pbCanvas.Size.Height / Ayarlar.Yukseklik; // oyun alanının sınırlarını alıyoruz

            Random rastgele = new Random();
            do
            {
                besin = new Cember();
                besin.X = rastgele.Next(0, maksimumX);
                besin.Y = rastgele.Next(0, maksimumY);
            } while (!BesinKonumuUygun(besin)); // besinin, yılanın gövdesi üzerinde oluşturulmaması gerekiyor
        }

        private bool BesinKonumuUygun(Cember besin)
        {
            Cember eslesenKonum = yilan.Where(r => r.X == besin.X & r.Y == besin.Y).FirstOrDefault();
            if (eslesenKonum == null) return true; // besin pozisyonunda yilan uzvu yok
            return false; // besin pozisyonunda yılan uzvu var
        }

        private void EkraniGuncelle(object sender, EventArgs e)
        {
            // Oyun Bitti mi kontrol et
            if (Ayarlar.OyunBitti == true)
            {
                // Eğer Enter a basıldıysa yeni oyun baslat
                if (Girdi.TusaBasildi(Keys.Enter))
                {
                    OyunuBaslat();
                }
            }
            else
            {
                // Onceki yön basılan tuşun tam ters yönünde değilse yönü güncelle
                if (Girdi.TusaBasildi(Keys.Right) && Ayarlar.yon != Yon.Sol)
                    Ayarlar.yon = Yon.Sag;
                else if (Girdi.TusaBasildi(Keys.Left) && Ayarlar.yon != Yon.Sag)
                    Ayarlar.yon = Yon.Sol;
                else if (Girdi.TusaBasildi(Keys.Up) && Ayarlar.yon != Yon.Asagi)
                    Ayarlar.yon = Yon.Yukari;
                else if (Girdi.TusaBasildi(Keys.Down) && Ayarlar.yon != Yon.Yukari)
                    Ayarlar.yon = Yon.Asagi;

                YilaniHareketEttir();
            }

            pbCanvas.Invalidate(); // Oyun alanını yenile
        }

        private void YilaniHareketEttir()
        {
            for (int i = yilan.Count - 1; i >= 0; i--)
            {
                // Bası hareket ettir 
                if (i == 0)
                {
                    switch (Ayarlar.yon)
                    {
                        case Yon.Sag:
                            yilan[i].X++; break;
                        case Yon.Sol:
                            yilan[i].X--; break;
                        case Yon.Yukari:
                            yilan[i].Y--; break; // Y degeri aşağı doğru artıyor
                        case Yon.Asagi:
                            yilan[i].Y++; break;
                    }

                    // Oyun alanı sınırlarını al
                    int maksimumX = pbCanvas.Size.Width / Ayarlar.Genislik;
                    int maksimumY = pbCanvas.Size.Height / Ayarlar.Yukseklik;

                    // Oyun sınırına carpma durumunu kontrol et
                    if (yilan[i].X < 0 || yilan[i].Y < 0 || yilan[i].X >= maksimumX || yilan[i].Y >= maksimumY)
                    {
                        OyunuBitir();
                    }

                    // Govde ile carpısma durumunu kontrol et
                    for (int j = 1; j < yilan.Count; j++)
                    {
                        if (yilan[i].X == yilan[j].X && yilan[i].Y == yilan[j].Y)
                            OyunuBitir();
                    }

                    // Besini yeme durumunu kontrol et
                    if (yilan[0].X == besin.X && yilan[0].Y == besin.Y)
                    {
                        BesiniYe();
                    }
                }
                else
                {
                    // Govdeyi hareket ettir
                    yilan[i].X = yilan[i - 1].X;
                    yilan[i].Y = yilan[i - 1].Y;
                }
            }
        }

        private void BesiniYe()
        {
            // Govdeye yeni uzuv ekle
            besin = new Cember();
            besin.X = yilan[yilan.Count - 1].X;
            besin.Y = yilan[yilan.Count - 1].Y;
            yilan.Add(besin);

            // Puanı guncelle
            Ayarlar.Puan += Ayarlar.YemekPuani;
            lblPuan.Text = Ayarlar.Puan.ToString();

            BesinUret();
        }

        private void OyunuBitir()
        {
            Ayarlar.OyunBitti = true;
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics; // canvas objesini alıyoruz 

            if (!Ayarlar.OyunBitti) // Oyun bitmedi ise görsel güncellemeleri yapıyoruz
            {
                // Yılan konumunu guncelliyoruz
                Brush yilanRenk;

                for (int i = 0; i < yilan.Count; i++)
                {
                    // renk ataması
                    if (i == 0) yilanRenk = Brushes.Black; // bas kısmı siyah
                    else yilanRenk = Brushes.Green; // govdesi yesil

                    // uzuv konumu ataması
                    canvas.FillEllipse(yilanRenk, new Rectangle(yilan[i].X * Ayarlar.Genislik,
                                                                yilan[i].Y * Ayarlar.Yukseklik,
                                                                Ayarlar.Genislik, Ayarlar.Yukseklik));
                    // besin çizimi
                    canvas.FillEllipse(Brushes.Red,
                        new Rectangle(besin.X * Ayarlar.Genislik,
                                      besin.Y * Ayarlar.Yukseklik,
                                      Ayarlar.Genislik,
                                      Ayarlar.Yukseklik));

                }
            }
            else // Oyun bitti ise puanını gösterip oyunu sonlandırıyoruz
            {
                string oyunBitimiMetni = $"Oyun Bitti \nPuanınız : {Ayarlar.Puan}\nEnter a basarak yeni oyuna baslayabilirsiniz..";
                lblOyunSonuMetni.Text = oyunBitimiMetni;
                lblOyunSonuMetni.Visible = true;
            }
        }

        private void FormOyun_KeyDown(object sender, KeyEventArgs e)
        {
            // Klavyede tusa basılınca durumunu basılı olarak guncelle
            Girdi.DurumDegistir(e.KeyCode, true);
        }

        private void FormOyun_KeyUp(object sender, KeyEventArgs e)
        {
            // Tusa basmayı bırakınca durumunu basılı degil olarak guncelle
            Girdi.DurumDegistir(e.KeyCode, false);
        }
    }
}