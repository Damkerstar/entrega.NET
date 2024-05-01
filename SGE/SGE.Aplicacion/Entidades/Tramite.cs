namespace SGE.Aplicacion;

public class Tramite
{

    //Hacer propiedad ExpedienteId
    /*
    public int ExpedienteId {get; set;}
    */
    private static int s_id {get; set;} = 0;
    private int _id {get;}
    private Etiqueta_Tramite _etiqueta {get;} = Etiqueta_Tramite.Recien_Iniciado;
    private string _descripcion {get;};
    private DateTime _fechaYhoraCreacion{get;} = DateTime.Now;
    private DateTime _fechaYhoraModificacion {get;} = _fechaYhoraCreacion;
    private int _idUsuario;


    public Tramite(string descripcion, int idUsuario) 
    {

        this.s_id++;
        this._id = s_id;
        this._descripcion = descripcion;
        this._idUsuario = idUsuario;

    }

}