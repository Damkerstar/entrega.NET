namespace SGE.Aplicacion;

class TramiteValidador{
    public bool ValidarTramite(Tramite tramite,out string msg){
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