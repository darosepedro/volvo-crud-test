using System.Collections.Generic;
using System.Threading.Tasks;
using VolvoCrudApi.Models;

namespace VolvoCrudApi.Repositories
{
    public interface IModeloRepository
    {
        Task<Modelo> Insert(Modelo request);
        Task<Modelo> Get(int Id);
        Task<IEnumerable<Modelo>> GetList();
        Task<Modelo> Delete(int Id);
        Task<Modelo> Update(Modelo request);

    }
}
