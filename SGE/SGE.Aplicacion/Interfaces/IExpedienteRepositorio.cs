namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{

    private static int s_id = 0;
    private int _id = s_id;
    public int id { get => _id; }

    void AgregarExpediente(Expediente e);
    void EliminarExpediente(int eID);

}