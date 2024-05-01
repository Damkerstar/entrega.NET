namespace SGE.Aplicacion;

class ExpedienteValidador
{

    public static bool CaratulaValidador(string caratula)
    {

        if(caratula == "")
        {
            return true;
        }
        else
        {
            throw new ValidacionException("La carátula no puede estar vacía.");
        }

    }

}