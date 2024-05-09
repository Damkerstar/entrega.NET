namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioTramiteTXT: ITramiteRepositorio
{
    readonly string _nombreArch = "tramites.txt";
    public void agregarTramite(Tramite tramite)
    {
        escribirTramite(tramite);
        int? id = RepositorioTramiteID.conseguirID();
    }

    public List<Tramite> ListarTramite()
    {
        var resultado = new List<Tramite>();
        using var sr = new StreamReader(_nombreArch)
        while(!sr.EndOfStream)
        {
            // COMPLETAR
            var tramiteCopi = new Tramite();
            tramiteCopi. = int.Parse(sr.ReadLine() ?? "");
            tramiteCopi. = sr.ReadLine();
            tramiteCopi. = sr.ReadLine();
            tramiteCopi. = sr.ReadLine();
            tramiteCopi. = sr.ReadLine();
            tramiteCopi. = sr.ReadLine();
            resultado.Add(tramiteCopi);
        }
        return resultado;
    }

    public void eliminarTramite(Tramite tramite)
    {
        //COMPLETAR SI EXISTE EL ARCHIVO Y SI 
        if(File.Exists(_nombreArch))
        {
            List<Tramite> listTramite = ListarTramite();
            if(listTramite.Contains(tramite))
            {
                listTramite.Remove(tramite);
        
                foreach(var tramiteActual in listTramite)
                {
                    agregarTramite(tramiteActual);
                }
            }
            else
                throw new RepositorioException("No existe el tramite en cuestion");
        }
    }

    public void eliminarCompleto(int idE)
    {
        List<Tramite> lista = ListarTramite();

        foreach(Tramite tActual in lista)
        {
            if(tActual.ExpedienteId == idE)
            {
                lista.Remove(tActual)
            }
        }

        foreach(Tramite tActual in lista)
        {
            sobreescribirTramites(tActual); //ETODO PRIVADO CREAR
        }
    }

    public void buscarUltimo(int idE)
    {
        List<Tramite> listaPorExpedientes = listarPorExpediente();
        Tramite maxTramite;
        maxTramite.id = -1;
        foreach(Tramite tActual in listaPorExpedientes)
        {
            if(maxTramite.id < tActual.id)
            {
                maxTramite = tActual;
            }
        }
        
    }

    private List<Tramite> listarPorExpediente(int idE)
    {
        List<Tramite> lista = ListarTramite();
        List<Tramite> listaPorExpediente = new List<Tramite>();
        foreach(Tramite tActual in lista)
        {
            if(tActual.ExpedienteId == idE)
            {
                listarPorExpediente.Add(tActual);   
            }
        }
        return listaPorExpediente;
    }

    private void sobreescribirTramites(Tramite tramite)
    {
        if(File.Exists(_nombreArch))
        {
            escribirTramite(tramite);
        }
    }

    private void escribirTramite(Tramite tramite)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(tramite.id);
        sw.WriteLine(tramite.etiqueta);
        sw.WriteLine(tramite.descripcion);
        sw.WriteLine(tramite.fechaYhoraCreacion);
        sw.WriteLine(tramite.fechaYhoraModificacion);
        sw.WriteLine(tramite.IdUsuario);
    }
}
