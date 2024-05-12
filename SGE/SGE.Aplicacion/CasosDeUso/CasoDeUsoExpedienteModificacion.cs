namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repoExpe, ITramiteRepositorio repoTramite, EspecificacionCambioEstado especificacion, ServicioActualizacionEstado actualizacionEstado)
{
    public void Ejecutar(int idE,int idUsuario)
    {
        if (especificacion.VerificacionPermiso(idUsuario, Permiso.ExpedienteModificacion))
        {
            Tramite tramite = repoTramite.BuscarUltimo(idE);
            repoExpe.ModificarEstado(tramite.ExpedienteId, tramite.Etiqueta);
        }
    }
}
// SI se borra un tramite se debe pasar al estado anterior con la etiqueta del tramite anterior