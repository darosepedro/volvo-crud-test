using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolvoCrudApi.Models;

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
