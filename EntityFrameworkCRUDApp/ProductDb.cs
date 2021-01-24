using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCRUDApp
{
    static class ProductDb
    {
        // CRUD funtionality
        public static List<Product> GetAllProducts()
        {
            using(ProductContext context = new ProductContext())
            {
                //  Query Syntax
                List<Product> allProds =
                    (from prod in context.Products
                    select prod).ToList();

                //  Method Syntax
                List<Product> allProds2 =
                    context.Products.ToList();

                return allProds;
            }
        }

        /// <summary>
        /// Adds a product to the database.
        /// Returns the product with the <see cref="Product.ProductId"></see> column
        /// (Identity column) populated
        /// </summary>
        /// <param name="p">The product to be added</param>
        public static Product Add(Product p)
        {
            using (ProductContext context = new ProductContext())
            {
                context.Products.Add(p);  //  Prepares an INSERT query
                context.SaveChanges();    //  Executes all pending INSERT/UPDATE/DELETE queries

                return p;
            }       
        }

        public static Product Update(Product p)
        {
            using(var context = new ProductContext())
            {
                context.Database.Log = Console.WriteLine;
                //  Prepare Update query for product
                context.Entry(p).State = EntityState.Modified;

                context.SaveChanges();

                return p;
            }
        }

        public static void Delete(Product p)
        {
            using (ProductContext context = new ProductContext())
            {
                //  Write EF output to the console
                context.Database.Log = Console.WriteLine;

                //  Telling EF (Entity Framework) that the product 
                //  is already in the DB and should be deleted
                context.Entry(p).State = EntityState.Deleted;

                //  Executes DELETE query
                context.SaveChanges();
            }    
        }

        public static void Delete(int id)
        {
            using(var context = new ProductContext())
            {
                //  Get product to delete from database

                //  Query syntax
                Product prodToDelete =
                    (from p in context.Products
                     where p.ProductId == id
                     select p).Single();

                // Method Syntax
                Product prodToDelete2 =
                    context.Products
                           .Where(p => p.ProductId == id)
                           .Single();

                context.Entry(prodToDelete).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
