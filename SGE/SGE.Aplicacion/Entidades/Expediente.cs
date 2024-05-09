using System;
namespace SGE.Aplicacion;

public class Expediente
{

    private int  _id;
    public int ID {get => _id;
                    set {_id = value; } }
    public string? caratula;
    public DateTime fechaYHoraCreacion {get; set;} = DateTime.Now;
    public DateTime fechaYHoraActualizacion {get; set;}
    public int usuarioID {get; set;}
    public EstadoExpediente Estado {get; set;} = EstadoExpediente.Recien_Iniciado;

    public Expediente(string caratula, int usuarioID) 
    {

        this.caratula = caratula;
        this.fechaYHoraActualizacion = this.fechaYHoraCreacion;
        this.usuarioID = usuarioID;

    }

    public Expediente() {}
}