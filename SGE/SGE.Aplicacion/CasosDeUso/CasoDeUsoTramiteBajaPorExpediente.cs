namespace SGE.Aplicacion;
public class CasoDeUsoTramiteBajaPorExpediente(ITramiteRepositorio repoTramite, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int idExpediente, int idUsuario)
    {
        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteBaja))
        {
            repoTramite.EliminarCompleto(idExpediente);
        }

    }

}