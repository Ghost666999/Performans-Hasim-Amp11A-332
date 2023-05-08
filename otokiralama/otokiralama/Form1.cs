using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace otokiralama
{
    public partial class Form1 : Form
    {
        
        
        void listele()
        {
            
            SQLiteConnection baglantı = new SQLiteConnection("Data Source=C:\\Users\\hasim\\OneDrive\\Masaüstü\\projelerim\\sql.db;version=3");
            baglantı.Open();
            SQLiteDataAdapter adaptor = new SQLiteDataAdapter("SELECT * FROM OTOKIRALAMA",baglantı);
            DataSet ds= new DataSet();
            adaptor.Fill(ds, "OTOKIRALAMA");
            dataGridView1.DataSource = ds.Tables["OTOKIRALAMA"];
            baglantı.Close();
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection baglanti = new SQLiteConnection("Data Source=C:\\Users\\hasim\\OneDrive\\Masaüstü\\projelerim\\sql.db;version=3");
            baglanti.Open();
            SQLiteCommand komut = new SQLiteCommand();
            komut.Connection = baglanti;
            komut.CommandText = "INSERT INTO OTOKIRALAMA VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteConnection baglantı = new SQLiteConnection("Data Source=C:\\Users\\hasim\\OneDrive\\Masaüstü\\projelerim\\sql.db;version=3");
            baglantı.Open();
            SQLiteCommand komut = new SQLiteCommand();
            komut.Connection = baglantı;
            komut.CommandText = "UPDATE OTOKIRALAMA SET AdSoyad='" + textBox2.Text + "',AlınanAraclar='" + textBox3.Text + "'WHERE İD='" + textBox1.Text + "'";
            komut.ExecuteNonQuery();
            listele();
            baglantı.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglantı = new SQLiteConnection("Data Source=C:\\Users\\hasim\\OneDrive\\Masaüstü\\projelerim\\sql.db;version=3");
                baglantı.Open();
                SQLiteCommand kaydet = new SQLiteCommand();
                kaydet.Connection = baglantı;
                kaydet.CommandText = "DELETE FROM OTOKIRALAMA WHERE İD='" + textBox1.Text + "'";
                kaydet.ExecuteNonQuery();
                listele();
                baglantı.Close();
            }
            catch
            {
                MessageBox.Show("Kayıt Silinmedi....");
            }
            finally
            {
                textBox1.Text = "";
            }
        }
        
    }
}
