using System;

public class LeerVotos
{
	public LeerVotos(string path)
	{
        
        string line;
        try
        {
            System.IO.StreamReader file =
              new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] votos = line.Split(',');
                if (votos.Length() == 5)
                {
                    string voto = votos[0];
                    if (voto.Equals("amarillo"))
                    {
                       
                    }
                }
            }
            file.Close();

        }
        catch (InvalidCastException e)
        {

        }


    }
}
