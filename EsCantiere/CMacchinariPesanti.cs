using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    internal abstract class CMacchinariPesanti : IAssegnabile
    {
        public CCantiere CantiereAssegnato { get; protected set; }
        public string Targa { get; protected set; }
        protected string Modello { get; set; }
        protected int AnnoProduzione { get; set; }
        protected int VolumeSerbatoio { get; set; }
        public bool Stato { get; protected set; }
        
        public CMacchinariPesanti(string targa, string modello, int annoProduzione, int volumeSerbatoio)
        {
            Targa = targa;
            Modello = modello;
            AnnoProduzione = annoProduzione;
            VolumeSerbatoio = volumeSerbatoio;
            Stato = false;
        }

        public abstract string Descrizione();
        public void Assegna(CCantiere cantiere)
        {
            CantiereAssegnato = cantiere;
            Stato = true;
            cantiere.macchinari.Add(this);
        }

        public void Libera()
        {
            if (CantiereAssegnato != null)
            {
                CantiereAssegnato.macchinari.Remove(this);
                CantiereAssegnato = null;
            }
            Stato = false;
        }
    }
}
