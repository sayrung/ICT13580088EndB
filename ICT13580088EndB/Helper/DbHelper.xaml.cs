using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using ICT13580088EndB.Model;
using System.Linq;

namespace ICT13580088EndB.Helper
{
    
        public class DbHelper
        {
            SQLiteConnection db;

            public DbHelper(String dbPath)

            {
                db = new SQLiteConnection(dbPath);
                db.CreateTable<Product>();
            }

            public int AddProduct(Product product)
            {
                db.Insert(product);
                return db.Insert(product);
            }
            public List<Product> GetProducts()
            {
                return db.Table<Product>().ToList();

            }
            public int UpdateProduct(Product product)
            {
                return db.Update(product);
            }
            public int DeleteProduct(Product product)
            {
                return db.Delete(product);
            }
        }
    }
