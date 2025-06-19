using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Nclear1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string targetPath = @"C:\Nursultan";

            if (!Directory.Exists(targetPath))
            {
                MessageBox.Show("Папка не найдена: " + targetPath);
                return;
            }

            string[] files = Directory.GetFiles(targetPath, "*", SearchOption.AllDirectories);
            progressBar1.Value = 0;
            progressBar1.Maximum = files.Length;

            foreach (string file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch { }

                progressBar1.Value++;
                await Task.Delay(5); // для визуального прогресса
            }

            try
            {
                Directory.Delete(targetPath, true);
            }
            catch { }

            MessageBox.Show("Готово. Всё удалено.");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
