namespace SGE.Aplicacion;

class Expediente
{

    private static int s_id { get; set; } = 0;
    public int  _id {get;}
    private string _caratula {get;}
    private DateTime _fechaYHoraCreacion {get;}
    private DateTime _fechaYHoraActualizacion {get;}
    private int _usuarioID {get;}
    private EstadoExpediente _estado {get;}

    public Expediente(string caratula, int usuarioID) 
    {

        s_id++;
        _id = s_id;
        this._caratula = caratula;
        this._fechaYHoraCreacion = DateTime.Now;
        this._fechaYHoraActualizacion = this._fechaYHoraCreacion;
        this._usuarioID = usuarioID;
        this._estado = EstadoExpediente.Recien_Iniciado;

    }

}