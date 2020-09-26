using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    /*Since IStoreRepository is an interface, all properties and methods must be included in the classes that use this interface*/
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext context;
        public EFStoreRepository(StoreDbContext ctx) => context = ctx;

        public IQueryable<Product> Products => context.Products;
        /*
         * Products property in the context class returns a DbSet<Product> object, 
         * which implements the IQueryable<T> interface and makes it easy to
         * implement the repository interface when using Entity Framework Core
         */
    }
}
