namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpedienteID
{

    //readonly string _nombresito = "ExpedienteID.txt";

    public static int conseguirID()
    {

        int id;
        using var sr = new StreamReader("ExpedienteID.txt");
        {   
            id = int.Parse(sr.ReadLine() ?? "");
        }
        
        id++;
        
        using var sw = new StreamWriter("ExpedienteID.txt");
        {
            sw.WriteLine(id);
        }

        return id;

    }

}