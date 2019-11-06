using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotacionesV1
{
    class Votante
    {
        public ArrayList votos;
        public Votante()
        {
            votos = new ArrayList();
        }
        public void addVoto(string voto) {
            votos.Add(voto);
        }
    }
}
