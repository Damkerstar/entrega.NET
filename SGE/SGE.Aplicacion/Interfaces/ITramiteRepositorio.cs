namespace SGE.Aplicacion;

public interface ITramiteRepositorio{
    public void agregarTramite(Tramite tramite);
    public void eliminarTramite(Tramite tramite);
    public void eliminarCompleto(int idE);


}