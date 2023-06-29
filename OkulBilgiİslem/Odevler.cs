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
    public partial class Odevler : Form
    {
        public Odevler()
        {
            InitializeComponent();
        }
        Model1Container db = new Model1Container();

        private void button1_Click(object sender, EventArgs e)
        {
            Odev save = new Odev();
            save.OgrenciNo=Convert.ToInt32(textBox3.Text);
            save.OgrenciAdiSoyadi = textBox1.Text;
            save.Sinifi = textBox2.Text;
            save.Bolumu = comboBox1.Text;
            save.Ders = comboBox2.Text;
            save.Konu = textBox5.Text;
            save.VerilisTarihi = dateTimePicker1.Text; 
            save.TeslimTarihi = dateTimePicker2.Text;
            save.Notu = textBox8.Text;
            db.OdevSet.Add(save);
            db.SaveChanges();
            dataGridView1.DataSource = db.OdevSet.ToList(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Anasayfa go = new Anasayfa();
            go.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            var sil = db.OdevSet.Where(x => x.OdevNo == id).FirstOrDefault();
            db.OdevSet.Remove(sil);
            db.SaveChanges();
            dataGridView1.DataSource = db.OdevSet.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            var güncelle = db.OdevSet.Where(x => x.OdevNo == id).FirstOrDefault();
            güncelle.OgrenciAdiSoyadi = textBox1.Text;
            güncelle.Sinifi = textBox2.Text;
            güncelle.Bolumu = comboBox1.Text;
            güncelle.Ders = comboBox2.Text;
            güncelle.Konu = textBox5.Text;
            güncelle.VerilisTarihi = dateTimePicker1.Text;
            güncelle.TeslimTarihi = dateTimePicker2.Text;
            güncelle.Notu = textBox8.Text;
            db.SaveChanges();
            dataGridView1.DataSource = db.OdevSet.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.OdevSet.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.OdevSet.Where(X => X.OgrenciAdiSoyadi.Contains(textBox9.Text)).ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Tag = row.Cells["OdevNo"].Value.ToString();
            textBox1.Text = row.Cells["OgrenciAdiSoyadi"].Value.ToString();
            textBox2.Text = row.Cells["Sinifi"].Value.ToString();
            comboBox1.Text = row.Cells["Bolumu"].Value.ToString();
            comboBox2.Text = row.Cells["Ders"].Value.ToString();
            textBox5.Text = row.Cells["Konu"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["VerilisTarihi"].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells["TeslimTarihi"].Value.ToString();
            textBox8.Text = row.Cells["Notu"].Value.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
