using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Doctors.Core.Consts;
using Doctors.Core.Interfaces;
using Doctors.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Doctors.EF.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{

    protected DoctorsDbContext _context;
    public BaseRepository(DoctorsDbContext context)
    {
        _context = context;
    }

    public async Task<T> Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<T>> AddRange(IEnumerable<T> entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    public async Task<T> Find(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().SingleOrDefaultAsync(predicate);
    }

    public Task<T> Find(Expression<Func<T, bool>> predicate, string[] includes = null)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate, string[] includes = null)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate, int? take, int? skip, string[] includes = null,
         Expression<Func<T,object>> orderBy = null,string orderByDirection = OrderBy.DESC)
    {
        IQueryable<T> query = _context.Set<T>().Where(predicate);
        if(take.HasValue)
            query.Take(take.Value);
        if(skip.HasValue)
            query.Take(skip.Value);

        if(orderBy != null)
            if(orderByDirection == OrderBy.ASC)
                query.OrderBy(orderBy);                        
            else
                query.OrderByDescending(orderBy);
        // TODO Add predecate logic 
        return await query.ToListAsync();
        //await _context.Set<T>().Where(predicate).Skip(skip).Take(take).ToListAsync();
        // throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAll(string[] includes)
    {
        IQueryable<T> query = _context.Set<T>();
        foreach(var include in includes)
            query.Include(include);
            
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(long id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
}
