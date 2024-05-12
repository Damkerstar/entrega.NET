namespace SGE.Aplicacion;

public class ExpedienteValidador
{

    public bool Validar(Expediente e, out string errorMessage)
    {

        errorMessage = "";

        if(string.IsNullOrWhiteSpace(e.caratula))
        {
            errorMessage = "La carátula no puede estar vacía.\n";
        }

        if(e.ID <= 0)
        {
            errorMessage += "La ID debe ser mayor a 0.\n";
        }

        return (errorMessage == "");

    }

}