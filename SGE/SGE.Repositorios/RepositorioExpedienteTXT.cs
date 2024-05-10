namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT: IExpedienteRepositorio
{
    
    readonly string _nomArchivo = "expedientes.txt";    

    public void AgregarExpediente(Expediente e)
    {
        
        int id = RepositorioExpedienteID.conseguirID();
        e.ID = id;
        EscribirExpediente(e);

    }

    public List<Expediente> ListarExpedientes()
    {
        var resultado = new List<Expediente>();
        using var sr = new StreamReader(_nomArchivo);
        {
            while(!sr.EndOfStream)
            {
                Expediente expedienteCopia = new Expediente();
                string[] exp = sr.ReadLine().Split("||");

                expedienteCopia.ID = int.Parse(exp[0]);
                expedienteCopia.caratula = exp[1];
                expedienteCopia.fechaYHoraCreacion = DateTime.Parse(exp[2]);
                expedienteCopia.fechaYHoraActualizacion = DateTime.Parse(exp[3]);
                expedienteCopia.usuarioID = int.Parse(exp[4]);
                expedienteCopia.Estado = (EstadoExpediente) Enum.Parse(typeof(EstadoExpediente), exp[5]);

                resultado.Add(expedienteCopia);
            }
        }
        return resultado;
    }

    public void EliminarExpediente(int eID)
    {

        List<Expediente> listaExpedientes = ListarExpedientes();

        RepositorioTramiteTXT.EliminarCompleto(eID);
        bool encontre = false;

        if(File.Exists(_nomArchivo))
        {

            foreach(Expediente e in listaExpedientes)
            {

                if(e.ID == eID)
                {

                    listaExpedientes.Remove(e);
                    encontre = true;

                }

            }

        }

        if(!encontre)
        {
            throw new RepositorioException("El expediente buscado no existe.");
        }
        else
        {
            SobreEscribirExpediente(listaExpedientes);
        }

    }

    private static void SobrescribirExpediente(List<Expediente> lista)
    {

        if(File.Exists(_nomArchivo))
        {

            foreach(Expediente e in lista)
            {

                EscribirExpediente(e);

            }

        }

    }

    public static void EscribirExpediente(Expediente e)
    {

        using var sw = new StreamWriter(_nomArchivo);
        {

            sw.WriteLine($"{e.ID} || {e.caratula} || {e.fechaYHoraCreacion.ToString()} || {e.fechaYHoraActualizacion.ToString()} || {e.Estado} || {e.usuarioID}");

        }

    }

}
