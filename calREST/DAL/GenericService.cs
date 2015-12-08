using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using calREST.Models;
using System.Data.Entity;

namespace calREST.DAL
{
    public class GenericService<TEntity> : IGenericService where TEntity : class
    {
        public  DbSet<TEntity> DbSet { get; set; }
        
        public GenericService(ApplicationDbContext ctx)
        {
            this.DbSet = ctx.Set<TEntity>();
        }
    }
}