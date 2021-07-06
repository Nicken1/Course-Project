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
    public partial class FormSchoolboy : Form
    {
        public FormSchoolboy()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection(DB.connectionstr);
        private void buttonProfile_Click(object sender, EventArgs e)
        {
            InfoSchoolboy t1 = new InfoSchoolboy();
            t1.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            StartMenu t3 = new StartMenu();
            t3.Show();
            this.Close();
        }

        private void buttonGradebook_Click(object sender, EventArgs e)
        {

            string global_log = login.global_log;
            connection.Open();
            string sql = "select users.idusers from users where users.login ='" + global_log + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            object r = command.ExecuteScalar();
            string cmd = $"SELECT a.`Код Класса`, b.`Фамилия`, a.`Четверть`,a.`Оценка по Русскому языку`,a.`Оценка по Математике`,a.`Оценка по Физике`,a.`Оценка по Химии`,a.`Оценка по Биологии`,a.`Оценка по Информатике`,a.`Оценка по Географии`,a.`Оценка по Иностранному языку` FROM `users` c, `итоговые оценки` a, `ученики` b WHERE a.`Код ученика`=b.`Код ученика` and b.userID = c.idusers and a.`Код ученика` = b.`Код ученика` and b.userID = {r}";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();

            //connection.Open();
            //string sql = "SELECT a.`Код Класса`, b.`Фамилия`, a.`Четверть`,a.`Оценка по Русскому языку`,a.`Оценка по Математике`,a.`Оценка по Физике`,a.`Оценка по Химии`,a.`Оценка по Биологии`,a.`Оценка по Информатике`,a.`Оценка по Географии`,a.`Оценка по Иностранному языку`  FROM `итоговые оценки` a, `ученики` b where a.`Код ученика`=b.`Код ученика` and a.`Код класса` = " + IDclass + ";";
            //MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
            //connection.Close();
        }

        private void buttonTimetable_Click(object sender, EventArgs e)
        {
            string global_log = login.global_log;
            connection.Open();
            string sql = "select users.idusers from users where users.login ='" + global_log + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            object r = command.ExecuteScalar();
            string cmd = $"SELECT b.`День недели`, a.`Номер урока`, c.`Название`, d.`Время начала`, d.`Время окончания`, a.`Номер кабинета` FROM `ученики` f , `период проведения урока` d , `предмет` c, `расписание` a, `день недели` b, `users` e WHERE a.`Номер урока` = d.`Номер урока` and a.`Номер дня недели`=b.`Номер дня недели` and f.`Код класса` = a.`Код класса` and c.`Код предмета` = a.`Код предмета` and f.userID = e.idusers and f.userID = {r};";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void buttonEvents_Click(object sender, EventArgs e)
        {
            string global_log = login.global_log;
            connection.Open();
            string sql = "select users.idusers from users where users.login ='" + global_log + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            object r = command.ExecuteScalar();
            string cmd = $"SELECT a.`Название`, a.`Время` ,a.`День недели` FROM `кружки` a, `ученики` b, `users` c  WHERE a.`Код кружка` = b.`Код кружка` and b.userID = c.idusers and b.userID = {r};";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void FormSchoolboy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
