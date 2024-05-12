namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void AgregarExpediente(Expediente e);
    void EliminarExpediente(int eID);
    void ModificarExpediente(int idExpediente);
    List<Expediente> ListarExpedientes();
    void ModificarEstado(int idExpediente, Etiqueta_Tramite etiqueta);
    Expediente ExpedienteID(int idExpediente);
}