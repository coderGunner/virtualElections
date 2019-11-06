using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotacionesV1
{
    class LeerVotantes
    {
        ArrayList votantes;
        public LeerVotantes(string path)
        {

            string line;

            try
            {
                votantes = new ArrayList();
                System.IO.StreamReader file =
                  new System.IO.StreamReader(path);

                while ((line = file.ReadLine()) != null)
                {
                    votantes.Add(line);
                }
                file.Close();
                Variables.votantes = votantes;
            }
            catch (InvalidCastException e)
            {

            }


        }



    }
}

