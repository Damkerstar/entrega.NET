namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void AgregarExpediente(Expediente e);
    void EliminarExpediente(int eID);
    void ModificarEstadoExpediente(Expediente e, EstadoExpediente estado);
    Expediente BuscarExpedientePorId(int eId);
    void ImprimirPantalla();
    void ImprimirPantallaPorId(Expediente e);
}