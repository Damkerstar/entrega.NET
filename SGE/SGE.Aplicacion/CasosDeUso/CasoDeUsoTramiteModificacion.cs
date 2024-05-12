using SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repoTramite, EspecificacionCambioEstado especificacionEstado, ServicioActualizacionEstado servicioActualizacion)
{
    public void Ejecutar(int idUsuario, int idTramite)
    {
        if(especificacionEstado.VerificacionPermiso(idUsuario, Permiso.TramiteModificacion))
        {
            repoTramite.ModificarTramite(idTramite);
            int idExpediente = repoTramite.EncontrarExpediente(idTramite);
            servicioActualizacion.Ejecutar(idExpediente);
        }
    }
}