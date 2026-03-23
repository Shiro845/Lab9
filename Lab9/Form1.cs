namespace Lab9
{
    public partial class Form1 : Form
    {
        long number;


        bool IsLeapYear(long year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
        private void buttonCalibration()
        {
            label1.Location = new Point((Width/2) - label1.Width / 2, 150);
        }

        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            label1.AutoSize = true;
            buttonCalibration();
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
            buttonCalibration();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
