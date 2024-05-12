using SGE.Aplicacion;
using SGE.Repositorios;

class Program
{
    public static void Main(string[] args)
    {
        IExpedienteRepositorio ExpedienteRepositorio = new RepositorioExpedienteTXT();
        ITramiteRepositorio TramiteRepositorio = new RepositorioTramiteTXT();
        ServicioActualizacionEstado ServicioActualizacion = new ServicioActualizacionEstado(ExpedienteRepositorio, new EspecificacionCambioEstado());

        var BajaExpediente = new CasoDeUsoExpedienteBaja(ExpedienteRepositorio, TramiteRepositorio, new ServicioAutorizacionProvisorio());
        var AltaExpediente = new CasoDeUsoExpedienteAlta(ExpedienteRepositorio, new ExpedienteValidador(), new ServicioAutorizacionProvisorio());
        var TodosExpedientes = new CasoDeUsoExpedienteConsultaTodos(ExpedienteRepositorio);
        //var ExpedientesPorID = new CasoDeUsoExpedienteConsultaPorID(ExpedienteRepositorio);
        //var ModiExpediente = new CasoDeUsoExpedienteModificacion(ExpedienteRepositorio, new ServicioAutorizacionProvisorio());

        var BajaTramite = new CasoDeUsoTramiteBaja(TramiteRepositorio, new ServicioAutorizacionProvisorio(), ServicioActualizacion);
        var AltaTramite = new CasoDeUsoTramiteAlta(TramiteRepositorio, new TramiteValidador(), new ServicioAutorizacionProvisorio(), ServicioActualizacion);
        var TramitePorID = new CasoDeUsoTramiteConsultaPorEtiqueta(TramiteRepositorio);
        var TramiteModificacion = new CasoDeUsoTramiteModificacion(TramiteRepositorio, new ServicioAutorizacionProvisorio(), ServicioActualizacion);
    
        try
        {
            Expediente expediente1 = new Expediente("Bertone", 1);
            Expediente expediente2 = new Expediente("Thomas", 1);
            Expediente expediente3 = new Expediente("Matias", 1);

            AltaExpediente.Ejecutar(expediente1, 1);
            AltaExpediente.Ejecutar(expediente2, 1);
            AltaExpediente.Ejecutar(expediente3, 1);

            var lista = ExpedienteRepositorio.ListarExpedientes();   
        
            foreach(Expediente e in lista)
            {
                Console.WriteLine(e.ToString());
            }

            Tramite tramite1 = new Tramite("AAAAH", 1, 1);
            Tramite tramite2 = new Tramite("DDDD", 1, 1);
            Tramite tramite3 = new Tramite("DORMIR", 1, 2);

            AltaTramite.Ejecutar(tramite1, 1);
            AltaTramite.Ejecutar(tramite2, 1);
            AltaTramite.Ejecutar(tramite3, 1);

            var listaTramite = TramiteRepositorio.ListarTramite();

            foreach(Tramite tramite in listaTramite)
            {
                Console.WriteLine(tramite);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}