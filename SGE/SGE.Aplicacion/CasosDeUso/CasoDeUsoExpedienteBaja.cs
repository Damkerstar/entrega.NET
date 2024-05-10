namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, ITramiteRepositorio repoTramite, IServicioAutorizacion autorizacion)
{

    public void Ejecutar(int idExpediente, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
        {

           repoTramite.Ejecutar(idExpediente, idUsuario);

            repo.EliminarExpediente(idExpediente);

        }

    }

}