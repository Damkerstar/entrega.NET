namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo)
{

    public void Ejecutar(Expediente e)
    {
        // PREGUNTAR?
        CasoDeUsoTramiteBaja.Ejecutar(e.ID);

        repo.EliminarExpediente(e);

    }

}