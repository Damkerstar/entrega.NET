namespace SGE.Aplicacion;
public class CasoDeUsoTramiteBaja(ITramiteRepositorio repoTramite, IServicioAutorizacion autorizacion, ServicioActualizacionEstado servicioActualizacion, IExpedienteRepositorio repoExpediente){
    public void Ejecutar(int idTramite, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteBaja))
        {
            repoTramite.EliminarTramite(idTramite);
            Tramite t = repoTramite.BuscarTramite(idTramite);
            int expedienteID = repoTramite.BuscarExpedientePorTramite(t);
            Expediente e = repoExpediente.BuscarExpedientePorId(expedienteID);
            servicioActualizacion.Ejecutar(e, t.Etiqueta);
        }
        else
        {

            throw new AutorizacionException("No posee los permisos necesarios para realizar esa operación.");

        }

    }
}