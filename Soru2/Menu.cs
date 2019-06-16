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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);// transparan arkaplan desteklemesi 
        }
        KnownColor c;
        private void Menu_Load(object sender, EventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(renk));
            FileStream fs = new FileStream("Renk.xml", FileMode.Open);//daha önce kaydedilen renk değeri ilgili dosyadan okunur
            renk k = xs.Deserialize(fs) as renk;
            fs.Close();
            string renk = k.FormRengi;
            RenkCalistir(renk);

            KnownColor[] tipler = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            for (int i = 0; i < tipler.Count(); i++)//KnownColor içindeki renkler combo boxa eklenir
            {
                c = (KnownColor)Enum.Parse(typeof(KnownColor), tipler[i].ToString());
                comboBox1.Items.Add(c);
            }           
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string renk = comboBox1.SelectedItem.ToString();
            RenkCalistir(renk);
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(renk));
            FileStream fs = new FileStream("Renk.xml", FileMode.Create);//seçilen renk xml dosyasına kaydedilir
            renk k = new renk(c.ToString());
            serializer.Serialize(fs, k);
            fs.Close();
            MessageBox.Show("Ayarlar Kaydediliyor");
        }

        private void RenkCalistir(string renk)//combo boxtan seçilen renk arkaplan olarak ayarlanır
        {
            c = (KnownColor)Enum.Parse(typeof(KnownColor), renk);
            this.BackColor = Color.FromKnownColor(c);
        }
    }
}
