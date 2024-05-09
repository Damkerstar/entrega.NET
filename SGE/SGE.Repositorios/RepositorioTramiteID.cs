namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioTramiteID
{

    //readonly string _nombresito = "TramiteID.txt";

    public static int conseguirID()
    {

        int id;
        using var sr = new StreamReader("TramiteID.txt");
        {   
            id = int.Parse(sr.ReadLine() ?? "");
        }
        
        id++;
        
        using var sw = new StreamWriter("TramiteID.txt");
        {
            sw.WriteLine(id);
        }

        return id;

    }

}