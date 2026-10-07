using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    public enum DimensioneBenna
    {
        Mm300 = 300,
        Mm500 = 500,
        Mm700 = 700,
        Mm1000 = 1000,
        Mm1500 = 1500,
        Mm2000 = 2000
    }
    internal class CRuspa : CMacchinariPesanti
    {
        private DimensioneBenna benna;

        public CRuspa(string targa, string modello, int anno, int volumeSerbatoio, DimensioneBenna totbenna) : base(targa, modello, anno, volumeSerbatoio)
        {
            benna = totbenna;
        }
        
        public override string Descrizione()
        {
            string statoMacchinario = Stato ? "Assegnato" : "Libero";
            return $"Targa: {Targa}, Modello: {Modello}, Anno: {AnnoProduzione}, Volume Serbatoio: {VolumeSerbatoio}, Stato: {statoMacchinario}, Benna: {benna}";
        }

        public string CambiaBenna(DimensioneBenna nuovaBenna)
        {
            benna = nuovaBenna;
            return $"Benna cambiata ({nuovaBenna}) con successo.";
        }
    }
}
