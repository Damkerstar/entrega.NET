namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, IServicioAutorizacion autorizacion)
{

    public void Ejecutar(Expediente e, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
        {

            CasoDeUsoTramiteBaja.Ejecutar(e.ID, idUsuario); //Ver si no es mejor mandar la lista de tramites en lugar de la ID de Expediente

            repo.EliminarExpediente(e.ID);

        }

    }

}