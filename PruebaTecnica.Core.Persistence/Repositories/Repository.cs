using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Core.Domain.Entities;
using PruebaTecnica.Core.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Persistence.Repositories
{

    public class Repository : IBaseRepository<IEntityBase>
    {
        private readonly CoreDbContext _context;

        public Repository(CoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEntityBase> Add(IEntityBase entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.DateUpdated = DateTime.Now;

            await _context.Set<IEntityBase>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var obj = await _context.Set<IEntityBase>().FirstOrDefaultAsync(entity => entity.Id == id);
            if (obj is null) return;

            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<IEntityBase>> GetAll()
        {
            return await _context.Set<IEntityBase>().ToListAsync();
        }

        public async Task<IEntityBase> GetById(int id)
        {
            return await _context.Set<IEntityBase>().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<IEntityBase> Update(int id, IEntityBase entity)
        {
            var obj = await _context.Set<IEntityBase>().FirstOrDefaultAsync(entity => entity.Id == id);

            obj.DateUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return obj;
        }
    }

}
