using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Soru2
{
    public partial class KayitliKullanıcı : Form
    {
        public KayitliKullanıcı()
        {
            InitializeComponent();
        }
        string email = string.Empty;
        string sifre = string.Empty;
        string girilenSifre = string.Empty;
        string girilenMail = string.Empty;

        private void KayitliKullanıcı_Load(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Kullanıcı));
            FileStream fs = new FileStream("Kullanıcı.xml", FileMode.Open);//kullanıcı bilgilerini almak için ilgili xm dosyası okunur
            Kullanıcı kullanıcı = serializer.Deserialize(fs)as Kullanıcı;
            email = kullanıcı.Email;//gelen mail bilgisi değişkene atılır
            sifre = kullanıcı.Sifre.ToString();//gelen şifre bilgisi değişkene atılır
            MessageBox.Show(email+" "+sifre);
            fs.Close();
        }
        
        private void btnEntry_Click(object sender, EventArgs e)
        {
            girilenMail = txtEmail.Text;
            girilenSifre = txtSifre.Text;

            if (email==girilenMail)//şifre ve mail doğru girilirse Menu Formu açılır
            {
                if (girilenSifre==sifre)
                {
                    Menu menu = new Menu();
                    menu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Şifre yanlış");
                }
            }
            else
            {
                MessageBox.Show("Mail adresi yanlış");
            }
        }
    }
}
