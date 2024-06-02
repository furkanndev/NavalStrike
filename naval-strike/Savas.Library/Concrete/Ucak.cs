
/*
FURKAN GÜLTEKİN B221200388 NDP PROJE
*/


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Savas.Library.Abstract;

namespace Savas.Library.Concrete
{
    internal class Ucak : Cisim //Denizaltı sınıfı, Cisim sınıfından türemiştir. Cisim sınıfı ise bir soyut sınıftır. 
    {
        private static readonly Random Random = new Random();
        private static Timer _speedTimer = new Timer();

        public Ucak(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            HareketMesafesi = (int)(Width * .1); 
            Left= Random.Next(hareketAlaniBoyutlari.Width - Width + 1); //denizaltıyı oluşturuluacağı yükseklik ayarlandı. 
            Top = Random.Next(hareketAlaniBoyutlari.Height - Height + 1); //denizaltıyı oluşturuluacağı yükseklik ayarlandı. 

            _speedTimer.Interval = 7000;
            _speedTimer.Tick += SpeedTimer_Tick; // Zamanlayıcının tick olayı
            _speedTimer.Start(); // Zamanlayıcıyı başlat
        }
        private void SpeedTimer_Tick(object sender, EventArgs e)
        {
            HareketMesafesi += 10; // Her 7 saniyede bir hareket mesafesini 10 artır
        }

        public Mermi VurulduMu(List<Mermi> mermiler)
        {
            foreach (var mermi in mermiler)
            {
                var vurulduMu = mermi.Top > Bottom && mermi.Right > Left && mermi.Left < Right;
                if (vurulduMu) return mermi;
            }

            return null;
        }






    }
}
