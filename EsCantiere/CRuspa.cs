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
        public DimensioneBenna Benna { get; set; }

        public CRuspa(string targa, string modello, int anno, int volumeSerbatoio, DimensioneBenna benna) : base(targa, modello, anno, volumeSerbatoio)
        {
            Benna = benna;
        }
        
        public override string Descrizione()
        {
            string statoMacchinario = Stato ? "Assegnato" : "Libero";
            return $"Targa: {Targa}, Modello: {Modello}, Anno: {AnnoProduzione}, Volume Serbatoio: {VolumeSerbatoio}, Stato: {statoMacchinario}, Benna: {Benna}";
        }

        public string CambiaBenna(DimensioneBenna nuovaBenna)
        {
            Benna = nuovaBenna;
            return $"Benna cambiata ({nuovaBenna}) con successo.";
        }
    }
}
