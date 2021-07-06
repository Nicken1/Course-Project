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
    public partial class add_new_users : Form
    {

        public add_new_users()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection(DB.connectionstr);
        int access;

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand hash = new MySqlCommand("call school.hashPass(" + textBox2.Text + ")", connection);
            object hashedPass = hash.ExecuteScalar();
            string sql = @"insert into users (idusers,login,password, access) value(NULL,'" + textBox1.Text + "','"+hashedPass.ToString()+"'," + access + ");";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            connection.Close();

            try
            {
                label4.Text = "Статус: УСПЕШНО";
                label4.ForeColor = Color.Green;
            }
            catch (MySqlException ex)
            {
                label4.Text = "Статус: ОШИБКА";
                label4.ForeColor = Color.Red;
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Учитель")
            {
                try
                {
                    access = 1;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (comboBox1.Text == "Ученик")
            {
                try
                {
                    access = 2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (comboBox1.Text == "Админ")
            {
                try
                {
                    access = 3;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
