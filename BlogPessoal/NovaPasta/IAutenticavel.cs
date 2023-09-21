namespace BlogPessoal.NovaPasta;

public interface IAutenticavel
{
    void Autenticar();
    dynamic BuscarValoresDocumento(string idDoArquivo, string range);
}
