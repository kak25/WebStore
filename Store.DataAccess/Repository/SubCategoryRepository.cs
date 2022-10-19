using Store.DataAccess.Data;
using Store.DataAccess.Repository.IRepository;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.Repository
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        private AppDbContext _db;

        public SubCategoryRepository(AppDbContext db) : base(db)
        {
            _db = db;

        }


        public void Update(SubCategory obj)
        {
            _db.SubCategories.Update(obj);
        }
    }
}
