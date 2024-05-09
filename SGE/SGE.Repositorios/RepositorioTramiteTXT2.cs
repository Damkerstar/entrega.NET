namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioTramiteTXT: ITramiteRepositorio
{
    readonly string _nombreArch = "tramites.txt";
    public void AgregarTramite(Tramite tramite)
    {
        int? id = RepositorioTramiteID.conseguirID();
        escribirTramite(tramite);
    }

    public List<Tramite> ListarTramite()
    {
        var resultado = new List<Tramite>();
        using var sr = new StreamReader(_nombreArch);
        while(!sr.EndOfStream)
        {
            Tramite tramiteCopi = new Tramite();
            tramiteCopi.IDTramite = int.Parse(sr.ReadLine() ?? "");
            tramiteCopi.ExpedienteId = int.Parse(sr.ReadLine() ?? "");
            tramiteCopi.Etiqueta = (Etiqueta_Tramite) Enum.Parse(typeof(Etiqueta_Tramite), sr.ReadLine()?? "");
            tramiteCopi.descripcion = sr.ReadLine();
            tramiteCopi.fechaYhoraCreacion = DateTime.Parse(sr.ReadLine()?? "");
            tramiteCopi.fechaYhoraModificacion = DateTime.Parse(sr.ReadLine()?? "");
            tramiteCopi.idUsuario = int.Parse(sr.ReadLine()?? "");
            resultado.Add(tramiteCopi);
        }
        return resultado;
    }

    public void EliminarTramite(Tramite tramite)
    {
        if(File.Exists(_nombreArch))
        {
            List<Tramite> listTramite = ListarTramite();
            if(listTramite.Contains(tramite))
            {
                listTramite.Remove(tramite);
        
                foreach(var tramiteActual in listTramite)
                {
                    AgregarTramite(tramiteActual);
                }
            }
            else
                throw new RepositorioException("No existe el tramite en cuestion");
        }
    }

    public void EliminarCompleto(int idE)
    {
        List<Tramite> lista = ListarTramite();

        foreach(Tramite tActual in lista)
        {
            if(tActual.ExpedienteId == idE)
            {
                lista.Remove(tActual);
            }
        }

        foreach(Tramite tActual in lista)
        {
            sobreescribirTramites(tActual);
        }
    }

    public void BuscarUltimo(int idE)
    {
        List<Tramite> listaPorExpedientes = listarPorExpediente(idE);
        Tramite maxTramite;
        maxTramite.ID = -1;
        foreach(Tramite tActual in listaPorExpedientes)
        {
            if(maxTramite.ID < tActual.ID)
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
                listaPorExpediente.Add(tActual);   
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
        sw.WriteLine(tramite.IDTramite);
        sw.WriteLine(tramite.Etiqueta);
        sw.WriteLine(tramite.descripcion);
        sw.WriteLine(tramite.fechaYhoraCreacion);
        sw.WriteLine(tramite.fechaYhoraModificacion);
        sw.WriteLine(tramite.idUsuario);
    }
}
