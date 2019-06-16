using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soru2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void yeniKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniKayıt yeniKayıt = new YeniKayıt();
            yeniKayıt.MdiParent = this;
            if (ActiveMdiChild != null)//aktif herhangi bir pencere varsa kapatılır
                ActiveMdiChild.Close();
            yeniKayıt.Show();

        }

        private void kayıtlıKullanıcıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KayitliKullanıcı kayitliKullanıcı = new KayitliKullanıcı();
            kayitliKullanıcı.MdiParent = this;
            if (ActiveMdiChild != null)//aktif herhangi bir pencere varsa kapatılır
                ActiveMdiChild.Close();
            kayitliKullanıcı.Show();
        }

        private void arkaplanRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.MdiParent = this;
            menu.Show();
        }
    }
}
