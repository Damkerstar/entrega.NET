namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioTramiteTXT : ITramiteRepositorio
{
    readonly string _nombreArch = "tramites.txt";
    // PREGUTAR SI HACER EL ID ACA DENTRO PORQUE SINO HAY QUE HACER REPOSITORIOS APARTE CON SU ID
    public static void AgregarTramite(Tramite tramite)
    {
        int id = RepositorioTramiteID.conseguirID();
        tramite.IDTramite = id;
        escribirTramite(tramite);
    }

    public static List<Tramite> ListarTramite()
    {
        var resultado = new List<Tramite>();
        using var sr = new StreamReader("tramites.txt");
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

    public static void EliminarTramite(int idtramite)
    {
        if(File.Exists("tramites.txt"))
        {
            bool ok = false;
            List<Tramite> listTramite = ListarTramite();
            foreach(Tramite tramite in listTramite)
            {
                if(tramite.IDTramite == idtramite){
                    listTramite.Remove(tramite);
                    ok = true;
                }
            }

            foreach(var tramiteActual in listTramite)
            {
                AgregarTramite(tramiteActual);
            }

            if(ok)
                throw new RepositorioException("No existe el tramite en cuestion");
        }
    }

    public static void EliminarCompleto(Expediente e)
    {
        List<Tramite> lista = ListarTramite();

        foreach(Tramite tActual in lista)
        {
            if(tActual.ExpedienteId == e.ID)
            {
                lista.Remove(tActual);
            }
        }

        foreach(Tramite tActual in lista)
        {
            sobrescribirTramites(tActual);
        }
    }

    private Tramite BuscarUltimo(int idE)
    {
        List<Tramite> listaPorExpedientes = listarPorExpediente(idE);
        Tramite maxTramite = new Tramite();
        // Preguntar porque queda con maxTramite de esa forma
        maxTramite.IDTramite = -1;
        foreach(Tramite tActual in listaPorExpedientes)
        {
            if(maxTramite.IDTramite < tActual.IDTramite)
            {
                maxTramite = tActual;
            }
        }
        return maxTramite;
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

    private static void sobrescribirTramites(Tramite tramite)
    {
        if(File.Exists("tramite.txt"))
        {
            escribirTramite(tramite);
        }
    }

    private static void escribirTramite(Tramite tramite)
    {
        using var sw = new StreamWriter("tramite.txt", true);
        sw.WriteLine(tramite.IDTramite);
        sw.WriteLine(tramite.ExpedienteId);
        sw.WriteLine(tramite.Etiqueta);
        sw.WriteLine(tramite.descripcion);
        sw.WriteLine(tramite.fechaYhoraCreacion);
        sw.WriteLine(tramite.fechaYhoraModificacion);
        sw.WriteLine(tramite.idUsuario);
    }
}
