using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySql {
    class img_type {
     int Vproducts = 0, Vcategories = 0, Vmanufacturers = 0, Vsuppliers = 0, Vscenes = 0, Vstores = 0;     

     public int id_image_type {get; set;}
     public string name {get; set;}
     public int width {get; set;}
     public int height {get; set;}
     public int products {
         get {return Vproducts;} 
         set {Vproducts =value;}
     }
     public int categories {
         get { return Vcategories; }
         set { Vcategories = value; }
     } 
     public int manufacturers {
         get { return Vmanufacturers; }
         set { Vmanufacturers = value; }
     } 
     public int suppliers {
         get { return Vsuppliers; }
         set { Vsuppliers = value; }
     }
     public int scenes {
         get { return Vscenes; }
         set { Vscenes = value; }
     }
     public int stores {
         get { return Vstores; }
         set { Vstores = value; }
     }
   }
}