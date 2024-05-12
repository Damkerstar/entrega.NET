namespace SGE.Aplicacion;

public class TramiteValidador
{
    public bool ValidarTramite(Tramite tramite,out string msg)
    {

        msg = "";
        if(string.IsNullOrWhiteSpace(tramite.descripcion))
        {
            msg = "La descripcion del tramite no puede ser vacia. ";
        }
        
        if(tramite.idUsuario < 0)
        {
            msg += "El id de usuario tiene que ser mayor que 0.";
        }
        return msg == "";

    }
}