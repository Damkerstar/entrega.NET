namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void AgregarExpediente(Expediente e);
    void EliminarExpediente(int eID);
    List<Expediente> ListarExpedientes();
    void ModificarEstadoExpediente(Expediente e, string etiqueta);
    Expediente BuscarExpedientePorId(int eId);
}