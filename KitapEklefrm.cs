using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyon
{
    public partial class KitapEklefrm : Form
    {
        public KitapEklefrm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-FEBFK33\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyonDatabase;Integrated Security=True");  // "\" hata verdiği için başına @ ekledim

        private void KitapEklefrm_Load(object sender, EventArgs e)
        {

        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Kitap(barkodno,kitapadi,yazari,cevirmen,yayinevi,sayfasayisi,turu,stoksayisi,rafno,aciklama,kayittarihi) values(@barkodno,@kitapadi,@yazari,@cevirmen,@yayinevi,@sayfasayisi,@turu,@stoksayisi,@rafno,@aciklama,@kayittarihi)", baglanti); // @ = new

            komut.Parameters.AddWithValue("@barkodno",txtBarkodNo .Text);
            komut.Parameters.AddWithValue("@kitapadi",txtKitapAdi.Text);
            komut.Parameters.AddWithValue("@yazari", txtYazari .Text);
            komut.Parameters.AddWithValue("@cevirmen", txtCevirmen.Text);
            komut.Parameters.AddWithValue("@yayinevi",txtYayinevi .Text);
            komut.Parameters.AddWithValue("@sayfasayisi", txtSayfaSayisi.Text);
            komut.Parameters.AddWithValue("@turu", comboTuru.Text);
            komut.Parameters.AddWithValue("@stoksayisi",txtStokSayisi .Text);
            komut.Parameters.AddWithValue("@rafno",txtRafNo .Text);
            komut.Parameters.AddWithValue("@aciklama",txtAciklama .Text);
            komut.Parameters.AddWithValue("@kayittarihi",DateTime.Now.ToShortDateString());
            

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yeni kitap kaydı yapıldı.");
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                      item.Text = " ";
                    
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
