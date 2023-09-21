using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace BlogPessoal.Services
{
    public static class PlanilhaService
    {
        public static Dictionary<string, string> LerPlanilha(IList<IList<object>> values)
        {
            Dictionary<string, string> menuDictionary = new Dictionary<string, string>();            

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    string idImagem = row.Count > 0 ? row[0].ToString() : null;
                    string linkImagem = row.Count > 1 ? row[1].ToString() : null;

                    if (idImagem != null && linkImagem != null)
                    {
                        menuDictionary.Add(idImagem, linkImagem);
                    }
                }
            }

            return menuDictionary;
        }        
    }
}