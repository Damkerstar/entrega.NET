namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, ExpedienteValidador validador)
{
        
    public void Ejecutar(Expediente e)
    {

        if(!validador.Validar(e, out string errorMessage))
        {

            throw new ValidacionException(errorMessage);

        }
        
        repo.AgregarExpediente(e);

    } 
    
}