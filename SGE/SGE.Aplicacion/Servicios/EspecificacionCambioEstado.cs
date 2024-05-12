using SGE.Aplicacion;

public class EspecificacionCambioEstado(ServicioActualizacionEstado servicioActualizacion)
{
    public bool VerificacionPermiso(int idUsuario, Permiso permiso)
        => idUsuario == 1;
}