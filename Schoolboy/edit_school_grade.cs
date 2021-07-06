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
    public partial class edit_school_grade : Form
    {
        public edit_school_grade()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection(DB.connectionstr);
        MySqlDataReader dataReader;
        internal string selectedLogin;

        private void edit_school_grade_Load(object sender, EventArgs e)
        {
            string global_log = login.global_log;
            connection.Open();
            string sql = "select users.idusers from users where users.login ='" + global_log + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            object r = command.ExecuteScalar();
            MySqlCommand cmd = new MySqlCommand($"SELECT `ученики`.`Фамилия`, `Оценка по Русскому`, `Оценка по Математике`, `Оценка по Физике`, `Оценка по Химии`, `Оценка по Биологии`, `Оценка по Информатике`, `Оценка по Географии`,`Оценка по Иностранному языку`" +
                $"FROM users, `ученики`, `итоговые оценки` WHERE  `итоговые оценки`.`Код ученика` = `ученики`.`Код ученика` and {selectedLogin} = `ученики`.`Код ученика`", connection);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read() == true)
            {
                textbox_surname.Text = dataReader.GetValue(0).ToString();
                textbox_ru.Text = dataReader.GetFloat(1).ToString();
                textbox_math.Text = dataReader.GetFloat(2).ToString();
                textbox_ph.Text = dataReader.GetFloat(3).ToString();
                textbox_ch.Text = dataReader.GetFloat(4).ToString();
                textbox_bi.Text = dataReader.GetFloat(5).ToString();
                textbox_inf.Text = dataReader.GetFloat(6).ToString();
                textbox_ge.Text = dataReader.GetFloat(7).ToString();
                textbox_en.Text = dataReader.GetFloat(8).ToString();
            }
            dataReader.Close();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string ru = textbox_ru.Text;
            string math = textbox_math.Text;
            string ph = textbox_ph.Text;
            string ch = textbox_ch.Text;
            string bi = textbox_bi.Text;
            string inf = textbox_inf.Text;
            string ge = textbox_ge.Text;
            string en = textbox_en.Text;

            int test = Convert.ToInt32(selectedLogin);
            labelStat.Text = test.ToString();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand($"set sql_safe_updates=0; UPDATE `итоговые оценки` SET `Оценка по Русскому` = {ru},`Оценка по Математике` = {math},`Оценка по Физике` = {ph}, `Оценка по Химии`= {ch}, `Оценка по Биологии` = {bi}, `Оценка по Информатике` = {inf}, `Оценка по Географии` = {ge}, `Оценка по Иностранному языку` = {en} Where `Код ученика` = {selectedLogin}",connection);
            try
            {
                dataReader = cmd.ExecuteReader();
                dataReader.Close();
                labelStat.Text = "Статус: УСПЕШНО";
                labelStat.ForeColor = Color.Green;
            }
            catch(MySqlException ex)
            {
                labelStat.Text = "Статус: ОШИБКА";
                labelStat.ForeColor = Color.Red;
                MessageBox.Show(ex.ToString());
            }
            connection.Close();
        }

        private void textbox_en_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


//MySqlCommand cmd = new MySqlCommand($"UPDATE `итоговые оценки` SET" +
//    $"`Оценка по Русскому языку` = `{textbox_ru.Text}`, " +
//    $"`Оценка по Математике` = `{textbox_math.Text}`, " +
//    $"`Оценка по Физике` = `{textbox_ph.Text}`, " +
//    $"`Оценка по Химии`= `{textbox_ch.Text}`, " +
//    $"`Оценка по Биологии` = `{textbox_bi.Text}`, " +
//    $"`Оценка по Информатике` = `{textbox_inf.Text}`, " +
//    $"`Оценка по Географии` = `{textbox_ge.Text}`, " +
//    $"`Оценка по Иностранному языку` = `{textbox_en.Text}`" +
//    $"Where `итоговые оценки`.`Код ученика` = `{test}`", connection);