namespace SGE.Aplicacion;
public class CasoDeUsoTramiteBaja(ITramiteRepositorio repoTramite, IservicioAutorizacion autorizacion){
    public void Ejecutar(Tramite tramite){
        if(autorizacion.PoseeElPermiso(1, Permiso permiso)){
            repoTramite.eliminarTramite(tramite);
        }
    }

    public void Ejecutar(int idE){
        if(autorizacion.PoseeElPermiso(0, Permiso permiso)){
            repoTramite.eliminarCompleto(idE);
        }
    }
}