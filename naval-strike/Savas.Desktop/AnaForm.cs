/*
FURKAN GÜLTEKİN B221200388 NDP PROJE
*/

using System;
using System.Windows.Forms;
using Savas.Library.Concrete;
using Savas.Library.Enum;

namespace Savas.Desktop
{
    public partial class AnaForm : Form
    {
        private readonly Oyun _oyun; //_oyun adında bir değişken tanımlıyoruz.
        private bool oyunDuraklatıldı;

        public AnaForm()
        {
            InitializeComponent();

            _oyun = new Oyun(ucaksavarPanel, savasAlaniPanel,skor,skor1,skor2);
            _oyun.GecenSureDegisti += Oyun_GecenSureDegisti;
            oyunDuraklatıldı = false;
            oyuncu.Text = Form1.SetValueForText1;
        }

        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    _oyun.Baslat();
                    oyunDuraklatıldı = false;
                    _oyun.ZamanlayicilariBaslat();
                    break;
                case Keys.Right:
                    _oyun.UcaksavariHareketEttir(Yon.Saga);
                    break;
                case Keys.Left:
                    _oyun.UcaksavariHareketEttir(Yon.Sola);
                    break;
                case Keys.Space:
                    _oyun.AtesEt();
                    break;
                case Keys.P:
                    oyunDuraklatıldı = !oyunDuraklatıldı;
                    _oyun.ZamanlayicilariDurdur();
                    break;
            }
        }

        private void Oyun_GecenSureDegisti(object sender, EventArgs e)
        {
            sureLabel.Text = _oyun.GecenSure.ToString(@"m\:ss");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            

        }

        private void savasAlaniPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            _oyun.ZamanlayicilariDurdur();
            MessageBox.Show("Bütün İlerlemeler Silinecektir!!");
            Form1 getir = new Form1();
            getir.Show();
            this.Close();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Bütün uygulamaları kapatmak için kullandım.
        }

       


    }
}
