namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, ITramiteRepositorio repoTramite, IServicioAutorizacion autorizacion)
{

    public void Ejecutar(int idExpediente, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
        {

<<<<<<< HEAD
           repoTramite.EliminarCompleto(idExpediente);
=======
            repoTramite.EliminarCompleto(idExpediente);
>>>>>>> fb6ba83721d2d1209721c43e2fef55d49487a650

            repo.EliminarExpediente(idExpediente);

        }

    }

}