using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopOnCore.Library.Common.Response;

namespace OnlineShopOnCore.Library.Clients
{
    internal interface IRepoClient<T>
    {
        Task<ServiceResponse<Guid>> Add(T entity);

        Task<ServiceResponse<T>> Update(T entity);

        Task<ServiceResponse<object>> Remove(Guid entityId);

        Task<ServiceResponse<object>> RemoveRange(IEnumerable<Guid> entityIds);

        Task<ServiceResponse<IEnumerable<Guid>>> AddRange(IEnumerable<T> entities);

        Task<ServiceResponse<T>> GetOne(Guid entityId);

        Task<ServiceResponse<IEnumerable<T>>> GetAll();


    }
}
