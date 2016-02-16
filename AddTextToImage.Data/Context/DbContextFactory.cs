using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTextToImage.Data.Context
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext dbContext;

        ///<summary>
        /// Creates a new instance of the DbContextFactory class.
        ///</summary>
        public DbContextFactory()
        {
            dbContext = new Db();
        }

        public DbContext GetContext()
        {
            return dbContext;
        }
    }
}
