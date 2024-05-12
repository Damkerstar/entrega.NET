namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repoExpe, ITramiteRepositorio repoTramite, IServicioAutorizacion autorizacion, ServicioActualizacionEstado actualizacionEstado)
{
    public void Ejecutar(int eId, int idUsuario)
    {
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteModificacion))
        {
            Tramite tramite = repoTramite.BuscarUltimo(eId);
            Expediente e = repoExpe.BuscarExpedientePorId(eId);
            actualizacionEstado.Ejecutar(e.ID, tramite.Etiqueta);
        }
        else
        {

            throw new AutorizacionException("No posee los permisos necesarios para realizar esa operación.");

        }
    }
}