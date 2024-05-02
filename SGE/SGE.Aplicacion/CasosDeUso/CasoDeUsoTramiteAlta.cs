namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repoTramite, TramiteValidador validador)
{
    public void Ejecutar(Tramite tramite){
        if(!validador.ValidarTramite(tramite, out string msg)){
            throw new Exception(msg);
        }
        repoTramite.agregarTramite(tramite);
    }
}