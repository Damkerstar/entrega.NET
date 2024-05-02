namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, IServicioAutorizacion autorizacion)
{

    public void Ejecutar(Expediente e, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
        {

            CasoDeUsoTramiteBaja.Ejecutar(e.ID);

            repo.EliminarExpediente(e.ID);

        }

    }

}