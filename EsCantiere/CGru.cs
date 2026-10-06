using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    internal class CGru : CMacchinariPesanti
    {
        public int PortataMaxCarico { get; set; }
        public int AltezzaLavoro { get; set; }
        public CGru(string targa, string modello, int annoProduzione, int volumeSerbatoio, int portataMaxCarico, int altezzaLavoro)
            : base(targa, modello, annoProduzione, volumeSerbatoio)
        {
            PortataMaxCarico = portataMaxCarico;
            AltezzaLavoro = altezzaLavoro;
        }
        public override string Descrizione()
        {
            string statoMacchinario = Stato ? "Assegnato" : "Libero";
            return $"Targa: {Targa}, Modello: {Modello}, Anno: {AnnoProduzione}, Volume Serbatoio: {VolumeSerbatoio}, Stato: {statoMacchinario}, Portata Massima Carico: {PortataMaxCarico}, Altezza Lavoro: {AltezzaLavoro}";
        }

        public void AumentaAltezza()
        {
            AltezzaLavoro += 1;
        }
        public void DiminuisciAltezza()
        {
            if (AltezzaLavoro > 0)
            {
                AltezzaLavoro -= 1;
            }
        }
    }
}
