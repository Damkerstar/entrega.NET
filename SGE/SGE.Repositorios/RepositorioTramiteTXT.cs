namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioTramiteTXT : ITramiteRepositorio
{

    readonly string _nombreArch = @"..\SGE.Repositorios\tramites.txt";

    public void AgregarTramite(Tramite tramite)
    {
        int id = RepositorioTramiteID.conseguirID();
        tramite.IDTramite = id;
        EscribirTramite(tramite, true);
    }

        private void EscribirTramite(Tramite tramite, bool ok)
    {
        if(File.Exists(_nombreArch))
        {    
            using (var sw = new StreamWriter(_nombreArch, ok))
            {
                sw.WriteLine(tramite.IDTramite);
                sw.WriteLine(tramite.ExpedienteId);
                sw.WriteLine(tramite.ExpedienteId);
                sw.WriteLine(tramite.Etiqueta);
                sw.WriteLine(tramite.descripcion);
                sw.WriteLine(tramite.fechaYhoraCreacion);
                sw.WriteLine(tramite.fechaYhoraModificacion);
                sw.WriteLine(tramite.idUsuario);
            }
        }    
    }

    public List<Tramite> ListarTramite()
    {
        var resultado = new List<Tramite>();
        using (var sr = new StreamReader(_nombreArch))
        {
            while(!sr.EndOfStream)
            {
                Tramite tramiteCopi = new Tramite();

                tramiteCopi.IDTramite = int.Parse(sr.ReadLine() ?? "");
                tramiteCopi.ExpedienteId = int.Parse(sr.ReadLine() ?? "");
                tramiteCopi.Etiqueta = (EtiquetaTramite) Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine()?? "");
                tramiteCopi.descripcion = sr.ReadLine();
                tramiteCopi.fechaYhoraCreacion = DateTime.Parse(sr.ReadLine()?? "");
                tramiteCopi.fechaYhoraModificacion = DateTime.Parse(sr.ReadLine()?? "");
                tramiteCopi.idUsuario = int.Parse(sr.ReadLine()?? "");

                resultado.Add(tramiteCopi);
            }
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

            SobrescribirListaTramites(listTramite);
        }
    }

    public void EliminarCompleto(int idE)
    {
        List<Tramite> listaTramite = ListarTramite();
        List<Tramite> listaTramiteCopia = ListarTramite();
        bool listaModificada = false;
        
        foreach(Tramite t in listaTramite)
        {

            if(t.ExpedienteId == idE)
            {

                listaTramiteCopia.Remove(t);
                listaModificada = true;

            }

        }

        if(listaModificada)
        {
            SobrescribirListaTramites(listaTramiteCopia);
        }
    }

    public Tramite BuscarUltimo(int idE)
    {
        List<Tramite> listaPorExpedientes = ListarPorExpediente(idE);
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

    public List<Tramite> ListarPorExpediente(int idE)
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

    public void ModificarTramite(Tramite t, EtiquetaTramite etiqueta)
    {
        
        List<Tramite> lista = ListarTramite();

        t.Etiqueta = etiqueta;

        SobrescribirListaTramites(lista);

    }

    private void SobrescribirListaTramites(List<Tramite> listTramite)
    {
        foreach(Tramite tramiteAct in listTramite)
        {
            EscribirTramite(tramiteAct, false);
        }
    }

    public int BuscarExpedientePorTramite(Tramite t)
    {

        return t.ExpedienteId;

    }

    public Tramite BuscarTramite(int idTramite)
    {

        List<Tramite> listaTramites = ListarTramite();
        Tramite tAux = new Tramite();

        foreach(Tramite aux in listaTramites)
        {

            if(aux.IDTramite == idTramite)
            {

                return aux;

            }

        }

        throw new RepositorioException("El expediente buscado no existe.");

    }

    public List<Tramite> BuscarEtiqueta(string etiqueta)
    {
        List<Tramite> listaTramites = ListarTramite();
        EtiquetaTramite etiq = (EtiquetaTramite) Enum.Parse(typeof(EtiquetaTramite), etiqueta);
        List<Tramite> resultado = null;
        foreach(Tramite tramite in listaTramites)
        {
            if(tramite.Etiqueta == etiq)
            {
                resultado.Add(tramite);
            }
        }
        return resultado;
    }
}
