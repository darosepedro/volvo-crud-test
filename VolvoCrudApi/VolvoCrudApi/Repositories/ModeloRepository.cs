using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolvoCrudApi.Models;

namespace VolvoCrudApi.Repositories
{
    public class ModeloRepository: IModeloRepository
    {
        private readonly VolvoContext _context;
        public ModeloRepository(VolvoContext context)
        {
            _context = context;
        }

        public Task<Modelo> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Modelo> Get(int Id)
        {
            try
            {
                return await _context.Modelos.FindAsync(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Modelo>> GetList()
        {
            try
            {
                return await _context.Modelos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Modelo> Insert(Modelo request)
        {
            try
            {
                await _context.Modelos.AddAsync(request);
                await _context.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Modelo> Update(Modelo request)
        {
            try
            {
                var update = _context.Modelos.Update(request);
                update.State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
