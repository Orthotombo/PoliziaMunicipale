using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliziaMunicipale
{
    internal class Trasgressori
    {
        public string IdTrasgressore { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }
        public string CodiceFiscale { get; set; }
        public List<Verbale> Verbali { get; set; } = new List<Verbale>();
        public List<Veicolo> Veicoli { get; set; } = new List<Veicolo>();
        public Trasgressori(string id, string nome, string cognome, string indirzzo, string citta, string cap, string codiceFiscale) 
        {
            IdTrasgressore = id;
            Nome = nome;
            Cognome = cognome;
            Indirizzo = indirzzo;
            Citta = citta;
            CAP = cap;
            CodiceFiscale = codiceFiscale;
        }
        public void AddVerbale(Verbale v)
        {
            Verbali.Add(v);
        }

        public void AddVeicolo(Veicolo veicle)
        {
            Veicoli.Add(veicle);
        }
        public void StampaTrasgressore()
        {
            Console.WriteLine($"Id trasgressore: {IdTrasgressore}\n");
            Console.WriteLine($"Cognome del trasgressore: {Cognome}\n");
            Console.WriteLine($"Nome del trasgressore: {Nome}\n");
            Console.WriteLine($"Indirizzo del trasgressore: {Indirizzo} \n");
            Console.WriteLine($"Città del trasgressore: {Citta} \n");
            Console.WriteLine($"CAP: {CAP} \n");
            Console.WriteLine($"Codice fiscale: {CodiceFiscale} \n");
            foreach(Verbale v in Verbali)
            {
                v.StampaVerbale();
            }
            foreach (Veicolo item in Veicoli) 
            {
                item.StampaVeicolo();
            }
        }
        public void StampaVerbali()
        {
            Console.WriteLine($"Il Signor: {Cognome} {Nome} ha supito {Verbali.Count} verbali\n");
            foreach (Verbale item in Verbali) 
            {
                item.StampaVerbale();
                Console.WriteLine("");
            }
        }
    }
}
