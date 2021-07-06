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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection(DB.connectionstr);


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (listBox1.Text == "users")
            {
                add_new_users t1 = new add_new_users();
                t1.Show();
            }
            if (listBox1.Text == "расписание")
            {
                school_timetable_add t1 = new school_timetable_add();
                t1.Show();
            }

        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.Text == "users")
            {
                buttonDelete.Enabled = true;
                buttonAdd.Enabled = true;
                buttonEdit.Enabled = false;
            }
            if (listBox1.Text == "расписание")
            {
                buttonDelete.Enabled = true;
                buttonAdd.Enabled = true;
                buttonEdit.Enabled = true;
            }

                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM `"+listBox1.Text+"`;";
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string sql = "SELECT * FROM `logs`;";
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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int p = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString());
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int p = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString());
            string sql = "set sql_safe_updates=0; delete from `" + listBox1.SelectedItem.ToString() + "` where `" + dataGridView1.Columns[0].HeaderText.ToString() + "`='" + dataGridView1.Rows[p].Cells[0].Value.ToString() + "';";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            MySqlConnection connection1 = new MySqlConnection(DB.connectionstr);
            string sql1 = "SELECT * FROM `" + listBox1.SelectedItem.ToString() + "`;";
            connection.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql1, connection1);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();

        }
        int test;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
                test = dataGridView1.SelectedCells[0].RowIndex + 1;          
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
