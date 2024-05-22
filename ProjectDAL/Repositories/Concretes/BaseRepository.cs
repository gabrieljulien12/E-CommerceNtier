using Entıtıes.Interface;
using Microsoft.EntityFrameworkCore;
using ProjectDAL.Context;
using ProjectDAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        MyContext _db;

        public BaseRepository(MyContext db)
        {
            _db = db;
        }

        public void Add(T item)
        {
            
             _db.Set<T>().Add(item);
            _db.SaveChanges();
             
            
        }

        public async Task AddAsync(T item)
        {
            await _db.Set<T>().AddAsync(item);
            await _db.SaveChangesAsync();
        }
        public async Task AddRangeAsync(List<T> list)
        {
            await _db.Set<T>().AddRangeAsync();
            await _db.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().AnyAsync(exp);
        }

        //verinin pasife çekilmesi
        public void Delete(T item)
        {
            item.status = Entıtıes.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            _db.SaveChanges();
        }

        public void DeleteRange(List<T> list)
        {
            foreach(T item in list) Delete(item);
            
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            _db.SaveChanges();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            _db.SaveChanges();
        }

        public async Task<T> FindAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async  Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(exp);
        }

        public IQueryable<T> GetActives()
        {
            return Where(x => x.status != Entıtıes.Enums.DataStatus.Deleted);
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().AsQueryable();
        }

        public IQueryable<T> GetModifieds()
        {
            return Where(x => x.status != Entıtıes.Enums.DataStatus.Updated);
        }

        public IQueryable<T> GetPassives()
        {
            return Where(x => x.status != Entıtıes.Enums.DataStatus.Deleted);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public async Task UpdateAsync(T item)
        {
            item.status = Entıtıes.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            T original = await FindAsync(item.ID);
            _db.Entry(original).CurrentValues.SetValues(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(List<T> list)
        {
            foreach (T item in list) await UpdateAsync(item);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp);
        }
    }
}
