namespace SGE.Aplicacion;
// VERIFICAR CON ESPECIFICACION Y EJECUTAR ESTE PARA CAMBIAR EL ESTADO DEL EXPEDIENTE DEPENDIENDO DEL ULTIMO TRAMITE
public class ServicioActualizacionEstado(IExpedienteRepositorio repoExpe)
{
    public void Ejecutar(Expediente e, string etiqueta)
    {
        repoExpe.ModificarEstadoExpediente(e, etiqueta);
    }
}