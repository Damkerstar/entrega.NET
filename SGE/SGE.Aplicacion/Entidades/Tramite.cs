namespace SGE.Aplicacion;

public class Tramite
{

    //Hacer propiedad ExpedienteId
    /*
    public int ExpedienteId {get; set;}
    */
    private static int s_id {get; set;} = 0;
    private int _id {get;}
    private Etiqueta_Tramite _etiqueta {get;} = Etiqueta_Tramite.Escrito_Presentado;
    private string _descripcion;
    public string Descripcion => _descripcion;
    private DateTime _fechaYhoraCreacion{get;} = DateTime.Now;
    private DateTime _fechaYhoraModificacion {get;}
    private int _idUsuario;
    public int IdUsuario => _idUsuario;


    public Tramite(string descripcion, int idUsuario) 
    {

        s_id++;
        this._id = s_id;
        this._descripcion = descripcion;
        this._idUsuario = idUsuario;
        this._fechaYhoraModificacion = _fechaYhoraCreacion;
        this._idUsuario = idUsuario;

    }

}