using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Аеропорт
{
    
    public partial class Form13 : Form
    {
        public static string connectString = "Provider=ADsDSOObject; Data Source=Аеропорт.mdf;";
        private OleDbConnection myConnection;
        public Form13()
        {
            InitializeComponent();
            // создаем экземпляр класса OleDbConnection
            myConnection = new OleDbConnection(connectString);

            // открываем соединение с БД
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // текст запроса

            string query = textBox1.Text.ToString();

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);

            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();

            // очищаем listBox1
            listBox1.Items.Clear();

            // в цикле построчно читаем ответ от БД
            while (reader.Read())
            {

                listBox1.Items.Add(reader[0].ToString() + "  " + reader[1].ToString() + "  " + reader[2].ToString() + "  ");

            }
            try
            {
                this.Validate();
                MessageBox.Show("Виконано запит");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Помилка запиту");
            }
            // закрываем OleDbDataReader
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // текст запроса

            string query = "SELECT * From Країна";

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);

            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();

            // очищаем listBox1
            listBox1.Items.Clear();

            // в цикле построчно читаем ответ от БД
            while (reader.Read())
            {
                // выводим данные столбцов текущей строки в listBox1
                listBox1.Items.Add(reader[0].ToString() + " | " + reader[1].ToString() + " | ");
            }
            try
            {
                this.Validate();
                MessageBox.Show("Виконано запит");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Помилка запиту");
            }
            // закрываем OleDbDataReader
            reader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form13_FormClosing(object sender, FormClosingEventArgs e)
        {
            // заркываем соединение с БД
            myConnection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            // текст запроса

            string query = "SELECT * from Посади";

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);

            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();

            // очищаем listBox1
            listBox1.Items.Clear();

            // в цикле построчно читаем ответ от БД
            while (reader.Read())
            {
                // выводим данные столбцов текущей строки в listBox1
                listBox1.Items.Add("  " + reader[0].ToString() + " | " + reader[1].ToString() + " | " + reader[2].ToString() + " | " + reader[3].ToString());
            }
            try
            {
                this.Validate();
                MessageBox.Show("Виконано запит");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Помилка запиту");
            }
        }
        }
}
