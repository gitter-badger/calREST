using System;

namespace calREST.DAL.GenericRepository
{ 
    /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="TId"></typeparam>
    public interface IEntity<TId> where TId : IComparable
    {
        TId Id { get; set; }
    }
}
