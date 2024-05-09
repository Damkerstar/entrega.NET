namespace SGE.Aplicacion;

public class Tramite
{


    public int ExpedienteId {get; set;}
    private int _id {get;};
    public int IDTramite
    {
        get => _id;
        set => _id = value;
    }
    public EtiquetaTramite etiqueta {get;} = Etiqueta_Tramite.Escrito_Presentado;
    public string descripcion;
    public DateTime fechaYhoraCreacion{get;} = DateTime.Now;
    public DateTime fechaYhoraModificacion {get;}
    private int idUsuario;
    public int IdUsuario => idUsuario;


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