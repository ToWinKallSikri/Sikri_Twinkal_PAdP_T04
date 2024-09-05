# Progetto -  Traccia N04 

Realizzazione di una web api che permetta la prenotazioni di risorse (auto, sale riunioni etc).

L'applicazione deve avere un elenco di utenti con le seguenti proprietà :
- Email
- Nome 
- Cognome
- Password

Una risorsa ha le seguenti proprietà :
- Nome
- Tipologia (auto, sala riunione) da gestire su tabella separata


Le api che dovranno essere realizzate sono le seguenti :
 - Creazione di un utente (anonima senza autenticazione)
 - Autenticazione
 - Creazione di una risorsa
 - Prenotazione di una risorsa da data a data. La prenotazione deve essere possibile solamente se la risorsa è libera nell'intervallo di tempo specificato

 - Ricerca delle disponibilità.Questa api deve restituire tutte le risorse disponibili all'interno dell'intervallo di tempo specificato.
   Questa chiamata deve prevedere i seguenti parametri :
   Data Inizio (obbligatorio)
   Data Fine (obbligatorio)
   Codice Risorsa (opzionale)
   
   La ricerca dovrà paginare i risultanti, in base ad un parametro passato nella chiamata

# How to
 Una volta clonata la repository, modificare la stringa di connessione con il database SQL locale.
