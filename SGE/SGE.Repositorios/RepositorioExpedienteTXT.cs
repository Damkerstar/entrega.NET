namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
    
    readonly string _nomArchivo = @"..\SGE.Repositorios\expedientes.txt";    

    public void AgregarExpediente(Expediente e)
    {
        
        int id = RepositorioExpedienteID.conseguirID();
        e.ID = id;
        EscribirExpediente(e);

    }

    public void EscribirExpediente(Expediente e)
    {

        if(File.Exists(_nomArchivo))
        {    
            using (var sw = new StreamWriter(_nomArchivo, true))
            {
                sw.WriteLine($"{e.ID} || {e.caratula} || {e.fechaYHoraCreacion} || {e.fechaYHoraActualizacion.ToString()} || {e.Estado} || {e.usuarioID}");
            }
        }

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
                expedienteCopia.Estado = (EstadoExpediente) Enum.Parse(typeof(EstadoExpediente), exp[4]);
                expedienteCopia.usuarioID = int.Parse(exp[5]);

                resultado.Add(expedienteCopia);
            }
        }
        return resultado;
    }

    public void EliminarExpediente(int eID)
    {

        List<Expediente> listaExpedientes = ListarExpedientes();
        Expediente e = BuscarExpedientePorId(eID);

        bool encontre = false;

        if(listaExpedientes.Contains(e))
        {

            listaExpedientes.Remove(e);
            encontre = true;

        }
        
        if(!encontre)
        {
            throw new RepositorioException("El expediente buscado no existe.");
        }
        else
        {
            SobrescribirListaExpediente(listaExpedientes);
        }

    }

    private void SobrescribirListaExpediente(List<Expediente> lista)
    {

        if(File.Exists(_nomArchivo))
        {    
            using (var sw = new StreamWriter(_nomArchivo, false))
            {

                foreach(Expediente e in lista)
                {

                    sw.WriteLine($"{e.ID} || {e.caratula} || {e.fechaYHoraCreacion} || {e.fechaYHoraActualizacion.ToString()} || {e.Estado} || {e.usuarioID}");

                }

            }
        }

    }

    public void ModificarEstadoExpediente(Expediente e, EstadoExpediente estado)
    {

        e.Estado =  estado;
        e.fechaYHoraActualizacion = DateTime.Now;
        List<Expediente> lista = ListarExpedientes();
        SobrescribirListaExpediente(lista);

    }

    public Expediente BuscarExpedientePorId(int eId)
    {

        List<Expediente> lista = ListarExpedientes();

        foreach(Expediente eAux in lista)
        {

            if(eAux.ID == eId)
            {

                return eAux;

            } 

        }

        throw new RepositorioException("El expediente buscado no existe.");

    }

}
