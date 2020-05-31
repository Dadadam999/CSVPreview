using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MySql
{
    public partial class Form1 : Form
    {
        string[] all;
        int sizecolumn = 26;
        int catid = 3, nrightleft = 0;
        translit trs = new translit();
        categories[] cat = new categories[0];
        product[] pr = new product[0];
        img_type[] type;
        image[] img;
        MainForm main = new MainForm();


        public static Form1 selfref { get; set; }
        public Form1()
        {
            InitializeComponent();
            selfref = this;
            main.Dock = DockStyle.Fill;
            this.Controls.Add(main);
            main.BringToFront();
            panel1.Visible = false;
            panel2.Visible = false;
        }
        #region обработчики кнопок
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                try { all = File.ReadAllLines(openFileDialog1.FileName, Encoding.GetEncoding(1251)); }
                catch (System.FormatException) { MessageBox.Show("Error: Config have incorrect parametrs. Restart program", "Error", MessageBoxButtons.OK); }
            dataGridView1.ColumnCount = sizecolumn;
            string[] temp;
            dataGridView1.RowCount = all.Length;
            for (int j = 0; j < dataGridView1.RowCount; j++)
            {
                temp = all[j].Split(';');

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    dataGridView1[i, j].Value = temp[i];
            }
            createcategories();
            createstructimg(false);
          //  gruop_category();
        }

        void gruop_category()
        {
            string category = "";
            for (int i = 1; i < cat.Length; i++)
                for (int j = 1; j < 4; j++)
                {
                    category += "(" + cat[i].id + ", " + j + ")";
                    if (cat.Length - 1 == i) category += ";"; else category += ",\n";
                }
            Form2 f2 = new Form2();
            RichTextBox r = new RichTextBox();
            r.Text = category;
            r.Dock = DockStyle.Fill;
            f2.Text = "Результат таблица Category Gruop";
            f2.Controls.Add(r);
            f2.Show();
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
            createstructimg(true);
        }
        string GetCategory(string patch)
        {
            string category = "2";
            string[] temp = patch.Split('/');
            foreach (categories ct in cat)
                if (temp[temp.Length - 1] == ct.name)
                {
                    category = Convert.ToString(ct.id);
                    break;
                }
            return category;
        }

        bool checcopy(string id, int this_id)
        {
            bool flag = false;
            for (int i = 0; i < dataGridView1.RowCount; i++)
                if (i == this_id) continue;
                else
                    if (Convert.ToString(dataGridView1[0, i].Value) == id) { flag = true; break; }
            return flag;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string result = "";
            for (int i = 1; i < dataGridView1.RowCount; i++)
                if (!checcopy(Convert.ToString(dataGridView1[0, i].Value), i))
                {
                    result += "(" + dataGridView1[0, i].Value + ",'0','0','" + GetCategory(Convert.ToString(dataGridView1[3, i].Value)) + "','1','0','0','0','" + dataGridView1[14, i].Value + "', '000', '" + dataGridView1[4, i].Value + ".000000', '0', '1', '" + dataGridView1[4, i].Value + ".000000', '" + dataGridView1[6, i].Value + ".000000', '0', '0.000000', '0.00', '" + dataGridView1[0, i].Value + "', '0', '0', '0.000000', '0.000000', '0.000000', '0.000000', '2', '0', '0', '0', '0', '0', '', '0', '1', '2016-03-20', 'new', '1', '0', 'both', '0', '0', '0', '0', '2016-03-20 00:00:00', '2016-03-20 00:00:00', '0')";
                    if (dataGridView1.RowCount - 1 == i) result += ";"; else result += ",\n";
                }
            Form2 f2 = new Form2();
            RichTextBox r = new RichTextBox();
            r.Text = result;
            r.Dock = DockStyle.Fill;
            r.Text = result;
            f2.Text = " Результат таблица Product";
            f2.Controls.Add(r);
            f2.Show();
        }
        // 1 - article, 0 - name
        string get_article_of_name(string name, bool mode)
        {
            string[] word = name.Split(' ');
            if (mode) return word[word.Length - 1];
            else
            {
                name = "";
                for (int i = 0; i < word.Length - 1; i++) name += word[i] + " ";
                return name;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string result = "";
            for (int i = 1; i < dataGridView1.RowCount; i++)
                if (!checcopy(Convert.ToString(dataGridView1[0, i].Value), i))
                {
                    result += "(" + dataGridView1[0, i].Value + ", 1," + GetCategory(Convert.ToString(dataGridView1[3, i].Value)) + ", 0, 0, 0, '0.000000', 1, '" + dataGridView1[4, i].Value + ".000000', '" + dataGridView1[6, i].Value + ".000000', '', '0.000000', '0.00', 0, 0, 0, 1, '404', 0, 1, '0000-00-00', 'new', 1, 1, 'both', 0, 0, '2016-03-20 21:44:21', '2016-03-20 21:44:49')";
                    if (dataGridView1.RowCount - 1 == i) result += ";"; else result += ",\n";
                }
            Form2 f2 = new Form2();
            RichTextBox r = new RichTextBox();
            r.Text = result;
            r.Dock = DockStyle.Fill;
            r.Text = result;
            f2.Text = " Результат таблица Product_shop";
            f2.Controls.Add(r);
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string result = "";
            for (int i = 1; i < dataGridView1.RowCount; i++)
                if (!checcopy(Convert.ToString(dataGridView1[0, i].Value), i))
                {
                    //                                                            `description`,                                   `description_short`,                 `link_rewrite`,                        `meta_description`,               `meta_keywords`,                     `meta_title`,                                                                                 `name`,                `available_now`, `available_later`
                    result += "(" + dataGridView1[0, i].Value + ", 1, 1, '<p>" + dataGridView1[19, i].Value + "</p>', '<p>" + dataGridView1[18, i].Value + "</p>', '" + dataGridView1[24, i].Value + "' ,'" + dataGridView1[23, i].Value + "', '" + dataGridView1[22, i].Value + "', '" + dataGridView1[21, i].Value + "', '" + get_article_of_name(Convert.ToString(dataGridView1[2, i].Value), false) + "', '', '')";
                    if (dataGridView1.RowCount - 1 == i) result += ";"; else result += ",\n";
                }

            Form2 f2 = new Form2();
            RichTextBox r = new RichTextBox();
            r.Text = result;
            r.Dock = DockStyle.Fill;
            r.Text = result;
            f2.Text = "Результат таблица Product_lang";
            f2.Controls.Add(r);
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string category = "";

            for (int i = 0; i < cat.Length; i++)
            {
                // (`id_category`, `id_parent`, `id_shop_default`, `level_depth`, `nleft`, `nright`, `active`, `date_add`, `date_upd`, `position`, `is_root_category`)
                category += "(" + cat[i].id + ", " + cat[i].parent + ", " + cat[i].idshop + "," + cat[i].level_depth + "," + cat[i].nleft + "," + cat[i].nright + "," + cat[i].active + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " + cat[i].position + ", " + cat[i].is_root_category + ")";
                if (cat.Length - 1 == i) category += ";"; else category += ",\n";
            }

            Form2 f2 = new Form2();
            RichTextBox r = new RichTextBox();
            r.Text = category;
            r.Dock = DockStyle.Fill;

            f2.Text = "Результат таблица Category";
            f2.Controls.Add(r);
            f2.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string category = "";

            for (int i = 0; i < cat.Length; i++)
            {
                //  (`id_category`, `id_shop`, `position`) 
                category += "(" + cat[i].id + "," + cat[i].idshop + "," + cat[i].position + ")";
                if (cat.Length - 1 == i) category += ";"; else category += ",\n";
            }

            Form2 f2 = new Form2();
            RichTextBox r = new RichTextBox();
            r.Text = category;
            r.Dock = DockStyle.Fill;

            f2.Text = "Результат таблица Category_shop";
            f2.Controls.Add(r);
            f2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string category = "";

            for (int i = 0; i < cat.Length; i++)
            {
                // (`id_category`, `id_shop`, `id_lang`, `name`, `description`, `link_rewrite`, `meta_title`, `meta_keywords`, `meta_description`)
                category += "(" + cat[i].id + "," + cat[i].idshop + ", " + cat[i].idlang + ", '" + cat[i].name + "', '" + cat[i].description + "', '" + cat[i].rewrite_link + "', '" + cat[i].meta_title + "', '" + cat[i].meta_keywords + "', '" + cat[i].meta_description + "')";
                if (cat.Length - 1 == i) category += ";"; else category += ",\n";
            }

            Form2 f2 = new Form2();
            RichTextBox r = new RichTextBox();
            r.Text = category;
            r.Dock = DockStyle.Fill;
            f2.Text = "Результат таблица Category_lang";
            f2.Controls.Add(r);
            f2.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string category = "";

            for (int i = 1; i < dataGridView1.RowCount; i++)
            {
                // (`id_category`, `id_product`, `position`)
                category += "(" + GetCategory(Convert.ToString(dataGridView1[3, i].Value)) + ", " + dataGridView1[0, i].Value + ", 0)";
                if (dataGridView1.RowCount - 1 == i) category += ";"; else category += ",\n";
            }

            Form2 f2 = new Form2();
            RichTextBox r = new RichTextBox();
            r.Text = category;
            r.Dock = DockStyle.Fill;
            f2.Text = "Результат таблица Category_product";
            f2.Controls.Add(r);
            f2.Show();
        }

        #endregion
        #region категории
        void createcategories()
        { //создание категорий
            create_root_category();
            string[] tempcat;
            for (int i = 1; i < dataGridView1.RowCount; i++)
            {
                if (checkpath(Convert.ToString(dataGridView1[3, i].Value), i))
                {
                    tempcat = Convert.ToString(dataGridView1[3, i].Value).Split('/');
                    for (int j = 0; j < tempcat.Length; j++)
                    {
                        if (!isCategory(tempcat[j]))
                        {
                            Array.Resize(ref cat, cat.Length + 1);
                            cat[cat.Length - 1] = new categories();
                            cat[cat.Length - 1].id = catid;
                            catid++;
                            cat[cat.Length - 1].level_depth = j + 2;
                            cat[cat.Length - 1].name = tempcat[j];
                            cat[cat.Length - 1].rewrite_link = trs.GetTranslit(tempcat[j]);
                            cat[cat.Length - 1].patch = Convert.ToString(dataGridView1[3, i].Value);
                            if (j == 0) cat[cat.Length - 1].parent = 2;
                            else cat[cat.Length - 1].parent = get_category();
                        }
                    }
                }
            }
            create_structure_category();
            test();
        }
        void create_root_category()
        { // создание рут категорий
            Array.Resize(ref cat, cat.Length + 1);
            cat[cat.Length - 1] = new categories();
            cat[cat.Length - 1].id = 1;
            cat[cat.Length - 1].level_depth = 0;
            cat[cat.Length - 1].name = "Корень";
            cat[cat.Length - 1].rewrite_link = "root";
            cat[cat.Length - 1].patch = "Корень";
            cat[cat.Length - 1].parent = 0;
            Array.Resize(ref cat, cat.Length + 1);
            cat[cat.Length - 1] = new categories();
            cat[cat.Length - 1].id = 2;
            cat[cat.Length - 1].level_depth = 1;
            cat[cat.Length - 1].name = "Главная";
            cat[cat.Length - 1].rewrite_link = "home";
            cat[cat.Length - 1].patch = "Корень/Главная";
            cat[cat.Length - 1].parent = 1;
            cat[cat.Length - 1].is_root_category = 1;
        }
        void create_structure_category()
        { // создание структуры категорий
            nrightleft = 1;
            set_child_properties();
            set_nrightleft_parent(0);
        }
        void set_nrightleft_parent(int id)
        { //рекурсия заполнения границ категорий
            if (cat[id].nleft == 0 && cat[id].nright == 0)
                if (isParent(cat[id]))
                {
                    cat[id].nleft = nrightleft++;
                    for (int i = 0; i < cat.Length; i++)
                        if (cat[i].parent == cat[id].id)
                            if (isParent(cat[i])) set_nrightleft_parent(i);
                            else
                            {
                                cat[i].nleft = nrightleft++;
                                cat[i].nright = nrightleft++;
                            }
                    cat[id].nright = nrightleft++;
                }
                else if (!isChild(cat[id]))
                {
                    cat[id].nleft = nrightleft++;
                    cat[id].nright = nrightleft++;
                }
        }
        bool isChild(categories chaild)
        { //является ли категория подкатегорией
            bool flag = false;
            foreach (categories ct in cat)
                if (ct.id == chaild.parent)
                {
                    flag = true;
                    break;
                }
            return flag;
        }
        bool isParent(categories parent)
        { //является ли категория родителем
            bool flag = false;
            foreach (categories child in cat)
                if (child.parent == parent.id)
                {
                    flag = true;
                    break;
                }
            return flag;
        }
        void set_child_properties()
        { //заполение массивов подкатегорий
            foreach (categories parent in cat)
                foreach (categories child in cat)
                    if (parent.id == child.parent)
                        parent.add_child = child.id;
        }
        int get_category()
        { //получение родителя подкатегории
            string[] temp_patch = cat[cat.Length - 1].patch.Split('/');
            string parent = temp_patch[temp_patch.Length - 2];
            string this_category = temp_patch[temp_patch.Length - 1];
            foreach (categories ct in cat)
                if (cat[cat.Length - 1].name != ct.name)
                    if (parent == ct.name)
                        return ct.id;
            return 2;
        }
        bool isCategory(string category_name)
        {
            bool flag = false;
            for (int i = 0; i < cat.Length; i++)
                if (cat[i].name == category_name)
                {
                    flag = true;
                    break;
                }
            return flag;
        }
        bool checkpath(string path, int length)
        {
            bool flag = true;
            for (int i = 1; i < length; i++)
            {
                if (path == Convert.ToString(dataGridView1[3, i].Value))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        void test()
        {
            string test = "", probel;
            for (int j = 0; j < cat.Length; j++)
            {
                probel = "";
                for (int i = 0; i < cat[j].level_depth; i++) probel += "  ";
                test += probel + cat[j].id + ":" + cat[j].parent + ":" + ":" + cat[j].level_depth + ":" + cat[j].rewrite_link + ":" + cat[j].nleft + ":" + cat[j].nright + "\n";
            }
            Form2 f2 = new Form2();
            RichTextBox r = new RichTextBox();
            r.Text = test;
            r.Dock = DockStyle.Fill;
            f2.Text = "Категории";
            f2.Controls.Add(r);
            f2.Show();
        }
        #endregion
        string[] testsave()
        {
            downloadfile test = new downloadfile();
            string[] urlmass, p = new string[0];
            for (int i = 1; i < dataGridView1.RowCount; i++)
            {
                urlmass = Convert.ToString(dataGridView1[25, i].Value).Split(',');
                for (int j = 0; j < urlmass.Length; j++)
                {
                    if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\img\" + Path.GetFileName(urlmass[j]))) test.savefile(urlmass[j], AppDomain.CurrentDomain.BaseDirectory + @"\img\");
                    Array.Resize(ref p, p.Length + 1);
                    p[p.Length - 1] = Path.GetFileName(urlmass[j]);
                }
            }

            return p;
        }


        void createstructimg(bool create_minature)
        {
            img = new image[0];
            int index = 0;
            string[] urlmass;
            string path = AppDomain.CurrentDomain.BaseDirectory + "p";
            string path_temp = AppDomain.CurrentDomain.BaseDirectory + "img";
            //MessageBox.Show(path);
            DirectoryInfo di;
            downloadfile download = new downloadfile();

            init_img_type();
            string[] file_name = testsave();

            int file_name_k = 0;

            try
            {
                if (!Directory.Exists(path))
                {
                    di = Directory.CreateDirectory(path);
                }

                for (int i = 1; i < dataGridView1.RowCount; i++)
                {
                    urlmass = Convert.ToString(dataGridView1[25, i].Value).Split(',');
                    for (int j = 0; j < urlmass.Length; j++)
                    {
                        Array.Resize(ref img, img.Length + 1);
                        img[img.Length - 1] = new image();
                        img[img.Length - 1].id_image = index;
                        img[img.Length - 1].id_product = Convert.ToInt32(dataGridView1[0, i].Value);
                        img[img.Length - 1].legend = Convert.ToString(dataGridView1[2, i].Value);
                        img[img.Length - 1].patch = path + createpatchimg(index);
                        img[img.Length - 1].position = j;
                        index++;
                        if (create_minature)
                        {
                            if (!Directory.Exists(img[img.Length - 1].patch)) { di = Directory.CreateDirectory(img[img.Length - 1].patch); }
                            if (!File.Exists(img[img.Length - 1].patch + @"\" + img[img.Length - 1].id_image + ".jpg")) ResizeImage(path_temp + "\\" + file_name[file_name_k], img[img.Length - 1].patch + @"\" + img[img.Length - 1].id_image + ".jpg", 600, 600, true);
                            for (int type_i = 0; type_i < type.Length; type_i++)
                                if (!File.Exists(img[img.Length - 1].patch + @"\" + type[type_i].name + ".jpg"))
                                    ResizeImage(path_temp + "\\" + file_name[file_name_k], img[img.Length - 1].patch + @"\" + img[img.Length - 1].id_image + "-" + type[type_i].name + ".jpg", type[type_i].width, type[type_i].height, true);
                            file_name_k++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка создания струтуры папок. Не были созданы или были созданы частично: " + e.ToString(), "Оповещение", MessageBoxButtons.OK);
            }
            finally { }

        }

        string createpatchimg(int index)
        {
            string patch = "";
            StringBuilder num = new StringBuilder(Convert.ToString(index));
            for (int i = 0; i < num.Length; i++)
                patch += @"\" + num[i];
            return patch;
        }

        void init_img_type()
        {
            type = new img_type[0];
            string[] temp_name = { "small_default", "medium_default", "home_default", "large_default", "thickbox_default", "cart_default" };

            for (int i = 0; i < temp_name.Length; i++)
            {
                Array.Resize(ref type, type.Length + 1);
                type[type.Length - 1] = new img_type();
                type[type.Length - 1].id_image_type = i;
                type[type.Length - 1].name = temp_name[i];
            }

            type[0].width = 98;
            type[0].height = 98;

            type[1].width = 125;
            type[1].height = 125;

            type[2].width = 250;
            type[2].height = 250;

            type[3].width = 458;
            type[3].height = 458;

            type[4].width = 800;
            type[4].height = 800;

            type[5].width = 80;
            type[5].height = 80;


            /*(1, 'cart_default', 80, 80, 1, 0, 0, 0, 0, 0),
            (2, 'small_default', 98, 98, 1, 0, 1, 1, 0, 0),
            (3, 'medium_default', 125, 125, 1, 1, 1, 1, 0, 1),
            (4, 'home_default', 250, 250, 1, 0, 0, 0, 0, 0),
            (5, 'large_default', 458, 458, 1, 0, 1, 1, 0, 0),
            (6, 'thickbox_default', 800, 800, 1, 0, 0, 0, 0, 0),
            (7, 'category_default', 870, 217, 0, 1, 0, 0, 0, 0),
            (8, 'scene_default', 870, 270, 0, 0, 0, 0, 1, 0),
            (9, 'm_scene_default', 161, 58, 0, 0, 0, 0, 1, 0);*/

        }

        Image FullSizeImage, NewImage;
        ImageCodecInfo jpgEncoder;
        EncoderParameters myEncoderParameters;
        EncoderParameter myEncoderParameter;
        public void ResizeImage(string OrigFile, string NewFile, int NewWidth, int MaxHeight, bool ResizeIfWider)
        {
            FullSizeImage = Image.FromFile(OrigFile);  // Ensure the generated thumbnail is not being used by rotating it 360 degrees
            FullSizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
            FullSizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
            if (ResizeIfWider)
                if (FullSizeImage.Width <= NewWidth)
                    NewWidth = FullSizeImage.Width;
            int NewHeight = FullSizeImage.Height * NewWidth / FullSizeImage.Width;
            if (NewHeight > MaxHeight)
            { // Height resize if necessary 
                NewWidth = FullSizeImage.Width * MaxHeight / FullSizeImage.Height;
                NewHeight = MaxHeight;
            }
            // Create the new image with the sizes we've calculated
            NewImage = FullSizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);
            FullSizeImage.Dispose();


            jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            // Create an Encoder object based on the GUID for the Quality parameter category.
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            // Create an EncoderParameters object. An EncoderParameters object has an array of EncoderParameter objects. In this case, there is only one EncoderParameter object in the array.
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;


            NewImage.Save(NewFile, jpgEncoder, myEncoderParameters);
        }
        //вес/4 = качество/4*размер2 = качество*(размер/2)2
        ImageCodecInfo[] codecs;
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //   `id_image`, `id_product`, `position`, `cover`
            string result = "";
            for (int i = 0; i < img.Length; i++)
            {
                result += "(" + img[i].id_image + "," + img[i].id_product + "," + img[i].position + "," + img[i].cover + ")";
                if (img.Length - 1 == i) result += ";"; else result += ",\n";
            }

            Form2 f2 = new Form2();
            RichTextBox r = new RichTextBox();
            r.Text = result;
            r.Dock = DockStyle.Fill;
            f2.Text = "Результат таблица Image";
            f2.Controls.Add(r);
            f2.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // (`id_image`, `id_lang`, `legend`)
            string result = "";
            for (int i = 0; i < img.Length; i++)
            {
                result += "(" + img[i].id_image + "," + img[i].id_lang + ", '" + img[i].legend + "')";
                if (img.Length - 1 == i) result += ";"; else result += ",\n";
            }

            Form2 f2 = new Form2();
            RichTextBox r = new RichTextBox();
            r.Text = result;
            r.Dock = DockStyle.Fill;
            f2.Text = "Результат таблица Image Lang";
            f2.Controls.Add(r);
            f2.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //(`id_image`, `id_shop`, `cover`)
            string result = "";
            for (int i = 0; i < img.Length; i++)
            {
                result += "(" + img[i].id_image + "," + img[i].id_shop + ", " + img[i].cover + ")";
                if (img.Length - 1 == i) result += ";"; else result += ",\n";
            }

            Form2 f2 = new Form2();
            RichTextBox r = new RichTextBox();
            r.Text = result;
            r.Dock = DockStyle.Fill;
            f2.Text = "Результат таблица Image Shop";
            f2.Controls.Add(r);
            f2.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                try { string[] addfile = File.ReadAllLines(openFileDialog1.FileName, Encoding.GetEncoding(1251)); }
                catch (System.FormatException) { MessageBox.Show("Error: Config have incorrect parametrs. Restart program", "Error", MessageBoxButtons.OK); }
            dataGridView1.ColumnCount = sizecolumn;
            string[] temp;
            dataGridView1.RowCount = all.Length;
            for (int j = 0; j < dataGridView1.RowCount; j++)
            {
                temp = all[j].Split(';');
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    dataGridView1[i, j].Value = temp[i];
            }
            createcategories();
            createstructimg(false);
            gruop_category();
        }



        void createproduct()
        { //fake
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Array.Resize(ref pr, pr.Length + 1);
                pr[pr.Length - 1] = new product(); 
                pr[pr.Length - 1].id_product = row.Cells[0].FormattedValue.ToString();
                pr[pr.Length - 1].id_supplier = row.Cells[12].FormattedValue.ToString();
                pr[pr.Length - 1].id_manufacturer = row.Cells[13].FormattedValue.ToString();
                pr[pr.Length - 1].id_category_default = row.Cells[3].FormattedValue.ToString();

                pr[pr.Length - 1].ean13 = row.Cells[14].FormattedValue.ToString();
                pr[pr.Length - 1].quantity = row.Cells[17].FormattedValue.ToString();
                pr[pr.Length - 1].price = row.Cells[4].FormattedValue.ToString();
                pr[pr.Length - 1].wholesale_price = row.Cells[6].FormattedValue.ToString();

                pr[pr.Length - 1].width = "";
                pr[pr.Length - 1].height = "";
                pr[pr.Length - 1].depth = "";
                pr[pr.Length - 1].weight = "";
                pr[pr.Length - 1].active = row.Cells[1].FormattedValue.ToString();

                pr[pr.Length - 1].description = row.Cells[19].FormattedValue.ToString();
                pr[pr.Length - 1].description_short = row.Cells[18].FormattedValue.ToString();

                pr[pr.Length - 1].meta_description = row.Cells[23].FormattedValue.ToString();
                pr[pr.Length - 1].meta_keywords = row.Cells[22].FormattedValue.ToString();
                pr[pr.Length - 1].meta_title = row.Cells[21].FormattedValue.ToString();
                pr[pr.Length - 1].name = row.Cells[2].FormattedValue.ToString();
            }
        }

        public temp_mass temp;
        private void button12_Click(object sender, EventArgs e) {
            createproduct();
            temp = new temp_mass();
            temp.get_categories = cat;
            temp.get_product = pr;
            temp.get_image = img;
            MainForm.selfref.get_mass();
            panel1.Visible = false;
            panel2.Visible = false;
            main.Show();
        }

    }


}
