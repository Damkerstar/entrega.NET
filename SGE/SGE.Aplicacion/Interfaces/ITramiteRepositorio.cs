namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void AgregarTramite(int idTramite);
    void EliminarTramite(int idTramite);
    void EliminarCompleto(int idExpediente);
    List<Tramite> ListarTramite();
}