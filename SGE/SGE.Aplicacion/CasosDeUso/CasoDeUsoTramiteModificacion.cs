using SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repoTramite, IServicioAutorizacion autorizacion, ServicioActualizacionEstado servicioActualizacion, IExpedienteRepositorio repoExpediente)
{
    public void Ejecutar(int idTramite, string etiquetaString, int idUsuario)
    {
        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteModificacion))
        {
            Tramite tAux = repoTramite.BuscarTramite(idTramite);
            EtiquetaTramite etiqueta = (EtiquetaTramite) Enum.Parse(typeof(EtiquetaTramite), etiquetaString);
            repoTramite.ModificarTramite(tAux, etiqueta);

            int idExpediente = repoTramite.BuscarExpedientePorTramite(tAux);
            Expediente eAux = repoExpediente.BuscarExpedientePorId(idExpediente);
            servicioActualizacion.Ejecutar(eAux, tAux.Etiqueta);
        }
        else
        {

            throw new AutorizacionException("No posee los permisos necesarios para realizar esa operación.");

        }
    }
}