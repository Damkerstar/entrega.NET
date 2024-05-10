namespace SGE.Aplicacion;
class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio repoT)
{
    public void Ejecutar(int idE)
    {
        repoT.BuscarEtiqueta(idE);
        
    }
}