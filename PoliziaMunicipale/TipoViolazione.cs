using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliziaMunicipale
{
    internal class TipoViolazione
    {
        public int IdViolazione { get; set; }
        public string Descrizione { get; set; }

        public TipoViolazione(int idViolazione, string descrizione) 
        {
            IdViolazione = idViolazione;
            Descrizione = descrizione;
        }

        public void StampaTipoViolazione() 
        {
            Console.WriteLine($"Identificativo e descrizione della violazione: {IdViolazione}. {Descrizione}");
        }
    }
}
