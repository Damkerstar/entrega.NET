namespace SGE.Aplicacion;

public class Expediente
{

    private int  _id;
    public int ID => _id;
    public string caratula;
    public DateTime fechaYHoraCreacion {get;} = DateTime.Now;
    public DateTime fechaYHoraActualizacion {get;}
    public int usuarioID {get;}
    public EstadoExpediente estado {get;} = EstadoExpediente.Recien_Iniciado;

    public Expediente(string caratula, int usuarioID) 
    {

        s_id++;
        _id = s_id;
        this._caratula = caratula;
        this._fechaYHoraActualizacion = this._fechaYHoraCreacion;
        this._usuarioID = usuarioID;

    }
}