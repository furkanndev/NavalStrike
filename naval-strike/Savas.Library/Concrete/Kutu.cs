/*
FURKAN GÜLTEKİN B221200388 NDP PROJE
*/


using Savas.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Savas.Library.Concrete
{
    internal class Kutu : Cisim
    {
        private static readonly Random Random = new Random();
        public Kutu(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            HareketMesafesi = (int)(Width * .25);
            Left = Random.Next(hareketAlaniBoyutlari.Width - Width + 1); //rastgele kutu oluşturuyoruz.
            Top = Random.Next(hareketAlaniBoyutlari.Height - Height + 1); //rastgele kutu oluşturuyoruz.
        }

        public Mermi VurulduMu(List<Mermi> mermiler) // Kutu vurulması için mermiler.
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
