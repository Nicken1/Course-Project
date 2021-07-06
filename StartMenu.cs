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
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {

            login log = new login();
            log.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = "В  1991  году  построено  новое  одноэтажное  кирпичное  здание. Много труда было вложено директором школы Цыгановым Анатолием Степановичем. " +
                "Он с августа 1981 года по 2 августа 2010 года работал директором этой школы. С 2001  года неполная средняя школа преобразована в основную общеобразовательную школу.    Школа функционирует как муниципальное общеобразовательное учреждение «Верхнебагряжская  основная  общеобразовательная школа» Заинскoro муниципального района с  2006 года.  С 2010 года школа функционирует как муниципальное бюджетное общеобразовательное учреждение «Верхнебагряжская  основная  общеобразовательная школа» Заинскoro муниципального района Республики Татарстан. С 3 августа 2010 года директором школы работает Иванов Николай Михайлович.";
            MessageBox.Show(text1, "Информация о школе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text2 = "Данное приложение разрабатывается для учебного курсового проекта, не предназначено для коммерческого использования ";
            MessageBox.Show(text2, "Информация о приложении", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
