namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repoTramite, TramiteValidador validador, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteAlta))
        {
            
            if(!validador.ValidarTramite(tramite, out string msg))
            {
                throw new Exception(msg);
            }
            repoTramite.agregarTramite(tramite);

        }
    }
}