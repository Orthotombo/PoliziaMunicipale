using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliziaMunicipale
{
    internal class Veicolo
    {
        public string Targa { get; set; }
        public string NumeroTelaio { get; set; }
        public string MarcaVeicolo { get; set; }
        public string TipoVeicolo { get; set; }
        public Veicolo(string targa, string numeroTelaio, string marcaVeicolo, string tipoVeicolo)
        {
            Targa = targa;
            NumeroTelaio = numeroTelaio;
            MarcaVeicolo = marcaVeicolo;
            TipoVeicolo = tipoVeicolo;
        }

        public void StampaVeicolo()
        {
            Console.WriteLine($"Targa del veicolo: {Targa}");
            Console.WriteLine($"Numero di telaio del veiocolo: {NumeroTelaio}");
            Console.WriteLine($"Marca del veicolo: {MarcaVeicolo}");
            Console.WriteLine($"Tipo di veicolo: {TipoVeicolo}");
        }
    }
}
