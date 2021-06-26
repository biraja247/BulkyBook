using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(Product entity)
        {
            var objfromDb = _db.Products.FirstOrDefault(s => s.Id == entity.Id);
            if(objfromDb != null)
            {
                if(objfromDb.ImageUrl != null)
                {
                    objfromDb.ImageUrl = entity.ImageUrl;
                }
                objfromDb.ISBN = entity.ISBN;
                objfromDb.Price = entity.Price;
                objfromDb.Price50 = entity.Price50;
                objfromDb.ListPrice = entity.ListPrice;
                objfromDb.Price100 = entity.Price100;
                objfromDb.Title = entity.Title;
                objfromDb.Description = entity.Description;
                objfromDb.CategoryId = entity.CategoryId;
                objfromDb.Author = entity.Author;
                objfromDb.CoverTypeId = entity.CoverTypeId;
            }
        }
    }
}
