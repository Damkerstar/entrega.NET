namespace SGE.Aplicacion;

public class Tramite
{

    //Hacer propiedad ExpedienteId
    private static int s_id {get; set;} = 0;
    private int _id {get;}

    public Tramite() 
    {

        s_id++;
        _id = s_id;

    }

}