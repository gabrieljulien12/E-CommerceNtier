using Entıtıes.Interface;
using Entıtıes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBLL.ManagerServices.Abstracs
{
    public interface IManeger<T> where T:class,IEntity
    {
        //List Commands
        IQueryable<T> GetAll();

        IQueryable<T> GetActives();

        IQueryable<T> GetModifieds();

        IQueryable<T> GetPassives();

        // Modifies Commands
        string Add(T item);
        Task AddAsync(T item);
        Task AddRangeAsync(List<T> list);
        Task UpdateAsync(T item);
        Task UpdateRangeAsync(List<T> list);
        void Delete(T item);
        void DeleteRange(List<T> list);
        void Destroy(T item);
        void DestroyRange(List<T> list);

        //Linq Commands
        IQueryable<T> Where(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp);

        //Find
        Task<T> FindAsync(int id);
    }
}
