namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioTramiteID
{
    public static int conseguirID()
    {
        string nombresito = @"..\SGE.Repositorios\TramiteID.txt";

        int id;
        using var sr = new StreamReader(nombresito);
        {   
            id = int.Parse(sr.ReadLine() ?? "");
        }
        
        id++;
        
        using var sw = new StreamWriter(nombresito);
        {
            sw.WriteLine(id);
        }

        return id;

    }

}