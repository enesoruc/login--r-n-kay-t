using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soru1
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
         
        }
        int fiyat = 0;
        List<Urun> urunler;
        Urun urun;
       
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUrunAd.Text) && !string.IsNullOrWhiteSpace(txtUrunFiyat.Text))
            {
                fiyat = int.Parse(txtUrunFiyat.Text);
                if (txtUrunAd.Text.Length >= 5)
                {
                    if (fiyat >= 3)
                    {
                        Urun.GetInstance(txtUrunAd.Text, cmbRenkler.SelectedItem.ToString(),fiyat);
                        urunler.Add(urun);
                    }
                    else
                    {
                        MessageBox.Show("fiyat 3 tlden az olamaz");
                    }
                }
                else
                {
                    MessageBox.Show("ürün adı en az 5 en fazla 20 karakterden oluşabilir");
                }
            }
            else
            {
                MessageBox.Show("lütfen tüm alanları doldurunuz");
            }
        }

        private void txtUrunFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtUrunAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            urunler = new List<Urun>();
            Renkler[] renkler = (Renkler[])Enum.GetValues(typeof(Renkler));
            foreach (Renkler item in renkler)
            {
                cmbRenkler.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Urun item in urunler)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
