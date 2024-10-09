using HR.LeaveManagment.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HrLeaveManagmentDbContext DbContext;
        public GenericRepository(HrLeaveManagmentDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        //public Task Delete(int id)
        //{
        //    DbContext.Set<T>().Remove(DbContext.Set<T>().Find(id));
        //    return DbContext.SaveChangesAsync();
        //}

        public async Task<bool> Exsists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public Task Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

    }
}
