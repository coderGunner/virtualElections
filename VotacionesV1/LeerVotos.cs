using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotacionesV1
{
    class LeerVotos
    {
        int conteoVotos;
        public LeerVotos(string path)
        {

            string line;
            try
            {
                System.IO.StreamReader file =
                  new System.IO.StreamReader(path);
                string headerLine = file.ReadLine();
                while ((line = file.ReadLine()) != null && Variables.conteoVotosTotales < Variables.maximovotos)
                {
                    Votante vo = new Votante();
                    string[] votos = line.Split(',');
                    if (votos.Length == 5)
                    {
                        for (int i = 0; i < votos.Length; i++)
                        {
                            string voto = votos[i].Trim();
                            if (voto.Equals("amarillo"))
                            {
                                Variables.cantidadvotosAmarillo[i] = Variables.cantidadvotosAmarillo[i] + 1;
                                vo.addVoto("amarillo");
                            }
                            else if (voto.Equals("verde"))
                            {
                                Variables.cantidadvotosVerde[i] = Variables.cantidadvotosVerde[i] + 1;
                                vo.addVoto("verde");
                            }
                            else if (voto.Equals("violeta"))
                            {
                                Variables.cantidadvotosVioleta[i] = Variables.cantidadvotosVioleta[i] + 1;
                                vo.addVoto("violeta");
                            }
                            else if (voto.Equals("rojo"))
                            {
                                Variables.cantidadvotosRojo[i] = Variables.cantidadvotosRojo[i] + 1;
                                vo.addVoto("rojo");
                            }
                            else if (voto.Equals("azul"))
                            {
                                Variables.cantidadvotosAzul[i] = Variables.cantidadvotosAzul[i] + 1;
                                vo.addVoto("azul");
                            }
                            else if (voto.Equals("nulo"))
                            {
                                vo.addVoto("nulo");
                            }
                        }//end for

                        Variables.votantes_v.Add(vo);
                    }
                    Variables.conteoVotosTotales++;
                }
                
                file.Close();


            }
            catch (InvalidCastException e)
            {

            }


        }
    }
}
