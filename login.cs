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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection(DB.connectionstr);
        MySqlDataReader dataReader;
        string log;
        public static string global_log;
        


        public void buttonLogin_Click(object sender, EventArgs e)
        {
            global_log = textBoxLogin.Text;
            connection.Open();

            MySqlCommand hash = new MySqlCommand("call school.hashPass(" + textBoxPassword.Text + ")", connection);
            object hashedPass = hash.ExecuteScalar();
            MySqlCommand cmd1 = new MySqlCommand(@"SELECT * FROM users WHERE login=@log AND password=@hashedPass", connection);

            log = textBoxLogin.Text;
            cmd1.Parameters.AddWithValue("@hashedPass", hashedPass);
            cmd1.Parameters.AddWithValue("@log", log);

            dataReader = cmd1.ExecuteReader();

            

            if (dataReader.Read() == true)
            {
                int sw = (int)dataReader["access"];
                dataReader.Close();
                switch (sw)
                {
                    case 1:
                        {
                            FormTeacher t1 = new FormTeacher();
                            t1.Show();
                            this.Hide();
                            break;
                        }
                    case 2:
                        {
                            FormSchoolboy t2 = new FormSchoolboy();
                            t2.Show();
                            this.Hide();
                            break;
                        }
                    case 3:
                        {
                            FormAdmin t3 = new FormAdmin();
                            t3.Show();
                            this.Hide();
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует");
            }
            connection.Close();
        }

    }
}
