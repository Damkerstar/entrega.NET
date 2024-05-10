namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, IServicioAutorizacion autorizacion)
{

    public void Ejecutar(int idExpediente, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
        {

            CasoDeUsoTramiteBaja.Ejecutar(idExpediente, idUsuario);

            repo.EliminarExpediente(idExpediente);

        }

    }

}