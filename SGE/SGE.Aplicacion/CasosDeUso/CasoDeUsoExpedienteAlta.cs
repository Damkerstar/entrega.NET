namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, ExpedienteValidador validador, IServicioAutorizacion autorizacion)
{
        
    public void Ejecutar(Expediente e)
    {

        if(autorizacion.PoseeElPermiso(e.usuarioID, Permiso.ExpedienteAlta))
        {

            if(!validador.Validar(e, out string errorMessage))
            {

                throw new ValidacionException(errorMessage);

            }
            
            repo.AgregarExpediente(e);

        }

    } 
    
}