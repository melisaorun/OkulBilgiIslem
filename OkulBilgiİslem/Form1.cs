using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulBilgiİslem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Model1Container db=new Model1Container();

        public bool Giris(string kadi,string sifre)
        {
            var login = from Kullanici in db.KullaniciSet where Kullanici.KullaniciAdi == kadi && Kullanici.Sifre == sifre select Kullanici;

            if(login.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(Giris(textBox1.Text,textBox2.Text))
            {
                Anasayfa go=new Anasayfa();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("GİRİS BASARISIZ");
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
