
/*
FURKAN GÜLTEKİN B221200388 NDP PROJE
*/


using System.Drawing;
using Savas.Library.Abstract;

namespace Savas.Library.Concrete
{
    internal class Mermi : Cisim
    {
        public Mermi(Size hareketAlaniBoyutlari, int namluOrtasiX) : base(hareketAlaniBoyutlari)
        {
            BaslangicKonumunuAyarla(namluOrtasiX);
            HareketMesafesi = (int)(Height * 1.5); //merminin hızı
        }

        private void BaslangicKonumunuAyarla(int namluOrtasiX)
        {
            
            Center = namluOrtasiX;
        }
    }
}
