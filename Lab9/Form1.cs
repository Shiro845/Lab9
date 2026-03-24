using System.Text.Json;
using System.IO;

namespace Lab9
{
    public partial class Form1 : Form
    {
        long number;

        bool IsLeapYear(long year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
        private void LabelCalibration()
        {
            label1.Location = new Point((Width / 2) - label1.Width / 2, 150);
        }

        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            label1.AutoSize = true;
            listBox1.Hide();
            LabelCalibration();
            label1.TextAlign = ContentAlignment.MiddleCenter;
            textBox1.Location = new Point(Width / 2 - textBox1.Width / 2, 225);
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (long.MaxValue > Convert.ToInt64(textBox1.Text)) { number = long.Parse(textBox1.Text); }
                label1.Text = $"Введений рік:\n{number}\n";
                if (IsLeapYear(number)) { label1.Text += "Високосний\nрік!"; }
                else { label1.Text += "Не високосний\nрік!"; }
            }
            catch (FormatException)
            {
                label1.Text = "Некоректний\nввід!";
                return;
            }
            catch (OverflowException)
            {
                label1.Text = "Число занадто\nвелике!";
                return;
            }
            label1.Refresh();
            LabelCalibration();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string directorypath = System.AppDomain.CurrentDomain.BaseDirectory;
            string jsonText = File.ReadAllText($"{directorypath}\\Years.json");
            List<int> years = JsonSerializer.Deserialize<List<int>>(jsonText);
            if (!checkBox1.Checked)
            {
                textBox1.Text = "";
                textBox1.Hide();
                label1.Text = "Зчитано з файлу:";
                LabelCalibration();
                foreach (int year in years) 
                {
                    if (IsLeapYear(year))
                    {
                        listBox1.Items.Add($"{year}: Високосний рік!\n");
                    }
                    else
                    {
                        listBox1.Items.Add($"{year}: Не високосний рік!\n");
                    }
                }
                listBox1.Show();
            }
            else
            {
                listBox1.Items.Clear();
                listBox1.Hide();
                textBox1.Show();
                label1.Text = "Введіть рік:";
                LabelCalibration();
            }
        }
    }
}
