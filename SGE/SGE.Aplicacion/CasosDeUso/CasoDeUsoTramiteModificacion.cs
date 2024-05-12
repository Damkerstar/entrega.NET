using SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repoTramite, IServicioAutorizacion autorizacion, EspecificacionCambioEstado cambioEstado, IExpedienteRepositorio repoExpediente)
{
    public void Ejecutar(int idTramite, string etiqueta, int idUsuario)
    {
        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteModificacion))
        {
            repoTramite.ModificarTramite(idTramite, etiqueta);
            Tramite tAux = repoTramite.BuscarTramite(idTramite);

            int idExpediente = repoTramite.BuscarExpedientePorTramite(tAux);
            Expediente eAux = repoExpediente.BuscarExpedientePorId(idExpediente);
            cambioEstado.Ejecutar(eAux, tAux.Etiqueta);
        }
    }
}