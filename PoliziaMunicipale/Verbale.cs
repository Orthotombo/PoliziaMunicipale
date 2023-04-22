using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliziaMunicipale
{
    internal class Verbale
    {
        public string IdVerbale { get; set; }
        public List<TipoViolazione> Violazioni { get; set; } = new List<TipoViolazione>();
        public Trasgressori Trasgressore { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string CittaViolazione { get; set; }
        public string NominativoAgenteVerbalizzante { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
        public int PuntiDecurtati { get; set; }

        public Verbale(string id, DateTime datav, string indirizzov, string cittav, string agente, DateTime datat, decimal importo, int punti)
        {
            IdVerbale = id;
            DataViolazione = datav;
            IndirizzoViolazione = indirizzov;
            CittaViolazione = cittav;
            NominativoAgenteVerbalizzante = agente;
            DataTrascrizioneVerbale = datat;
            Importo = importo;
            PuntiDecurtati = punti;
        }

        public void AggiungiTrasgressori(Trasgressori t) 
        {
            Trasgressore = t;
        }
        public void AggiungiViolazione(TipoViolazione v)
        {
            Violazioni.Add(v);
        }
        public void StampaVerbale()
        {

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Identificativo del verbale: {IdVerbale}\n");
            foreach (TipoViolazione item in Violazioni) 
            {  
                item.StampaTipoViolazione();
                Console.WriteLine("");
            }
            Console.WriteLine($"Data della violazione: {DataViolazione} \n");
            Console.WriteLine($"Indirizzo di dov'é avvenuta: {IndirizzoViolazione} \n");
            Console.WriteLine($"Città in cui è avvenuta: {CittaViolazione} \n");
            Console.WriteLine($"Agente che ha effettuato il verbale: {NominativoAgenteVerbalizzante} \n");
            Console.WriteLine($"Data in cui il verbale è stato trascritto in caserma: {DataTrascrizioneVerbale} \n");
            Console.WriteLine($"Importo della sanzione: {Importo.ToString("C2")}\n");
            Console.WriteLine($"Punti decurtati dalla patente: {PuntiDecurtati}  \n");
            Console.WriteLine("----------------------------------------\n");
        }

        public void StampaPerMenu() 
        {
            Console.WriteLine($"Cognome: {Trasgressore.Cognome}");
            Console.WriteLine($"Nome: {Trasgressore.Nome}");
            Console.WriteLine($"Data in cui è avvenuta la violazione: {DataViolazione}");
            Console.WriteLine($"Importo della sanzione erogata: {Importo.ToString("C2")}");
            Console.WriteLine($"Numero di punti persi sulla patente: {PuntiDecurtati}");
        }
    }
}
