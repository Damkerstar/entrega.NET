using SGE.Aplicacion;

public class EspecificacionCambioEstado()
{
    
    public EstadoExpediente? Ejecutar(EtiquetaTramite etiqueta)
    {

        switch(etiqueta)
        {

            case (EtiquetaTramite.Resolucion):
                    return EstadoExpediente.Con_Resolucion;
            
            case (EtiquetaTramite.Pase_Estudio):
                    return EstadoExpediente.Para_Resolver;

            case (EtiquetaTramite.Pase_Archivo):
                    return EstadoExpediente.Finalizado;
                
            default:
                    return null;

        }

    }
}