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
    public partial class YeniKayıt : Form
    {
        public YeniKayıt()
        {
            InitializeComponent();
        }
        object sifre = string.Empty;
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtAd.Text)&& string.IsNullOrEmpty(txtSoyad.Text)&& string.IsNullOrEmpty(txtEmail.Text)&& string.IsNullOrEmpty(txtSifre.Text)))//İlgili alanlar boş geçilmişmi ona bakılır
            {
                if (txtSifre.Text == txtSifreTekrar.Text)
                {
                    sifre = txtSifre.Text;
                    XmlSerializer serializer = new XmlSerializer(typeof(Kullanıcı));//kullanıcı tipinde serileştirme yapılır
                    FileStream fs = new FileStream("Kullanıcı.xml", FileMode.Create);//xml dosyası oluşturulur
                    Kullanıcı kullanıcı = new Kullanıcı(txtAd.Text, txtSoyad.Text, datetimePicker.Value, txtEmail.Text, sifre);//girilen değerler kullanıcı tipine aktarılır 
                    serializer.Serialize(fs, kullanıcı);//serileştirme yapılır
                    fs.Close();
                    MessageBox.Show("Kayıt Başarıyla Gerçekleştirildi..");
                }
                else
                {
                    MessageBox.Show("Girilen şifreler aynı olmalıdır");
                }
            }
            else
            {
                MessageBox.Show("lüften tüm alanları doldurunuz");
                return;
            }       
         }
    }
}
