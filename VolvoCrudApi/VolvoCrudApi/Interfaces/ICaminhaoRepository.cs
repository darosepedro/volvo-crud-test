using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoCrudApi.Models;
using VolvoCrudApi.Requests;

namespace VolvoCrudApi.Repositories
{
    public interface ICaminhaoRepository
    {
        Task<Caminhao> Insert(Caminhao request);
        Task<Caminhao> Get(int Id);
        Task<IEnumerable<Caminhao>> GetList();
        Task<Caminhao> Delete(int Id);
        Task<Caminhao> Update(Caminhao request);

    }
}
