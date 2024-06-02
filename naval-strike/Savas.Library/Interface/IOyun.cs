
/*
FURKAN GÜLTEKİN B221200388 NDP PROJE
*/

using System;
using Savas.Library.Enum;

namespace Savas.Library.Interface
{
    internal interface IOyun
    {
        event EventHandler GecenSureDegisti;

        bool DevamEdiyorMu { get; }
        TimeSpan GecenSure { get; }
       
        void Baslat();
        void AtesEt();
        void UcaksavariHareketEttir(Yon yon); //parametre adı olarak yon kullanıldı.

        void ZamanlayicilariDurdur();

        void ZamanlayicilariBaslat();
    }
}
