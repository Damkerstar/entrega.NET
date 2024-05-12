namespace SGE.Aplicacion;
// VERIFICAR CON ESPECIFICACION Y EJECUTAR ESTE PARA CAMBIAR EL ESTADO DEL EXPEDIENTE DEPENDIENDO DEL ULTIMO TRAMITE
public class ServicioActualizacionEstado(IExpedienteRepositorio repoExpe)
{
    public void Ejecutar(int idE)
    {
        repoExpe.ModificarExpediente(idE);
    }
}