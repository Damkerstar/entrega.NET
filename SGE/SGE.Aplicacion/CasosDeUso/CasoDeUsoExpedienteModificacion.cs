namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repoExpe, ITramiteRepositorio repoTramite, IServicioAutorizacion autorizacion, ServicioActualizacionEstado actualizacionEstado)
{
    public void Ejecutar(int eId,int idUsuario)
    {
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteModificacion))
        {
            Tramite tramite = repoTramite.BuscarUltimo(eId);
            Expediente e = repoExpe.BuscarExpedientePorId(eId);
            string etiqueta = $"{tramite.Etiqueta}";
            repoExpe.ModificarEstadoExpediente(e, etiqueta);
        }
    }
}
// SI se borra un tramite se debe pasar al estado anterior con la etiqueta del tramite anterior