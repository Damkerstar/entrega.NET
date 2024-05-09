namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT: IExpedienteRepositorio
{
    
    readonly string _nomArchivo = "expedientes.txt";    

    public void AgregarExpediente(Expediente e)
    {

        escribirExpediente(e);

    }

    public void EliminarExpediente(int eID)
    {



    }

}
