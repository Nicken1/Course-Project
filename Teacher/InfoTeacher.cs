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

namespace Клиентское
{
    public partial class InfoTeacher : Form
    {
        public InfoTeacher()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection(DB.connectionstr);
        MySqlDataReader dataReader;

        private void textBoxLog_TextChanged(object sender, EventArgs e)
        {

        }
        private void InfoTeacher_Load(object sender, EventArgs e)
        {
            string global_log = login.global_log;
            connection.Open();
            string sql = "select users.idusers from users where users.login ='" + global_log + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            object r = command.ExecuteScalar();
            MySqlCommand cmd = new MySqlCommand($"SELECT users.login, `Фамилия`, `Имя`, `Отчество`, `Телефон`, `Дата рождения`, `Адрес`,userID " +
                $"FROM users, `учителя` WHERE `учителя`.userID = `users`.idusers and `учителя`.userID = {r}", connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read() == true)
            {

                textBoxLog.Text = dataReader.GetValue(0).ToString();
                textBoxSurname.Text = dataReader.GetValue(1).ToString();
                textBoxName.Text = dataReader.GetValue(2).ToString();
                textBoxPatronymic.Text = dataReader.GetValue(3).ToString();
                textBoxPhone.Text = dataReader.GetValue(4).ToString();
                textBoxDOB.Text = dataReader.GetValue(5).ToString();
                textBoxAddress.Text = dataReader.GetValue(6).ToString();
                textBoxID.Text = dataReader.GetValue(7).ToString();
            }
            dataReader.Close();
            connection.Close();
        }
    }
}
