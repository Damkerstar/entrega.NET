using SGE.Aplicacion;
using SGE.Repositorios;

class Program
{
    public static void Main(string[] args)
    {
        // Configurar dependencias
        IExpedienteRepositorio ExpedienteRepositorio = new RepositorioExpedienteTXT();
        ITramiteRepositorio TramiteRepositorio = new RepositorioTramiteTXT();
        ServicioActualizacionEstado ServicioActualizacion = new ServicioActualizacionEstado(ExpedienteRepositorio, new EspecificacionCambioEstado());

        // Casos de Uso Expediente
        var BajaExpediente = new CasoDeUsoExpedienteBaja(ExpedienteRepositorio, TramiteRepositorio, new ServicioAutorizacionProvisorio());
        var AltaExpediente = new CasoDeUsoExpedienteAlta(ExpedienteRepositorio, new ExpedienteValidador(), new ServicioAutorizacionProvisorio());
        var TodosExpedientes = new CasoDeUsoExpedienteConsultaTodos(ExpedienteRepositorio);
        //var ExpedientesPorID = new CasoDeUsoExpedienteConsultaPorID(ExpedienteRepositorio);
        //var ModiExpediente = new CasoDeUsoExpedienteModificacion(ExpedienteRepositorio, new ServicioAutorizacionProvisorio());

        // Casos de uso Tramite
        var BajaTramite = new CasoDeUsoTramiteBaja(TramiteRepositorio, new ServicioAutorizacionProvisorio(), ServicioActualizacion);
        var AltaTramite = new CasoDeUsoTramiteAlta(TramiteRepositorio, new TramiteValidador(), new ServicioAutorizacionProvisorio(), ServicioActualizacion);
        var TramitePorID = new CasoDeUsoTramiteConsultaPorEtiqueta(TramiteRepositorio);
        var TramiteModificacion = new CasoDeUsoTramiteModificacion(TramiteRepositorio, new ServicioAutorizacionProvisorio(), ServicioActualizacion);
    
        try
        {
            // Dar de alta 3 expedientes
            AltaExpediente.Ejecutar(new Expediente(){caratula = "Carátula del Expediente", ID = 1}, 1);
            AltaExpediente.Ejecutar(new Expediente(){caratula = "Carátula del Expediente", ID = 1}, 1);
            AltaExpediente.Ejecutar(new Expediente(){caratula = "Carátula del Expediente", ID = 1}, 1);

            // Obtener una lista de los expedientes y imprimirla
            var lista = ExpedienteRepositorio.ListarExpedientes();   
        
            foreach(Expediente e in lista)
            {
                Console.WriteLine(e.ToString());
            }

            // Dar de alta 3 tramites y imprimirlo
            AltaTramite.Ejecutar(new Tramite(){descripcion = "Descripción del Tramite", ID = 1, idE = 1}, 1);
            AltaTramite.Ejecutar(new Tramite(){descripcion = "Descripción del Tramite", ID = 1, idE = 1}, 1);
            AltaTramite.Ejecutar(new Tramite(){descripcion = "Descripción del Tramite", ID = 1, idE = 2}, 1);

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