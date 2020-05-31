using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySql {
   public class product {
        public string id_product { get; set; }
        public string id_supplier { get; set; }
        public string id_manufacturer { get; set; }
        public string id_lang { get; set; }
        public string id_shop { get; set; }
        public string id_tax_rules_group { get; set; }
        public string id_category_default { get; set; }
        public string id_product_redirected { get; set; }

        public string on_sale { get; set; }
        public string online_only { get; set; }
        public string ean13 { get; set; }
        public string upc { get; set; }
        public string ecotax { get; set; }
        public string quantity { get; set; }
        public string minimal_quantity { get; set; }
        public string price { get; set; }
        public string wholesale_price { get; set; }
        public string unity { get; set; }
        public string unit_price_ratio { get; set; }
        public string additional_shipping_cost { get; set; }
        public string reference { get; set; }
        public string supplier_reference { get; set; }
        public string location { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string depth { get; set; }
        public string weight { get; set; }
        public string out_of_stock { get; set; }
        public string quantity_discount { get; set; }
        public string customizable { get; set; }
        public string uploadable_files { get; set; }
        public string text_fields { get; set; }
        public string active { get; set; }
        public string redirect_type { get; set; }

        public string available_for_order { get; set; }
        public string available_date { get; set; }
        public string available_now { get; set; }
        public string available_later { get; set; }

        public string date_add { get; set; }
        public string date_upd { get; set; }

        public string condition { get; set; }
        public string show_price { get; set; }
        public string indexed { get; set; }
        public string visibility { get; set; }
        public string cache_is_pack { get; set; }
        public string cache_has_attachments { get; set; }
        public string is_virtual { get; set; }
        public string cache_default_attribute { get; set; }
        public string advanced_stock_management { get; set; }

        public string description { get; set; }
        public string description_short { get; set; }
        public string link_rewrite { get; set; }
        public string meta_description { get; set; }
        public string meta_keywords { get; set; }
        public string meta_title { get; set; }
        public string name { get; set; }
    }
}