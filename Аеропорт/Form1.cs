using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Аеропорт
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin")
            {
                if (textBox2.Text == "122334")
                {
                    this.Hide();
                    MessageBox.Show("Авторизація успішна!");
                    Form2 f2 = new Form2();
                    f2.ShowDialog();

                }

            }
            else

                MessageBox.Show("Неправильний логін або пароль!!!");
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
