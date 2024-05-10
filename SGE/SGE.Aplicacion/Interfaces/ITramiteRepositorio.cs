namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void AgregarTramite(Tramite Tramite);
    void EliminarTramite(int idTramite);
    void EliminarCompleto(int idExpediente);
    List<Tramite> ListarTramite();
}