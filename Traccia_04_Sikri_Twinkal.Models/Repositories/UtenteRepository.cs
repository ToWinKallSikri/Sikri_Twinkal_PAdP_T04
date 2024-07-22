﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traccia_04_Sikri_Twinkal.Models.Context;
using Traccia_04_Sikri_Twinkal.Models.Entities;

namespace Traccia_04_Sikri_Twinkal.Models.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(ServizioDiPrenotazioneContext ctx) : base(ctx) { }
            public override Utente? Ottieni(object id)
        {
            return _ctx.Utenti
                .Include(u => u.Prenotazioni)
                .FirstOrDefault(u => u.UtenteId == (int)id);
        }

        public bool Esiste(string email)
        {
            return DaEmail(email) != null;
        }

        public bool LogIn(string email, string password)
        {
            var utente = DaEmail(email);
            return utente != null && utente.Password == password;
        }

        private Utente? DaEmail(string email)
        {
            return _ctx.Utenti.FirstOrDefault(u => u.Email == email);
        }

    }
}

