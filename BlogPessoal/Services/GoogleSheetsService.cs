using BlogPessoal.Util;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace BlogPessoal.Services
{
    public static class GoogleSheetsService
    {
        static string ApplicationName = "BlogPessoal";
        static string ServiceAccountKeyPath = "C:\\Users\\Pessoal\\Desktop\\BlogPessoal\\BlogPessoal\\bin\\Debug\\net6.0\\credentials.json";
        public static SheetsService AutenticarServicoSheets()
        {
            GoogleCredential credential;

            using (var stream = new FileStream(ServiceAccountKeyPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(SheetsService.Scope.Spreadsheets);
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }
        public static Dictionary<string, string> LerPlanilha()
        {
            string idDoArquivo = "14WAhfvLWZSaJbsB-OS3WcQu_ZdYi1121dwVIvuUZ2Ns";

            Dictionary<string, string> menuDictionary = new Dictionary<string, string>();

            var range = "A:B";

            var servicoDrive = AutenticarServicoSheets();

            SpreadsheetsResource.ValuesResource.GetRequest request = servicoDrive.Spreadsheets.Values.Get(idDoArquivo, range);

            ValueRange response = request.Execute();

            IList<IList<object>> values = response.Values;

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