namespace SGE.Aplicacion;

<<<<<<< HEAD
class TramiteValidador{
    public bool ValidarTramite(Tramite tramite,out string msg){
=======
public class TramiteValidador
{
    public bool ValidarTramite(Tramite tramite,out string msg)
    {
>>>>>>> 647f4061424ed0dcde365c07158fb9e68ed4c8f5
        msg = "";
        if(string.IsNullOrWhiteSpace(tramite.Descripcion)){
            msg = "La descripcion del tramite no puede ser vacia. ";
        }
        
        if(tramite.IdUsuario < 0){
            msg += "El id de usuario tiene que ser mayor que 0.";
        }
        return msg == "";
    }
}