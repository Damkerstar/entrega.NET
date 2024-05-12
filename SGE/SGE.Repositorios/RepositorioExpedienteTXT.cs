namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT: IExpedienteRepositorio
{
    
    readonly string _nomArchivo = @"..\SGE.Repositorios\expedientes.txt";    

    public void AgregarExpediente(Expediente e)
    {
        
        int id = RepositorioExpedienteID.conseguirID();
        e.ID = id;
        EscribirExpediente(e);

    }

    public List<Expediente> ListarExpedientes()
    {
        var resultado = new List<Expediente>();
        using var sr = new StreamReader(_nomArchivo);
        {
            while(!sr.EndOfStream)
            {
                Expediente expedienteCopia = new Expediente();
                string[] exp = sr.ReadLine().Split("||");

                expedienteCopia.ID = int.Parse(exp[0]);
                expedienteCopia.caratula = exp[1];
                expedienteCopia.fechaYHoraCreacion = DateTime.Parse(exp[2]);
                expedienteCopia.fechaYHoraActualizacion = DateTime.Parse(exp[3]);
                expedienteCopia.Estado = (EstadoExpediente) Enum.Parse(typeof(EstadoExpediente), exp[4]);
                expedienteCopia.usuarioID = int.Parse(exp[5]);

                resultado.Add(expedienteCopia);
            }
        }
        return resultado;
    }

    public void EliminarExpediente(int eID)
    {

        List<Expediente> listaExpedientes = ListarExpedientes();
        Expediente e;

        bool encontre = true;

        if(File.Exists(_nomArchivo))
        {
            encontre = false;
            int i = 0;
            while(i <= listaExpedientes.Count && !encontre)
            {
                e = listaExpedientes[i];
                if(e.ID == eID)
                {
                    listaExpedientes.Remove(e);
                    encontre = true;
                }
            }

        }
        if(!encontre)
        {
            throw new RepositorioException("El expediente buscado no existe.");
        }
        else
        {
            SobrescribirListExpediente(listaExpedientes);
        }

    }

    private void SobrescribirListExpediente(List<Expediente> lista)
    {

        if(File.Exists(_nomArchivo))
        {
            using (var sw = new StreamWriter(_nomArchivo))
            {
                foreach(Expediente e in lista)
                {
                    sw.WriteLine($"{e.ID} || {e.caratula} || {e.fechaYHoraCreacion.ToString()} || {e.fechaYHoraActualizacion.ToString()} || {e.Estado} || {e.usuarioID}");
                }
            }
        }
    }

    public void EscribirExpediente(Expediente e)
    {

        if(File.Exists(_nomArchivo))
        {    using (var sw = new StreamWriter(_nomArchivo, true))
            {

                sw.WriteLine($"{e.ID} || {e.caratula} || {e.fechaYHoraCreacion} || {e.fechaYHoraActualizacion.ToString()} || {e.Estado} || {e.usuarioID}");
            }
        }

    }

}
