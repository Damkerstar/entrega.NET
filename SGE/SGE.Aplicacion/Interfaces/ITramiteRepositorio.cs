namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    public void AgregarTramite(Tramite tramite);
    public void EliminarTramite(Tramite tramite);
    public void EliminarCompleto(int idE);
    public void BuscarUltimo(int idE);
    List<Tramite> ListarTramite();
}