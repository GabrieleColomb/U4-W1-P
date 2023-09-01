using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4_W1_P
{
    internal class ContribuentiManager
    {
        private List<Contribuente> contribuenti = new List<Contribuente>();

        public void AggiungiContribuente(Contribuente contribuente)
        {
            contribuenti.Add(contribuente);
        }

        public List<Contribuente> GetContribuenti()
        {
            return contribuenti;
        }
    }
}
