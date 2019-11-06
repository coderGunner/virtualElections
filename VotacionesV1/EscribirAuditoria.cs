using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotacionesV1
{
    class EscribirAuditoria
    {
        public EscribirAuditoria(string path)
        {
          
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(path, false))
            {

                file.WriteLine("Presidente, Alcalde, DiputadoNacional, DiputadoDistrital, DiputadoParlacen");
                foreach(Votante voto in Variables.votantes_v)
                {
                    int index = 0;
                    foreach (string v in voto.votos)
                    {
                        file.Write(v);
                        if (index < 4)
                        {
                            file.Write(", ");
                        }
                        index++;
                    }
                    file.WriteLine("");
                }
                
            }
        }
    }
}
