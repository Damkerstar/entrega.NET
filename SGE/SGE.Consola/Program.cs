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
        var ExpedientesPorID = new CasoDeUsoExpedienteConsultaPorId(ExpedienteRepositorio, TramiteRepositorio);
        var ModiExpediente = new CasoDeUsoExpedienteModificacion(ExpedienteRepositorio, new ServicioAutorizacionProvisorio());

        // Casos de uso Tramite
        var BajaTramite = new CasoDeUsoTramiteBaja(TramiteRepositorio, new ServicioAutorizacionProvisorio(), ServicioActualizacion);
        var AltaTramite = new CasoDeUsoTramiteAlta(TramiteRepositorio, new TramiteValidador(), new ServicioAutorizacionProvisorio(), ServicioActualizacion);
        var TramitePorID = new CasoDeUsoTramiteConsultaPorEtiqueta(TramiteRepositorio);
        var TramiteModificacion = new CasoDeUsoTramiteModificacion(TramiteRepositorio, new ServicioAutorizacionProvisorio(), ServicioActualizacion);
    
        try
        {
            // Dar de alta 3 Expedientes
            AltaExpediente.Ejecutar(new Expediente("Carátula del Expediente", 1){}, 1);
            AltaExpediente.Ejecutar(new Expediente("Carátula del Expediente", 1){}, 1);
            AltaExpediente.Ejecutar(new Expediente("Carátula del Expediente", 1){}, 1);

            // Dar de alta 3 Tramites
            AltaTramite.Ejecutar(new Tramite("Descripción del Tramite", 1, 1){}, 1);
            AltaTramite.Ejecutar(new Tramite("Descripción del Tramite", 1, 2){}, 1);


            Console.WriteLine("LISTAR TODOS EXPEDIENTES 1");
            // Listar Expedientes todos
            TodosExpedientes.Ejecutar();

            // Dar de baja expediente 3
            BajaExpediente.Ejecutar(3, 1);

            // Modificar Tramite 1 y dar de alta otro tramite en el mismo Expediente
            TramiteModificacion.Ejecutar(1, "Pase_Estudio", 1);

            Console.WriteLine("LISTAR TODOS EXPEDIENTES 2");
            TodosExpedientes.Ejecutar();


            AltaTramite.Ejecutar(new Tramite("Descripción del Tramite", 1, 1), 1);

            // Modificacion Expediente
            ModiExpediente.Ejecutar(2, 1, "Nueva caratula", "En_Notificacio");

            Console.WriteLine("LISTAR TODOS EXPEDIENTES 3");
            // Listar Expedientes
            TodosExpedientes.Ejecutar();

            Console.WriteLine("LISTAR TODOS Tramites por etiqueta 1");
            // Listar Tramites por etiqueta
            TramitePorID.Ejecutar("Escrito_Presentado");

            // Baja Tramite
            BajaTramite.Ejecutar(2, 1);

            // Listar Expedientes por ID
            ExpedientesPorID.Ejecutar(1);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}