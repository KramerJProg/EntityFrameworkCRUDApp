using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkCRUDApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Product p = new Product()
            //{
            //    Title = "Gadget",
            //    Price = 9.99
            //};

            //ProductContext dbContext = new ProductContext();
            //dbContext.Products.Add(p);
            //dbContext.SaveChanges();
            //MessageBox.Show("Added");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var p1 = new Product()
            {
                Title = "Widget",
                Price = 5.99
            };

            ProductDb.Add(p1);

            var p2 = new Product()
            {
                Title = "Gaming Chair",
                Price = 299.99
            };

            ProductDb.Add(p2);

            p1.Price = 15.50;

            ProductDb.Update(p1);

            List<Product> prods = ProductDb.GetAllProducts();

            ProductDb.Delete(p1);
            ProductDb.Delete(p2);

            prods = ProductDb.GetAllProducts();
        }
    }
}
