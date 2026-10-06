using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    internal class CBetoniera : CMacchinariPesanti
    {
        public int CapacitaMax { get; set; }
        public int CapacitaAttuale { get; set; }
        public CBetoniera(string targa, string modello, int annoProduzione, int volumeSerbatoio, int capacitaMax)
            : base(targa, modello, annoProduzione, volumeSerbatoio)
        {
            CapacitaMax = capacitaMax;
            CapacitaAttuale = 0;
        }
        public override string Descrizione()
        {
            string statoMacchinario = Stato ? "Assegnato" : "Libero";
            return $"Targa: {Targa}, Modello: {Modello}, Anno: {AnnoProduzione}, Volume Serbatoio: {VolumeSerbatoio}, Stato: {statoMacchinario}, Capacità Massima: {CapacitaMax}, Capacità Attuale: {CapacitaAttuale}";
        }
        public string CaricaCemento(int quantita)
        {
            if (quantita <= 0)
            {
                return "Quantità di cemento non valida.";
            }
            if (CapacitaAttuale + quantita <= CapacitaMax)
            {
                CapacitaAttuale += quantita;
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
            if (CapacitaAttuale - quantita >= 0)
            {
                CapacitaAttuale -= quantita;
                return $"Cemento ({quantita}) versato con successo.";
            }
            return "Impossibile versare il cemento. Quantità insufficiente.";
        }
    }
}
