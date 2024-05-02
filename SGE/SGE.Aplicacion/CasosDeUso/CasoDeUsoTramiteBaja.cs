namespace SGE.Aplicacion;
public class CasoDeUsoTramiteBaja(ITramiteRepositorio repoTramite, IServicioAutorizacion autorizacion){
    public void Ejecutar(Tramite tramite, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteBaja))
        {
            repoTramite.eliminarTramite(tramite);
        }

    }

    public void Ejecutar(int idE, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(0, Permiso.TramiteBaja))
        {
            repoTramite.eliminarCompleto(idE);
        }

    }
}