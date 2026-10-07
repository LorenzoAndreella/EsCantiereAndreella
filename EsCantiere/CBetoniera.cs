using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    internal class CBetoniera : CMacchinariPesanti
    {
        private int capacitaMax;
        private int capacitaAttuale;
        public CBetoniera(string targa, string modello, int annoProduzione, int volumeSerbatoio, int totcapacitaMax)
            : base(targa, modello, annoProduzione, volumeSerbatoio)
        {
            capacitaMax = totcapacitaMax;
            capacitaAttuale = 0;
        }
        public override string Descrizione()
        {
            string statoMacchinario = Stato ? "Assegnato" : "Libero";
            return $"Targa: {Targa}, Modello: {Modello}, Anno: {AnnoProduzione}, Volume Serbatoio: {VolumeSerbatoio}, Stato: {statoMacchinario}, Capacità Massima: {capacitaMax}, Capacità Attuale: {capacitaAttuale}";
        }
        public string CaricaCemento(int quantita)
        {
            if (quantita <= 0)
            {
                return "Quantità di cemento non valida.";
            }
            if (capacitaAttuale + quantita <= capacitaMax)
            {
                capacitaAttuale += quantita;
                return $"Cemento ({quantita}) caricato con successo.";
            }
            return "Impossibile caricare il cemento. Capacità massima superata.";
        }
        public string VersaCemento(int quantita)
        {
            if (quantita <= 0)
            {
                return "Quantità di cemento non valida.";
            }
            if (capacitaAttuale - quantita >= 0)
            {
                capacitaAttuale -= quantita;
                return $"Cemento ({quantita}) versato con successo.";
            }
            return "Impossibile versare il cemento. Quantità insufficiente.";
        }
    }
}
