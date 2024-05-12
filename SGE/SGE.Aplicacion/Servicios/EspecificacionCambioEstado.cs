using SGE.Aplicacion;

public class EspecificacionCambioEstado(ServicioActualizacionEstado servicioActualizacion)
{
    
    public void Ejecutar(Expediente e, EtiquetaTramite etiqueta)
    {
            
        string etiquetaTramite = $"{etiqueta}";

        switch(etiquetaTramite)
        {

            case "Resolucion":
                    servicioActualizacion.Ejecutar(e, "Resolucion");
                    break;
            
            case "Pase_Estudio":
                    servicioActualizacion.Ejecutar(e, "Pase_Estudio");
                    break;

            case "Pase_Archivo":
                    servicioActualizacion.Ejecutar(e, "Pase_Archivo");
                    break;

        }

    }
}