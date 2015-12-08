using calREST.Models;
using System.Data.Entity;
using System;

namespace calREST.DAL
{
    public class GenericServiceUnit<TEntity> : IGenericServiceUnit<TEntity> where TEntity : class
    {
        public  DbSet<TEntity> DbSet { get; }
        private DbContext _ctx { get; }


        public GenericServiceUnit(DbContext ctx)
        {
            _ctx = ctx;
            this.DbSet = ctx.Set<TEntity>();
        }

    }
}