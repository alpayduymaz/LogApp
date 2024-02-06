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

namespace LogAppWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
        }
        private void SetupDataGridView()
        {
            // Sütunlar oluşturuluyor
            dataGridView1.Columns.Add("Tarih", "Tarih");
            dataGridView1.Columns.Add("Saat", "Saat");
            dataGridView1.Columns.Add("MakineAdi", "Makine Adı");
            dataGridView1.Columns.Add("KullaniciAdi", "Kullanıcı Adı");
        }

        private void LoadDataFromFile()
        {
            string programDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string veriketAppFolder = Path.Combine(programDataFolder, "VeriketApp");
            string filePath = Path.Combine(veriketAppFolder, "VeriketAppTest.txt");

            // Dosya var mı kontrol et
            if (File.Exists(filePath))
            {
                // Dosyayı satır satır oku ve DataGridView'e ekle
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Satırı boşluk karakterlerine göre ayır
                        string[] parts = line.Split(' ');

                        // DataGridView'e satır ekleniyor
                        dataGridView1.Rows.Add(parts);
                    }
                }
            }
            else
            {
                MessageBox.Show("Dosya bulunamadı!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tekrar tıklama durumunda verilerin mükerrer olmaması için
            dataGridView1.Rows.Clear();


            LoadDataFromFile();
        }
    }
}
