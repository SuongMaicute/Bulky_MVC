using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using bulkyweb.Data;
using bulkyweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly BulkyDBContext _db;
        public ProductRepository(BulkyDBContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }

    }
}
