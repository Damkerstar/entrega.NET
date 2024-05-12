namespace SGE.Aplicacion;
/*
Además, se debe implementar un caso de uso que permita la consulta de un expediente junto con todos
sus trámites, utilizando el Id del expediente como referencia.
*/
public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repoExpediente, ITramiteRepositorio repoTramite)
{
    public void Ejecutar(int idE)
    {
        Expediente e = repoExpediente.BuscarExpedientePorId(idE);
        e.TramiteList = repoTramite.ListarPorExpediente(idE);
        repoExpediente.ImprimirPantallaPorId(e);
    }
}