using System;
using System.Linq.Expressions;
using Doctors.Core.Consts;

namespace Doctors.Core.Interfaces;

public interface IBaseRepository<T> where T : class 
{
     Task< T >GetById(long id);
     Task<IEnumerable<T>>GetAll();
     Task<IEnumerable<T>>GetAll(string[] includes=null);
     Task<T>Find(Expression<Func<T,bool>> predicate,string[] includes=null);
     Task<IEnumerable<T>>FindAll(Expression<Func<T,bool>> predicate,string[] includes=null);
     Task<IEnumerable<T>>FindAll(Expression<Func<T,bool>> predicate,int? take,int? skip,string[] includes=null,
     Expression<Func<T,object>> orderBy = null,string orderByDirection = OrderBy.DESC);

     Task<T> Add(T entity);
     Task<IEnumerable<T>> AddRange(IEnumerable<T> entity);
}