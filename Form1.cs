using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            db db = new db();
            DataTable table = new DataTable();


            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            //проверка на наличие данных
            if (table.Rows.Count > 0)
            {
                //проверка на администратора
                if (login == "Serega" && password == "321" || login== "DanilLange" && password == "123")
                {
                    
                    MessageBox.Show("Добро пожаловать " + login);
                    
                }
  

            }
            else
                MessageBox.Show("Такой пользователь не найден в системе");


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
