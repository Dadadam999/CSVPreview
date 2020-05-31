using MySql.Data.MySqlClient.Memcached;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySql
{
public class downloadfile {

       WebClient Client = new WebClient();
       public string downloadtobitmap(string url, string savepatch) {
           try {
                Client.DownloadFile(url, savepatch + "\\" + Path.GetFileName(url));
                return savepatch + "\\" + Path.GetFileName(url);
           } catch (WebException ex) {

                   MessageBox.Show(Convert.ToString(ex));
                   return AppDomain.CurrentDomain.BaseDirectory + @"p\" + @"ru.jpg";
           }
           
        }
        public void savefile(string url, string savepatch)  {
            try {
                Client.DownloadFile(url, savepatch + "\\" + Path.GetFileName(url));
            }
            catch (WebException ex) {
                HttpWebResponse errorResponse = (HttpWebResponse) ex.Response;
                if (errorResponse.StatusCode == HttpStatusCode.NotFound) {
                }
            }

        }
    }
}
