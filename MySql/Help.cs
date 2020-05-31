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
    public partial class Help : UserControl
    {
        public Help()
        {
            InitializeComponent();
            webBrowser1.DocumentText = "<html><body><p>Помощь при работе с приложением</p><br><p>Для загрузки данных используйте пункт меню. В открывшемся окне выберите загрузить файл.<br>Полсде чкго нажмите на кнопку загрузить. Все товары появятся в левом окне, а их свойства в правом.<br> Для сохраненния изменений, нажмите на пункт меню Сохранить.<br>Для выгрузки данных на сайт и получения запроса, нажмите на пункут меню - выгрузить.</p></body></html>";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
