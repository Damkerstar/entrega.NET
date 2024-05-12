namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioTramiteTXT : ITramiteRepositorio
{
    readonly string _nombreArch = @"..\SGE.Repositorios\tramites.txt";
    public void AgregarTramite(Tramite tramite)
    {
        int id = RepositorioTramiteID.conseguirID();
        tramite.IDTramite = id;
        escribirTramite(tramite, true);
    }

    public List<Tramite> ListarTramite()
    {
        var resultado = new List<Tramite>();
        using (var sr = new StreamReader(_nombreArch))
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

    public void EliminarTramite(int idtramite)
    {
        if(File.Exists(_nombreArch))
        {
            List<Tramite> listTramite = ListarTramite();
            Tramite tramite;
            int i = 0;

            if(File.Exists(_nombreArch))
            {   
                
                while(i <= listTramite.Count && i != -1)
                {
                    tramite = listTramite[i];
                    if(tramite.IDTramite == idtramite)
                    {
                        listTramite.Remove(tramite);
                        i = -1;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            if(i != -1)
            {
                throw new RepositorioException("No existe el tramite en cuestion");
            }

            sobrescribirListTramites(listTramite);
        }
    }

    public void EliminarCompleto(int idE)
    {
        List<Tramite> listaTramite = ListarTramite();
        Tramite tramite;
        
        int i = 0;
        while(i <= listaTramite.Count && i != -1)
        {
            tramite = listaTramite[i];
            if(tramite.ExpedienteId == idE)
            {
                listaTramite.Remove(tramite);
                i = -1;
            }
            else
            {
                i++;
            }
        }

        if(i == -1)
        {
            sobrescribirListTramites(listaTramite);
        }
    }

    public Tramite BuscarUltimo(int idE)
    {
        List<Tramite> listaPorExpedientes = listarPorExpediente(idE);
        Tramite maxTramite = new Tramite();

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

    public List<Tramite> listarPorExpediente(int idE)
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

    public void TramiteModificacion(int idTramite, string etiqueta)
    {
        List<Tramite> listTramite = ListarTramite();
        Tramite tramite;
        int i = 0;
        while(i <= listTramite.Count && i != -1)
        {
            tramite = listTramite[i];
            if(tramite.IDTramite == idTramite)
            {
                tramite.Etiqueta = (Etiqueta_Tramite) Enum.Parse(typeof(Etiqueta_Tramite), etiqueta);
                i = -1;
            }
            else
            {
                i++;
            }
        }

        if(i != -1)
        {
            throw new RepositorioException("No existe el tramite en cuestion");
        }
        else
        {
            sobrescribirListTramites(listTramite);
        }
    }

    private void sobrescribirListTramites(List<Tramite> listTramite)
    {
        foreach(Tramite tramiteAct in listTramite)
        {
            escribirTramite(tramiteAct, true);
        }
    }

    private void escribirTramite(Tramite tramite, bool ok)
    {
        if(File.Exists(_nombreArch))
        {    
            using (var sw = new StreamWriter(_nombreArch, ok))
            {
                sw.WriteLine(tramite.IDTramite);
                sw.WriteLine(tramite.ExpedienteId);
                sw.WriteLine(tramite.Etiqueta);
                sw.WriteLine(tramite.descripcion);
                sw.WriteLine(tramite.fechaYhoraCreacion);
                sw.WriteLine(tramite.fechaYhoraModificacion);
                sw.WriteLine(tramite.idUsuario);
            }
        }    
    }
}
