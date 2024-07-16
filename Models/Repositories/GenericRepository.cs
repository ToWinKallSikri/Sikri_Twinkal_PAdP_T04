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

        public void Aggiungi(T entity)
        {
            _ctx.Set<T>().Add(entity);
        }

        public void Modifica(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
        }

        public virtual T? Ottieni(object id)
        {
            return _ctx.Set<T>()
                .Find(id);

        }

        public void Elimina(object id)
        {
            var entity = Ottieni(id);
            if(entity != null)
                _ctx.Entry(entity).State = EntityState.Deleted;
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

    }
}
