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
    public partial class FormTeacher : Form
    {
        public FormTeacher()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection(DB.connectionstr);
        string selectedLogin;
        

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            InfoTeacher t1 = new InfoTeacher();
            t1.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            StartMenu t3 = new StartMenu();
            t3.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Оценки")
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                this.comboBox1.Size = new System.Drawing.Size(599, 21);
                this.label2.Location = new Point(264, 20);
                textBox1.Visible = false;
                label1.Visible = false;
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM `итоговые оценки`;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (comboBox1.Text == "Ученики")
            {
                this.comboBox1.Size = new System.Drawing.Size(424, 21);
                this.label2.Location = new Point(128, 20);
                textBox1.Visible = true;
                label1.Visible = true;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM `Ученики`;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            if (comboBox1.Text == "Информация о родителях")
            {
                textBox1.Visible = true;
                label1.Visible = true;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                this.comboBox1.Size = new System.Drawing.Size(424, 21);
                this.label2.Location = new Point(128, 20);
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM `информация о родителях`;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (comboBox1.Text == "Расписание")
            {
                textBox1.Visible = false;
                label1.Visible = false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                this.comboBox1.Size = new System.Drawing.Size(599, 21);
                this.label2.Location = new Point(264, 20);
                try
                {
                    connection.Open();
                    string sql = "SELECT b.`День недели`, a.`Номер урока`,a.`Код класса`,a.`Код предмета`,a.`Номер кабинета` FROM `расписание` a,`день недели` b where a.`Номер дня недели` = b.`Номер дня недели`";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            for (int j=0; j<dataGridView1.Columns.Count; j++)
            {
                comboBox5.Items.Add(dataGridView1.Columns[j].HeaderText);
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
            label4.Visible = true;
            string IDclass = comboBox2.Text;
            if (checkBox1.Checked)
            {


                try
                {
                    connection.Open();
                    string sql = "SELECT a.`Код Класса`, b.`Фамилия`, a.`Четверть`,a.`Оценка по Русскому`,a.`Оценка по Математике`,a.`Оценка по Физике`,a.`Оценка по Химии`,a.`Оценка по Биологии`,a.`Оценка по Информатике`,a.`Оценка по Географии`,a.`Оценка по Иностранному языку`  FROM `итоговые оценки` a, `ученики` b where a.`Код ученика`=b.`Код ученика` and a.`Код класса` = " + IDclass + ";";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {

                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM `итоговые оценки` where `Код класса` = " + IDclass + ";";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IDclass = comboBox2.Text;
            string IDpart = comboBox3.Text;
            try
            {
                connection.Open();
                string sql = "SELECT * FROM `итоговые оценки` where `Код класса` = "+IDclass+" and `Четверть` = "+IDpart+";";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void FormTeacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Ученики")
            {
                string sql = "Select* From `ученики` where `"+comboBox5.SelectedItem.ToString()+"` like '"+textBox1.Text+"%';";
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.ClearSelection();
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                connection.Close();
            }
            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    dataGridView1.Rows[i].Selected = false;
            //    for (int j = 0; j < dataGridView1.ColumnCount; j++)
            //        if (dataGridView1.Rows[i].Cells[j].Value != null)
            //            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
            //            {
            //                dataGridView1.Rows[i].Selected = true;
            //                break;
            //            }

            //}
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IDclass = comboBox4.Text;
            if (checkBox3.Checked)
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT c.`День недели`, b.`Номер урока`,b.`Код класса`,a.`Название`,b.`Номер кабинета` FROM `день недели` c, `предмет` a, `расписание` b where c.`Номер дня недели` = b.`Номер дня недели` and a.`Код предмета`=b.`Код предмета` and b.`Код класса` = " + IDclass + ";";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT b.`День недели`, a.`Номер урока`,a.`Код класса`,a.`Код предмета`,a.`Номер кабинета` FROM `расписание` a,`день недели` b  where a.`Номер дня недели` = b.`Номер дня недели` and `Код класса` = " + IDclass + ";";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedLogin != null)
            {
                edit_school_grade t1 = new edit_school_grade();
                t1.selectedLogin = selectedLogin;
                t1.Show();
            }
            else
                MessageBox.Show("Выберите ученика");
           
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            selectedLogin = Convert.ToString(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Оценки")
            {
                int i = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString());
                string sql = "set sql_safe_updates=0; UPDATE `итоговые оценки` SET " + dataGridView1.Columns[Convert.ToInt32(dataGridView1.CurrentCell.ColumnIndex.ToString())].HeaderText.ToString() + "= '" + dataGridView1.CurrentCell.Value.ToString() + "' where " + dataGridView1.Columns[0].HeaderText.ToString() + "='" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "';";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
//for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
//    for (int j = 0; j <= dataGridView1.ColumnCount - 1; j++)
//        if (dataGridView1.Rows[i].Cells[j].Value != null && dataGridView1.Rows[i].Cells[j].Value.ToString() == textBox1.Text)
//            dataGridView1.Rows[i].Cells[j].Selected = true;



