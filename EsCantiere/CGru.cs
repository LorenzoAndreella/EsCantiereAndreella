using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    internal class CGru : CMacchinariPesanti
    {
        private int portataMaxCarico;
        public int AltezzaLavoro { get; private set; }
        public CGru(string targa, string modello, int annoProduzione, int volumeSerbatoio, int totportataMaxCarico, int totaltezzaLavoro)
            : base(targa, modello, annoProduzione, volumeSerbatoio)
        {
            portataMaxCarico = totportataMaxCarico;
            AltezzaLavoro = totaltezzaLavoro;
        }
        public override string Descrizione()
        {
            string statoMacchinario = Stato ? "Assegnato" : "Libero";
            return $"Targa: {Targa}, Modello: {Modello}, Anno: {AnnoProduzione}, " +
                $"Volume Serbatoio: {VolumeSerbatoio}, Stato: {statoMacchinario}, Portata Massima Carico: {portataMaxCarico}," +
                $" Altezza Lavoro: {AltezzaLavoro}";
        }

        public void AumentaAltezza()
        {
            if (AltezzaLavoro < 100)
            {
                AltezzaLavoro += 1;
            }
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
