using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{

    /*The Repository pattern reduces duplication and ensures that operations on the database are performed consistently*/
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
        /* 
         * IQueryable<T> interface is derived from the more familiar IEnumerable<T> interface 
         * and represents a collection of objects that can be queried, such as those managed by a database
         * 
         * class that depends on the IProductRepository interface can 
         * obtain Product objects without needing to know the details of 
         * how they are stored or how the implementation class will deliver them
         * 
         * Add the scoped service to the Start.cs
         */
    }
}
