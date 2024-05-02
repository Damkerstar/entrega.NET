namespace SGE.Aplicacion;

class ServicioAutorizacionProvisorio : IServicioAutorizacion
{

    public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
    {

        return IdUsuario == 1;

    }

}