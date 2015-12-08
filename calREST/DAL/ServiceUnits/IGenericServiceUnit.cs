

using System.Data.Entity;

namespace calREST.DAL
{
    public interface IGenericServiceUnit<T> where T : class
    {
        DbSet<T> DbSet { get; }
    }
}
