using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace MySql {
    class MySqlConnector {
        string Database = "", //БАЗА - Имя базы в MySQL
               Datasource = "",//ХОСТ - Имя или IP-адрес сервера (если локально то можно и localhost)
               User = "", //ПОЛЬЗОВАТЕЛЬ - Имя пользователя MySQL
               Password = "", //ПАРОЛЬ - говорит само за себя - пароль пользователя БД MySQL
               Connect; // строка подключения
        MySqlConnection myConnection;
        MySqlCommand UniversalCommand;
        public string database {
            get { return Database; }
            set { Database = value; }
        }
        public string datasource {
            get { return Datasource; }
            set { Datasource = value; }
        }
        public string user {
            get { return User; }
            set { User = value; }
        }
        public string password {
            get { return Password; }
            set { Password = value; }
        }
      private void connection_init() {
          Connect = "database=" + Database + ";datasource=" + Datasource + ";username=" + User + ";password=" + Password + ";charset=utf8;port=3306";
          //   "datasource="+Datasource+";port=3306;username="+User+";password="+Password;
          MySqlConnectionStringBuilder mysqlCSB;
          mysqlCSB = new MySqlConnectionStringBuilder();
          mysqlCSB.Server = Datasource;
          mysqlCSB.Database = Database;
          mysqlCSB.UserID = User;
          mysqlCSB.Password = Password;
            try {
                myConnection = new MySqlConnection(mysqlCSB.ConnectionString);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } 
       }
        private void openCon() {
            if (myConnection.State == ConnectionState.Closed)
                myConnection.Open();
        }
        private void closeCon() {
            if (myConnection.State == ConnectionState.Open) {
                myConnection.Close();
            }
        }
        public void ExecuteQuery(string q) {
            connection_init();
             try { 
                openCon();                
                UniversalCommand = new MySqlCommand(q, myConnection);            
                   if (UniversalCommand.ExecuteNonQuery() == 1)                     
                    MessageBox.Show("Query Executed");                 
                   else MessageBox.Show("Query Not Executed"); 
             } catch (Exception ex) {           
                      MessageBox.Show(ex.Message);
             }finally {                 
                 closeCon();             
                }         
            }

    }
}


//      MySqlConnector mc = new MySqlConnector();
//     mc.database = "10.29.0.20";
//     mc.datasource = "ssh.t-avto_mysql.nichost.ru";
//     mc.user = "t-avto_mysql";
//     mc.password = "Sv8YL/ML";
//     mc.ExecuteQuery("INSERT INTO `t-avto_bag`.`product_shop` (`id_product`, `id_shop`, `id_category_default`, `id_tax_rules_group`, `on_sale`, `online_only`, `ecotax`, `minimal_quantity`, `price`, `wholesale_price`, `unity`, `unit_price_ratio`, `additional_shipping_cost`, `customizable`, `uploadable_files`, `text_fields`, `active`, `redirect_type`, `id_product_redirected`, `available_for_order`, `available_date`, `condition`, `show_price`, `indexed`, `visibility`, `cache_default_attribute`, `advanced_stock_management`, `date_add`, `date_upd`) VALUES ('1', '1', '0', '0', '0', '0', '0.000000', '1', '0.000000', '0.000000', 'unity', '0.000000', '0.00', '0', '0', '0', '0', '404', '0', '1', '2016-03-14', 'new', '1', '0', 'both', '10', '0', '2016-03-14 00:00:00', '2016-03-14 00:00:00');"); //29
//      INSERT INTO `t-avto_bag`.`product_shop` (`id_product`, `id_shop`, `id_category_default`, `id_tax_rules_group`, `on_sale`, `online_only`, `ecotax`, `minimal_quantity`, `price`, `wholesale_price`, `unity`, `unit_price_ratio`, `additional_shipping_cost`, `customizable`, `uploadable_files`, `text_fields`, `active`, `redirect_type`, `id_product_redirected`, `available_for_order`, `available_date`, `condition`, `show_price`, `indexed`, `visibility`, `cache_default_attribute`, `advanced_stock_management`, `date_add`, `date_upd`) VALUES ('1', '1', '0', '0', '0', '0', '0.000000', '1', '0.000000', '0.000000', 'unity', '0.000000', '0.00', '0', '0', '0', '0', '404', '0', '1', '2016-03-14', 'new', '1', '0', 'both', '10', '0', '2016-03-14 00:00:00', '2016-03-14 00:00:00');
