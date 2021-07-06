using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Клиентское
{
    public partial class school_timetable_add : Form
    {
        public school_timetable_add()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection(DB.connectionstr);
        int Day_of_the_week, subject_id;

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Понедельник")
                Day_of_the_week = 1;
            if (comboBox1.Text == "Вторник")
                Day_of_the_week = 2;
            if (comboBox1.Text == "Среда")
                Day_of_the_week = 3;
            if (comboBox1.Text == "Четверг")
                Day_of_the_week = 4;
            if (comboBox1.Text == "Пятница")
                Day_of_the_week = 5;
            if (comboBox1.Text == "Суббота")
                Day_of_the_week = 6;

            if (comboBox4.Text == "Физика")
                subject_id = 1;
            if (comboBox4.Text == "Русский язык")
                subject_id = 2;
            if (comboBox4.Text == "Математика")
                subject_id = 3;
            if (comboBox4.Text == "Иностранный язык")
                subject_id = 4;
            if (comboBox4.Text == "Информатика")
                subject_id = 5;
            if (comboBox4.Text == "Химия")
                subject_id = 6;
            if (comboBox4.Text == "Биология")
                subject_id = 7;
            if (comboBox4.Text == "География")
                subject_id = 8;

            connection.Open();
            string sql = "insert into расписание (`Номер дня недели`,`Номер урока`,`Код класса`,`Код предмета`, `Номер кабинета`) value(" + Day_of_the_week+"," +comboBox2.Text+ "," +comboBox3.Text+ "," +subject_id+ ","+comboBox5.Text+");";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            connection.Close();
            try
            {
                label1.Text = "Статус: УСПЕШНО";
                label1.ForeColor = Color.Green;
            }
            catch (MySqlException ex)
            {
                label1.Text = "Статус: ОШИБКА";
                label1.ForeColor = Color.Red;
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
