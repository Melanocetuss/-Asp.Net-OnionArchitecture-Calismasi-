using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsycn();
        Task<T> GetByIdAsycn(int id);
        Task CreateAsycn(T entity);
        Task UpdateAsycn(T entity);
        Task RemoveAsycn(T entity);
    }
}