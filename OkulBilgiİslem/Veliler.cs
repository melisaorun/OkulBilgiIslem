using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OkulBilgiİslem
{
    public partial class Veliler : Form
    {
        public Veliler()
        {
            InitializeComponent();
        }
        Model1Container db = new Model1Container();
        private void button6_Click(object sender, EventArgs e)
        {
            Anasayfa go = new Anasayfa();
            go.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Veli save = new Veli();
            save.VeliAdiSoyadi = textBox1.Text;
            save.Yakinlik = textBox2.Text;
            save.Adres = textBox3.Text;
            save.Telefon = textBox4.Text;
            save.EgitimDurumu = comboBox1.Text;
            db.VeliSet.Add(save);
            db.SaveChanges();
            dataGridView1.DataSource = db.VeliSet.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            var sil = db.VeliSet.Where(x => x.VeliNo == id).FirstOrDefault();
            db.VeliSet.Remove(sil);
            db.SaveChanges();
            dataGridView1.DataSource = db.OgrenciSet.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            var güncelle = db.VeliSet.Where(x => x.VeliNo == id).FirstOrDefault();
            güncelle.VeliAdiSoyadi = textBox1.Text;
            güncelle.Yakinlik = textBox2.Text;
            güncelle.Adres = textBox3.Text;
            güncelle.Telefon = textBox4.Text;
            güncelle.EgitimDurumu = comboBox1.Text;
            db.SaveChanges();
            dataGridView1.DataSource = db.VeliSet.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.VeliSet.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.VeliSet.Where(X => X.VeliAdiSoyadi.Contains(textBox6.Text)).ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells["VeliNo"].Value.ToString();
            textBox1.Text = row.Cells["VeliAdiSoyadi"].Value.ToString();
            textBox2.Text = row.Cells["Yakinlik"].Value.ToString();
            textBox3.Text = row.Cells["Adres"].Value.ToString();
            textBox4.Text = row.Cells["Telefon"].Value.ToString();
            comboBox1.Text = row.Cells["EgitimDurumu"].Value.ToString();
            
        }
    }
}
