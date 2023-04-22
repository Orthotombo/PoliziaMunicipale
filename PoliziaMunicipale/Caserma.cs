using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliziaMunicipale
{
    internal class Caserma
    {
        public static List<TipoViolazione> Norme { get; set; } = new List<TipoViolazione>();
        public static List<Trasgressori> Trasgressori { get; set; } = new List<Trasgressori>();
        public static List<Verbale> Verbale { get; set; } = new List<Verbale>();
        public static void InizializzaDatabase()
        {
            TipoViolazione v1 = new TipoViolazione(0, "Guida in stato di ebrezza");
            TipoViolazione v2 = new TipoViolazione(1, "Uso di sostanze stupefacenti");
            TipoViolazione v3 = new TipoViolazione(2, "Superamento dei limiti di velocità");
            TipoViolazione v4 = new TipoViolazione(3, "Fuga da un posto di blocco");
            TipoViolazione v5 = new TipoViolazione(4, "Uso del cellulare al volante");

            Norme.Add(v1);
            Norme.Add(v2);
            Norme.Add(v3);
            Norme.Add(v4);
            Norme.Add(v5);

            Veicolo veicolo1 = new Veicolo("AD654FD", "01ergjeroh", "Kawasaki", "Moto");
            Veicolo veicolo2 = new Veicolo("WE123RT", "02uwrortgh", "Opel", "Autovettura");
            Veicolo veicolo3 = new Veicolo("WA789SD", "03rwuirotu", "Toyota", "Autoarticolato");

            DateTime data1 = new DateTime(2022, 01, 15);
            DateTime data2 = new DateTime(2022, 02, 16);
            DateTime data3 = new DateTime(2022, 03, 17 );
            DateTime data4 = new DateTime(2022, 04, 18);
            DateTime data5 = new DateTime(2022, 05, 19);
            DateTime data6 = new DateTime(2022, 06, 20);

            Verbale verbale1 = new Verbale("Identificativo 1", data1, "Via Pendino numero 5", "Fisciano", "Patella Emanuele", data2, 500, 6);
            Verbale verbale2 = new Verbale("Identificativo 2", data3, "Via Prato 1", "Salerno", "Patella Emanuele", data4, 350, 3);
            Verbale verbale3 = new Verbale("Identificativo 3", data5, "Viale dei fiori 75", "Salerno", "Patella Emanuele", data6, 400, 5);

            verbale1.AggiungiViolazione(v1);
            verbale1.AggiungiViolazione(v2);
            verbale1.AggiungiViolazione(v4);
            verbale2.AggiungiViolazione(v3);
            verbale3.AggiungiViolazione(v5);
            verbale3.AggiungiViolazione(v4);

            Trasgressori t1 = new Trasgressori("Id 1", "Gennaro", "Santolamanna", "Via gerghu", "Catanzaro", "12345", "AAAAAAAAAAAAAA12");
            Trasgressori t2 = new Trasgressori("Id 2", "Ciro", "Esposito", "Viale Europa", "Napoli", "23456", "BBBBBBBBBBBBBB12");
            Trasgressori t3 = new Trasgressori("Id 3", "Paolo", "Brosio", "Via grtfger", "Milano", "34567", "CCCCCCCCCCCCCC12");

            verbale1.AggiungiTrasgressori(t1);
            verbale2.AggiungiTrasgressori(t2);
            verbale3.AggiungiTrasgressori(t3);

            Verbale.Add(verbale1);
            Verbale.Add(verbale2);
            Verbale.Add(verbale3);

            t1.AddVerbale(verbale1);
            t2.AddVerbale(verbale2);
            t3.AddVerbale(verbale3);

            t1.AddVeicolo(veicolo1);
            t2.AddVeicolo(veicolo2);
            t3.AddVeicolo(veicolo3);

            Trasgressori.Add(t1);
            Trasgressori.Add(t2);
            Trasgressori.Add(t3);
        }
        public static void Menu()
        {
            int scelta;
            Console.WriteLine("========================================");
            Console.WriteLine("==========BENVENUTI IN CASERNA==========\n");
            Console.WriteLine("Inserire il numero corrispondente all'operazione da svolgere: ");
            Console.WriteLine("1. Totale dei verbali");
            Console.WriteLine("2. Elenco dei verbali di un dato trasgressore tramite Codice Fiscale");
            Console.WriteLine("3. Dati relativi ai trasgressori in una città specifica");
            Console.WriteLine("4. Trasgressori che ahnno perso più di 5 punti sulla patente");
            Console.WriteLine("5. Trasgressori che hanno pagato più di 400€ di multa");
            Console.WriteLine("6. Punti rimasti sulla patente di un trasgressore");
            Console.WriteLine("7. ESCI");
            Console.WriteLine("==========BENVENUTI IN CASERNA==========");
            Console.WriteLine("========================================");
            scelta = int.Parse( Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Caserma.TotaleVerbali();
                    break;
                case 2: 
                    Caserma.VerbaliDiTizio();
                    break; 
                case 3: 
                    Caserma.TrasgressoriCitta();
                    break; 
                case 4: 
                    Caserma.TrasgressoriPunti();
                    break; 
                case 5: 
                    Caserma.TrasgressoriMulta();
                    break; 
                case 6: 
                    Caserma.PuntiRimasti();
                    break; 
                case 7: 
                    Environment.Exit(0);
                    break;
                default: 
                    Console.Clear();
                    Console.WriteLine("Comando non riconosciuto, riprovare");
                    Caserma.Menu();
                    break;
            }
        }

        public static void TornaAlMenu()
        {
            Console.WriteLine("PREMERE INVIO PER TORNARE AL MENU");
            Console.ReadLine();
            Console.Clear();
            Caserma.Menu();
        }
        public static void TotaleVerbali()
        {
            decimal totale = 0;
            foreach (Verbale item in Verbale)
            {
                totale += item.Importo;
            }
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("==========BENVENUTI IN CASERNA==========\n");
            Console.WriteLine($"Sono stati rilasciati {Verbale.Count} verbali da questa casernma, per un totale di {totale.ToString("C2")}\n");
            Console.WriteLine("==========BENVENUTI IN CASERNA==========");
            Console.WriteLine("========================================\n");
            Caserma.TornaAlMenu();
        }

        public static void VerbaliDiTizio()
        {
            string codice;
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("==========BENVENUTI IN CASERNA==========\n");
            Console.WriteLine("Inserire qui il codice fiscale dell'individuo:");
            codice=Console.ReadLine();
            foreach (Trasgressori item in Trasgressori) 
            {
                if (item.CodiceFiscale==codice)
                {
                    item.StampaVerbali();
                }
            }
            Console.WriteLine("==========BENVENUTI IN CASERNA==========");
            Console.WriteLine("========================================\n");
            Caserma.TornaAlMenu();
        }

        public static void TrasgressoriCitta()
        {
            string citta;
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("==========BENVENUTI IN CASERNA==========\n");
            Console.WriteLine("Inserire qui la città presa in esame:");
            citta = Console.ReadLine();
            Console.WriteLine("----------------------------------------");
            foreach (Verbale t in Verbale)
            {
                if (t.CittaViolazione==citta)
                {
                    t.StampaPerMenu();
                    Console.WriteLine("----------------------------------------");
                }
            }
            Console.WriteLine("\n==========BENVENUTI IN CASERNA==========");
            Console.WriteLine("========================================\n");
            Caserma.TornaAlMenu();
        }

        public static void TrasgressoriPunti() 
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("==========BENVENUTI IN CASERNA==========\n");
            Console.WriteLine("----------------------------------------");
            foreach (Verbale t in Verbale)
            {
                if (t.PuntiDecurtati>=5)
                {
                    t.StampaPerMenu();
                    Console.WriteLine("----------------------------------------");
                }
            }
            Console.WriteLine("==========BENVENUTI IN CASERNA==========");
            Console.WriteLine("========================================\n");
            Caserma.TornaAlMenu();
        }
        public static void TrasgressoriMulta()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("==========BENVENUTI IN CASERNA==========\n");
            Console.WriteLine("----------------------------------------");
            foreach (Verbale t in Verbale)
            {
                if (t.Importo>=400)
                {
                    t.StampaPerMenu();
                    Console.WriteLine("----------------------------------------");
                }
            }
            Console.WriteLine("==========BENVENUTI IN CASERNA==========");
            Console.WriteLine("========================================\n");
            Caserma.TornaAlMenu();
        }

        public static void PuntiRimasti()
        {
            string codice;
            int puntiTolti = 20;
            string Cognome="";
            string nome="";
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("==========BENVENUTI IN CASERNA==========\n");
            Console.WriteLine("Inserire qui il codice fiscale dell'individuo:");
            codice = Console.ReadLine();
            foreach (Trasgressori item in Trasgressori)
            {
                if (item.CodiceFiscale == codice)
                {
                    Cognome = item.Cognome;
                    nome = item.Nome;
                    foreach (Verbale v in item.Verbali) 
                    {
                        puntiTolti -= v.PuntiDecurtati;
                    }
                }
            }
            Console.WriteLine($"\nIl signor {Cognome} {nome} ha ancora {puntiTolti} sulla sua patente\n");
            Console.WriteLine("==========BENVENUTI IN CASERNA==========");
            Console.WriteLine("========================================\n");
            Caserma.TornaAlMenu();

        }
    }
}
