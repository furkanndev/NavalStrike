/*
FURKAN GÜLTEKİN B221200388 NDP PROJE
*/


using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Savas.Library.Enum;
using Savas.Library.Interface;
using Savas.Library.Abstract;

namespace Savas.Library.Concrete
{
    public class Oyun : IOyun
    {
        #region Alanlar

        private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };
        private readonly Timer _hareketTimer = new Timer { Interval = 100 };
        private readonly Timer _ucakOlusturmaTimer = new Timer { Interval = 3000 }; //her üç saniyede bir denizaltı oluşturucak
        private readonly Timer _kutuOlusturmaTimer = new Timer { Interval = 10000 };//her 10 saniyede bir kutu oluşturucak
        private TimeSpan _gecenSure;
        private readonly Panel _ucaksavarPanel;
        private readonly Panel _savasAlaniPanel;
        private Ucaksavar _ucaksavar;
        private readonly List<Mermi> _mermiler = new List<Mermi>();
        private readonly List<Ucak> _ucaklar = new List<Ucak>();
        private readonly Label _skor;
        private readonly Label _skor1;
        private readonly Label _skor2;
        private readonly List<Kutu> _kutu = new List<Kutu>();

        #endregion

        #region Olaylar

        public event EventHandler GecenSureDegisti;

        #endregion

        #region Özellikler

        public bool DevamEdiyorMu { get; private set; }

        public TimeSpan GecenSure
        {
            get => _gecenSure;
            private set
            {
                _gecenSure = value;

                GecenSureDegisti?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Metotlar

        public Oyun(Panel ucaksavarPanel, Panel savasAlaniPanel, Label skor, Label skor1, Label skor2)
        {
            _ucaksavarPanel = ucaksavarPanel;
            _savasAlaniPanel = savasAlaniPanel;

            _gecenSureTimer.Tick += GecenSureTimer_Tick;
            _hareketTimer.Tick += HareketTimer_Tick;
            _ucakOlusturmaTimer.Tick += UcakOlusturmaTimer_Tick;
            _kutuOlusturmaTimer.Tick += KutuOlusturmaTimer_Tick;
            _skor = skor;
            _skor1 = skor1;
            _skor2 = skor2;

        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            GecenSure += TimeSpan.FromSeconds(1);
        }

        private void HareketTimer_Tick(object sender, EventArgs e)
        {
            MermileriHareketEttir();
            UcaklariHareketEttir();
            VurulanUcaklariCikar();
            KutulariHareketEttir();
            VurulanKutulariCikar();

        }
        public int skor = 0;
        public int skor2 = 0;
        private void VurulanKutulariCikar()
        {
            for (var i = _kutu.Count - 1; i >= 0; i--)
            {
                var kutu = _kutu[i];

                var vuranMermi = kutu.VurulduMu(_mermiler);


                if (vuranMermi is null) continue;
                Random rnd = new Random();
                int month = rnd.Next(-5, 5);
                skor = skor + month;
                _skor.Text = skor.ToString();

                skor2 += 1;
                _skor2.Text = skor2.ToString();


                _kutu.Remove(kutu);
                _mermiler.Remove(vuranMermi);
                _savasAlaniPanel.Controls.Remove(kutu);
                _savasAlaniPanel.Controls.Remove(vuranMermi);



            }
        }

        private void KutulariHareketEttir()
        {
            for (int i = _kutu.Count - 1; i >= 0; i--)
            {
                var kutu = _kutu[i];
                var sınıraUlaştım = kutu.HareketEttir(Yon.Sola);

                if (sınıraUlaştım)
                {
                    _kutu.Remove(kutu);
                    _savasAlaniPanel.Controls.Remove(kutu);
                }



            }
        }

        
        public int skor1 = 0;
        private void VurulanUcaklariCikar()
        {
            
            for (var i = _ucaklar.Count - 1; i >= 0; i--)
            {
                var ucak = _ucaklar[i];

                var vuranMermi = ucak.VurulduMu(_mermiler);
                

                if (vuranMermi is null) continue;
                skor += 5;
                _skor.Text = skor.ToString();
                skor1 += 1;
                _skor1.Text = skor1.ToString();


                _ucaklar.Remove(ucak);
                _mermiler.Remove(vuranMermi);
                _savasAlaniPanel.Controls.Remove(ucak);
                _savasAlaniPanel.Controls.Remove(vuranMermi);
            }
        }

        private void UcaklariHareketEttir()
        {
            for (int i = _ucaklar.Count - 1; i >= 0; i--)
            {
                var ucak = _ucaklar[i];
                var sınıraUlaştım = ucak.HareketEttir(Yon.Sola);
                
                if (sınıraUlaştım)
                {
                    _ucaklar.Remove(ucak);//Mermilerin savaş alanı dışına çıktığında mermilerin listeden silinmesi
                    _savasAlaniPanel.Controls.Remove(ucak);
                }
 


            }
        }

        private void UcakOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            UcakOlustur();
        }

        private void KutuOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            KutuOlustur();
        }



        private void MermileriHareketEttir()
        {
            for (int i = _mermiler.Count - 1; i >= 0; i--)
            {
                var mermi = _mermiler[i];
                var carptiMi = mermi.HareketEttir(Yon.Asagi);
                if (carptiMi)
                { 
                    _mermiler.Remove(mermi); //Mermilerin savaş alanı dışına çıktığında mermilerin listeden silinmesi
                    _savasAlaniPanel.Controls.Remove(mermi);
                }
            }
        }

        public void Baslat()
        {
            if (DevamEdiyorMu) return;

            DevamEdiyorMu = true;

            ZamanlayicilariBaslat();

            UcaksavarOlustur();
            UcakOlustur();
            
        }

        private void UcakOlustur() //düzenli aralıklarla yeni denizaltılar oluşturur.
        {
            var ucak = new Ucak(_savasAlaniPanel.Size);
            _ucaklar.Add(ucak);
            _savasAlaniPanel.Controls.Add(ucak);
        }

        private void KutuOlustur()
        {
            var kutu = new Kutu(_savasAlaniPanel.Size);
            _kutu.Add(kutu);
            _savasAlaniPanel.Controls.Add(kutu); 

        }

        public void ZamanlayicilariBaslat()
        {
            _gecenSureTimer.Start();
            _hareketTimer.Start();
            _ucakOlusturmaTimer.Start();
            _kutuOlusturmaTimer.Start();
        }

        private void UcaksavarOlustur() //geminin olduğu panelin size ını Gemi ye gönderiyoruz Gemi aldığı HareketAlanıBoyutlarını cisim e gönderiyor ve artık hareketalanı boyutlarını kullanabilirz.
        {
            _ucaksavar = new Ucaksavar(_ucaksavarPanel.Width, _ucaksavarPanel.Size);
            _ucaksavarPanel.Controls.Add(_ucaksavar);
        }

        private void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
            ZamanlayicilariDurdur();
        }

        public void ZamanlayicilariDurdur()
        {
            _gecenSureTimer.Stop();
            _hareketTimer.Stop();
            _ucakOlusturmaTimer.Stop();
            _kutuOlusturmaTimer.Stop();
        }


        public void AtesEt()
        {
            if (!DevamEdiyorMu) return;

            var mermi = new Mermi(_savasAlaniPanel.Size, _ucaksavar.Center);
            _mermiler.Add(mermi); //bir panelin üzerine ekleyebilmek için o sınıfın control den miras alması gerekir.
            _savasAlaniPanel.Controls.Add(mermi);
        }

        public void UcaksavariHareketEttir(Yon yon)
        {
            if (!DevamEdiyorMu) return; //oyunu başlatmadan geminin hareket etmesini önlüyoruz.

            _ucaksavar.HareketEttir(yon);
        }

        #endregion
    }
}
