namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{

    void AgregarExpediente(Expediente e);
    void EliminarExpediente(Expediente e);

}