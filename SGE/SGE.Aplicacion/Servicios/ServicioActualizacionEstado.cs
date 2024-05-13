namespace SGE.Aplicacion;
public class ServicioActualizacionEstado(IExpedienteRepositorio repoExpediente, EspecificacionCambioEstado cambioEstado)
{
    public void Ejecutar(int idE, EtiquetaTramite etiqueta)
    {
        Expediente e = repoExpediente.BuscarExpedientePorId(idE);
        Console.WriteLine($"{etiqueta}");
        EstadoExpediente estado = cambioEstado.Ejecutar(etiqueta) ?? e.Estado;
        Console.WriteLine($"{estado}");
        repoExpediente.ModificarEstadoExpediente(e, estado);
        
    }
}