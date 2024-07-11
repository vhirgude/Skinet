using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly DataContext _dataContext;

    public GenericRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<int> Count(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _dataContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsyc(int id)
    {
        return await _dataContext.Set<T>().FindAsync(id);
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }
    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_dataContext.Set<T>().AsQueryable(),spec);

    }
}
