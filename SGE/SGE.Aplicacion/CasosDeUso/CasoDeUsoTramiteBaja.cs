namespace SGE.Aplicacion;
public class CasoDeUsoTramiteBaja(ITramiteRepositorio repoTramite, IServicioAutorizacion autorizacion){
    public void Ejecutar(int idTramite, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteBaja))
        {
            repoTramite.EliminarTramite(idTramite);
        }

    }
}