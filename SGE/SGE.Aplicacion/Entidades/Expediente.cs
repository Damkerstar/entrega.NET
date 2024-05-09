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
        this.caratula = caratula;
        this.fechaYHoraActualizacion = this.fechaYHoraCreacion;
        this.usuarioID = usuarioID;

    }
}