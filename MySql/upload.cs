using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySql
{
    public partial class upload : UserControl
    {
        public upload(string sql)
        {
            InitializeComponent();
            richTextBox1.Text = sql;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сервер в данный момент не доступн, либо неверно установленны настройки. \n Так же вы можете провести Mysql запрос в ручную, он предоставлен в окне.", "Ошибка подключения", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
