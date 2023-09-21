namespace BlogPessoal.Util;

public class MapeadorDocumentos
{
    public static string GetTitleDocumento(string idDocumento)
    {
        string title = DICIONARIO_ID_DOCUMENTO_TITLE.FirstOrDefault(x => x.Key.Trim() == idDocumento.Trim()).Value;

        return title;
    }

    private static Dictionary<string, string> DICIONARIO_ID_DOCUMENTO_TITLE = new Dictionary<string, string>()
    {
       { "1lY_jNMuhXCRHKzR9KqqoVy6Ruw-FWDSUegmcWgLLfzI", "Princípio da Inversão de Dependência"}
    };

}
