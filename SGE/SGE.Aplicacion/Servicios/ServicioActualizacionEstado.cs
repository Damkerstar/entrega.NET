namespace SGE.Aplicacion;
// VERIFICAR CON ESPECIFICACION Y EJECUTAR ESTE PARA CAMBIAR EL ESTADO DEL EXPEDIENTE DEPENDIENDO DEL ULTIMO TRAMITE
public class ServicioActualizacionEstado(IExpedienteRepositorio repoExpe, EspecificacionCambioEstado cambioEstado)
{
    public void Ejecutar(Expediente e, EtiquetaTramite etiqueta)
    {
        EstadoExpediente estado = cambioEstado.Ejecutar(etiqueta) ?? e.Estado;

        repoExpe.ModificarEstadoExpediente(e, estado);
        
    }
}