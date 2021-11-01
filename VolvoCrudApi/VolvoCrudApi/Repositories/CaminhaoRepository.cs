using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoCrudApi.Models;
using VolvoCrudApi.Requests;

namespace VolvoCrudApi.Repositories
{
    public class CaminhaoRepository: ICaminhaoRepository
    {
        private readonly VolvoContext _context;
        public CaminhaoRepository(VolvoContext context)
        {
            _context = context;
        }

        public async Task<Caminhao> Insert(Caminhao request)
        {
            if (_context.Modelos.Find(request.ModeloId) is null)
                throw new Exception("Modelo Não encontrado");

            await _context.Caminhoes.AddAsync(request);
            await _context.SaveChangesAsync();
            return await Get(request.Id);
        }

        public async Task<Caminhao> Get(int Id)
        {
            return await _context.Caminhoes
                .Include(c => c.Modelo)
                .AsNoTracking()
                .Where(w => w.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Caminhao>> GetList()
        {
            return await _context.Caminhoes.ToListAsync();
        }

        public async Task<Caminhao> Delete(int Id)
        {
            Caminhao entity = await Get(Id);
            _context.Caminhoes.Remove(entity);
            await _context.SaveChangesAsync();
            return null;
        }
        public async Task<Caminhao> Update(Caminhao request)
        {
            var update = _context.Caminhoes.Update(request);
            update.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return null;
        }

    }
}
