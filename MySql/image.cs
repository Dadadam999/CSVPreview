using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySql
{
   public class image
    {
     int Vid_shop = 1, Vid_lang = 1, Vcover = 1;
     public int id_image { get; set; }
     public int id_product { get; set; }
     public int position { get; set; }
     public string legend { get; set; }
     public string name { get; set; }
     public string patch { get; set; }
     public int id_shop {
         get { return Vid_shop; }
         set {Vid_shop = value; }
     }
     public int id_lang {
         get { return Vid_lang; }
         set {Vid_lang = value; } 
     }
     public int cover {
         get { return Vcover; }
         set {Vcover = value; } 
     } 
    }
}
