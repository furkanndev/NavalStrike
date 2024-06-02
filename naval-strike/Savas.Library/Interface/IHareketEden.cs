

/*
FURKAN GÜLTEKİN B221200388 NDP PROJE
*/

using System.Drawing;
using Savas.Library.Enum;

namespace Savas.Library.Interface
{
    internal interface IHareketEden
    {
        Size HareketAlaniBoyutlari { get; } //sadece readonly olması için get yazdık set yazmadık.

        int HareketMesafesi { get; }
        
        /// <summary>
        /// Cismi istenilen yönde hareket ettirir
        /// </summary>
        /// <param name="yon">Hangi yöne hareket edileceği</param>
        /// <returns>Cisim duvara çaparsa true döndürür.</returns>
        bool HareketEttir(Yon yon);
    }
}
