using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    internal class CCantiere
    {
        public List<CMacchinariPesanti> macchinari { get; set; }
        public string NomeCantiere { get; private set; }
        public CCantiere(string nomeCantiere)
        {
            macchinari = new List<CMacchinariPesanti>();
            NomeCantiere = nomeCantiere;
        }
    }
}
