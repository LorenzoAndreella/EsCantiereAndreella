using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    internal interface IAssegnabile
    {
        void Assegna(CCantiere cantiere);
        void Libera();
    }
}
