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
    public partial class Ogrenciler : Form
    {
        public Ogrenciler()
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
            Ogrenci save = new Ogrenci();
            save.VeliNo=Convert.ToInt32(textBox3.Text);
            save.OgrenciAdiSoyadi = textBox1.Text;
            save.Sinifi= textBox2.Text;
            save.Bolumu = comboBox1.Text;
            save.Adresi= textBox4.Text;
            save.Telefon = textBox5.Text;
            save.OkulNo = textBox7.Text;
            db.OgrenciSet.Add(save);
            db.SaveChanges();
            dataGridView1.DataSource = db.OgrenciSet.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            var sil = db.OgrenciSet.Where(x => x.OgrenciNo == id).FirstOrDefault();
            db.OgrenciSet.Remove(sil);
            db.SaveChanges();
            dataGridView1.DataSource = db.OgrenciSet.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            var güncelle = db.OgrenciSet.Where(x => x.OgrenciNo == id).FirstOrDefault();
            güncelle.OgrenciAdiSoyadi = textBox1.Text;
            güncelle.Sinifi = textBox2.Text;
            güncelle.Bolumu = comboBox1.Text;
            güncelle.Adresi = textBox4.Text;
            güncelle.Telefon = textBox5.Text;
            güncelle.OkulNo = textBox7.Text;
            db.SaveChanges();
            dataGridView1.DataSource = db.OgrenciSet.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.OgrenciSet.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=db.OgrenciSet.Where(X=>X.OkulNo.Contains(textBox6.Text)).ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells["OgrenciNo"].Value.ToString();
            textBox1.Text = row.Cells["OgrenciAdiSoyadi"].Value.ToString();
            textBox2.Text = row.Cells["Sinifi"].Value.ToString();
            comboBox1.Text = row.Cells["Bolumu"].Value.ToString();
            textBox4.Text = row.Cells["Adresi"].Value.ToString();
            textBox5.Text = row.Cells["Telefon"].Value.ToString();
            textBox7.Text = row.Cells["OkulNo"].Value.ToString();
        }
    }
}
