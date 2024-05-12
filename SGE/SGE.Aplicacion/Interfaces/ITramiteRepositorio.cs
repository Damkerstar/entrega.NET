namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void AgregarTramite(Tramite Tramite);
    void EliminarTramite(int idTramite);
    void EliminarCompleto(int idExpediente);
    Tramite BuscarUltimo(int idExpediente);
    List<Tramite> BuscarEtiqueta(string etiqueta);
    List<Tramite> ListarPorExpediente(int idExpediente);
    List<Tramite> ListarTramite();
    int EncontrarExpediente(int idTramite);
    void ModificarTramite(int idTramite);
}