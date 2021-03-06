using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.IntUnitOfWork;
using MultiCoreApp.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MultiDbContext _db;
        private ProductRepository _productRepository; 
        private CategoryRepository _categoryRepository; 
        public UnitOfWork(MultiDbContext db)
        {
            _db = db;
        }

        public IProductRepository Product => _productRepository ??= new ProductRepository(_db); //product repository oluşmuşsa bir sorun yok olmuşmamışsa

        public ICategoryRepository Category=>_categoryRepository ??= new CategoryRepository(_db);


        public void Commit()
        {
          _db.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
