using StoreDataLayer.BusinessLayer;
using StoreDataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreWinForms
{
    public partial class AdminForm : Form
    {
        StoreContext context;
        BindingSource bSource;
        List<BusinessGood> dataGood;
        List<BusinessManufacturer> dataManufacturer;
        List<BusinessCategory> dataCategory;

        List<string> PhotosToDelete;

        public enum Entity { Manufacturer, Category };

        public AdminForm()
        {
            InitializeComponent();
            context = new StoreContext();
            bSource = new BindingSource();
            PhotosToDelete = new List<string>();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("Images"))
            {
                Directory.CreateDirectory("Images");
            }

            context.Goods.Load();
            context.Manufacturers.Load();
            context.Categories.Load();
            context.Photos.Load();

            dataGood = DisplayGoods.GetGoods(context);

            bSource.DataSource = dataGood;
            dgvGoods.DataSource = bSource;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
            //foreach (var photo in PhotosToDelete)
            //{
            //    File.Delete(photo);
            //}
        }

        private void manufacturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataManufacturer = DisplayManufacturers.GetManufacturers(context);

            bSource.DataSource = null;
            bSource.DataSource = dataManufacturer;
            dgvGoods.DataSource = bSource;

            btnAddPhoto.Enabled = false;
            btnRemovePhoto.Enabled = false;
            flwPhoto.Enabled = false;
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataCategory = DisplayCategory.GetCategories(context);

            bSource.DataSource = null;
            bSource.DataSource = dataCategory;
            dgvGoods.DataSource = bSource;

            btnAddPhoto.Enabled = false;
            btnRemovePhoto.Enabled = false;
            flwPhoto.Enabled = false;
        }

        private void goodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGood = DisplayGoods.GetGoods(context);
            bSource.DataSource = null;
            bSource.DataSource = dataGood;
            dgvGoods.DataSource = bSource;

            btnAddPhoto.Enabled = true;
            btnRemovePhoto.Enabled = true;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bSource.Current is BusinessGood)
            {
                var item = bSource.Current as BusinessGood;

                GoodManipForm edit = new GoodManipForm(context, item.GoodId);
                edit.ShowDialog();
                RefreshDgv();
            }
            else if (bSource.Current is BusinessManufacturer)
            {
                var item = bSource.Current as BusinessManufacturer;
                ManufCatManipForm edit = new ManufCatManipForm(context, Entity.Manufacturer, item.ManufacturerId);
                edit.txtManufCat.Text = item.ManufacturerName;
                DialogResult res = edit.ShowDialog();

                if (res == DialogResult.OK)
                {
                    foreach (var m in dataManufacturer)
                    {
                        if (m.ManufacturerId == item.ManufacturerId)
                        {
                            m.ManufacturerName = edit.txtManufCat.Text;
                        }
                    }
                }
            }
            else
            {
                var item = bSource.Current as BusinessCategory;
                ManufCatManipForm edit = new ManufCatManipForm(context, Entity.Category, item.CategoryId);
                edit.txtManufCat.Text = item.CategoryName;
                DialogResult res = edit.ShowDialog();

                if (res == DialogResult.OK)
                {
                    foreach (var c in dataCategory)
                    {
                        if (c.CategoryId == item.CategoryId)
                        {
                            c.CategoryName = edit.txtManufCat.Text;
                        }
                    }
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bSource.Current is BusinessGood)
            {
                GoodManipForm add = new GoodManipForm(context);
                add.ShowDialog();
                RefreshDgv();
            }
            else if (bSource.Current is BusinessManufacturer)
            {
                ManufCatManipForm add = new ManufCatManipForm(context, Entity.Manufacturer);
                DialogResult res = add.ShowDialog();

                if (res == DialogResult.OK)
                {
                    dataManufacturer = DisplayManufacturers.GetManufacturers(context);
                    bSource.DataSource = dataManufacturer;
                }
            }
            else
            {
                ManufCatManipForm add = new ManufCatManipForm(context, Entity.Category);
                DialogResult res = add.ShowDialog();

                if (res == DialogResult.OK)
                {
                    dataCategory = DisplayCategory.GetCategories(context);
                    bSource.DataSource = dataCategory;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bSource.Current is BusinessGood)
            {
                BusinessGood item = bSource.Current as BusinessGood;
                DialogResult confirmDeletion = MessageBox.Show($"Are you sure you would like to delete {item.GoodName}?", "Confirmation", MessageBoxButtons.YesNo);

                if (confirmDeletion == DialogResult.Yes)
                {
                    Good good = context.Goods.Local
                    .Where(g => g.GoodId == item.GoodId)
                    .FirstOrDefault();

                    context.Goods.Remove(good);
                    context.SaveChanges();
                    RefreshDgv();
                }
            }
            else if (bSource.Current is BusinessManufacturer)
            {
                BusinessManufacturer item = bSource.Current as BusinessManufacturer;
                DialogResult confirmDeletion = MessageBox.Show($"Are you sure you would like to delete {item.ManufacturerName}?", "Confirmation", MessageBoxButtons.YesNo);

                if (confirmDeletion == DialogResult.Yes)
                {
                    Manufacturer manuf = context.Manufacturers.Local
                    .Where(m => m.ManufacturerId == item.ManufacturerId)
                    .FirstOrDefault();

                    context.Manufacturers.Remove(manuf);
                    context.SaveChanges();
                    dataManufacturer = DisplayManufacturers.GetManufacturers(context);
                    bSource.DataSource = dataManufacturer;
                }
            }
            else
            {
                BusinessCategory item = bSource.Current as BusinessCategory;
                DialogResult confirmDeletion = MessageBox.Show($"Are you sure you would like to delete {item.CategoryName}?", "Confirmation", MessageBoxButtons.YesNo);

                if (confirmDeletion == DialogResult.Yes)
                {
                    Category category = context.Categories.Local
                    .Where(c => c.CategoryId == item.CategoryId)
                    .FirstOrDefault();

                    context.Categories.Remove(category);
                    context.SaveChanges();
                    dataCategory = DisplayCategory.GetCategories(context);
                    bSource.DataSource = dataCategory;
                }
            }
        }

        private void RefreshDgv()
        {
            dgvGoods.DataSource = null;
            List<BusinessGood> data = DisplayGoods.GetGoods(context);
            bSource.DataSource = data;
            dgvGoods.DataSource = bSource;
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Files(*.*)|*.*|Image Files(*.jpg)|*.jpg||";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(open.FileName);
                string fullpath = Path.Combine("Images", Guid.NewGuid().ToString() + "." + ext);
                File.Copy(open.FileName, fullpath);

                AddPhotoFlowPanel(fullpath);

                context.Photos.Local.Add(
                    new Photo()
                    {
                        GoodId = (bSource.Current as BusinessGood).GoodId,
                        PhotoPath = fullpath
                    });

                context.SaveChanges();
            }
        }

        private void AddPhotoFlowPanel(string fullpath)
        {
            Image img = Image.FromFile(fullpath);
            PictureBox p = new PictureBox();
            p.Width = 200;
            p.Height = 200;
            p.Image = FixedSize(img, p.Width, p.Height, true);
            flwPhoto.Controls.Add(p);
        }

        private System.Drawing.Image FixedSize(Image image,
                      int Width, int Height, bool needToFill)
        {

            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            int sourceX = 0;
            int sourceY = 0;
            double destX = 0;
            double destY = 0;

            double nScale = 0;
            double nScaleW = 0;
            double nScaleH = 0;

            nScaleW = ((double)Width / (double)sourceWidth);
            nScaleH = ((double)Height / (double)sourceHeight);
            if (!needToFill)
            {
                nScale = Math.Min(nScaleH, nScaleW);
            }
            else
            {
                nScale = Math.Max(nScaleH, nScaleW);
                destY = (Height - sourceHeight * nScale) / 2;
                destX = (Width - sourceWidth * nScale) / 2;
            }

            if (nScale > 1)
                nScale = 1;

            int destWidth = (int)Math.Round(sourceWidth * nScale);
            int destHeight = (int)Math.Round(sourceHeight * nScale);


            System.Drawing.Bitmap bmPhoto = null;
            try
            {
                bmPhoto = new System.Drawing.Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("destWidth:{0}, destX:{1}, destHeight:{2}, desxtY:{3}, Width:{4}, Height:{5}",
                    destWidth, destX, destHeight, destY, Width, Height), ex);
            }
            using (System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto))
            {
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.CompositingQuality = CompositingQuality.HighQuality;
                grPhoto.SmoothingMode = SmoothingMode.HighQuality;

                Rectangle to = new System.Drawing.Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
                Rectangle from = new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
                grPhoto.DrawImage(image, to, from, System.Drawing.GraphicsUnit.Pixel);

                return bmPhoto;
            }

        }

        private void dgvGoods_SelectionChanged(object sender, EventArgs e)
        {
            flwPhoto.Controls.Clear();
            flwPhoto.Update();
            if (bSource.Current is BusinessGood)
            {
                var list = context.Photos.Local
                .Where(g => g.GoodId == (bSource.Current as BusinessGood).GoodId)
                .ToList();
                foreach (var item in list)
                {
                    AddPhotoFlowPanel(item.PhotoPath);
                }
            }         
        }

        private void btnRemovePhoto_Click(object sender, EventArgs e)
        {
            int itemId = (bSource.Current as BusinessGood).GoodId;

            var PhotoToDelete = context.Photos.Local.
                        Where(ph => ph.GoodId == itemId).FirstOrDefault();

            string photoPath = PhotoToDelete.PhotoPath;

            Image img = Image.FromFile(photoPath);
            PictureBox p = new PictureBox();
            p.Image = img;

            flwPhoto.Controls.Remove(p);

            p.Image = null;

            //PhotosToDelete.Add(photoPath);

            bSource = null;
            context.Photos.Local.Remove(PhotoToDelete);
            context.SaveChanges();
            File.Delete(photoPath);
            List<BusinessGood> data = DisplayGoods.GetGoods(context);
            bSource.DataSource = data;
            dgvGoods.DataSource = bSource;

        }
    }
}
