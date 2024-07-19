using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traccia_04_Sikri_Twinkal.Models.Context;

namespace Traccia_04_Sikri_Twinkal.Models.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        protected ServizioDiPrenotazioneContext _ctx;
        public GenericRepository(ServizioDiPrenotazioneContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Aggiungi(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var Id = Ottieni(entity.GetType().GetProperty(entity.GetType().Name + "Id").GetValue(entity));  
            if (Id != null)
            {
                throw new InvalidOperationException("L'entità è già presente nel database");
            }
            await _ctx.Set<T>().AddAsync(entity);
        }

        public async Task Modifica(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task<T?> Ottieni(object id)
        {
            return await _ctx.Set<T>()
                .FindAsync(id);

        }

        public async Task Elimina(object id)
        {
            var entity = await Ottieni(id);
            if(entity != null)
                _ctx.Entry(entity).State = EntityState.Deleted;
        }

        public async Task Save()
        {
            await _ctx.SaveChangesAsync();
        }

    }
}
