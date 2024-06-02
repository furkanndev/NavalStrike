
/*
FURKAN GÜLTEKİN B221200388 NDP PROJE
*/



using System.Drawing;
using Savas.Library.Abstract;

namespace Savas.Library.Concrete
{
    internal class Ucaksavar : Cisim //oluşturduğum her gemi aynı zamanda bir cisim dir,her cisim bir picturebox dır.
    {
        public Ucaksavar(int panelGenisligi, Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            Center = panelGenisligi / 2;
            HareketMesafesi = Width;
        }
    }
}
