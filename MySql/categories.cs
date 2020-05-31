using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySql
{
   public class categories
    {
        int Vparent = 0, Vidshop = 1, Vidlang = 1, Vactive = 1, Vposition = 0, Vis_root_category = 0, Vnleft = 0, Vnright = 0;
        int[] Vchild = new int[0];
        public int id { get; set; }
        public int level_depth { get; set; }
        public int nleft {
            get { return Vnleft; }
            set { Vnleft = value; } 
        }
        public int nright {
            get { return Vnright; }
            set { Vnright = value; }
        }
        public int parent {
            get { return Vparent; }
            set { Vparent = value; }
        }
        public int idshop {
            get { return Vidshop; }
            set { Vidshop = value; }
        }
        public int idlang {
            get { return Vidlang; }
            set { Vidlang = value; }
        }
        public int active {
            get { return Vactive; }
            set { Vactive = value; }    
        }
        public int position {
            get { return Vposition; }
            set { Vposition = value; }
        }
        public int is_root_category {
            get { return Vis_root_category; }
            set { Vis_root_category = value; }
        }
        public string name { get; set; } 
        public string rewrite_link { get; set; } 
        public string description { get; set; } 
        public string meta_title { get; set; } 
        public string meta_keywords { get; set; }
        public string meta_description { get; set; }
        public string patch { get; set; }
        public string patch_img { get; set; }

        public int[] child { get { return Vchild; } }
        public int add_child { 
            set {
                Array.Resize(ref Vchild, Vchild.Length + 1);
                Vchild[Vchild.Length - 1] = value;
            } 
        }

        

    }
}
