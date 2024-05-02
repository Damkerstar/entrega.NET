namespace SGE.Aplicacion;
public class CasoDeUsoTramiteBaja(ITramiteRepositorio repoTramite){
    
    // QUE ES MEJOR llamar al autorizacion aca o fuera de la clase en el main
        // el IServicioAutorizacion autorizacion se pasa como primario
    public void Ejecutar(Tramite tramite){
        //if(autorizacion.PoseeElPermiso(1, permiso)){
            repoTramite.eliminarTramite(tramite);
    }

    public void Ejecutar(int idE){
        //if(autorizacion.PoseeElPermiso(0, Permiso permiso)){
            repoTramite.eliminarCompleto(idE);
    }
}